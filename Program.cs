


using Microsoft.Win32.SafeHandles;
using preEntrega_Final;
using System.Collections;
using System.Data.SqlClient;

//Inicializacion de las variables
int idUsuario = 0;
var usuario = new Usuario();
string opcion = string.Empty;
string nombreUsuario = string.Empty;
List<Venta> ventas = new List<Venta>();
List<Producto> productos = new List<Producto>();

//Menu inciial de pruebas
Console.WriteLine("A - Traer usuario - Ingresa Nombre de usuario y debe retornar el Objeto Usuario");
Console.WriteLine("B - Traer Producto - Ingresa un User ID y retorna ina lista de productos cargados por ese usuario");
Console.WriteLine("C - Traer Producto Vendido - Ingresa Usuario y trae todos los productos vendidos de el.");
Console.WriteLine("D - Traer Ventas - Ingresa User ID y debe retornar todas las ventas asignadas a ese usuario");
Console.WriteLine("E - Inicio de Sesion - Ingresa Nombre de Usuario y Password y retorna el User si existe o un User vacio");
Console.WriteLine("F - EXIT TEST");
Console.WriteLine();
Console.Write("Ingrese la opcion que desea testear:");
opcion = Console.ReadLine().ToUpper();


while (opcion != "F")
{ 
    switch (opcion)
    {
        case "A":
            //Punto A de la entrega: Traer Usuario - Invoco un metodo al que le paso un Nombre de Usuario y 
            //me devuelve el objeto usuario
            Console.Write("Ingrese el Nombre de USuario que desea traer:");
            nombreUsuario = Console.ReadLine();
            usuario = usuario.TraerUsuario(nombreUsuario);
            Console.WriteLine("ID del usuario= " + usuario.GetId().ToString());
            Console.WriteLine("Nombre de Usuario= "+usuario.GetName());
            Console.WriteLine("Apellido del usuario= " + usuario.GetApellido());
            Console.WriteLine("UserName del usuario= " + usuario.GetNombreUsuario());
            Console.WriteLine("Password del usuario= " + usuario.GetPassword());
            Console.WriteLine("Email del usuario= " + usuario.GetEmail());
            break;
        case "B":

            //Punto B de la entrega: Traer Producto - Invoco un metodo al que le paso un ID de usuario
            //y me retorna una lista de productos asignados a ese usuario
            Console.Write("Ingrese el User ID del que se desea traer los productos:");
            idUsuario = Convert.ToInt32(Console.ReadLine());
            productos = Producto.TraerProducto(idUsuario);
            Console.WriteLine("Lista de productos retornada para le Id " +idUsuario);
            foreach (Producto p in productos)
            {
                Console.Write("Descipcion: ");
                Console.WriteLine(p.GetDescripciones());
            }
            break;
        case "C":
            //Punto C de la entrega: Traer productos Vendidos - Invoco un metodo al que le ingreso un 
            //ID de usuario y me retorna todos los productos vendidos de ese usuario
            Console.Write("Ingrese el User ID del que se desea traer los productos Vendidos:");
            idUsuario = Convert.ToInt32(Console.ReadLine());
            productos = ProductoVendido.TraerProductosVendidos(idUsuario);
            Console.WriteLine("Lista de productos retornada para le Id " + idUsuario);
            foreach (Producto p in productos)
            {
                Console.Write("Descipcion: ");
                Console.WriteLine(p.GetDescripciones());
            }
            break;
        case "D":
            //Punto D de la entrega: Traer Ventas - Invoco metodo al que le ingreso un ID de Usuario
            //y me retorna todas las ventas asignadas a ese usuario
            Console.Write("Ingrese el User ID del que se desea traer todas las ventas:");
            idUsuario = Convert.ToInt32(Console.ReadLine());
            ventas = Venta.TraerVentas(idUsuario);
            Console.WriteLine("Lista de productos retornada para le Id " + idUsuario);
            foreach (Venta p in ventas)
            {
                Console.Write("Descipcion: ");
                Console.WriteLine(p.GetDescripciones());
                Console.Write("Comentarios: ");
                Console.WriteLine(p.GetComentarios());

            }
            break;

        case "E":
            //Punto E de la entrega: Inicio de Sesion - Metodo al que se le pasa "Nombre de Usuario" y
            //Contrasena y devuelve un objeto USuario con todos los datos del mismo o un Usuario vacio 
            //con ID=0 si los datos de inicio de sesion son incorrectos.
            Console.Write("Ingrese el nombre del Usuario:");
            nombreUsuario = Console.ReadLine();
            Console.Write("Ingrese su password:");
            string password = Console.ReadLine();
            usuario = usuario.InicioDeSesion(nombreUsuario,password);
            if (usuario.GetId()==0)
            {
                Console.WriteLine("Usuario no encontrado");
            }
            else
            {
                Console.WriteLine("Nombre del usuario: " + usuario.GetName());
                Console.WriteLine("Apellido del usuario: "+usuario.GetApellido());
                Console.WriteLine("ID del usuario:"+usuario.GetId().ToString());
                Console.WriteLine("MAil del usuario:"+usuario.GetEmail());
            }
            break;
        default:
            Console.WriteLine("La opcion ingresada no es valida. Intente nuevamente");
            break;
    }
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
    Console.Clear();

    //Menu de opciones de testeo.
    Console.WriteLine("A - Traer usuario - Ingresa Nombre de usuario y debe retornar el Objeto Usuario");
    Console.WriteLine("B - Traer Producto - Ingresa un User ID y retorna ina lista de productos cargados por ese usuario");
    Console.WriteLine("C - Traer Producto Vendido - Ingresa Usuario y trae todos los productos vendidos de el.");
    Console.WriteLine("D - Traer Ventas - Ingresa User ID y debe retornar todas las ventas asignadas a ese usuario");
    Console.WriteLine("E - Inicio de Sesion - Ingresa Nombre de Usuario y Password y retorna el User si existe o un User vacio");
    Console.WriteLine("F - EXIT TEST");
    Console.WriteLine();
    Console.Write("Ingrese la opcion que desea testear:");
    opcion = Console.ReadLine().ToUpper();

}

















