using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo;

namespace ToDo
{
    public static class UI
    {
        public static void UI_Menu(){
            Operations islem = new Operations();
            chooseMenu:
            Console.Clear();
            System.Console.WriteLine(
            "******* ToDo Uygulaması - Menu *******"+
            "\n1 - Kart Ekle"+
            "\n2 - Kart Güncelle"+
            "\n3 - Kart Sil"+
            "\n4 - Kart Taşı"+
            "\n5 - Board Listeleme"+
            "\n0 - Uygulamadan Çık");
            Console.Write("Seçiminizi giriniz: ");
            string secim = Console.ReadLine();
            switch (secim)
            {   
                case "0":
                    System.Console.WriteLine("ToDo Uygulamasından Çıkışınız Yapılıyor.");
                    break;
                case "1":
                    islem.addCard();
                    goto chooseMenu;
                case "2":
                    islem.updateCard();
                    goto chooseMenu;
                case "3":
                    islem.deleteCard();
                    goto chooseMenu;
                case "4":
                    islem.MoveCard();
                    goto chooseMenu;
                case "5":
                    islem.printstepbystep();
                    goto chooseMenu;
                default:
                    System.Console.WriteLine("Hatalı giriş yaptınız. Tekrar deneyiniz..");
                    Thread.Sleep(1500);
                    goto chooseMenu;
            }   
        }
        
    }
}