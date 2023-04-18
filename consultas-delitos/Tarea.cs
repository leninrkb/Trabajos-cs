using System.IO;

public class Tarea{
    public static List<Delito> LeerCSV(string path){
        StreamReader lector = new StreamReader(path);
        List<Delito> delitos = new List<Delito>();
        string[] datos;
        string linea;
        bool primera_linea = true;
        while (!lector.EndOfStream)
        {
            linea = lector.ReadLine();
            if (primera_linea){
                primera_linea = false;
                continue;
            }
            datos = linea.Split(',');
            Delito d = new Delito();
            d.provincia =  datos[0].ToLower();
            d.delito = datos[1].ToLower().Replace(". ","");
            d.fecha = datos[2].ToLower();
            d.judicializado = bool.Parse(datos[3]);
            d.victima = datos[4].ToLower();
            delitos.Add(d);
            // Console.WriteLine(d.ToString());
        }

        lector.Close();
        return delitos;
    }


    public static void ProvinciasMasDelitos(List<Delito> delitos, int top){
        var provincias = delitos.GroupBy(p => p.provincia)
        .Select(g => new{
            prov = g.Key,
            numero_delitos = g.Count()
        }).OrderByDescending(p => p.numero_delitos).Take(top);

        Console.WriteLine("pregunta 1 ---");
        foreach (var p in provincias)
        {
            Console.WriteLine($"- {p.prov}");
        }
        Console.WriteLine("fin pregunta 1 ---\n");
    }

    public static void ProvinciasNumeroDelitos(List<Delito> delitos){
        var provincias = delitos.GroupBy(p => p.provincia)
        .Select(g => new{
            prov = g.Key,
            numero_delitos = g.Count()
        }).OrderByDescending(p => p.numero_delitos);

        Console.WriteLine("pregunta 2 ---");
        foreach (var p in provincias)
        {
            Console.WriteLine($"- {p.prov} : {p.numero_delitos}");
        }
        Console.WriteLine("fin pregunta 2 ---\n");
    }

    public static void PorcentajesDelitosVictimas(List<Delito> delitos){
        int total_delitos = delitos.Count();
        var victimas = delitos.GroupBy(p => p.victima) 
        .Select(g => new{   
            victima = g.Key,    
            total_por_civtima = g.Count(),
            porcentaje = (g.Count()*100.0f ) / total_delitos
        }).OrderByDescending(p => p.porcentaje);         

        Console.WriteLine("pregunta 3 ---");            
        foreach (var d in victimas)      
        {
            Console.WriteLine($"- {d.victima} : {d.porcentaje}%");     
        }
        Console.WriteLine("fin pregunta 3 ---\n");  
    }

    public static void DelitosPorRegion(List<Delito> delitos){
        string[] sierra = {"pichincha","cotopaxi","tungurahua"}; 
        string[] oriente = {"napo","azuay"}; 

        var regiones = delitos.GroupBy(p => (
            sierra.Contains(p.provincia) ? "sierra" : 
            (oriente.Contains(p.provincia) ? "oriente" : "costa") ))
        .Select(g => new{
            region = g.Key,
            delitos_reg = g.Count()
        }).OrderByDescending(p => p.delitos_reg);

        Console.WriteLine("pregunta 4 ---");
        foreach (var p in regiones)
        {
            Console.WriteLine($"- {p.region} : {p.delitos_reg}");
        }
        Console.WriteLine("fin pregunta 4 ---\n");
    }   
}