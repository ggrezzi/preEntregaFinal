using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace preEntrega_Final
{
    public class Venta

    //Clase Venta - Hija de Producto.
    //Basicamente un producto que tambien tiene info de su propia venta
    {
        protected string _comentario;
        protected int _idVenta;
        protected int _idUsuario;
        protected List<ProductoVendido> _listaProductosVendidos = new List<ProductoVendido>();


        public Venta(int idUsuario, int idVenta, string comentario, List<ProductoVendido> listaProductosVendidos )
        //Constructor con toda la info
        {

            // int categoria
            _idUsuario = idUsuario;
            _comentario = comentario;
            _idVenta = idVenta;
            _listaProductosVendidos = listaProductosVendidos;
            //_listaProductosVendidos = ProductoVendido.TraerProductosVendidosPorIdVenta(idVenta);
        }

        static public List<Venta> TraerVentas(int userId)
            //Metodo al que se le ingresa un UserID y retorna la lista de ventas correspondiente
            //a ese usuario
        {
            List<Venta> ventas = new List<Venta> { };
            var traerVentas = ventas;
            string connectionString = "Server=W0447;Database=Master; Trusted_connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var comando = new SqlCommand("SELECT * from Venta Where IdUsuario = " + userId, connection);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ProductoVendido temporaryProd = new ProductoVendido();
                            Venta p = new Venta((int)Convert.ToInt64(dr.GetValue(2)),(int)Convert.ToInt64(dr.GetValue(0)), dr.GetString(1), temporaryProd.TraerProductosVendidosPorIdVenta((int)Convert.ToInt64(dr.GetValue(0))));
                            traerVentas.Add(p);
                        }
                    }
                }
                connection.Close();

            }
            return traerVentas;
        }

        public string GetComentarios()
            //Metodo que retorna los comentarios de la venta
        {
            return _comentario;
        }


        public  List<ProductoVendido> GetListaProductosVendidos()
        //Metodo que retorna los comentarios de la venta
        {
            return _listaProductosVendidos;
        }
        public string GetDescripciones()
        {
            return _comentario;

        }
    }
}
