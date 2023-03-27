using To_Do_List.Entities.Enums;

namespace To_Do_List.Entities
{
    class ToDo
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public Person Owner { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool Status { get; private set; }

        public ToDo(string description, Person person, DateTime created)
        {
            Id = Guid.NewGuid();
            Description = description;
            Owner = person;
            Created = created;
        }

        //Realiza o cadastro das informações que precisam ser coletadas do usuário sobre as Tarefas.
        public List<ToDo> CadastrarTarefa(Person owner)
        {
            char c;
            List<ToDo> listaTarefas = new List<ToDo>();
            do
            {
                Console.WriteLine("Informe a descrição da Tarefa: ");
                string description = (Console.ReadLine());

                Console.WriteLine("Informe a categoria da Tarefa: ");
                string category = Console.ReadLine();

                Console.WriteLine("Informe a Data Limite da Tarefa: ");
                string duedate = Console.ReadLine();

                //var task = new ToDo(description, category, owner, DateTime.Parse(duedate));

                List<string> p = new List<string>();

                Console.WriteLine("Tarefa incluída.");
                Console.WriteLine("------------------");
                Console.WriteLine("Deseja criar uma nova tarefa? (S/N)");
                c = char.Parse(Console.ReadLine());

                //listaTarefas.Add(task);

            } while (c != 'n');
            return listaTarefas;
        }

        //Salva a lista de tarefas dentro de um arquivo.
        public string ToFile(List<ToDo> listaTarefas)
        {
            string arquivo = @"Lista de Tarefas.csv";
            StreamWriter arquivoDeTarefas = new StreamWriter(arquivo);
            for (int i = 0; i < listaTarefas.Count; i++)
            {
                arquivoDeTarefas.WriteLine(listaTarefas[i].ToString());
            }
            arquivoDeTarefas.Close();
            return arquivo;
        }
        /*
        //Quando chamado muda o status da Tarefa de acordo com o prazo informado.
        public void SetStatus(ToDo tarefa)
        {
            if (tarefa.DueDate < DateTime.Now)
            {
                tarefa.Status = "Prazo Expirado";
            }
            if (tarefa.Status == "Pendente")
            {
                tarefa.Status = "Concluído";
            }
        }
        */
        //Carrega o arquivo para que depois seja possível fazer a impressão para o usuário.
        public StreamReader LoadFile(string arquivo = @"Lista de Tarefas.csv")
        {
            StreamReader arquivoDeTarefas = new StreamReader(arquivo);
            List<ToDo> listaTarefas = new List<ToDo>();
            int i = 0;

            do
            {
                string[] campos = arquivoDeTarefas.ReadLine().Split(";");
                int id = i++;
                string descricao = campos[1];
                string categoria = campos[2];
                Person owner = new Person(campos[3]);
                DateTime created = DateTime.Parse(campos[4]);
                DateTime duedate = DateTime.Parse(campos[5]);
                string status = campos[6];

                //listaTarefas.Add(new ToDo(Guid.Parse(id.ToString()), descricao, categoria, owner, created, duedate, status));
            } while (!arquivoDeTarefas.EndOfStream);
            arquivoDeTarefas.Close();

            return arquivoDeTarefas;
        }

        public void SetPerson(Person person)
        {

        }

        public override string ToString()
        {
            return Id + " | " + Description + " | " + Owner + " | " + Created.ToString("dd/MM/yyyy");
        }
    }
}
