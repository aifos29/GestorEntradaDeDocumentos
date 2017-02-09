using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;

using System.Web;
using System.Web.Services;

namespace ServicioWebSoap
{
    /// <summary>
    /// Descripción breve de ServicioClientes
    /// </summary>
    [WebService(Namespace = "http://sgoliver.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioClientes : System.Web.Services.WebService
    {
        string connection ="Data Source=(local)\\SQLEXPRESS;Initial Catalog=procedureDB;User Id=sa;Password=Proyectica2011;";

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public int loginVerification(string email, String password)
        {
            SqlConnection con =
                new SqlConnection(connection);

            con.Open();

            string sql = "dbo.androidLogin";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
            cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
            var returnParameter = cmd.Parameters.Add("@result", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            con.Close();
            int res = Int32.Parse(returnParameter.Value.ToString());

            return res;
        }

        [WebMethod]
        public Department[] DepartmentList()
        {
            SqlConnection con =
              new SqlConnection(connection);

            con.Open();

            string sql = "Select idDepartment,department,code from Department";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Department> lista = new List<Department>();

            while (reader.Read())
            {
                Console.Write(reader.GetString(1));
                lista.Add(
                    new Department(reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2)));
            }

            con.Close();

            return lista.ToArray();
        }
        [WebMethod]
        public Login[] LoginList()
        {
            SqlConnection con =
              new SqlConnection(
                connection);

            con.Open();

            string sql = "Select plat.idLogging,email,dbo.getPassword(password),idPlataformers,name,isABoss from procedureDB.dbo.logging as loging inner join procedureDB.dbo.Plataformers as plat on loging.idLogging=plat.idLogging;";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Login> lista = new List<Login>();

            while (reader.Read())
            {
                Console.Write(reader.GetString(1));
                lista.Add(
                    new Login(reader.GetInt32(0),
                                reader.GetString(1),
                                Encriptar(reader.GetString(2)),
                                reader.GetInt32(3),
                                reader.GetString(4),
                                reader.GetInt32(5)));
            }

            con.Close();

            return lista.ToArray();
        }

        [WebMethod]
        public Type[] TypeProcedureList()
        {
            SqlConnection con =
              new SqlConnection(
                connection);
            con.Open();

            string sql = "Select * from TypeOfProcedure";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Type> lista = new List<Type>();

            while (reader.Read())
            {

                lista.Add(
                    new Type(reader.GetInt32(0),
                                reader.GetString(1)
                                ));
            }

            con.Close();

            return lista.ToArray();
        }

        [WebMethod]
        public Type[] TypeIdentifyList()
        {
            SqlConnection con =
              new SqlConnection(
                connection);

            con.Open();

            string sql = "Select * from TypeOfIdentify";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Type> lista = new List<Type>();

            while (reader.Read())
            {

                lista.Add(
                    new Type(reader.GetInt32(0),
                                reader.GetString(1)
                                ));
            }

            con.Close();

            return lista.ToArray();
        }



        [WebMethod]
        public String insertProcedure(String date, int departmentID, int identify, string idPerson,String name,String contact, int typeProcedure, String detail, int userId)
        {
            SqlConnection con =
              new SqlConnection(
                connection);

            con.Open();
            string sql = "dbo.insertProcedure";
            
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@date", System.Data.SqlDbType.Date).Value = date;
            cmd.Parameters.Add("@departmentID", System.Data.SqlDbType.Int).Value = departmentID;
            cmd.Parameters.Add("@idTypeOfIdentify", System.Data.SqlDbType.Int).Value = identify;
            cmd.Parameters.Add("@personID", System.Data.SqlDbType.NVarChar).Value = idPerson;
            cmd.Parameters.Add("@personName", System.Data.SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@personContact", System.Data.SqlDbType.NVarChar).Value = contact;
            cmd.Parameters.Add("@idTypeOfProcedure", System.Data.SqlDbType.Int).Value = typeProcedure;
            cmd.Parameters.Add("@detail", System.Data.SqlDbType.NVarChar).Value = detail;
            cmd.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = userId;
            var returnParameter = cmd.Parameters.Add("@code", SqlDbType.Char,50);
            returnParameter.Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            con.Close();
            String res = returnParameter.Value.ToString();

            return res;


        }

        [WebMethod]
        public Searchs[] searchByDate(String from, String to)
        {
            SqlConnection con =new SqlConnection(connection);
            con.Open();
            string sql = "Select * from dbo.searchByDate(@from,@to)";
            
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@from", SqlDbType.VarChar).Value = from;
            cmd.Parameters.Add("@to", SqlDbType.VarChar).Value = to;

            SqlDataReader reader = cmd.ExecuteReader();

            List<Searchs> lista = new List<Searchs>();

            while (reader.Read())
            {

                lista.Add(
                    new Searchs(reader.GetDateTime(0).ToString("dd-MM-yyyy"),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6)));
            }

            con.Close();

            return lista.ToArray();

        }


        [WebMethod]
        public Searchs[] searchByDepartment(String department)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string sql = "Select * from dbo.searchByDepartment(@department)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@department", SqlDbType.VarChar).Value = department;
           
            SqlDataReader reader = cmd.ExecuteReader();

            List<Searchs> lista = new List<Searchs>();

            while (reader.Read())
            {

                lista.Add(
                    new Searchs(reader.GetDateTime(0).ToString("dd-MM-yyyy"), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
            }

            con.Close();

            return lista.ToArray();

        }

        [WebMethod]
        public Searchs[] searchByPlataformer(String name)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string sql = "Select * from dbo.searchByPlatformer(@name)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;

            SqlDataReader reader = cmd.ExecuteReader();

            List<Searchs> lista = new List<Searchs>();

            while (reader.Read())
            {

                lista.Add(
                    new Searchs(reader.GetDateTime(0).ToString("dd-MM-yyyy"), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
            }

            con.Close();

            return lista.ToArray();

        }

        [WebMethod]
        public Searchs[] searchByCode(String code)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string sql = "Select * from dbo.searchByCode(@code)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = code;

            SqlDataReader reader = cmd.ExecuteReader();

            List<Searchs> lista = new List<Searchs>();

            while (reader.Read())
            {

                lista.Add(
                    new Searchs(reader.GetDateTime(0).ToString("dd-MM-yyyy"), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
            }

            con.Close();

            return lista.ToArray();

        }

        private static string Encriptar(string texto)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(texto);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}


