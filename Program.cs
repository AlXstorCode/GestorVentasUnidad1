string productos;
int opt = 0;
static int LeerEntero(string mensaje, int min, int max)
{
    int numero = 0;
    while (true)
    {
        Console.WriteLine(mensaje);
        string entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out numero))
        {
            Console.WriteLine("[ERROR] Entrada no valida. Debe ingresar un numero entero.");
            continue;
        }
        if (numero < min || numero > max)
        {
            Console.WriteLine($"[ERROR] El numero debe estar entre {min} y {max}");
            continue;
        }
        return numero;
    }
}

do
{
    Console.WriteLine("SISTEMA GESTOR DE VENTAS E INVESTARIO (MINI-POS)");
    Console.WriteLine("1. Registrar nuevo producto en inventario");
    Console.WriteLine("2. Consultar inventario completo");
    Console.WriteLine("3. Registrar una venta");
    Console.WriteLine("4. Ver reporte de caja y estadísticas diarias");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción (1-5): ");
  


} while (opt !=5);
