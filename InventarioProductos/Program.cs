using System.Collections;
using System.Diagnostics;


class Program
{
    static List<string> codigos = new List<string>();
    static List<string> nombres = new List<string>();
    static List<double> precios = new List<double>();
    static List<int> stock = new List<int>();

    static int capacidadMaxima = 100;
    static int contador
{
    get { return codigos.Count; }
}
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
            codigos.RemoveAt(posicionEncontrada);
            nombres.RemoveAt(posicionEncontrada);
            precios.RemoveAt(posicionEncontrada);
            stock.RemoveAt(posicionEncontrada);
        }
    }
static void OrdenarProducto()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay productos para ordenar.");
            return;
        }

        for (int i = 0; i < contador - 1; i++)
        {
            for (int j = 0; j < contador - 1 - i; j++)
            {
                if (precios[j] > precios[j + 1])
                {
                    double tempPrecio = precios[j];
                    precios[j] = precios[j + 1];
                    precios[j + 1] = tempPrecio;

                    string tempCodigo = codigos[j];
                    codigos[j] = codigos[j + 1];
                    codigos[j + 1] = tempCodigo;

                    string tempNombre = nombres[j];
                    nombres[j] = nombres[j + 1];
                    nombres[j + 1] = tempNombre;

                    int tempStock = stock[j];
                    stock[j] = stock[j + 1];
                    stock[j + 1] = tempStock;
                }
            }
        }
        Console.WriteLine("\nProductos ordenados por precio exitosamente.");
    }
static void MostrarResumen()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay productos registrados para generar un resumen.");
            return;
        }

        double sumaTotalPrecios = 0;
        int indiceMayor = 0;
        int indiceMenor = 0;

        for (int i = 0; i < contador; i++)
        {
            sumaTotalPrecios += precios[i];
            if (precios[i] > precios[indiceMayor]) indiceMayor = i;
            if (precios[i] < precios[indiceMenor]) indiceMenor = i;
        }

        Console.WriteLine("\n====== RESUMEN DE PRODUCTOS ======");
        Console.WriteLine($"Total de elementos registrados: {contador}");
        Console.WriteLine($"Suma total del campo numérico (Precios): S/ {sumaTotalPrecios}");
        Console.WriteLine($"Elemento con mayor valor: {nombres[indiceMayor]} (S/ {precios[indiceMayor]})");
        Console.WriteLine($"Elemento con menor valor: {nombres[indiceMenor]} (S/ {precios[indiceMenor]})");
        Console.WriteLine("==================================");
    }
    static void ModificarProducto()
    {
        Console.Write("Ingrese el código del producto a modificar: ");
        string codigoBuscado = Console.ReadLine();

        int posicion = -1;

        for (int i = 0; i < codigos.Count; i++)
        {
            if (codigos[i] == codigoBuscado)
            {
                posicion = i;
                break;
            }
        }

        if (posicion == -1)
        {
            Console.WriteLine("Producto no encontrado.");
            return;
        }

        Console.Write("Nuevo nombre: ");
        nombres[posicion] = Console.ReadLine();

        Console.Write("Nuevo precio: ");
        precios[posicion] = double.Parse(Console.ReadLine());

        Console.Write("Nuevo stock: ");
        stock[posicion] = int.Parse(Console.ReadLine());

        Console.WriteLine("Producto modificado correctamente.");
    }

    static void InsertarProducto()
    {
        Console.Write("Posición donde insertar: ");
        int posicion = int.Parse(Console.ReadLine());

        if (posicion < 0 || posicion > codigos.Count)
        {
            Console.WriteLine("Posición inválida.");
            return;
        }

        Console.Write("Código: ");
        string codigo = Console.ReadLine();

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Precio: ");
        double precio = double.Parse(Console.ReadLine());

        Console.Write("Stock: ");
        int cantidad = int.Parse(Console.ReadLine());

        codigos.Insert(posicion, codigo);
        nombres.Insert(posicion, nombre);
        precios.Insert(posicion, precio);
        stock.Insert(posicion, cantidad);

        Console.WriteLine("Producto insertado correctamente.");
    }
}