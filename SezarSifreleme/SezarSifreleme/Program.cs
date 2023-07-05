using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SezarSifreleme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sezar Şifreleme";
            Console.ForegroundColor = ConsoleColor.Red;

            while (true)
            {
                Console.WriteLine("   _____ ______ ______         _____  \r\n  / ____|  ____|___  /   /\\   |  __ \\ \r\n | (___ | |__     / /   /  \\  | |__) |\r\n  \\___ \\|  __|   / /   / /\\ \\ |  _  / \r\n  ____) | |____ / /__ / ____ \\| | \\ \\ \r\n |_____/|______/_____/_/    \\_\\_|  \\_\\");
                Console.WriteLine("\n  by dgknsygn");

                Console.Write("\n  Şifrelenecek Metin(konum): ");
                string Konum = Console.ReadLine();
                string Kodlar = File.ReadAllText(Konum);

                Console.Write("  Kaydırma Sayısı: ");
                int KaydırmaSayisi = Convert.ToInt32(Console.ReadLine());

                Console.Write("  Kaydedilecek konum: ");
                string KaydedilecekKonum = Console.ReadLine();

                string SifrelenmisKod = Sifrele(Kodlar, KaydırmaSayisi);

                Console.Write("  Kaydetmek istediğine emin misin? [Y/n]: ");
                string Cevap = Console.ReadLine();

                if (Cevap.ToLower() == "y")
                {
                    File.WriteAllText(KaydedilecekKonum, SifrelenmisKod);
                    Console.Write("  Şifreli metin kaydedildi.\n  Tekrar şifreleme yapmak ister misin? [Y/n]: ");
                    string Tekrar = Console.ReadLine();

                    if (Tekrar.ToLower() == "y")
                    {
                        Console.Clear();
                    }
                    else if (Tekrar.ToLower() == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("  Sana sunulan seçenekler arasında " + Cevap + "diye bir cevap yok.");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }
                }
                else if (Cevap.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    Console.Write("  Sana sunulan seçenekler arasında " + Cevap + "diye bir cevap yok.");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
            }

            Console.Write("  Programdan çıkmak için herhangi bir tuşa bas.");
            Console.ReadKey();
        }

        public static string Sifrele(string metin, int kaydirmaMiktari)
        {
            string SifreliMetin = "";

            foreach (char karakter in metin)
            {
                if (char.IsLetter(karakter))
                {
                    char baslangic = char.IsUpper(karakter) ? 'A' : 'a';
                    char SifreliKarakter = (char)((karakter - baslangic + kaydirmaMiktari) % 26 + baslangic);
                    SifreliMetin += SifreliKarakter;
                }
                else
                {
                    SifreliMetin += karakter;
                }
            }

            return SifreliMetin;
        }
    }
}