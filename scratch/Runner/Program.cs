using System;
using DAL;

class Program
{
    static void Main()
    {
        DALIdioma dal = new DALIdioma();
        var dict = dal.ObtenerTraducciones();
        Console.WriteLine($"Traducciones cargadas con éxito: {dict.Count} elementos.");
        Console.WriteLine($"Prueba 'Bitácora de Cambios': {dict["Bitácora de Cambios"]}");
        Console.WriteLine($"Prueba 'Stock Venta': {dict["Stock Venta"]}");
    }
}
