using System;

namespace ToDo
{
    public class Card
    {
        public Card(string title, string content, string appointedPerson, string size, string line )
        {
            this.Title = title;
            this.Content = content;
            this.AppointedPerson = appointedPerson;
            this.Size = size;
            this.Line = line;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AppointedPerson{ get; set; }
        public string Size{ get; set; }
        public string Line{ get; set; }
    }
}