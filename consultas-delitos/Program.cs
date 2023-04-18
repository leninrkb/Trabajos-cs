public class Program{
    public static void Main(string[] args){
        List<Delito> delitos = Tarea.LeerCSV("./DelitosProvincia.csv");
        Console.WriteLine(delitos.Count());
        Tarea.ProvinciasMasDelitos(delitos, 3);
        Tarea.ProvinciasNumeroDelitos(delitos);
        Tarea.PorcentajesDelitosVictimas(delitos);
        Tarea.DelitosPorRegion(delitos);
    }
}
