public class Program{
    public static void Main(string[] args){
        List<Delito> delitos = Tarea.LeerCSV("./DelitosProvincia.csv");
        Console.WriteLine(delitos.Count());
    }
}
