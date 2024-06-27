using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Speech.Synthesis;

namespace SınavSorusu
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //.Önceden hazırlanmış soruların ve cevapların bulunduğu bir txt dosyası oluşturulur.

            //soru | cevap şeklinde satır satır bulunur.

            //toplam 20 soru olacak(sen yazabilirsin)
            //.Öğrenciden sınav öncesi ad-soyad - kimlik bilgisi alınır
            //.Sonrasında sorular satır satır ekrana getirilir
            //.Her soru için 30 saniye süre verilir
            //.30 saniye dolunca bir sonraki soruya geçilir
            //.Öğrenci 30 saniye içinde cevaplamaz ise boş sayılır.
            //.Testin sonunda 4 yanlış bir doğruyu götürecek şekilde puan hesaplanır.
            //.Soru sayısına göre 100 üzerinden bir puan oluşturulur
            //.Ekrana aşağıdaki bilgiler yazdırılır.

            //Öğrenci bilgileri

            //Toplam sınav süresi

            //Doğru - Yanlış - Boş sayısı
            //Puanı

            //    50 üzerinde ise kazandığı

            Console.WriteLine("Lütfen adınızı ve soyadınızı giriniz.");
            string isim = Console.ReadLine();
            string cevap = "";
            int dogru = 0;
            int yanlis = 0;
            int bos = 0;
            Console.Clear();
            SpeechSynthesizer ss = new SpeechSynthesizer();
            string dosya_yolu = @"C:\Users\omer_\OneDrive\Masaüstü\sorular.txt";
            string metin = System.IO.File.ReadAllText(dosya_yolu);
            string[] satirlar = metin.Split('|');
            DateTime baslangic = DateTime.Now;
            Console.WriteLine("Her soru için 30 saniye süreniz var, sürenizi iyi kullanın.");
            Console.ReadKey();
            Console.Clear();



            for (int i = 0; i < satirlar.Length; i++)
            {
                DateTime bas = DateTime.Now;
                Console.WriteLine(satirlar[i].Split('_')[0]);
                ss.Speak(satirlar[i]);
                cevap = Console.ReadLine();

                cevap = cevap.ToUpper();

                DateTime bit = DateTime.Now;

                TimeSpan fark = bit - bas;
                if (fark.TotalSeconds > 30)
                {
                    bos++;
                }
                else if (cevap == "x")
                {
                    Console.WriteLine("Cevabınız boş.");
                    bos += 1;
                }
                else if (satirlar[i].Split('_')[1] == cevap)
                {
                    Console.WriteLine("Cevabınız doğru.");
                    dogru += 1;
                }
                else if (satirlar[i].Split('_')[1] != cevap)
                {
                    Console.WriteLine("Cevabınız yanlış.");
                    yanlis += 1;
                }
                Console.Clear();
            }
            if (yanlis % 4 == 0)
            {
                dogru -= yanlis / 4;
            }
            int sonuc = dogru * 5;
            Console.Write("SINAV SONUCUNUZ");
            Console.WriteLine();
            Console.WriteLine(isim);
            DateTime bitis = DateTime.Now;
            TimeSpan toplamSure = bitis.Subtract(baslangic);
            Console.WriteLine($"Sınavınız {toplamSure.TotalMinutes.ToString().Substring(0,4)} dakika sürmüştür");
            Console.WriteLine($"Doğru sayısı : {dogru}");
            Console.WriteLine($"Yanlış sayısı : {yanlis}");
            Console.WriteLine($"Boş sayısı : {bos}");
            Console.WriteLine($"Toplam Puanınız : {sonuc}");
            if (sonuc >= 50) { Console.WriteLine("Sınavı geçtiniz"); }
            else { Console.WriteLine("Sınavdan kaldınız"); }

            Console.ReadKey();
        }
    }
}
