using To_Do_List.Entities;

class Program
{
    private static void Main(string[] args)
    {
        ToDo toDo = new ToDo("teste", new Person("Vinicius"), DateTime.Now);

        Console.WriteLine(toDo.ToString());
    }
}