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
            d.provincia = datos[0];
            d.delito = datos[1];
            d.fecha = datos[2];
            d.judicializado = datos[3];
            d.victima = datos[4];
            delitos.Add(d);
            // Console.WriteLine(d.ToString());
        }

        lector.Close();
        return delitos;
    }
}