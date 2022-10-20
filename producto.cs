using System.Data.SqlClient;

namespace preEntrega_Final
{
    public class Producto
    {

        private string _idProducto;
        private string _descripciones;
        private int _idUsuario;
        private double _precioDeCompra;
        private double _precioDeVenta;
        private int _stock;


        //Constructor por defecto
        public Producto()
        {
            _idProducto = string.Empty;
            _descripciones = string.Empty;
            _precioDeCompra = 0;
            _precioDeVenta = 0;
            _idUsuario = 0;
            _stock = 0;


        }

        //Constructor con toda la info
        public Producto(string idProducto, string descripciones, double precioDeVenta, double precioDeCompra,  int stock, int idUsuario)
        {
            _idProducto = idProducto;
            _descripciones = descripciones;
            _precioDeCompra = precioDeCompra;
            _precioDeVenta = precioDeVenta;
            _idUsuario = idUsuario;
            _stock = stock;
        }

        public bool HayPrecioDeVenta()
            //Retorna  Si hay un precio de Venta
        {
            return _precioDeVenta > 0;
        }

        public bool HayStock()
            //REtorna TRUE si hay stock mayor a 0
        {
            return _stock > 0;
        }

        public string GetDescripciones()
            //REtorna la descripcion
        {
            return _descripciones;
        }

        public int GetStock()
            //REtorna el stock disponible
        {
            return _stock;
        }
        public double GetPrecioVenta()
            //Retorna el Precio de venta del producto
        {
            return _precioDeVenta;
        }
        public double GetPrecioCompra()
            //Retorna el costo del producto
        {
            return _precioDeCompra;
        }
        public void ModificarStock(int venta)
        {
            //metodo para modificar el stock de un producto
            _stock -= venta;

        }
        public string GetIdProducto()
        //metodo que retorna el codigo de un producto
        {
            return _idProducto;
        }

        public int GetIdUsuario()
            //metodo que retorna el codigo de un producto
        {
            return _idUsuario;
        }


        public static List<Producto> TraerProducto(int idUsuario)
            //Metodo que recibe un UserID y retorna una lista de productos asignados a ese usuario
        {
            List<Producto> productos = new List<Producto> { };
            var listaProductos = productos;

            string connectionString = "Server=W0447;Database=Master; Trusted_connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var comando = new SqlCommand("Select * from Producto where idUsuario ='" + idUsuario + "'", connection);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //string codigo, string descripcion, double precioDeVenta, double precioDeCompra, string categoria, int stock)

                            Producto p = new Producto(dr.GetInt64(0).ToString(), dr.GetString(1), Convert.ToDouble(dr.GetDecimal(2)), Convert.ToDouble(dr.GetDecimal(3)), Convert.ToInt32(dr.GetValue(4)), Convert.ToInt32(dr.GetValue(5)));
                            listaProductos.Add(p);
                        }
                    }
                }
                connection.Close();
                return listaProductos;
            }
        }


     public static void TraerProductoByUsuario()
    {

        var listaProducto = new List<Producto>();

        Console.WriteLine("Ingrese el ID del USUARIO");
        int usuarioId = int.Parse(Console.ReadLine());

        SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
        conecctionbuilder.DataSource = "W0447";
        conecctionbuilder.InitialCatalog = "master";
        conecctionbuilder.IntegratedSecurity = true;
        var cs = conecctionbuilder.ConnectionString;

        using (SqlConnection connection = new SqlConnection(cs))
        {
            using (SqlCommand conect = new SqlCommand("Select * from Poducto where IdUsuario = @usuarioId", connection))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "Select  * from Producto where IdUsuario = @usuarioId";
                cmd.Parameters.Add(new SqlParameter("@usuarioId", usuarioId));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();
                        Console.WriteLine(reader.GetValue(0).ToString());
                        Console.WriteLine(reader.GetValue(1).ToString());
                        Console.WriteLine(reader.GetValue(2).ToString());
                        Console.WriteLine(reader.GetValue(3).ToString());
                        Console.WriteLine(reader.GetValue(4).ToString());

                }

   
            }
        }
    }

}
}


