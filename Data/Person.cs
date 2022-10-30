using System;

namespace ToDo
{
    public class Person
    {
        public Person(int id, string name, string team)
        {
            this.Id=id;
            this.Name=name;
            this.Team=team;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
    }
}