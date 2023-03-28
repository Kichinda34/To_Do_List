using To_Do_List.Entities;

class Program
{
    private static int Menu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("|".PadRight(43) + "|");
        Console.WriteLine("|              MENU DE OPÇÕES".PadRight(43) + "|");
        Console.WriteLine("|".PadRight(43) + "|");
        Console.WriteLine("|   [1] - Criar nova tarefa".PadRight(43) + "|");
        Console.WriteLine("|   [2] - Editar tarefa".PadRight(43) + "|");
        Console.WriteLine("|   [3] - Excluir tarefa".PadRight(43) + "|");
        Console.WriteLine("|   [4] - Imprimir tarefas".PadRight(43) + "|");
        Console.WriteLine("|   [5] - Sair do aplicativo".PadRight(43) + "|");
        Console.WriteLine("|".PadRight(43) + "|");
        Console.WriteLine("--------------------------------------------\n");
        Console.Write("Escolha uma opção: ");
        int option = int.Parse(Console.ReadLine());
        return option;
    }

    private static void Main(string[] args)
    {
        string fileName = "To Do List.txt";
        string path = @"C:\Users\" + Environment.UserName + @"\";
        string pathToDoList = path + fileName;

        ToDo toDo = new ToDo("Teste", new Person("Vinicius"), DateTime.Now);

        int option;

        do
        {
            option = Menu();
        } while (option != 5);

        using (StreamWriter sw = File.AppendText(pathToDoList))
        {
            sw.WriteLine(toDo.ToFile());
        }
    }

    private static void CreateTask()
    {

    }
}