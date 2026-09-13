using System.ComponentModel;

List<string> nombreProduc = new List<string>();
List<decimal> precioProduc = new List<decimal>();
List<int> stockProduc = new List<int>();
List<int> ventaUnidades = new List<int>();
int totalVentas = 0;
decimal totalDine = 0;

int opt = 0;

static void ImprimirEncabezado(string titulo)
{
    Console.Clear();

    string linea = new string('=', titulo.Length + 4);

    Console.WriteLine(linea);
    Console.WriteLine($"  {titulo.ToUpper()}  ");
    Console.WriteLine(linea);
}
static decimal LeerDecimal(string mensaje, decimal min)
{
    decimal numero = 0;
    while (true)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine();

        if (!decimal.TryParse(entrada, out numero))
        {
            Console.WriteLine("[ERROR] Entrada no valida. Debe ingresar un valor numerico.");
            continue;
        }
        if (numero < min)
        {
            Console.WriteLine($"[ERROR] Valor fuera de rango. Ingrese un valor mayor o igual a {min}");
            continue;
        }
        return numero;
    }
}

static int LeerEntero(string mensaje, int min, int max)
{
    int numero = 0;
    while (true)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out numero))
        {
            Console.WriteLine("[ERROR] Entrada no valida. Debe ingresar un numero entero.");
            continue;
        }
        if (numero < min || numero > max)
        {
            Console.WriteLine($"[ERROR] Opción fuera de rango. Ingrese un valor entre {min} y {max}");
            continue;
        }
        return numero;
    }
}

do
{
    ImprimirEncabezado("SISTEMA GESTOR DE VENTAS E INVENTARIO (MINI-POS)");
    Console.WriteLine("1. Registrar nuevo producto en inventario");
    Console.WriteLine("2. Consultar inventario completo");
    Console.WriteLine("3. Registrar una venta");
    Console.WriteLine("4. Ver reporte de caja y estadísticas diarias");
    Console.WriteLine("5. Salir");
    opt = LeerEntero("Seleccione una opción (1-5): ", 1, 5);

    switch (opt)
    {
        case 1:
            // 1. Mostrar encabezado "REGISTRAR PRODUCTO"
            ImprimirEncabezado("REGISTRAR PRODUCTO");
            // 2. Pedir el nombre
            Console.Write("Ingrese Nombre del Producto: ");
            string nProducto = Console.ReadLine();
            // 3. Si está vacío → mensaje de error + pausa + break
            if (string.IsNullOrWhiteSpace(nProducto))
            {
                Console.WriteLine("[ERROR] El nombre del producto no puede estar vacío.");
                Console.ReadKey();
                break;
            }
            // b. Si ya existe (sin importar mayúsculas) → error + pausa + break
            bool existe = false;
            foreach (string producto in nombreProduc)
            {
                if (producto.ToLower() == nProducto.ToLower())
                {
                    existe = true;
                }
            }
            if (existe)
            {
                Console.WriteLine($"[ERROR] El Producto {nProducto} ya se encuentra registrado.");
                Console.ReadKey();
                break;
            }

            // 4. Pedir el precio (LeerDecimal)
            decimal pProducto = LeerDecimal("Ingrese Precio del producto [$]: ", 0.01m);
            // 5. Pedir el stock (LeerEntero)
            int stProducto = LeerEntero("Ingrese Stock inicial del producto: ", 0, int.MaxValue);
            // 6. Agregar a las 4 listas
            nombreProduc.Add(nProducto);
            precioProduc.Add(pProducto);
            stockProduc.Add(stProducto);
            ventaUnidades.Add(0);
            // 7. Mensaje de éxito + pausa
            Console.WriteLine($"[EXITO] El Producto {nProducto} con valor {pProducto:C} y stock inicial de {stProducto} fue agregado con éxito! ");
            Console.ReadKey();
            break;

        case 2:
            break;

        case 3:
            break;

        case 4:
            break;

        case 5:
            break;
    }
} while (opt != 5);