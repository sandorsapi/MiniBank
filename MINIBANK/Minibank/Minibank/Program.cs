using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Minibank
{
    class Program
    {
        static void Main(string[] args)
        {
            AdatKezelo kezelo = new AdatKezelo();
            kezelo.FixAdatok();
            kezelo.FixTakarekAdatok();
            string valaszt = null;
            AlkalmazásMenu();
            while (valaszt != "Q")
            {
                valaszt = Console.ReadLine().ToUpper();
                switch (valaszt)
                {
                    case "C":
                        Console.Clear();
                        AlkalmazásMenu();
                        break;
                    case "U":
                        kezelo.UjAdat();
                        break;
                    case "N":
                        kezelo.NormalLista();
                        break;
                    case "T":
                        kezelo.TakarekList();
                        break;
                    case "X":
                        kezelo.AdatsorTorles();
                        break;
                    case "A":
                        kezelo.Tranzakcio();
                        break;
                    case "K":
                        kezelo.KamatRata();
                        break;
                    case "Q":
                        Console.WriteLine("Bezárom az alkalmazást");
                        break;
                    default:
                        Console.WriteLine("Rossz karakterbevitel!");                       
                        break;
                }
            }
        }
      
        static void AlkalmazásMenu()
        {
            Console.WriteLine("\t\t\t***************************");
            Console.WriteLine("\t\t\t*********MINI BANK*********");
            Console.WriteLine("\t\t\t***************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t----------Műveletek---------");
            Console.WriteLine("\t\t\t----------------------------");
            Console.WriteLine("\t\t\t-------Disp. törl. (C)------");
            Console.WriteLine("\t\t\t-------Új fiók     (U)------");
            Console.WriteLine("\t\t\t-------Normal List.(N)------");
            Console.WriteLine("\t\t\t-------Tak. List.  (T)------");
            Console.WriteLine("\t\t\t-------Felh. Törl. (X)------");
            Console.WriteLine("\t\t\t-------Tranzakció  (A)------");
            Console.WriteLine("\t\t\t-------Kamatráta   (K)------");
            Console.WriteLine("\t\t\t-------Kilépés     (Q)------");
            Console.WriteLine();
            Console.WriteLine("Válassz!\n");
           
        }
    }
}
