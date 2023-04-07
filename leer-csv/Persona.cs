public class Persona
{
    public String id {get; set;}
    public String nombre {get; set;}
    public String apellido {get; set;}
    public String ciudad {get; set;}
    public String genero {get; set;}
    public int ingresos {get; set;}
    public int egresos {get; set;}

    public override String ToString()
    {
        return $"id:{id}, nombre:{nombre}, apellido:{apellido},"
        + $" ciudad:{ciudad}, genero:{genero}, ingresos:{ingresos}, egresos:{egresos}";
    }
}