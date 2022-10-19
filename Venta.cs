using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace preEntrega_Final
{
    public class Venta:Producto

    //Clase Venta - Hija de Producto.
    //Basicamente un producto que tambien tiene info de su propia venta
    {
        protected string _comentario;
        protected int _idVenta;
        protected int _idUsuario;
        public Venta( int idUsuario, int idVenta, string comentario, string codigo, string descripcion, double precioDeVenta, double precioDeCompra, int stock, int categoria) : base(codigo, descripcion, precioDeVenta, precioDeCompra, stock, categoria)
            //Constructor con toda la info
        {
            _idUsuario = idUsuario;
            _comentario = comentario;
            _idVenta = idVenta;
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
                var comando = new SqlCommand("SELECT Venta.IdUsuario, Venta.Id, Venta.Comentarios, Producto.Id, producto.Descripciones, Producto.PrecioVenta, Producto.Costo, Producto.Stock, Producto.IdUsuario FROM ProductoVendido " +
                    "INNER JOIN Venta ON ProductoVendido.IdVenta = Venta.Id " +
                    "INNER JOIN Producto ON ProductoVendido.IdProducto = Producto.Id " +
                    "WHERE producto.IdUsuario = " + userId, connection);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Venta p = new Venta((int)Convert.ToInt64(dr.GetValue(0)),(int)Convert.ToInt64(dr.GetValue(1)), dr.GetString(2),dr.GetInt64(3).ToString(), dr.GetString(4), Convert.ToDouble(dr.GetDecimal(5)), Convert.ToDouble(dr.GetDecimal(6)), Convert.ToInt32(dr.GetValue(7)), Convert.ToInt32(dr.GetValue(8)));
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
    }
}
