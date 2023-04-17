public class Delito{
    public string provincia {get; set;}
    public string delito {get; set;}
    public string fecha {get; set;}
    public string judicializado {get; set;}
    public string victima {get; set;}


    public override string ToString()
    {
        return $"provincia:{provincia}, delito:{delito}, fecha:{fecha}, judicializado:{judicializado}, victima:{victima}";
    }

}