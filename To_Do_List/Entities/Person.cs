namespace To_Do_List.Entities
{
    class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Person(string name)
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8);
            Name = name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

