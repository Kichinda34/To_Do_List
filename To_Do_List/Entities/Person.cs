namespace To_Do_List.Entities
{
    class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Person(string name)
        {
            Id = this.Id;
            Name = name;
        }

        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Person SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

