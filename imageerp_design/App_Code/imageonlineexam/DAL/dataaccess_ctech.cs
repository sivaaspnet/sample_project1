 using System;
 using System.Collections;
 using System.Data;
 using System.Runtime.CompilerServices;
 using System.Runtime.InteropServices;
 using MySql.Data.MySqlClient;



 namespace MVC1
 {
     public class Mysqlconn_ctech
     {
         #region Dispose Objects If It Is In Use
         public static void disposeConnection(MySqlConnection Conn)
         {
             if ((Conn.State == ConnectionState.Open)) {
                 Conn.Close();
                 Conn.Dispose();
             }
         }

         public static void disposeCommand(MySqlCommand Comm)
         {
             Comm.Dispose();
         }
        
         public static void disposeConnection(MySqlConnection Conn, MySqlCommand Comm)
         {
             if ((Conn.State == ConnectionState.Open)) {
                 Conn.Close();
                 Conn.Dispose();
                 Comm.Dispose();
             }
         }
        
         public static void disposeConnection(MySqlConnection Conn, MySqlCommand Comm, MySqlDataReader MysqlDr)
         {
             if ((Conn.State == ConnectionState.Open)) {
                 Conn.Close();
                 Conn.Dispose();
                 Comm.Dispose();
                 MysqlDr.Close();
             }
         }
        
         public static void disposeConnection(MySqlConnection Conn, MySqlCommand Comm, MySqlDataReader MysqlDr, MySqlDataAdapter MysqlDa)
         {
             if ((Conn.State == ConnectionState.Open)) {
                 Conn.Close();
                 Conn.Dispose();
                 Comm.Dispose();
                 MysqlDr.Close();
                 MysqlDa.Dispose();
             }
         }
         #endregion

         #region Execute Scalar
         public static int ExecuteMysqlScalar(string MysqlStatement)
         {
             int no = 0;
             MySqlConnection Conn = new MySqlConnection(ConnectionString);
             Mysqlconn_ctech.disposeConnection(Conn);
             Conn.Open();
             MySqlCommand Comm = new MySqlCommand(MysqlStatement, Conn);

             try
             {
                 no = Convert.ToInt32(Comm.ExecuteScalar().ToString());
             }
             catch(Exception ex)
             {
                 SiteFunctions.Log(ex);
             }
             finally
             {
                 Mysqlconn_ctech.disposeConnection(Conn, Comm);
             }
             return no;
         }

         public static int ExecuteMysqlScalar(MySqlCommand Comm)
         {
             int no = 0;
             try
             {
                 no = Convert.ToInt32(Comm.ExecuteScalar().ToString());
             }
             catch (Exception ex)
             {
                 SiteFunctions.Log(ex);
             }
             return no;
         }

         #endregion
         #region Execute Scalar_str
         public static string ExecuteMysqlScalar_str(string MysqlStatement)
         {
             string result = "";
             MySqlConnection Conn = new MySqlConnection(ConnectionString);
             Mysqlconn_ctech.disposeConnection(Conn);
             Conn.Open();
             MySqlCommand Comm = new MySqlCommand(MysqlStatement, Conn);

             try
             {
                 result =Comm.ExecuteScalar().ToString();
             }
             catch (Exception ex)
             {
                 SiteFunctions.Log(ex);
             }
             finally
             {
                 Mysqlconn_ctech.disposeConnection(Conn, Comm);
             }
             return result;
         }

         public static string ExecuteMysqlScalar_str(MySqlCommand Comm)
         {
             string result = "";
             try
             {
                 result=Comm.ExecuteScalar().ToString();
             }
             catch (Exception ex)
             {
                 SiteFunctions.Log(ex);
             }
             return result;
         }

         #endregion

         #region Execute Command
         public static int ExecuteMySqlCommand(string MysqlStatement)
         {
             int retCount = 0;
             MySqlConnection Conn = new MySqlConnection(ConnectionString);
             Mysqlconn_ctech.disposeConnection(Conn);
             Conn.Open();
             MySqlCommand Comm = new MySqlCommand(MysqlStatement, Conn);
             try
             {
                 retCount = Comm.ExecuteNonQuery();
             }
             catch (Exception ex)
             {
                 SiteFunctions.Log(ex);
             }
             finally
             {
                 Mysqlconn_ctech.disposeConnection(Conn, Comm);
             }
             return retCount;
         }

         public static int ExecuteMySqlCommand(MySqlCommand Comm)
         {
             int retCount = 0;
             try
             {
                 retCount = Comm.ExecuteNonQuery();
             }
             catch (Exception ex)
             {
                 SiteFunctions.Log(ex);
             }
             return retCount;
         }
        #endregion

         #region Execute DataReader
         public static MySqlDataReader ExecuteMySqlDataReader(string MysqlStatement)
         {

             MySqlConnection connection = new MySqlConnection(ConnectionString); //Mysqlconn.ExecuteMySqlConnection();//new MySqlConnection(MySqlConnection); //
             disposeConnection(connection);
             connection.Open();
             MySqlCommand command = new MySqlCommand(MysqlStatement, connection);
             return command.ExecuteReader(CommandBehavior.CloseConnection);

         }
         public static MySqlDataReader ExecuteMySqlDataReader(MySqlCommand Comm)
         {
                 return Comm.ExecuteReader(CommandBehavior.CloseConnection);
         }

         #endregion

         #region Execute DataTable
         public static DataTable ExecuteMysqlDataTable(string MysqlStatement)
         {
             MySqlConnection Conn = new MySqlConnection(ConnectionString);
             Mysqlconn_ctech.disposeConnection(Conn);
             Conn.Open();
             DataTable Dtable = new DataTable();
             try 
             {
                 MySqlCommand selectCommand = new MySqlCommand(MysqlStatement, Conn);
                 MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
                 DataSet ds = new DataSet();
                 adapter.Fill(Dtable);
                 adapter.Fill(ds);
                 selectCommand.Dispose();
                 adapter.Dispose();
             }
             catch (Exception ex)
             {
                 SiteFunctions.Log(ex);
             }
             finally
             {
                 Conn.Dispose();
             }

             return Dtable;
         }


         public static DataTable ExecuteMysqlDataTable(MySqlCommand Comm)
         {
             DataTable Dtable = new DataTable();
             try
             {
                 MySqlDataAdapter adapter = new MySqlDataAdapter(Comm);

                 adapter.Fill(Dtable);
             }
             catch (Exception ex)
             {
                 SiteFunctions.Log(ex);
             }
            
             return Dtable;
         }


        #endregion

         #region Execute DataSet
         public static DataSet ExecuteMysqlDataset(string MysqlStatement)
         {
             MySqlConnection Conn = new MySqlConnection(ConnectionString);
             Mysqlconn_ctech.disposeConnection(Conn);
             Conn.Open();
             DataSet dataSet = new DataSet();
             try
             {
                 MySqlCommand selectCommand = new MySqlCommand(MysqlStatement, Conn);
                 MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
                 adapter.Fill(dataSet, "Table");
                 selectCommand.Dispose();
                 adapter.Dispose();
             }
             catch (Exception ex)
             {
                 SiteFunctions.Log(ex);
             }
             finally
             {
                 Conn.Dispose();
             }
             return dataSet;
         }
         #endregion

         #region Connection String
         public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
         public static string ConnectionString_cert = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1_cert"].ConnectionString;
         #endregion
     }
 }