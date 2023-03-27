using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    internal class ToDo
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public Person Owner { get; set; }

        public DateTime Created { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; }
        public Guid Guid { get; }
        public string Descricao { get; }
        public string Categoria { get; }

        public ToDo(string d, string c, Person owner, DateTime duedate, string status = "Pendente")
        {
            Id = Guid.NewGuid();
            Description = d;
            Category = c;
            Owner = owner;
            Created = DateTime.Today;
            DueDate = duedate;
            Status = status;
        }

        public ToDo(Guid guid, string descricao, string categoria, Person owner, DateTime created, DateTime duedate, string status)
        {
            Guid = guid;
            Descricao = descricao;
            Categoria = categoria;
            Owner = owner;
            Created = created;
            DueDate = duedate;
            Status = status;
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

                var task = new ToDo(description, category, owner, DateTime.Parse(duedate));

                List<string> p = new List<string>();

                Console.WriteLine("Tarefa incluída.");
                Console.WriteLine("------------------");
                Console.WriteLine("Deseja criar uma nova tarefa? (S/N)");
                c = char.Parse(Console.ReadLine());

                listaTarefas.Add(task);

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

        //Quando chamado muda o status da Tarefa de acordo com o prazo informado.
        public void SetStatuS(ToDo tarefa)
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

                listaTarefas.Add(new ToDo(Guid.Parse(id.ToString()), descricao, categoria, owner, created, duedate, status));
            } while (!arquivoDeTarefas.EndOfStream);
            arquivoDeTarefas.Close();

            return arquivoDeTarefas;
        }
    }
}
