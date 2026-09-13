# GestorVentasUnidad1

**Nombre del estudiante:** Owhen Geovanny Padilla Polanco

## Descripción

Programa de consola en C# que ayuda a gestionar las ventas de un negocio. Tiene funciones para agregar productos al inventario, ver los productos registrados, registrar ventas (con IVA del 19% y descuento de cliente frecuente) y consultar un reporte de caja con las estadísticas del día.

Todo se maneja en memoria usando listas, así que al cerrar el programa la información se borra.

## Cómo ejecutarlo

Necesitas tener instalado el SDK de .NET.

1. Clona el repositorio:
   ```
   git clone https://github.com/AlXstorCode/GestorVentasUnidad1.git
   ```
2. Entra a la carpeta del proyecto:
   ```
   cd GestorVentasUnidad1
   ```
3. Ejecuta el programa:
   ```
   dotnet run
   ```

> **Nota:** para los precios con decimales usa punto, por ejemplo `18000.50`.

## Ejemplos

### Menú principal

```
========================================================
  SISTEMA GESTOR DE VENTAS E INVENTARIO (MINI-POS)
========================================================

1. Registrar nuevo producto en inventario
2. Consultar inventario completo
3. Registrar una venta
4. Ver reporte de caja y estadísticas diarias
5. Salir
Seleccione una opción (1-5): abc
[ERROR] Entrada no valida. Debe ingresar un numero entero.
Seleccione una opción (1-5): 9
[ERROR] Opción fuera de rango. Ingrese un valor entre 1 y 5
```

### Consultar inventario

```
1. Café Colombiano 500g | Precio: $18,000.00 | Stock: 10
2. Pan Tajado Integral | Precio: $6,500.00 | Stock: 3 [ALERTA: BAJO STOCK]
```

### Registrar una venta

```
Seleccione el numero/id del producto a vender (1-2): 1
Ingrese la cantidad a comprar: 15
[ERROR] Stock insuficiente. Solo quedan 10 unidades en inventario.
Ingrese la cantidad a comprar: 2
Aplica descuento de cliente frecuente (10%)? (S/N): S

 Producto:          Café Colombiano 500g (x2)
 Subtotal:          $36,000.00
 Descuento (10%):   -$3,600.00
 IVA (19%)          +$6,156.00
 ------------------------------------------
 TOTAL A PAGAR:     $38,556.00
[OK] Venta efectuada con exito. Stock actualizado: 8 unidades.
```

### Reporte de caja

```
Total de ventas realizadas:  1
Total ingresado a caja:      $38,556.00
Promedio por venta:          $38,556.00
Producto mas vendido:        Café Colombiano 500g (2 unidades)
```
