using System.ComponentModel;

List<string> nombreProduc = new List<string>();
List<decimal> precioProduc = new List<decimal>();
List<int> stockProduc = new List<int>();
List<int> ventaUnidades = new List<int>();
int totalVentas = 0;
decimal totalDinero = 0;

int opt = 0;
//ZONA DE METODOS
static void ImprimirEncabezado(string titulo)
{
    Console.Clear();

    string linea = new string('=', titulo.Length + 8);

    Console.WriteLine(linea);
    Console.WriteLine($"   {titulo.ToUpper()}  ");
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
static decimal CalcularFactura(decimal precio, int cantidad, bool tieneDescuento, out decimal montoIva, out decimal montoDescuento)
{
    decimal subtotal = precio * cantidad;
    if (tieneDescuento)
    {
        montoDescuento = subtotal * 0.10m;
    }
    else
    {
        montoDescuento = 0;
    }
    montoIva = (subtotal - montoDescuento) * 0.19m;

    return subtotal - montoDescuento + montoIva;
}
//Aqui terminan los metodos.
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
            ImprimirEncabezado("INVENTARIO COMPLETO");
            if (nombreProduc.Count == 0)
            {
                Console.WriteLine("[!] No hay productos registrados");
                Console.ReadKey();
                break;
            }
            else
            {
                for (int i = 0; i < nombreProduc.Count; i++)
                {
                    Console.Write($"{i + 1}. {nombreProduc[i]} | Precio: {precioProduc[i]:C} | Stock: {stockProduc[i]} ");
                    if (stockProduc[i] < 5)
                    {
                        Console.Write("[ALERTA: BAJO STOCK]");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
            break;

        case 3:
            ImprimirEncabezado("REGISTRAR VENTA");
            if (nombreProduc.Count == 0)
            {
                Console.WriteLine("[!] No hay productos registrados");
                Console.ReadKey();
                break;
            }
            else
            {
                for (int i = 0; i < nombreProduc.Count; i++)
                {
                    Console.Write($"{i + 1}. {nombreProduc[i]} | Precio: {precioProduc[i]:C} | Stock: {stockProduc[i]} ");
                    if (stockProduc[i] < 5)
                    {
                        Console.Write("[ALERTA: BAJO STOCK]");
                    }
                    Console.WriteLine();
                }
            }
            int indice = LeerEntero($"Seleccione el numero/id del producto a vender (1-{nombreProduc.Count}): ", 1, nombreProduc.Count) - 1;
            if (stockProduc[indice] == 0) 
            {
                Console.WriteLine("[ERROR] Producto sin stock.");
                Console.ReadKey();
                break;
            }
            int cantidad = LeerEntero("Ingrese la cantidad a comprar: ", 1, int.MaxValue);
            while(cantidad > stockProduc[indice])
            {
                Console.WriteLine($"[ERROR] Stock insuficiente. Solo quedan {stockProduc[indice]} unidades en inventario.");
                cantidad = LeerEntero("Ingrese la cantidad a comprar: ", 1, int.MaxValue);
            }

            string respuesta;
            do
            {
                Console.Write("Aplica descuento de cliente frecuente (10%)? (S/N): ");
                respuesta = Console.ReadLine().ToUpper();

            } while (respuesta != "S" && respuesta != "N");

            bool tieneDescuento = respuesta == "S";

            decimal total = CalcularFactura(precioProduc[indice], cantidad, tieneDescuento, out decimal iva, out decimal descuento);
            stockProduc[indice] -= cantidad;
            ventaUnidades[indice] += cantidad;
            totalVentas++;
            totalDinero += total;

            ImprimirEncabezado("TICKET DE VENTA");
            Console.WriteLine($" Producto:          {nombreProduc[indice]} (x{cantidad})");
            Console.WriteLine($" Subtotal:          {precioProduc[indice]*cantidad:C}");
            Console.WriteLine($" Descuento (10%):         -{descuento:C}");
            Console.WriteLine($" IVA (19%)          +{iva:C}");
            Console.WriteLine($" --------------------------------------------------------------");
            Console.WriteLine($" TOTAL A PAGAR:            {total:C}");
            Console.WriteLine("=================================================================");
            Console.WriteLine($"[OK] Venta efectuada con exito. Stock actualizado: {stockProduc[indice]} unidades.");
            Console.ReadKey();
            break;
        case 4:
            ImprimirEncabezado("REPORTE DE CAJA");
            if (totalVentas == 0)
            {
                Console.WriteLine("[!] Aun no se han realizado ventas.");
                Console.ReadKey();
                break;
            }
            decimal promedio = totalDinero / totalVentas;

            int indiceMax = 0;
            for (int i = 1; i < ventaUnidades.Count; i++)
            {
                if (ventaUnidades[i] > ventaUnidades[indiceMax])
                {
                    indiceMax = i;
                }
            }
            Console.WriteLine($"Total de ventas realizadas:  {totalVentas}");
            Console.WriteLine($"Total ingresado a caja:      {totalDinero:C}");
            Console.WriteLine($"Promedio por venta:          {promedio:C}");
            Console.WriteLine($"Producto mas vendido:        {nombreProduc[indiceMax]} ({ventaUnidades[indiceMax]} unidades)");
            Console.ReadKey();
            break;

        case 5:
            Console.WriteLine("Gracias por usar el Mini-POS! Hasta pronto!");
            break;
    }
} while (opt != 5);