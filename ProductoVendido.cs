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
    public class ProductoVendido : Producto

    //Clase Venta - Hija de Producto.
    //Basicamente un producto que tambien tiene info de su propia venta
    {
        protected int _idProductoVendido;
        protected int _idVenta;
        protected int _cantidadVendida;

        public ProductoVendido() : base()
        //Constructor con toda la info
        {
            _idProductoVendido = 0;
            _idVenta = 0;
            _cantidadVendida = 0;
        }

        public ProductoVendido(int idProductoVendido, int cantidadVendida, int idVenta, string idProducto, string descripciones, double precioDeVenta, double precioDeCompra, int stock, int idUsuario) : base(idProducto, descripciones, precioDeVenta, precioDeCompra, stock, idUsuario)
        //Constructor con toda la info
        {
            _idProductoVendido = idProductoVendido;
            _idVenta = idVenta;
            _cantidadVendida = cantidadVendida;
        }

        static public List<Producto> TraerProductosVendidos(int idUsuario)
        //Metodo que recive un UserID y retorna una lista de productos vendidos asignados a ese usuario
        {
            string query = "";
            bool agregado = false;
            List<Producto> productos = new List<Producto> { };
            var listaProductos = TraerProducto(idUsuario);
            var listaProductosVendidos = productos;
            foreach (Producto p in listaProductos)
            {
                if (idUsuario == p.GetIdUsuario())
                {
                    if (agregado)
                    {
                        query = query + "," + p.GetIdProducto();
                    }
                    else
                    {
                        agregado = true;
                        query = p.GetIdProducto();
                    }
                }
            }

            string connectionString = "Server=W0447;Database=Master; Trusted_connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var comando = new SqlCommand("Select * from ProductoVendido INNER JOIN Producto on producto.id = productoVendido.IdProducto"
                    + " where idProducto in (" + query + ")", connection);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //string codigo, string descripcion, double precioDeVenta, double precioDeCompra, string categoria, int stock)
                            Producto p = new Producto(dr.GetInt64(0).ToString(), dr.GetString(5), Convert.ToDouble(dr.GetDecimal(7)), Convert.ToDouble(dr.GetDecimal(6)), Convert.ToInt32(dr.GetValue(2)), Convert.ToInt32(dr.GetValue(8)));
                            listaProductosVendidos.Add(p);
                        }
                    }
                }
                connection.Close();
            }

            return listaProductosVendidos;
        }
   
        public int GetIdProductoVendido()
        {
            return _idProductoVendido;
        }
        public int GetIdVenta()
        {
            return _idVenta;
        }
        public int GetCantidadVendida()
        {
            return _cantidadVendida;
        }
    }
}

