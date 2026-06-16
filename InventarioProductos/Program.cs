using System.Collections;
using System.Diagnostics;


class Program
{
    static List<string> codigos = new List<string>();
    static List<string> nombres = new List<string>();
    static List<double> precios = new List<double>();
    static List<int> stock = new List<int>();

    static int capacidadMaxima = 100;

    static void Main()
    {
        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("====== INVENTARIO DE PRODUCTOS ======");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Mostrar productos");
            Console.WriteLine("3. Buscar producto");
            Console.WriteLine("4. Modificar producto");
            Console.WriteLine("5. Insertar producto");
            Console.WriteLine("6. Eliminar producto");
            Console.WriteLine("7. Ordenar productos");
            Console.WriteLine("8. Resumen de productos");
            Console.WriteLine("9. Salir");
            Console.WriteLine("=====================================");

            Console.Write("\nSeleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarProducto();
                    break;

                case 2:
                    MostrarProductos();
                    break;

                case 3:
                    BuscarProducto();
                    break;

                case 4:
                    ModificarProducto();
                    break;

                case 5:
                    InsertarProducto();
                    break;

                case 6:
                    EliminarProducto();
                    break;

                case 7:
                    OrdenarProducto();
                    break;

                case 8:
                    MostrarResumen();
                    break;

                case 9:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

        } while (opcion != 9);
    }

    static void RegistrarProducto()
    {
        if (codigos.Count >= capacidadMaxima)
        {
            Console.WriteLine("Capacidad máxima alcanzada.");
            return;
        }

        string codigo;

        do
        {
            Console.Write("Código: ");
            codigo = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(codigo));

        string nombre;

        do
        {
            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(nombre));

        double precio;

        do
        {
            Console.Write("Precio: ");
            precio = double.Parse(Console.ReadLine());
        }
        while (precio < 0);

        int cantidad;

        do
        {
            Console.Write("Stock: ");
            cantidad = int.Parse(Console.ReadLine());
        }
        while (cantidad < 0);

        codigos.Add(codigo);
        nombres.Add(nombre);
        precios.Add(precio);
        stock.Add(cantidad);

        Console.WriteLine("\nProducto registrado correctamente.");
    }
}