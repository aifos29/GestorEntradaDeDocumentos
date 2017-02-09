using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace GestorDocumentosEntrada.Models
{
    public class ProcedureConnection
    {
        private static String connectionString = "Data Source = (local)\\SQLEXPRESS; Initial Catalog=procedureDB;Integrated security=true";
        private SqlConnection connection = new SqlConnection(connectionString);

        //get the data to fill the differents departments
        public DataSet getDepartments()
        {
            DataSet departmentTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from getDepartments() Order by department", connection);
                sqlQuery.Fill(departmentTable, "DepartmentsList");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return departmentTable;
        }

        //get the data to fill the procedure type
        public DataSet getProcedureType()
        {
            DataSet procedureTypeTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from getProcedureType() Order by TypeOfProcedure", connection);
                sqlQuery.Fill(procedureTypeTable, "ProcedureTypeList");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return procedureTypeTable;
        }

        //get the data to fill the id type
        public DataSet getIdentifyType()
        {
            DataSet identifyTypeTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from getIdentifyType()", connection);
                sqlQuery.Fill(identifyTypeTable, "IdentifyTypeList");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return identifyTypeTable;
        }


        //Get the code to assign a the new procedure
        public string getCode(int departmentId)
        {
            String code = null;
            connection.Open();
            if (connection != null)
            {
                SqlCommand sqlQuery = new SqlCommand("select dbo.getConsecutive(" + departmentId + ")", connection);
                SqlDataReader reader = sqlQuery.ExecuteReader();
                while (reader.Read())
                {
                    code = reader[0].ToString();
                }
                connection.Close();
            }
            else
            {
                code = "Error de Conexion";
            }
            return code;
        }


        public string insertProcedure(DateTime date,int departmentId,int idTypeOfIdentify,String personID,String personName,String personContact,int  idTypeOfProcedure,String detail,int userId)

        {
            String code = null;
            connection.Open();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand("dbo.insertProcedure", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@departmentId", departmentId);
                cmd.Parameters.AddWithValue("@idTypeOfIdentify", idTypeOfIdentify);
                cmd.Parameters.AddWithValue("@personID", personID);
                cmd.Parameters.AddWithValue("@personName", personName);
                cmd.Parameters.AddWithValue("@personContact", personContact);
                cmd.Parameters.AddWithValue("@idTypeOfProcedure", idTypeOfProcedure);
                cmd.Parameters.AddWithValue("@detail", detail);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                code = Convert.ToString(cmd.Parameters["@code"].Value);

                connection.Close();
            }
            return code;
        }

        public DataSet getProcedure(String procedureCode)
        {
            DataSet procedureTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                string query = "Select * from getProcedure('" + procedureCode + "')";
                SqlDataAdapter sqlQuery = new SqlDataAdapter(query, connection);
                sqlQuery.Fill(procedureTable, "procedureList");
                connection.Close();
            }
            return procedureTable;
        }

        public void updateProcedure(String code, int idTypeOfIdentify, String personID, String personName, String personContact, int idTypeOfProcedure, String detail)

        {
            connection.Open();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand("dbo.updateProcedure", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@idTypeOfIdentify", idTypeOfIdentify);
                cmd.Parameters.AddWithValue("@personID", personID);
                cmd.Parameters.AddWithValue("@personName", personName);
                cmd.Parameters.AddWithValue("@personContact", personContact);
                cmd.Parameters.AddWithValue("@idTypeOfProcedure", idTypeOfProcedure);
                cmd.Parameters.AddWithValue("@detail", detail);
                int rowAffected = cmd.ExecuteNonQuery();

                connection.Close();
            }
        }
        /*1*/
        public DataSet getPlatformers()
        {
            DataSet platformerTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from getPlatformers() Order by name", connection);
                sqlQuery.Fill(platformerTable, "PlatformerList");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return platformerTable;
        }
        /*2*/
        public DataSet getSearchDep(String dep)
        {
            DataSet depTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from dbo.searchByDepartment('" + dep + "')", connection);
                sqlQuery.Fill(depTable, "Table");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;
        }
        /*3*/
        public DataSet getSearchPlat(String plat)
        {
            DataSet depTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from dbo.searchByPlatformer('" + plat + "')", connection);
                sqlQuery.Fill(depTable, "Table");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;
        }
        /*4*/
        public DataSet getSearchDate(DateTime from, DateTime to)
        {

            DataSet depTable = new DataSet();
            connection.Open();
            String newFrom = from.ToString("yyyy-MM-dd");
            String newTo = to.ToString("yyyy-MM-dd");
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from dbo.searchByDate('" + newFrom + "', '" + newTo + "')", connection);
                sqlQuery.Fill(depTable, "Table");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;

        }
        /*5*/
        public DataSet getSearchCode(String code)
        {
            DataSet depTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from dbo.searchByCode('" + code + "')", connection);
                sqlQuery.Fill(depTable, "Table");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;
        }
        
        public DataSet getBinnacle(DateTime from, DateTime to)
        {

            DataSet depTable = new DataSet();
            connection.Open();
            String newFrom = from.ToString("yyyy-MM-dd");
            String newTo = to.ToString("yyyy-MM-dd");
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from dbo.getBinnacle('" + newFrom + "', '" + newTo + "') Order by Fecha", connection);
                sqlQuery.Fill(depTable, "Table");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;

        }
        /*6*/
        public int getIDLogin(string email, string pwd)
        {
            connection.Open();
            int id = 0;
            if (connection != null)
            {
                SqlCommand sqlQuery = new SqlCommand("select [dbo].[LoginUsuario]('" + email + "','" + pwd + "')", connection);
                SqlDataReader reader = sqlQuery.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader[0];
                }
                connection.Close();
            }
            else
            {
                id = -1;
            }
            return id;
        }
        /*7*/
        public int getIDPlatformer(int idLog)
        {
            connection.Open();
            int id = 0;
            if (connection != null)
            {
                SqlCommand sqlQuery = new SqlCommand("select [dbo].[seacrhInPlatformer] (" + idLog + ")", connection);
                SqlDataReader reader = sqlQuery.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader[0];
                }
                connection.Close();
            }
            else
            {
                id = -1;
            }
            return id;
        }
        /*8*/
        public string getNamePlatformer(int platformertId)
        {
            String code = null;
            connection.Open();
            if (connection != null)
            {
                SqlCommand sqlQuery = new SqlCommand("select [dbo].[getNamePlatforme] (" + platformertId + ")", connection);
                SqlDataReader reader = sqlQuery.ExecuteReader();
                while (reader.Read())
                {
                    code = reader[0].ToString();
                }
                connection.Close();
            }
            else
            {
                code = "Error de Conexion";
            }
            return code;
        }
        /*9*/
        public int IsABoss(int idPlat)
        {
            connection.Open();
            int flag = 0;
            if (connection != null)
            {
                SqlCommand sqlQuery = new SqlCommand("select [dbo].[IsABoss] (" + idPlat + ")", connection);
                SqlDataReader reader = sqlQuery.ExecuteReader();
                while (reader.Read())
                {
                    flag = (int)reader[0];
                }
                connection.Close();
            }
            else
            {
                flag = -1;
            }
            return flag;
        }

        /*10*/
        public int getIDSecretary(int idLog)
        {
            connection.Open();
            int id = 0;
            if (connection != null)
            {
                SqlCommand sqlQuery = new SqlCommand("select [dbo].[seacrhInSecretary] (" + idLog + ")", connection);
                SqlDataReader reader = sqlQuery.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader[0];
                }
                connection.Close();
            }
            else
            {
                id = -1;
            }
            return id;
        }
        /*11*/
        public string getNameSecretary(int secretarytId)
        {
            String code = null;
            connection.Open();
            if (connection != null)
            {
                SqlCommand sqlQuery = new SqlCommand("select [dbo].[getNameSecretary] (" + secretarytId + ")", connection);
                SqlDataReader reader = sqlQuery.ExecuteReader();
                while (reader.Read())
                {
                    code = reader[0].ToString();
                }
                connection.Close();
            }
            else
            {
                code = "Error de Conexion";
            }
            return code;
        }
        /*12*/
        public DataSet getViewUsers()
        {
            DataSet depTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from [dbo].[getViewOfUser] () order by Nombre", connection);
                sqlQuery.Fill(depTable, "Table");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            } 
            return depTable;
        }
        /*13*/
        public int existEmail(String email)
        {
            int code = 0;
            int flag = 0;
            int idLog = 0;
            connection.Open();
            if (connection != null)
            {

                SqlCommand sqlQuery = new SqlCommand("select [dbo].[existEmail] ('" + email + "')", connection);
                SqlDataReader reader = sqlQuery.ExecuteReader();
                while (reader.Read())
                {
                    flag = (int)reader[0];
                }
            }
            connection.Close();
            return flag;

        }
        /*14*/
        public int insertLoggin(String email, String pwd)
        {
            int code = 0;

            connection.Open();
            if (connection != null)
            {

                SqlCommand cmd = new SqlCommand("dbo.insertLogging", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", pwd);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
            return code;

        }
        /*15*/
        public int searchInLogging(String email)
        {
            int idLog = 0;
            String pwd = null;
            connection.Open();
            if (connection != null)
            {

                SqlCommand sqlQuery2 = new SqlCommand("select [dbo].[searchInLogging] ('" + email + "','" + pwd + "')", connection);
                SqlDataReader reader2 = sqlQuery2.ExecuteReader();
                while (reader2.Read())
                {
                    idLog = (int)reader2[0];
                }
            }
            connection.Close();
            return idLog;

        }
        /*16*/
        public int insertPlatfor(String email, String pwd, String name, int boss)
        {
            int code = 0;
            int flag = 0;
            int idLog = 0;
            connection.Open();
            if (connection != null)
            {
                connection.Close();
                flag = existEmail(email);

                if (flag == 0)
                {
                    insertLoggin(email, pwd);
                    idLog = searchInLogging(email);
                    connection.Open();
                    SqlCommand cmd2 = new SqlCommand("dbo.insertPlatformers", connection);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@name", name);
                    cmd2.Parameters.AddWithValue("@isABoss", boss);
                    cmd2.Parameters.AddWithValue("@idLogging", idLog);
                    cmd2.ExecuteNonQuery();
                    code = 0;
                }
                else
                { code = -1; }

                connection.Close();
            }
            return code;
        }
        /*17*/
        public int insertSecre(String email, String pwd, String name, String dep)
        {
            int code = 0;
            int flag = 0;
            int idLog = 0;
            int idDep = 0;
            connection.Open();
            if (connection != null)
            {
                connection.Close();
                flag = existEmail(email);

                if (flag == 0)
                {
                    insertLoggin(email, pwd);
                    idLog = searchInLogging(email);
                    connection.Open();

                    SqlCommand sqlQuery3 = new SqlCommand("select [dbo].[searchInDepartment] ('" + dep + "')", connection);
                    SqlDataReader reader3 = sqlQuery3.ExecuteReader();
                    while (reader3.Read())
                    {
                        idDep = (int)reader3[0];
                    }
                    connection.Close();
                    connection.Open();
                    SqlCommand cmd2 = new SqlCommand("dbo.insertSecretary", connection);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@name", name);
                    cmd2.Parameters.AddWithValue("@idLoggingin", idLog);
                    cmd2.Parameters.AddWithValue("@idDepartment", idDep);
                    cmd2.ExecuteNonQuery();
                    code = 0;
                }
                else
                { code = -1; }

                connection.Close();
            }
            return code;
        }

        public DataSet getStadisticByDate(String to, String from)
        {
            DataSet depTable = new DataSet();
            connection.Open();

            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from [dbo].getStadisticByDate('" + to + "','" + from + "')", connection);
                sqlQuery.Fill(depTable, "Table");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;

        }

        public DataTable getStadisticByPlataformer(string code)
        {
            DataTable depTable = new DataTable();
            connection.Open();

            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("SELECT * FROM [dbo].[getStadisticbyPlataformer] ('" + code + "') order by position", connection);
                sqlQuery.Fill(depTable);
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;
        }

        public DataTable getStadisticByDateForDepartment(string from, string to)
        {
            DataTable depTable = new DataTable();
            connection.Open();

            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("SELECT * FROM [dbo].[getStadisticByDateForDeparment] ('" + from + "','" + to + "') ", connection);
                sqlQuery.Fill(depTable);
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;
        }


        internal DataTable getStadisticByDateForPlataformer(string from, string to)
        {
            DataTable depTable = new DataTable();
            connection.Open();

            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("SELECT * FROM [dbo].[getStadisticByDateForPlataformer] ('" + from + "','" + to + "') ", connection);
                sqlQuery.Fill(depTable);
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;
        }

        public DataTable getStadisticByDepartment(String id)
        {
            DataTable depTable = new DataTable();
            connection.Open();

            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("SELECT * FROM [dbo].[getStadisticbyDepartment] ('" + id + "') order by position", connection);
                sqlQuery.Fill(depTable);
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;
        }
        /*18*/
        public DataSet test(int departmentId)
        {
            DataSet depTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * FROM [dbo].[getDailyProcedures]("+departmentId+")", connection);
                sqlQuery.Fill(depTable, "Table");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;
        }
        /**/
        public int getIDDepartmentBySec(int id)
        {
            int code = 0;
            connection.Open();
            if (connection != null)
            {
                SqlCommand sqlQuery = new SqlCommand("select [dbo].[getIDDepartmentBySec] (" + id + ")", connection);
                SqlDataReader reader = sqlQuery.ExecuteReader();
                while (reader.Read())
                {
                    code = (int)reader[0];
                }
                connection.Close();
            }
            else
            {
                code = 0;
            }
            return code;
        }
        /**/
        public string getNameDep(int departmentId)
        {

            String code = null;
            connection.Open();
            if (connection != null)
            {
                SqlCommand sqlQuery = new SqlCommand("select dbo.getNameDepartment(" + departmentId + ")", connection);
                SqlDataReader reader = sqlQuery.ExecuteReader();
                while (reader.Read())
                {
                    code = reader[0].ToString();
                }
                connection.Close();
            }
            else
            {
                code = "Error de Conexion";
            }
            return code;

        }

        public int insertProcedureType(String name)
        {
            int code = 0;
            int flag = 0;
            
            connection.Open();
            if (connection != null)
            {
                connection.Close();
                flag = existProcedureType(name);

                if (flag == 0)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("dbo.insertTypeProc", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeOfProcedur", name);
                    cmd.ExecuteNonQuery();
                    code = 0;
                }
                else
                { code = -1; }

                connection.Close();
            }
            return code;

        }
        public int existProcedureType(String name)
        {

            int flag = 0;

            connection.Open();
            if (connection != null)
            {

                SqlCommand sqlQuery = new SqlCommand("select [dbo].[existTypeOfProc] ('" + name + "')", connection);
                SqlDataReader reader = sqlQuery.ExecuteReader();
                while (reader.Read())
                {
                    flag = (int)reader[0];
                }
            }
            connection.Close();
            return flag;

        }
        /**/
        public DataSet getViewProcType()
        {
            DataSet depTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * from [dbo].[getViewOfTypeProce] ()", connection);
                sqlQuery.Fill(depTable, "Table");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;
        }

        public DataSet getDisplayDepartmentProcedures(int departmentID)
        {
            DataSet depTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * FROM [dbo].[getDisplayProcedures]("+ departmentID +")", connection);
                sqlQuery.Fill(depTable, "Table");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;
        }

        public DataSet getProcedureStates()
        {
            DataSet depTable = new DataSet();
            connection.Open();
            if (connection != null)
            {
                SqlDataAdapter sqlQuery = new SqlDataAdapter("Select * FROM [dbo].[getStates]()", connection);
                sqlQuery.Fill(depTable, "State");
                connection.Close();
            }
            else
            {
                var message = "Error de Conexion";
            }
            return depTable;
        }

        /**/
       public int  TransferProcedure(int idProc,int recive,int send,String code,String justi)
       {


           connection.Open();
           if (connection != null)
           {
              
                   
                   SqlCommand cmd = new SqlCommand("dbo.transferProcedure", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@idDep", recive);
                   cmd.Parameters.AddWithValue("@code", code);
                   cmd.ExecuteNonQuery();

                   SqlCommand cmd2 = new SqlCommand("dbo.insertTransferdDoc", connection);
                   cmd2.CommandType = CommandType.StoredProcedure;
                   cmd2.Parameters.AddWithValue("@justification ", justi);
                   cmd2.Parameters.AddWithValue("@idSender_Secretary ", send);
                   cmd2.Parameters.AddWithValue("@idReceiver_Department", recive);
               cmd2.Parameters.AddWithValue("@idProcedure", idProc);
                   cmd2.ExecuteNonQuery();
                   connection.Close();
               return 0;
                   
               }
               else
           {
               return -1;

              
           }
        
       }

        public void closeProcedure(String state, String observation, int idProcedure, DateTime date)
        {
            connection.Open();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand("dbo.closeProcedure", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@observation", observation);
                cmd.Parameters.AddWithValue("@idProcedure", idProcedure);
                cmd.Parameters.AddWithValue("@date", date);
                int rowAffected = cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void changeProcedureStatus(String state, int idProcedure)
        {
            connection.Open();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand("dbo.changeProcedureStatus", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@idProcedure", idProcedure);
                int rowAffected = cmd.ExecuteNonQuery();

                connection.Close();
            }
        }
        /**/
        public int init(String code) {
            int flag = 0;
            connection.Open();
            if (connection != null)
            {
               

                //insertLoggin(email, pwd);
                
                SqlCommand cmd2 = new SqlCommand("dbo.initializeProcedure", connection);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@code", code);
                cmd2.ExecuteNonQuery();

                connection.Close();
            }
            return flag;
        
            
        
        }
        /**/
        public int eliminateUser(String email) {
            int code = 0;
            int flag = 0;
            int idLog = 0;
            String pwd = null;
            connection.Open();
            if (connection != null)
            {
                connection.Close();
                flag = existEmail(email);

                
                    //insertLoggin(email, pwd);
                    idLog = searchInLogging(email);
                    connection.Open();
                    SqlCommand cmd2 = new SqlCommand("dbo.cleanLogin", connection);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@id", idLog);
                    cmd2.ExecuteNonQuery();
                    code = 0;

                connection.Close();
            }
            return code;
        
        
        
        }
        
        
        public int updateEmail(String email, int idLog) {
            connection.Open();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand("dbo.updateEmail", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id", idLog);
                
                int rowAffected = cmd.ExecuteNonQuery();

                connection.Close();
            }
            return 0;
        }


        public int updateSecretary(String name, String newDep, int idlog){
            connection.Open();
            int idDep = 0;
            if (connection != null)
            {
                SqlCommand sqlQuery3 = new SqlCommand("select [dbo].[searchInDepartment] ('" + newDep + "')", connection);
                    SqlDataReader reader3 = sqlQuery3.ExecuteReader();
                    while (reader3.Read())
                    {
                        idDep = (int)reader3[0];
                    }
                    connection.Close();
                    connection.Open();
                    
                SqlCommand cmd = new SqlCommand("dbo.updateSecretary", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDep", idDep);
                cmd.Parameters.AddWithValue("@idlog", idlog);
                cmd.Parameters.AddWithValue("@name", name);
                int rowAffected = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return 0;
        
        
        }

        public int updatePlataforma(String name, int boss, int idlog) {
            connection.Open();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand("dbo.updatePlatformer", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idlog", idlog);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@isABoss", boss);
                int rowAffected = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return 0;
        
        }


        public int moveToDepartment(String name, String newDep, int idlog, String email) {
            connection.Open();
            int newIdLog = 0;
            int idDep = 0;
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand("dbo.reInsertLogin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idlog);
                cmd.Parameters.AddWithValue("@email", email);
                int rowAffected = cmd.ExecuteNonQuery();
                connection.Close();
                newIdLog = searchInLogging(email);
                connection.Open();

                SqlCommand sqlQuery3 = new SqlCommand("select [dbo].[searchInDepartment] ('" + newDep + "')", connection);
                SqlDataReader reader3 = sqlQuery3.ExecuteReader();
                while (reader3.Read())
                {
                    idDep = (int)reader3[0];
                }
                connection.Close();
                connection.Open();
                SqlCommand cmd2 = new SqlCommand("dbo.insertSecretary", connection);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@name", name);
                cmd2.Parameters.AddWithValue("@idLoggingin", newIdLog);
                cmd2.Parameters.AddWithValue("@idDepartment", idDep);
                cmd2.ExecuteNonQuery();
                connection.Close();
            }
            return 0;
        }

        public int moveToPlatformer(String name, int boss, int idlog, String email) {
            connection.Open();
            if (connection != null)
            {
                SqlCommand cmd = new SqlCommand("dbo.deleteSecretary", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idlog", idlog);
                int rowAffected = cmd.ExecuteNonQuery();
                connection.Close();
                connection.Open();
                SqlCommand cmd2 = new SqlCommand("dbo.insertPlatformers", connection);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@name", name);
                cmd2.Parameters.AddWithValue("@isABoss", boss);
                cmd2.Parameters.AddWithValue("@idLogging", idlog);
                cmd2.ExecuteNonQuery();
                connection.Close();

            }
            return 0;
        }
    

    }
}