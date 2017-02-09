using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorDocumentosEntrada.Models;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

namespace GestorDocumentosEntrada.Controllers
{
    public class ReportsController : Controller
    {
        private ProcedureConnection con = new ProcedureConnection();

        public ActionResult Statistic()
        {
            ViewBag.deparmentTable = con.getDepartments();
            ViewBag.platformersTable = con.getPlatformers();
            return View();
        }

        public ActionResult Binnacle()
        {
            return View();
        }

        public ActionResult getBinnacle(DateTime from, DateTime to)
        {
            ViewBag.searchTable = con.getBinnacle(from, to);
            return PartialView();
        }

        public String createBinnaclePDF(DateTime date1, DateTime date2)
        {
            DataSet binnacleToExport = con.getBinnacle(date1, date2);

            if (binnacleToExport.Tables["Table"].Rows.Count != 0)
            {
                // Creamos el documento con el tamaño de página tradicional
                Document doc = new Document(PageSize.LETTER);
                // Indicamos donde vamos a guardar el documento
                String pdfName = "Bitacora_" + date1.ToString("dd-MM-yyyy") + "_" + date2.ToString("dd-MM-yyyy");
                PdfWriter writer = PdfWriter.GetInstance(doc,
                                            new FileStream(@"C:\Users\ProyectoVerano_2016\Downloads\"+pdfName+".pdf", FileMode.Create));

             

                // Le colocamos el título y el autor
                // **Nota: Esto no será visible en el documento
                doc.AddTitle("Bitacora");
                doc.AddCreator("Gestor de Entrada de Documentos");

                // Abrimos el archivo
                doc.Open();

                // Creamos el tipo de Font que vamos utilizar
                iTextSharp.text.Font tableFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                BaseFont headerBaseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                Font headerFont = new Font(headerBaseFont, 12, Font.BOLD, iTextSharp.text.BaseColor.GRAY);

                BaseFont titleBaseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                Font titleFont = new Font(titleBaseFont, 16, Font.BOLD, iTextSharp.text.BaseColor.BLACK);

                BaseFont dateBaseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                Font dateFont = new Font(dateBaseFont, 12, Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
               
                // Escribimos el encabezamiento en el documento
                Paragraph programName = new Paragraph("Gestor de Entrada de Documentos", headerFont);
                programName.Alignment = Element.ALIGN_LEFT;
                doc.Add(programName);
                Paragraph placeName = new Paragraph("Municipalidad de Alajuelita", headerFont);
                placeName.Alignment = Element.ALIGN_LEFT;
                doc.Add(placeName);
                doc.Add(Chunk.NEWLINE);

                Paragraph title = new Paragraph("Bitácora de Ingreso de Documentos", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                doc.Add(Chunk.NEWLINE);

                String text = "Bitácora generada a partir del ingreso de documentos en el período comprendido entre el " + date1.ToShortDateString()
                    + " al " + date2.ToShortDateString() + ", obtenido el día " + DateTime.Now.ToShortDateString() + " a las " 
                    + DateTime.Now.ToString("HH:mm");
                Paragraph dateFrom = new Paragraph(text, dateFont);
                dateFrom.Alignment = Element.ALIGN_LEFT;
                doc.Add(dateFrom);
                doc.Add(Chunk.NEWLINE);

                // Creamos una tabla que contendrá el nombre, apellido y país
                // de nuestros visitante.
                PdfPTable tblPrueba = new PdfPTable(7);
                tblPrueba.WidthPercentage = 100;

                // Configuramos el título de las columnas de la tabla
                PdfPCell clDate = new PdfPCell(new Phrase("Fecha", tableFont));
                clDate.BorderWidth = 0;
                clDate.BorderWidthBottom = 0.75f;

                PdfPCell clConsecutive = new PdfPCell(new Phrase("Consecutivo", tableFont));
                clConsecutive.BorderWidth = 0;
                clConsecutive.BorderWidthBottom = 0.75f;

                PdfPCell clDepartment = new PdfPCell(new Phrase("Departamento", tableFont));
                clDepartment.BorderWidth = 0;
                clDepartment.BorderWidthBottom = 0.75f;

                PdfPCell clId = new PdfPCell(new Phrase("Cédula", tableFont));
                clId.BorderWidth = 0;
                clId.BorderWidthBottom = 0.75f;

                PdfPCell clProcedureState = new PdfPCell(new Phrase("Estado del Trámite", tableFont));
                clProcedureState.BorderWidth = 0;
                clProcedureState.BorderWidthBottom = 0.75f;

                PdfPCell clProcedureType = new PdfPCell(new Phrase("Tipo de Trámite", tableFont));
                clProcedureType.BorderWidth = 0;
                clProcedureType.BorderWidthBottom = 0.75f;

                PdfPCell clPlatformist = new PdfPCell(new Phrase("Plataformista", tableFont));
                clPlatformist.BorderWidth = 0;
                clPlatformist.BorderWidthBottom = 0.75f;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(clDate);
                tblPrueba.AddCell(clConsecutive);
                tblPrueba.AddCell(clDepartment);
                tblPrueba.AddCell(clId);
                tblPrueba.AddCell(clProcedureState);
                tblPrueba.AddCell(clProcedureType);
                tblPrueba.AddCell(clPlatformist);


                foreach (DataRow row in binnacleToExport.Tables["Table"].Rows)
                {
                    // Llenamos la tabla con información
                    clDate = new PdfPCell(new Phrase((DateTime.Parse(row["Fecha"].ToString()).ToShortDateString()), tableFont));
                    clDate.BorderWidth = 0;

                    clConsecutive = new PdfPCell(new Phrase((row["Consecutivo"]).ToString(), tableFont));
                    clConsecutive.BorderWidth = 0;

                    clDepartment = new PdfPCell(new Phrase((row["Departamento"]).ToString(), tableFont));
                    clDepartment.BorderWidth = 0;

                    clId = new PdfPCell(new Phrase((row["Cèdula"]).ToString(), tableFont));
                    clId.BorderWidth = 0;

                    clProcedureState = new PdfPCell(new Phrase((row["Estado"]).ToString(), tableFont));
                    clProcedureState.BorderWidth = 0;

                    clProcedureType = new PdfPCell(new Phrase((row["Tipo de Procedimiento"]).ToString(), tableFont));
                    clProcedureType.BorderWidth = 0;

                    clPlatformist = new PdfPCell(new Phrase((row["Plataformista"]).ToString(), tableFont));
                    clPlatformist.BorderWidth = 0;

                    // Añadimos las celdas a la tabla
                    tblPrueba.AddCell(clDate);
                    tblPrueba.AddCell(clConsecutive);
                    tblPrueba.AddCell(clDepartment);
                    tblPrueba.AddCell(clId);
                    tblPrueba.AddCell(clProcedureState);
                    tblPrueba.AddCell(clProcedureType);
                    tblPrueba.AddCell(clPlatformist);
                }

                // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
                doc.Add(tblPrueba);

                doc.Close();
                writer.Close();

                return "yes";
            }
            else {
                return "no";
            }
            
        }

        public String createStatisticByDatePDF(String urlDepartment, String urlPlatform, DateTime date1, DateTime date2)
        {
                // Creamos el documento con el tamaño de página tradicional
                Document doc = new Document(PageSize.LETTER);
                // Indicamos donde vamos a guardar el documento
                String pdfName = "Estadisticas_" + date1.ToString("dd-MM-yyyy") + "_" + date2.ToString("dd-MM-yyyy");
                PdfWriter writer = PdfWriter.GetInstance(doc,
                                            new FileStream(@"C:\Users\ProyectoVerano_2016\Downloads\" + pdfName + ".pdf", FileMode.Create));



                // Le colocamos el título y el autor
                // **Nota: Esto no será visible en el documento
                doc.AddTitle("Estadisticas por Fecha");
                doc.AddCreator("Gestor de Entrada de Documentos");

                // Abrimos el archivo
                doc.Open();

                // Creamos el tipo de Font que vamos utilizar
                BaseFont headerBaseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                Font headerFont = new Font(headerBaseFont, 12, Font.BOLD, iTextSharp.text.BaseColor.GRAY);

                BaseFont titleBaseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                Font titleFont = new Font(titleBaseFont, 16, Font.BOLD, iTextSharp.text.BaseColor.BLACK);

                BaseFont dateBaseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                Font dateFont = new Font(dateBaseFont, 12, Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                // Escribimos el encabezamiento en el documento
                Paragraph programName = new Paragraph("Gestor de Entrada de Documentos", headerFont);
                programName.Alignment = Element.ALIGN_LEFT;
                doc.Add(programName);
                Paragraph placeName = new Paragraph("Municipalidad de Alajuelita", headerFont);
                placeName.Alignment = Element.ALIGN_LEFT;
                doc.Add(placeName);
                doc.Add(Chunk.NEWLINE);

                Paragraph title = new Paragraph("Estadísticas de Ingreso de Documentos", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                doc.Add(Chunk.NEWLINE);

                String text = "Estadísticas generadas a partir del ingreso de documentos en el período comprendido entre el " + date1.ToShortDateString()
                    + " al " + date2.ToShortDateString() + ", obtenido el día " + DateTime.Now.ToShortDateString() + " a las "
                    + DateTime.Now.ToString("HH:mm") + " por " + Session["userName"].ToString();
                Paragraph dateFrom = new Paragraph(text, dateFont);
                dateFrom.Alignment = Element.ALIGN_LEFT;
                doc.Add(dateFrom);
                doc.Add(Chunk.NEWLINE);

                //Imagen de departamento
                byte[] bytesDEpartment = Convert.FromBase64String(urlDepartment.Split(',')[1]);
                iTextSharp.text.Image imageDepartment = iTextSharp.text.Image.GetInstance(bytesDEpartment);
                //Resize image depend upon your need
                imageDepartment.ScaleToFit(600f, 600f);
                //Give space before image
                imageDepartment.SpacingBefore = 10f;
                //Give some space after the image
                imageDepartment.SpacingAfter = 1f;
                imageDepartment.Alignment = Element.ALIGN_CENTER;

                //Imagen de plataformista
                byte[] bytesPlatform = Convert.FromBase64String(urlDepartment.Split(',')[1]);
                iTextSharp.text.Image imagePlatform = iTextSharp.text.Image.GetInstance(bytesPlatform);
                //Resize image depend upon your need
                imagePlatform.ScaleToFit(600f, 600f);
                //Give space before image
                imagePlatform.SpacingBefore = 10f;
                //Give some space after the image
                imagePlatform.SpacingAfter = 1f;
                imagePlatform.Alignment = Element.ALIGN_CENTER;

                doc.Add(imageDepartment);
                doc.Add(imagePlatform);
                //cerramos el documento
                doc.Close();
                writer.Close();

                return "yes";

        }

        public String createStatisticPDF(String chartURL, String chartType, String chartName)
        {
            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            String pdfName = "Estadisticas_" + chartName;
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(@"C:\Users\ProyectoVerano_2016\Downloads\" + pdfName + ".pdf", FileMode.Create));



            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Estadisticas por Fecha");
            doc.AddCreator("Gestor de Entrada de Documentos");

            // Abrimos el archivo
            doc.Open();

            // Creamos el tipo de Font que vamos utilizar
            BaseFont headerBaseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
            Font headerFont = new Font(headerBaseFont, 12, Font.BOLD, iTextSharp.text.BaseColor.GRAY);

            BaseFont titleBaseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
            Font titleFont = new Font(titleBaseFont, 16, Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            BaseFont dateBaseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
            Font dateFont = new Font(dateBaseFont, 12, Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            Paragraph programName = new Paragraph("Gestor de Entrada de Documentos", headerFont);
            programName.Alignment = Element.ALIGN_LEFT;
            doc.Add(programName);
            Paragraph placeName = new Paragraph("Municipalidad de Alajuelita", headerFont);
            placeName.Alignment = Element.ALIGN_LEFT;
            doc.Add(placeName);
            doc.Add(Chunk.NEWLINE);

            Paragraph title = new Paragraph("Estadísticas de Ingreso de Documentos", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);
            doc.Add(Chunk.NEWLINE);

            String text;
            if (chartType == "D")
            {
                text = "Estadísticas generadas a partir del ingreso de documentos en el presente año " + DateTime.Now.ToString("yyyy")
                + " dirigidos al departamento " + chartName + ", obtenido el día " + DateTime.Now.ToShortDateString() + " a las "
                + DateTime.Now.ToString("HH:mm") + " por " + Session["userName"].ToString();
            }
            else 
            {
                text = "Estadísticas generadas a partir del ingreso de documentos en el presente año " + DateTime.Now.ToString("yyyy")
                + " registrados por el plataformista " + chartName + ", obtenido el día " + DateTime.Now.ToShortDateString() + " a las "
                + DateTime.Now.ToString("HH:mm") + " por " + Session["userName"].ToString();
            }
            
            Paragraph dateFrom = new Paragraph(text, dateFont);
            dateFrom.Alignment = Element.ALIGN_LEFT;
            doc.Add(dateFrom);
            doc.Add(Chunk.NEWLINE);

            //Imagen de departamento
            byte[] bytesURL = Convert.FromBase64String(chartURL.Split(',')[1]);
            iTextSharp.text.Image imageChart = iTextSharp.text.Image.GetInstance(bytesURL);
            //Resize image depend upon your need
            imageChart.ScaleToFit(600f, 600f);
            //Give space before image
            imageChart.SpacingBefore = 10f;
            //Give some space after the image
            imageChart.SpacingAfter = 1f;
            imageChart.Alignment = Element.ALIGN_CENTER;

            doc.Add(imageChart);
            //cerramos el documento
            doc.Close();
            writer.Close();

            return "yes";

        }

    }
}
