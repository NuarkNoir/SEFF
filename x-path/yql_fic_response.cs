public class H1
{
    public string content { get; set; }
}

public class Results
{
    public H1 h1 { get; set; }
}

public class Query
{
    public int count { get; set; }
    public Results results { get; set; }
}

public class RootObject
{
    public Query query { get; set; }
}
