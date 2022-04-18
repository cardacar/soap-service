using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using AlmacenWebService.Models;

namespace AlmacenWebService
{
    /// <summary>
    /// Summary description for AlmacenService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AlmacenService : System.Web.Services.WebService
    {

        string connectionString = "server=localhost;database=almacen_dabeiba;uid=root;pwd=root;";

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public DataSet ListProductsByLocalId(int localId)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sqlQuery = "SELECT * FROM producto p WHERE p.id_almacen =" + localId.ToString();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [WebMethod]
        public String CreateProduct(Product product)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sqlQuery = $"INSERT INTO producto (codigo,nombre,precio,cantidad,id_almacen) VALUES ('{product.Codigo}','{product.Nombre}',{product.Precio},{product.Cantidad},{product.IdAlmacen})";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return "Exito";
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
