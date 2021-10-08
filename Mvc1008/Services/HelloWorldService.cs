public class HelloWorldService
{
    public string Name { get; set; } = "Will";

    public string SayHello()
    {
        return "Hello, " + Name;
    }
}