using Microsoft.AspNetCore.Mvc;

public class HomeController
{
    public string Index()
    {
        return "Hello, world!";
    }

    public string Greet(string name)
    {
        return $"Hello, {name}!";
    }
}
