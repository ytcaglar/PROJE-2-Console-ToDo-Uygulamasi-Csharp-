using System;

namespace ToDo
{
    public class Board
    {
        public List<Card> ToDo { get; set; }
        public List<Card> InProgress { get; set; }
        public List<Card> Done { get; set; }
    }
}