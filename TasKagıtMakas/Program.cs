using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TasKagıtMakas
{
    internal class Program
    {
        static void Main(string[] args)
        {

        //TAŞ-KAĞIT-MAKAS OYUNU
        //.Bilgisayara karşı ve iki kişilik şeklinde oyun modu seçilebilir
        //.Giriş ekranında oyuncunun / oyuncuların isimleri alınır
        //.10 defa kazanan oyunun galibi olur
        //.Oyuncu / oyunculardan veri girişi alınır.

        //    Veri Girişleri 1 - Taş , 2 - Kağıt , 3 - Makas şeklindedir
        //.Bilgisayara karşı oynanıyorsa random şekilde seçim yapar bilgisayar
        //.Her elin sonunda kazanan gösterilir
        //Oyun sonunda ise liste şeklinde oyuncuların kazandıkları oyunlar ve totalde galip gelen oyuncu gösterilir.
        //.Tekrar oynamak için "Devam" çıkış için "Çıkış" şeklinde geri dönüt istenir.


        baslangic:
            string kullanici = "";
            string multiplayer = "";
            string isim = "";

            Console.WriteLine(@"Bilgisayara karşı oynamak istiyorsanız ""bilgisayar"" iki kişilik oynamak istiyorsanız ""oyuncu"" yazınız.");
            multiplayer = Console.ReadLine();


            if (multiplayer == "bilgisayar")
            {
                Console.WriteLine("Adınızı giriniz");
                isim = Console.ReadLine();
                int kazanan = 0;
                int kaybeden = 0;
                var liste = new Dictionary<int, string>();

                
            }

            if (multiplayer == "oyuncu")
            {
                string oyuncu1 = "";
                string oyuncu2 = "";
                string secim1 = "";
                string secim2 = "";
                int kazananOyuncu1 = 0;
                int kazananOyuncu2 = 0;

                Console.WriteLine("1. Oyuncu adınızı giriniz.");
                oyuncu1 = Console.ReadLine();
                Console.WriteLine("2. Oyuncu adınızı giriniz.");
                oyuncu2 = Console.ReadLine();
                var ikikisilik = new Dictionary<int, string>();

                for (int i = 1; i <= 30; i++)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"{i}. ROUND");
                    Console.WriteLine("1. oyuncu lütfen tas kagit ve makas seçeneklerinden birini girin");
                    secim1 = Console.ReadLine();
                    Console.WriteLine("2. oyuncu lütfen tas kagit ve makas seçeneklerinden birini girin");
                    secim2 = Console.ReadLine();
                    string[] secenek = { "tas", "kagit", "makas" };
                    Random pc = new Random();
                    int a = pc.Next(3);

                    DataTable kazanalar = new DataTable();
                    kazanalar.Columns.Add("secimBir");
                    kazanalar.Columns.Add("secimIki");
                    kazanalar.Columns.Add("sonuc");

                    kazanalar.Rows.Add("tas","kagit","2. Oyuncu Kazandı");
                    kazanalar.Rows.Add("tas", "makas", "1. Oyuncu Kazandı");
                    kazanalar.Rows.Add("tas", "tas", "Berabere");
                    kazanalar.Rows.Add("makas", "kagit", "1. Oyuncu Kazandı");
                    kazanalar.Rows.Add("makas", "tas", "2. Oyuncu Kazandı");
                    kazanalar.Rows.Add("makas", "makas", "Berabere");

                    DataRow[] sonucsdsd = kazanalar.Select("secimBir='" + secim1 + "' and secimIki='" + secim2+"'"); 
                    ikikisilik.Add(i, sonucsdsd[0]["sonuc"].ToString());
                     
                    if (kazananOyuncu1 == 10)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("OYUN SONUCU!!!");
                        foreach (KeyValuePair<int, string> item in ikikisilik)
                        { 
                            Console.WriteLine(item.Key + ". RAUND " + item.Value);
                        }
                        Console.WriteLine("");
                        Console.WriteLine($"{oyuncu1} KAZANDI");
                        i += 30;
                    }
                    if (kazananOyuncu2 == 10)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("OYUN SONUCU!!!");
                        foreach (KeyValuePair<int, string> item in ikikisilik)
                        {
                            Console.WriteLine(item.Key + ". RAUND " + item.Value);
                        }
                        Console.WriteLine("");
                        Console.WriteLine($"{oyuncu2} KAZANDI");
                        i += 30;
                    }
                }
            }
            Console.WriteLine(@"Devam etmek için ""devam"" çıkmak için ""cikis"" yazınız.");
            string sonuc = "";
            sonuc = Console.ReadLine();
            if (sonuc == "cikis")
            {
            }
            if (sonuc == "devam")
            {
                goto baslangic;
            }
            else
            {
                Console.WriteLine("Doğru yazdığınızdan emin olunuz.");
            }
        }
    }
}
