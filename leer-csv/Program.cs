using System.IO;
public class Program
{
    public static void Main(String[] args)
    {
        List<Persona> lista = Herramientas.LeerCSV("./IngresosEgresos.csv");
        Herramientas.AvgDescendienteIngresosCiudades(lista);
        Herramientas.AvgIngresosGenero(lista);
        Herramientas.AvgUtilidadesCiudad(lista);
        Herramientas.AvgIngresosPorRegion(lista);
    }
}
