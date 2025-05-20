

// See https://aka.ms/new-console-template for more information

using AccesoDatos.Models;
using AccesoDatos.operation;

Console.WriteLine("Hello, World!");



//Console.WriteLine("********  Erick Navarro Vega              **********");
//Console.WriteLine("********  jordan emmanuel nieves vargas           **********");
//Console.WriteLine("********  Johan Alejandro Piscoya Morillo **********");
//Console.WriteLine("********  Karen Gabriela macuyama yañac   **********");




Console.WriteLine("****************************************************");
Console.WriteLine("************      GRUPO 4          *****************");
Console.WriteLine("********  Jonathan Vera Segura            **********");

Console.WriteLine("");


ServicioDAO opServicio = new ServicioDAO();



var ServicioRazaPrecio = opServicio.ServicioRazaPrecios();

foreach (var item in ServicioRazaPrecio)

{
    Console.WriteLine("");
    Console.WriteLine($"Nombre Servicio: {item.NombreServicio}, Descripcion Servicio: {item.DescripcionServicio}, " +
        $"Nombre Raza: {item.NombreRaza}, Descripcion Raza: {item.DescripcionRaza}, Especie: {item.Especie}, Precio: {item.PrecioPersonalizado}");
}










////*OBTENER TODOS LOS SERVICIOS*/////
//var servicios = opServicio.seleccionarTodo();
//foreach(var servicio in servicios)
//{
//    Console.WriteLine($"ID: {servicio.id_servicio}, Nombre: {servicio.nombre_servicio}, Descripcion: {servicio.descripcion}" +
//    $", Precio: {servicio.precio}");
//}


////*OBTENER UN SERVICIO*/////
//Console.WriteLine("Ingrese el ID del servicio que desea consultar:");
//int idServicio = Convert.ToInt32(Console.ReadLine());

//var servicioConsultado = opServicio.seleccionarServicio(idServicio);
//if (servicioConsultado != null)
//{
//    Console.WriteLine($"ID: {servicioConsultado.id_servicio}, Nombre: {servicioConsultado.nombre_servicio}, Descripcion: {servicioConsultado.descripcion}" +
//    $", Precio: {servicioConsultado.precio}");
//}
//else
//{
//    Console.WriteLine("No se encontró el servicio con el ID proporcionado.");
//}


////*INSERTAR SERVICIO*/////
//opServicio.insertarServicio("Cirugia Inmediata", "Riesgo de vida en absoluto.", 500.0f);
