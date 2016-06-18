using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DConexion
    {
        /* public static String CnBDEmpresa = "Data Source=.\\SQLExpress; Initial Catalog=BDEmpresa; Integrated Security=SSPI;"; */
        public static String CnBDEmpresa = "Data Source = .\\SQLEXPRESS;Initial Catalog = BDEmpresa; Integrated Security = True";
        public static String CnMaster = "Data Source=NOTEBOOK-ACER\\HERNANDEMCZUK; Initial Catalog=master; Integrated Security=SSPI;";

        public String ChequearConexion()
        {
            String mensaje = "";
            SqlConnection SqlConexion = new SqlConnection();

            try
            {
                SqlConexion.ConnectionString = DConexion.CnBDEmpresa;
                SqlConexion.Open();
                mensaje = "Y";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                SqlConexion.Close();
            }

            return mensaje;
        }
    }
}