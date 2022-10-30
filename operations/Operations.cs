namespace ToDo
{
    public class Operations
    {
        List<Card> _list = Database.Board;
        List<Person> _personList = Database.PersonList;
      
       
        public void addCard()
        {
            Console.Clear();
            List<Person> personList = Database.PersonList;
            EnterTitle:
                Console.Clear();
                System.Console.Write("Başlık Giriniz                                  : ");
                string title = Console.ReadLine();
                if(title ==""){
                    System.Console.WriteLine("Başlık kısmını boş bırakmazsınız. Lütfen tekrar geçerli bir başlık giriniz.");
                    Thread.Sleep(1500);
                    goto EnterTitle;
                }
            EnterContent:
                Console.Clear();
                System.Console.Write("İçerik Giriniz                                  : ");
                string content = Console.ReadLine();
                if(content ==""){
                    System.Console.WriteLine("İçerik kısmını boş bırakmazsınız. Lütfen tekrar geçerli bir içerik giriniz.");
                    Thread.Sleep(1500);
                    goto EnterContent;
                }
            string size = "XS";
            choseSize:
            Console.Clear();
            System.Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  : ");
            if(int.TryParse(Console.ReadLine(), out int sizeValue)==true && sizeValue<=5 && 1<=sizeValue)
            {
                size = Enum.GetName(typeof(sizes), sizeValue);
            }
            else
            {
                System.Console.WriteLine("Hatalı giriş yaptınız. Lütfen tekrar geçerli bir giriş yapınız...");
                Thread.Sleep(1500);
                goto choseSize;
            }
            chosePerson:
            string personName = personChose();
            if(personName==""){
                againPerson:
                System.Console.WriteLine("Atama yapılacak kişiyi seçmediniz!");
                System.Console.WriteLine("(1) Tekrar Seç");
                System.Console.WriteLine("(2) Ana Menüye");
                System.Console.Write("Seçiminiz Nedir: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        goto chosePerson;
                        break;
                    case "2":
                        goto End;
                        break;
                    default:
                        System.Console.WriteLine("Hatalı seçim yaptınız. Tekrar deneyiniz...");
                        goto againPerson;
                        break;
                }
            }
            string line = lineChoese();
            Card card = new Card(title,content,personName,size,line);
            _list.Add(card);
            End:
                End();

        }
        public void deleteCard()
        {
            Console.Clear();
            
            writeTitle:
            Console.Clear();
            System.Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            System.Console.Write("Lütfen kart başlığını yazınız: ");
            string chose = Console.ReadLine();
            Card card =  _list.FirstOrDefault(x => x.Title.ToLower() == chose.ToLower());
            if(card != null){
                againDelete:
                Console.Clear();
                System.Console.WriteLine("Silincek kart: ");
                cardShow(card);
                System.Console.Write("Kart Silinmek Üzere Onaylıyor musunuz? (y/n): ");
                string yesorno = Console.ReadLine();
                if(yesorno.ToLower() == "y"){System.Console.WriteLine("Kart silindi."); Thread.Sleep(1500); _list.Remove(card);}else if(yesorno.ToLower() == "n"){goto End;}else{System.Console.WriteLine("Hatalı giriş yaptınız. Tekrar deneyiniz."); goto againDelete;}
            }else{
                choseEnd:
                Console.Clear();
                System.Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı.");
                System.Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                System.Console.WriteLine("* Yeniden denemek için : (2)");
                System.Console.Write("Lütfen bir seçim yapınız: ");
                string chose2 = Console.ReadLine();

                if(chose2 == "1"){
                    goto End;
                }else if(chose2 == "2"){
                    goto writeTitle;
                }else{
                    System.Console.WriteLine("Hatalı seçim yaptınız. Lütfen tekrar deneyiniz.");
                    Thread.Sleep(1500);
                    goto choseEnd;
                }
            }
            End:
                End();

        }
        public void printstepbystep(){
            Console.Clear();
            
            string[] boardType = {"TODO","IN PROGRESS","DONE"};
            
            for (int i = 0; i < boardType.Length; i++)
            {                                            
                System.Console.WriteLine(boardType[i]+" LINE");
                System.Console.WriteLine("************************");
                int sayi = 0;
                foreach (var item in _list)
                {
                    
                    if(item.Line == boardType[i])
                    {
                        sayi++;
                        cardShow(item);
                        System.Console.WriteLine("-");
                    }
                }
            }
            Console.Write("Tekrar menüye dönmek için Enter'a basınız.");
            Console.ReadLine();
        }
        public void updateCard(){
            writeTitle:
            Console.Clear();
            Card _cardwithtitle =  this.cardChoseWithTitle();
            System.Console.WriteLine("Öncelikle değiştirmek istediğiniz kartı seçmeniz gerekiyor.");
            if(_cardwithtitle != null){
                againUpd:
                Console.Clear();
                System.Console.WriteLine("Değiştirilecek kart: ");
                cardShow(_cardwithtitle);
                System.Console.WriteLine("-----------------------------------");
                System.Console.WriteLine("Hangi Bilgisini Değiştirilecek:");
                System.Console.WriteLine("(1) Başlık");
                System.Console.WriteLine("(2) Atanan Kişi");
                System.Console.WriteLine("(3) İçerik");
                System.Console.WriteLine("(4) Büyüklük");
                System.Console.WriteLine("(0) Menüye Dönmek");
                System.Console.Write("Kartın Hangi Bilgisini Değiştirecekseniz Seçiniz: ");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        System.Console.Write("Lütfen kartın başlığını giriniz: ");
                        _cardwithtitle.Title = Console.ReadLine();
                        break;
                    case "2":
                        chosePerson:
                            string personName = personChose();
                            if(personName==""){
                                againPerson:
                                System.Console.WriteLine("Atama yapılacak kişiyi seçmediniz!");
                                System.Console.WriteLine("(1) Tekrar Seç");
                                System.Console.WriteLine("(2) Ana Menüye");
                                System.Console.Write("Seçiminiz Nedir: ");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        goto chosePerson;
                                        break;
                                    case "2":
                                        goto End;
                                        break;
                                    default:
                                        System.Console.WriteLine("Hatalı seçim yaptınız. Tekrar deneyiniz...");
                                        goto againPerson;
                                        break;
                                }
                            }
                            else
                            {
                            _cardwithtitle.AppointedPerson = personName;
                            }
                        break;
                    case "3":
                        System.Console.Write("Lütfen kartın içeriğini giriniz: ");
                        _cardwithtitle.Content = Console.ReadLine();
                        break;
                    case "4":
                        string size = "XS";
                        choseSize:
                        Console.Clear();
                        System.Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  : ");
                        if(int.TryParse(Console.ReadLine(), out int sizeValue)==true && sizeValue<=5 && 1<=sizeValue)
                        {
                            size = Enum.GetName(typeof(sizes), sizeValue);
                            _cardwithtitle.Size = size;
                        }
                        else
                        {
                            System.Console.WriteLine("Hatalı giriş yaptınız. Lütfen tekrar geçerli bir giriş yapınız...");
                            Thread.Sleep(1500);
                            goto choseSize;
                        }
                        break;
                    case "0":
                        goto End;
                        break;
                    
                    default:
                        End();
                        goto againUpd;
                }


            }else{
                choseEnd:
                Console.Clear();
                System.Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı.");
                System.Console.WriteLine("* Değiştirmeyi sonlandırmak için : (1)");
                System.Console.WriteLine("* Yeniden denemek için : (2)");
                System.Console.Write("Lütfen bir seçim yapınız: ");
                string chose2 = Console.ReadLine();

                if(chose2 == "1"){
                    goto End;
                }else if(chose2 == "2"){
                    goto writeTitle;
                }else{
                    System.Console.WriteLine("Hatalı seçim yaptınız. Lütfen tekrar deneyiniz.");
                    Thread.Sleep(1500);
                    goto choseEnd;
                }
            }
            End:
                End();
        }

        public void End(){
            Thread.Sleep(1500);
                System.Console.WriteLine("Menüye yönlendiriliyorsunuz.");
        }
        public void MoveCard(){
            writeTitle:
            Console.Clear();
            System.Console.WriteLine("Öncelikle line'nını değiştirmek istediğiniz kartı seçmeniz gerekiyor.");
            System.Console.Write("Lütfen kart başlığını yazınız: ");
            string chose = Console.ReadLine();
            Card card =  _list.FirstOrDefault(x => x.Title.ToLower() == chose.ToLower());
            if(card != null){
                
                Console.Clear();
                System.Console.WriteLine("Değiştirilecek kart: ");
                cardShow(card);
                System.Console.WriteLine("Line: "+card.Line);

                card.Line = lineChoese();
            }else{
                choseEnd:
                Console.Clear();
                System.Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı.");
                System.Console.WriteLine("* Değiştirmeyi sonlandırmak için : (1)");
                System.Console.WriteLine("* Yeniden denemek için : (2)");
                System.Console.Write("Lütfen bir seçim yapınız: ");
                string chose2 = Console.ReadLine();

                if(chose2 == "1"){
                    goto End;
                }else if(chose2 == "2"){
                    goto writeTitle;
                }else{
                    System.Console.WriteLine("Hatalı seçim yaptınız. Lütfen tekrar deneyiniz.");
                    Thread.Sleep(1500);
                    goto choseEnd;
                }
            }
            End:
                System.Console.WriteLine("Menüye yönlendiriliyorsunuz.");
                Thread.Sleep(1500);
        }
        public void cardShow(Card card){
            System.Console.WriteLine("Başlık      : {0}",card.Title);
            System.Console.WriteLine("İçerik      : {0}",card.Content);
            System.Console.WriteLine("Atanan Kişi : {0}",card.AppointedPerson);
            System.Console.WriteLine("Büyüklük    : {0}",card.Size);
        }
        public string personChose(){
            personChose:
            Console.Clear();
            System.Console.Write("Şeçeceğiniz Kişinin ID numarasını giriniz       : ");
            int.TryParse(Console.ReadLine(), out int personID);
            Person person = _personList.FirstOrDefault(x => x.Id == personID);
            
                if(person != null){
                    personInf:
                    Console.Clear();
                    System.Console.WriteLine("Seçilen Kişinin Bilgileri:");
                    System.Console.WriteLine("*****************************");
                    System.Console.WriteLine("Kişinin ID No: {0}",person.Id);
                    System.Console.WriteLine("Kişinin Adı: {0}",person.Name);
                    System.Console.WriteLine("Kişinin Takımı: {0}",person.Team);
                    System.Console.Write("Seçtiğiniz kişi doğru mu?(y/n): ");
                    string secim;
                    if((secim =Console.ReadLine()).ToLower()=="y"){
                        return person.Name;
                    }else if(secim.ToLower()=="n"){
                        return "";
                    }else{
                        System.Console.WriteLine("Hatalı giriş yaptınız. Lütfen tekrar deneyiniz.");
                        goto personInf;
                    }
                }else{
                    System.Console.WriteLine("Seçiminiz Hatalı Lütfen Tekrar Deneyiniz..");
                    Thread.Sleep(1500);
                    goto personChose;
                }
        }
        public string lineChoese(){
            string[] boardType = {"TODO","IN PROGRESS","DONE"};
            System.Console.WriteLine("Hangi line'a eklemek istersiniz:");
            int i = 0;
            foreach (var item in boardType)
            {
                System.Console.WriteLine("({0}) {1}",i+1,item);
                i++;
            }
            LineSec:
                System.Console.Write("Line Seçiniz                                    : ");
                int.TryParse(Console.ReadLine(),out int value);
                
                if(value==1||value==2||value==3)
                {
                    value--;
                    return boardType[value];
                    
                }else{
                    System.Console.WriteLine("Hatalı giriş yaptınız... Tekrar deneyiniz.");
                    Thread.Sleep(1500);
                    goto LineSec;
                }
        }
        public Card cardChoseWithTitle(){
            System.Console.Write("Lütfen kart başlığını yazınız: ");
            string chose = Console.ReadLine();
            return _list.FirstOrDefault(x => x.Title.ToLower() == chose.ToLower());
        }
    }
}