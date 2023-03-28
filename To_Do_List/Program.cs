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

        int option;
        do
        {
            option = Menu();
            switch (option)
            {
                case 1:
                    CreateTask(pathToDoList);
                    Console.Clear();
                    Console.WriteLine("Tarefa criada com sucesso!!!");
                    Thread.Sleep(3000);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Aplicativo fechado!\n");
                    Thread.Sleep(3000);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida! Por favor, escolha uma opção válida");
                    Thread.Sleep(3000);
                    break;
            }
        } while (option != 5);
    }

    private static void CreateTask(string path)
    {
        string description;
        string name;
        DateTime dueDate = DateTime.Now;

        do
        {
            Console.Clear();
            Console.Write("Informe a descrição da tarefa: ");
            description = Console.ReadLine();
            Console.Write("Quem é o responsável por essa tarefa: ");
            name = Console.ReadLine();
            Console.Write("Data para conclusão (dd/mm/yyyy): ");
            dueDate = DateTime.Parse(Console.ReadLine());
            if ((description is "") || (name is ""))
            {
                Console.Clear();
                Console.WriteLine("Por favor, preencha todos os campos");
                Thread.Sleep(3000);
            }
        } while ((description is "") || (name is ""));

        ToDo toDo = new ToDo(description, new Person(name), dueDate);

        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(toDo.ToFile());
        }
    }
}