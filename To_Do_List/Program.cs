using To_Do_List;

internal class Program
{
    private static void Main(string[] args)
    {
        Person person = new Person();
        Console.WriteLine("Qual o nome do Usuário? ");
        var name = Console.ReadLine();
        person.SetName(name);


    }
}