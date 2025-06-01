

// See https://aka.ms/new-console-template for more information

using AccesoDatos.Models;
using AccesoDatos.Operations;

//Console.WriteLine("Hello, World!");



//Console.WriteLine("********  Erick Navarro Vega              **********");
//Console.WriteLine("********  jordan emmanuel nieves vargas           **********");
//Console.WriteLine("********  Johan Alejandro Piscoya Morillo **********");
//Console.WriteLine("********  Karen Gabriela macuyama yañac   **********");




//Console.WriteLine("****************************************************");
//Console.WriteLine("************      GRUPO 4          *****************");
//Console.WriteLine("********  Jonathan Vera Segura            **********");

//Console.WriteLine("");


//ServicioDAO opServicio = new ServicioDAO();



//var ServicioRazaPrecio = opServicio.ServicioRazaPrecios();

//foreach (var item in ServicioRazaPrecio)

//{
//    Console.WriteLine("");
//    Console.WriteLine($"Nombre Servicio: {item.NombreServicio}, Descripcion Servicio: {item.DescripcionServicio}, " +
//        $"Nombre Raza: {item.NombreRaza}, Descripcion Raza: {item.DescripcionRaza}, Especie: {item.Especie}, Precio: {item.PrecioPersonalizado}");
//}
ProductoDAO opProducto = new ProductoDAO();

//var product = opProducto.seleccionarTodo();

//Console.WriteLine("Lista de productos:\n");
//foreach (var producto in product)
//{
//    Console.WriteLine($"ID: {producto.id_producto}, Nombre: {producto.nombre_producto}, CategoriaID: {producto.id_categoria}, Precio: {producto.precio_unitario}");
//}



//Console.Write("Ingrese el ID del producto a buscar: ");
//if (int.TryParse(Console.ReadLine(), out int idProducto))
//{
//    var producto = opProducto.seleccionarProducto(idProducto);
//    if (producto != null)
//    {
//        Console.WriteLine($"ID: {producto.id_producto}");
//        Console.WriteLine($"Nombre: {producto.nombre_producto}");
//        Console.WriteLine($"CategoriaID: {producto.id_categoria}");
//        Console.WriteLine($"Descripcion: {producto.descripcion}");
//        Console.WriteLine($"Precio unitario: {producto.precio_unitario}");
//        Console.WriteLine($"Cantidad en stock: {producto.cantidad_en_stock}");
//        Console.WriteLine($"Fecha última actualización: {producto.fecha_ultima_actualizacion}");
//    }
//    else
//    {
//        Console.WriteLine("Producto no encontrado.");
//    }
//}
//else
//{
//    Console.WriteLine("ID inválido.");
//}

Console.WriteLine("****************************************************");
Console.WriteLine("************      GRUPO 4          *****************");
Console.WriteLine("********  Erick Navarro Vega            **********");

Console.WriteLine("");



//bool insert1 = opProducto.insertarProducto("Antipulgas Canino", 1, "Elimina pulgas y garrapatas", 25.50m, 50);
//bool insert2 = opProducto.insertarProducto("Croquetas Gato Adulto", 2, "Bolsa de alimento balanceado", 18.00m, 80);
//bool insert3 = opProducto.insertarProducto("Collar Reflectante", 3, "Collar para perro con tira reflectante", 12.90m, 30);

//if (insert1 && insert2 && insert3)
//{
//    Console.WriteLine("Productos insertados correctamente.");
//}
//else
//{
//    Console.WriteLine("Error al insertar uno o más productos.");
//}

//Console.Write("Ingresa el ID del producto a eliminar: ");
//if (int.TryParse(Console.ReadLine(), out int idProducto))
//{
//    bool eliminado = opProducto.eliminarProducto(idProducto);

//    if (eliminado)
//    {
//        Console.WriteLine("Producto eliminado correctamente.");
//    }
//    else
//    {
//        Console.WriteLine("No se pudo eliminar el producto (no existe o error).");
//    }
//}
//else
//{
//    Console.WriteLine("ID inválido.");
//}


var prodCat = opProducto.seleccionarProductosConCategoria();

Console.WriteLine("\n--- Categoria con su Producto ---\n");
foreach (ProductoCategoria pc in prodCat)
{
    Console.WriteLine(pc.NombreCategoria + " -> " + pc.NombreProducto);
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
