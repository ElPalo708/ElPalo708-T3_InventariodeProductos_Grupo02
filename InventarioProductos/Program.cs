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

    static void MostrarProductos()
{
    if (codigos.Count == 0)
    {
        Console.WriteLine("No hay productos registrados.");
        return;
    }

    Console.WriteLine("\n=== LISTA DE PRODUCTOS ===");

    for (int i = 0; i < codigos.Count; i++)
    {
        Console.WriteLine($"Producto #{i + 1}");
        Console.WriteLine($"Código: {codigos[i]}");
        Console.WriteLine($"Nombre: {nombres[i]}");
        Console.WriteLine($"Precio: S/ {precios[i]}");
        Console.WriteLine($"Stock: {stock[i]}");
        Console.WriteLine("-------------------------");
    } 
}

    static void BuscarProducto()
{
    Console.Write("Ingrese el código a buscar: ");
    string codigoBuscar = Console.ReadLine();

    bool encontrado = false;

    for (int i = 0; i < codigos.Count; i++)
    {
        if (codigos[i] == codigoBuscar)
        {
            Console.WriteLine("\n=== PRODUCTO ENCONTRADO ===");
            Console.WriteLine($"Código: {codigos[i]}");
            Console.WriteLine($"Nombre: {nombres[i]}");
            Console.WriteLine($"Precio: S/ {precios[i]}");
            Console.WriteLine($"Stock: {stock[i]}");

            encontrado = true;
            break;
        }
    }

    if (!encontrado)
    {
        Console.WriteLine("Producto no encontrado.");
    }
}

}
static void EliminarProducto()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay productos registrados para eliminar.");
            return;
        }

        Console.Write("Ingrese el código del producto a eliminar: ");
        string codigoBuscar = Console.ReadLine();
        int posicionEncontrada = -1;

        for (int i = 0; i < contador; i++)
        {
            if (codigos[i] == codigoBuscar)
            {
                posicionEncontrada = i;
                break;
            }
        }

        if (posicionEncontrada == -1)
        {
            Console.WriteLine("Producto no encontrado.");
        }
        else
        {
            for (int i = posicionEncontrada; i < contador - 1; i++)
            {
                codigos[i] = codigos[i + 1];
                nombres[i] = nombres[i + 1];
                precios[i] = precios[i + 1];
                stock[i] = stock[i + 1];
            }
            contador--;
            Console.WriteLine("\nProducto eliminado correctamente.");
        }
    }
