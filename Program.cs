using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YONETMENLER_VE_FILMLERI_JAGGED_ARRAY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Yönetmen: Quentin Tarantino - Filmler: Pulp Fiction, Kill Bill, Desperado

            //Yönetmen: Steven Spielberg - Filmler: Shindler's List, E.T, Saving Private Ryan

            //Yönetmen: Nuri Bilge Ceylan - Filmler: Kış Uykusu, Ahlat Ağacı, Uzak

            //Yönetmen: Clint Eastwood - Filmler: Million Dollar Baby


            string[] yonetmenler = YonetmenDizisiOlustur("Quentin Tarantino", "Steven Spielberg", "Nuri Bilge Ceylan", "Clint Eastwood");
            string[][] yonetmenlerVeFilmleri = YonetmenVeFilmleriDizisiOlustur(ref yonetmenler);
            YonetmenlereFilmEkle(ref yonetmenlerVeFilmleri, "Quentin Tarantino", "Pulp Fiction", "Kill Bill", "Desperado");
            YonetmenlereFilmEkle(ref yonetmenlerVeFilmleri, "Steven Spielberg", "Shindler's List", "E.T", "Saving Private Ryan");
            YonetmenlereFilmEkle(ref yonetmenlerVeFilmleri, "Nuri Bilge Ceylan", "Kış Uykusu", "Ahlat Ağacı", "Uzak");
            YonetmenlereFilmEkle(ref yonetmenlerVeFilmleri, "Clint Eastwood", "Million Dollar Baby");
            string girilen = string.Empty;
            do
            {
                EkranaYonetmenYaz("Lütfen bir yönetmen seçiniz (Birden fazla yönetmen seçerken , kullanabilrisiniz 'büyük-küçük harf önemli değildir'): \n", yonetmenler);
                Console.WriteLine(new string('-', 100));
                girilen = Console.ReadLine().ToLower().Trim();
                Console.WriteLine(new string('-', 100));
                string[] girilenDizisi = girilen.Split(',');
                for (int i = 0; i < girilenDizisi.Length; i++)
                { 
                    girilenDizisi[i] =  new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(girilenDizisi[i].Trim());
                }
                if (yonetmenler.Intersect(girilenDizisi).Count() > 0)
                {
                    EkranaYonetmeninFilmleriniYaz(yonetmenlerVeFilmleri, girilenDizisi);
                }
                else if (girilen == "çık")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Böyle bir yönetmen bulunmamaktadır. Çıkmak için çık yazabilirsiniz!");
                    Console.WriteLine(new string('-', 100));
                }
            } while (girilen != "çık");

            Console.WriteLine("Uygulamamızı kullandığınız için teşekkür ederiz!");

            
        }

        private static void EkranaYonetmeninFilmleriniYaz(string[][] yonetmenlerVeFilmleri, params string[] yonetmenadi)
        {
            foreach (string[] yonetmen in yonetmenlerVeFilmleri)
            {
                for (int index = 0; index < yonetmenadi.Length; index++)
                {
                    if (yonetmen[0] == yonetmenadi[index])
                    {
                        Console.WriteLine(yonetmenadi[index] + "'in filmleri : ");
                        Console.WriteLine(new string('-', 100));
                        for (int i = 0; i < yonetmen.Length - 1; i++)
                        {
                            Console.WriteLine(yonetmen[i + 1]);
                            Console.WriteLine(new string('-', 100));
                        }
                    }
                }

            }



        }

        static string[] YonetmenDizisiOlustur(params string[] yonetmenler)
        {
            return yonetmenler;
        }

        static string[][] YonetmenVeFilmleriDizisiOlustur(ref string[] yonetmenler)
        {
            string[][] yonetmenlerVeFilmleri = new string[yonetmenler.Length][];

            for (int i = 0; i < yonetmenler.Length; i++)
            {
                yonetmenlerVeFilmleri[i] = new string[] {yonetmenler[i]};
            }
            
            return yonetmenlerVeFilmleri;

        }

        static void YonetmenlereFilmEkle(ref string[][] yonetmenlerVeFilmleri, string yonetmenadi, params string[] filmler)
        {
            int index;
            for (index = 0; index < yonetmenlerVeFilmleri.Length; index++)
            {
                if (yonetmenlerVeFilmleri[index][0] == yonetmenadi)
                {
                    int filmEklenmedenOncekiHal = yonetmenlerVeFilmleri[index].Length;
                    Array.Resize(ref yonetmenlerVeFilmleri[index], filmEklenmedenOncekiHal + filmler.Length);
                    for (int i = 0; i < filmler.Length; i++)
                    {
                        yonetmenlerVeFilmleri[index][filmEklenmedenOncekiHal+i] = filmler[i];
                    }
                    break;
                }
            }


            //var array = new long[][]
            //{
            //new long[]{1},
            //new long[]{2,3}
            //};

            //// change existing element
            //array[1][0] = 0;

            //// add row & fill it
            //Array.Resize(ref array, 3);
            //Array.Resize(ref array[2], 1);
            //array[2][0] = 5;

            //// resize existing row

            //Array.Resize(ref array[1], 3);
            //array[1][2] = 6;

        }


        static void EkranaYonetmenYaz(string mesaj,params string[] yonetmenler)
        {
            string yonetmenlerSiralandi = string.Empty;
            for (int i = 0; i < yonetmenler.Length; i++)
            {
                if (i<yonetmenler.Length-1)
                {
                    yonetmenlerSiralandi += yonetmenler[i] + ", ";
                }
                else
                {
                    yonetmenlerSiralandi += yonetmenler[i];
                }
                
            }

            Console.WriteLine(mesaj + yonetmenlerSiralandi);
        }




    }
}
