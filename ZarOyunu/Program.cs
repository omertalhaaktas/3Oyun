using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ZarOyunu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Zar Oyunu
            //      .Oyun multiplayer şeklinde oynanmaktadır
            //      .Her oyuncu 100 puan almak için yarışmaktadır.
            //      .Her turda bir oyuncu zarı 1 gelene kadar yada kendisi bırakana kadar atabilmektedir:
            //       1 geldiğinde bu turdan sıfır almakta
            //       kendisi bıraktığında bu turdan almış olduğu skor toplam skoruna eklenmektedir.
            //       .Toplam skoru 100 ü geçen yarışmacı oyunu kazanır.
            //       .Oyun sonunda tüm oyuncuların listesi puan sıralamasına göre gösterilir.

            
            
            Console.WriteLine("Kaç kişi oynamak istediğinizi yazınız.");
            int kisiSayisi = int.Parse(Console.ReadLine());
            string[] isim = new string[kisiSayisi];
            int[] puan = new int[kisiSayisi];
            int sinir = 0;
            bool cikis = true;

            for (int i = 0; i < kisiSayisi; i++)
            {
                Console.WriteLine($"{i+1}. oyuncu adını giriniz");
                isim[i] = Console.ReadLine();
            }
            while (cikis == true)
            {
                for (int i = 0; i < isim.Length; i++)
                {
                    Console.WriteLine($"Sıra {isim[i]} adlı oyuncuda");
                    Console.WriteLine(@"Zar atmak için ""enter"" tuşuna basınız.");
                    Console.ReadKey();
                    string cevap = "";
                    int skor = 0;

                    while (cevap == "")
                    {
                        int[] zar = { 1, 2, 3, 4, 5, 6 };
                        Random pc = new Random();
                        int a = pc.Next(6);

                        if (zar[a] == 1)
                        {
                            Console.WriteLine("Attığınız zar 1 geldi bu turdan puan alamadınız :( Sıra, sıradaki oyuncuya geçti.");
                            cevap = "q";
                            skor += 0;
                        }
                        else
                        {
                            Console.WriteLine("Attığınız zar " + zar[a] +@" geldi. Tekrar zar atmak için ""enter"" tuşuna, sıranızı bitirmek için ""q"" tuşuna basınız");
                            cevap = Console.ReadLine();
                            skor += zar[a];
                        }
                    }
                    puan[i] += skor;                                           
                    if (puan[i] >= 100)
                    {
                        cikis = false;
                    }
                }
            }
            Console.Clear();
            Array.Sort(puan);
            Array.Reverse(puan);
            Console.WriteLine("SKOR TABLOSU");
            for (int i = 0; i < isim.Length; i++)
            {
                Console.WriteLine($"{i+1}. {isim[i]}   {puan[i]} PUAN ");
            }
            //sıralama algoritmaları
            Console.ReadKey();




        }
    }
}
