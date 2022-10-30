namespace ToDo
{ 
    
    public static class Database
    {  
        private static List<Card> _board;
        private static List<Person> _personList;
        static Database()
        {
            _board = new List<Card>
            {
                new Card("Toplantı","Salı Gunu Toplantı Duzenlenecek","Ahmet", "M", "TODO"),
                new Card("Odev","Proje Odevi Yapılacak","Samet", "S", "TODO"),
                new Card("Arşiv","Arşiv Düzenlenecek","Mehmet", "XL", "IN PROGRESS"),
                new Card("Fatura","Faturaların Ödemesi Yapılacak","Ahmet", "L", "DONE"),
            };

            _personList = new List<Person>
            {
                new Person(1,"Tolunay","A"),
                new Person(2,"Ahmet","A"),
                new Person(3,"Ali","B"),
                new Person(4,"Cemal","C"),
                new Person(5,"Hakan","A")
            };


        }
        public static List<Card> Board => _board;
        public static List<Person> PersonList => _personList;
    }
    enum sizes{
        XS=1,S,M,L,XL
    }
}