using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Minibank
{
    class AdatKezelo
    {
        private  string szSzamHonnan = null;
        private    string szSzamHova = null;
        private  int utalas = 0;
        private   bool tranzakcioEngedely = true;
        

        ArrayList fList = new ArrayList();
        ArrayList takarekList = new ArrayList();

        public void FixAdatok()
        {
            fList.AddRange(new NormalSzamla[] { new NormalSzamla(1, "555-1111111-58", "Mr. Big Buck", 10), 
                new NormalSzamla(2, "555-3333333-10", "Mss. Kis", 10) });
        }

        public void FixTakarekAdatok()
        {
            takarekList.AddRange(new TakarekSzamla[] { new TakarekSzamla(1, "666-2222222-31", "Mr. Big Buck", 250),
                new TakarekSzamla(2, "666-4444444-80","Mss, Kis", 250) });
        }

        public void KamatRata()
        {
            TakarekSzamla takarekSzla = new TakarekSzamla();
            double kamat;

            Console.WriteLine("Kamatráta:\n");
            kamat = double.Parse(Console.ReadLine());
            takarekSzla.KamatLabAdat = kamat;
            Console.WriteLine("Kamatráta értéke {0}%-ra beállítva\n", kamat);
        }
        public void UjAdat()
        {
            string valasztas = null;
            Console.WriteLine("Új adat - (Normál(N)/Takarék(T)\n");
            valasztas = Console.ReadLine().ToUpper();
            switch (valasztas)
            {
                case "N":
                    NormalUjAdat();
                    break;
                case "T":
                    TakarekUjAdat();
                    break;
                default:
                    Console.WriteLine("Hibás karakterbevitel!\n");
                    break;
            }
        }
        public void NormalUjAdat()
        {
            bool hibaIndex = false;
            object[] arrayOfNormalSzla = fList.ToArray();
            Console.WriteLine("Index:\n");
            int fIndex = int.Parse(Console.ReadLine());
            Console.WriteLine("Számlaszám:\n");
            string szSzam = Console.ReadLine();
            Console.WriteLine("Felhasználó neve:\n");
            string felhasznalo = Console.ReadLine();
            Console.WriteLine("Összeg:\n");
            int betet = int.Parse(Console.ReadLine());


            for (int i = 0; i < arrayOfNormalSzla.Length; i++)
            {
                if (((NormalSzamla)arrayOfNormalSzla[i]).SzamlaSzamTarolo == szSzam)
                {
                    hibaIndex = true;
                }
            }

            if (hibaIndex == false)
            {
                fList.Insert(fList.Count, new NormalSzamla(fIndex, szSzam, felhasznalo, betet + 10));
                Console.WriteLine("Adatok rögzítve!\n");
            }
            else
            {
                Console.WriteLine("Már létezik a felhasználó és/vagy a számlaszám!\n");
                hibaIndex = false;
            }
        }

        public void TakarekUjAdat()
        {
            bool hibaIndex = false;
            object[] arrayOfTakarekSzla = takarekList.ToArray();
            Console.WriteLine("Index:\n");
            int fIndex = int.Parse(Console.ReadLine());
            Console.WriteLine("Számlaszám:\n");
            string szSzam = Console.ReadLine();
            Console.WriteLine("Felhasználó neve:\n");
            string felhasznalo = Console.ReadLine();
            Console.WriteLine("Összeg:\n");
            int betet = int.Parse(Console.ReadLine());


            for (int i = 0; i < arrayOfTakarekSzla.Length; i++)
            {
                if (((TakarekSzamla)arrayOfTakarekSzla[i]).SzamlaSzamTarolo == szSzam)
                {
                    hibaIndex = true;
                }
            }

            if (hibaIndex == false)
            {
                takarekList.Insert(takarekList.Count, new TakarekSzamla(fIndex, szSzam, felhasznalo, betet));
                Console.WriteLine("Adatok rögzítve!\n");
            }
            else
            {
                Console.WriteLine("Már létezik a felhasználó és/vagy a számlaszám!\n");
                hibaIndex = false;
            }
        }

        public void Tranzakcio()
        {
            int akcioKod = 0;
            string valasztas = null;
            Console.WriteLine("Melyik számláról utalsz? (Normál(N)/Takarék(T)\n");
            valasztas = Console.ReadLine().ToUpper();
            switch (valasztas)
            {
                case "N":                    
                    HonnanBevitel();                   
                    if (NormalSzamlaEllenor(szSzamHonnan) == false)
                    {
                        tranzakcioEngedely = true;                        
                        akcioKod = 1;
                    }
                    else
                    {
                        Console.WriteLine("Hiba!\n");
                        tranzakcioEngedely = false;
                        akcioKod = 0;
                    }
                    break;
                case "T":                   
                    HonnanBevitel();                   
                    if (TakarekSzamlaEllenor(szSzamHonnan) == false)
                    {
                        tranzakcioEngedely = true;                        
                        akcioKod = 2;
                    }
                    else
                    {
                        Console.WriteLine("Hiba!\n");
                        tranzakcioEngedely = false;
                        akcioKod = 0;
                    }
                    break;
                default:
                    Console.WriteLine("Hibás karakterbevitel!\n");
                    break;
            }
            valasztas = null;
            if (tranzakcioEngedely == true)
            {
                Console.WriteLine("Melyik számlára utalsz? (Normál(N)/Takarék(T)\n");
                valasztas = Console.ReadLine().ToUpper();
                switch (valasztas)
                {
                    case "N":
                        HovaBevitel();
                        if (NormalSzamlaEllenor(szSzamHova) == false)
                        {
                            if (akcioKod == 1)
                            {
                                NSzamlaHonnanUtal(szSzamHonnan, utalas);
                            }
                            else if (akcioKod == 2)
                            {
                                TSzamlaHonnanUtal(szSzamHonnan, utalas);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hiba!\n");
                            Console.WriteLine("Új tranzakció!");
                        }
                        if (tranzakcioEngedely == true)
                        {
                            NSzamlaHovaUtal(szSzamHova, utalas);
                            Console.WriteLine("Tranzakció végrehajtva!\n");
                            akcioKod = 0;
                        }
                        else
                        {
                            Console.WriteLine("Hiba!\n");
                            Console.WriteLine("Új tranzakció!");
                        }
                        break;
                    case "T":
                        HovaBevitel();
                        if (TakarekSzamlaEllenor(szSzamHova) == false)
                        {
                            if (akcioKod == 1)
                            {
                                NSzamlaHonnanUtal(szSzamHonnan, utalas);
                            }
                            else if (akcioKod == 2)
                            {
                                TSzamlaHonnanUtal(szSzamHonnan, utalas);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hiba!\n");
                            Console.WriteLine("Új tranzakció!");
                        }
                        if (tranzakcioEngedely == true)
                        {
                            TSzamlaHovaUtal(szSzamHova, utalas);
                            Console.WriteLine("Tranzakció végrehajtva!\n");
                            akcioKod = 0;
                        }
                        else
                        {
                            Console.WriteLine("Hiba!\n");
                            Console.WriteLine("Új tranzakció!");
                        }
                        break;
                    default:
                        Console.WriteLine("Hibás karakterbevitel!\n");
                        break;
                }
            }
            else
            {                
                Console.WriteLine("Új tranzakció!");
            }
            tranzakcioEngedely = true;
        }

        public void AdatsorTorles()
        {
            int index = 0;
            string valasztas = null;
            Console.WriteLine("Melyik számláról akarsz törölni? (Normál(N)/Takarék(T)\n");
            valasztas = Console.ReadLine().ToUpper();
            switch (valasztas)
            {
                case "N":
                    Console.WriteLine("Index:\n");
                    index = int.Parse(Console.ReadLine());
                    if (index < fList.Count - 1 || index > fList.Count)
                        {
                            Console.WriteLine("Hibás index!");
                        }
                    else if (index <= 0)
                    {
                        Console.WriteLine("A record nem létezik!");
                    }
                    else
                        {
                            fList.RemoveAt(index - 1);
                            Console.WriteLine("Töröltem a tételt!");
                            index = 0;
                        }
                    break;
                case "T":
                    Console.WriteLine("Index:\n");
                    index = int.Parse(Console.ReadLine());
                    if (index < takarekList.Count - 1 || index > takarekList.Count)
                        {
                            Console.WriteLine("Hibás index!");
                        }
                        else if (index <= 0)
                        {
                            Console.WriteLine("A record nem létezik!");
                        }
                        else
                        {
                            takarekList.RemoveAt(index - 1);
                            Console.WriteLine("Töröltem a tételt!");
                            index = 0;
                        }
                    break;
                default:
                    Console.WriteLine("Hibás karakterbevitel!\n");
                    break;
            }           
        }
        public void NormalLista()
        {
            object[] arrayOfNormalSzla = fList.ToArray();
            Console.WriteLine("Normál számla adatai:\n");
            Console.WriteLine("Index\t - Felhasználó Neve\t - Számlaszám\t - Betét(EUR)");
            Console.WriteLine("-----------------------------------------------------------");
            for (int i = 0; i < arrayOfNormalSzla.Length; i++)
            {
                Console.WriteLine("{0},\t {1},\t\t {2},\t {3}\n",
                    ((NormalSzamla)arrayOfNormalSzla[i]).IndexTarolo,
                    ((NormalSzamla)arrayOfNormalSzla[i]).FelhasznaloTarolo,
                    ((NormalSzamla)arrayOfNormalSzla[i]).SzamlaSzamTarolo,
                    ((NormalSzamla)arrayOfNormalSzla[i]).MennyisegTarolo);
            }
            arrayOfNormalSzla = null;
        }
        public void TakarekList()
        {
            object[] arrayOfTakarekSzla = takarekList.ToArray();
            Console.WriteLine("Takarékszámla adatai:\n");
            Console.WriteLine("Index\t - Felhasználó Neve\t - Számlaszám\t - Betét(EUR)");
            Console.WriteLine("-----------------------------------------------------------");
            for (int i = 0; i < arrayOfTakarekSzla.Length; i++)
            {
                Console.WriteLine("{0},\t {1},\t\t {2},\t {3}\n",
                    ((TakarekSzamla)arrayOfTakarekSzla[i]).IndexTarolo,
                    ((TakarekSzamla)arrayOfTakarekSzla[i]).FelhasznaloTarolo,
                    ((TakarekSzamla)arrayOfTakarekSzla[i]).SzamlaSzamTarolo,
                    ((TakarekSzamla)arrayOfTakarekSzla[i]).MennyisegTarolo);
            }
            arrayOfTakarekSzla = null;
        }
        public void HonnanBevitel()
        {           
            Console.WriteLine("Honnan? - Számlaszám:\n");
            szSzamHonnan = Console.ReadLine();
            Console.WriteLine("Utalandő összeg:\n");
            utalas = int.Parse(Console.ReadLine());       
        }
        public void HovaBevitel()
        {            
            Console.WriteLine("Hová? - Számlaszám:\n");
            szSzamHova = Console.ReadLine();              
        }
        public void NSzamlaHonnanUtal(string szSzam, int utalas)
        {
            int honnanIndex = 0;           
            object[] arrayOfNormalSzla = fList.ToArray();          
                for (int i = 0; i < arrayOfNormalSzla.Length; i++)
                {
                    if (((NormalSzamla)arrayOfNormalSzla[i]).SzamlaSzamTarolo == szSzam)
                    {
                        honnanIndex = i;
                    }
                }
                if (((((NormalSzamla)arrayOfNormalSzla[honnanIndex]).MennyisegTarolo) - utalas) <= -500)
                {
                    tranzakcioEngedely = false;
                    utalas = 0;
                    Console.WriteLine("A bank nem engedélyezi az átutalást! (Limit -500 EUR)");
                }
                else
                {
                    (((NormalSzamla)arrayOfNormalSzla[honnanIndex]).MennyisegTarolo) = (((NormalSzamla)arrayOfNormalSzla[honnanIndex]).MennyisegTarolo) - utalas;
                }           
            }           
            
        
        public void TSzamlaHonnanUtal(string szSzam, int utalas)
        {
            int honnanIndex = 0;            
            object[] arrayOfTakarekSzla = takarekList.ToArray();          
                for (int i = 0; i < arrayOfTakarekSzla.Length; i++)
                {
                    if (((TakarekSzamla)arrayOfTakarekSzla[i]).SzamlaSzamTarolo == szSzam)
                    {
                        honnanIndex = i;
                    }
                }
                if (((((TakarekSzamla)arrayOfTakarekSzla[honnanIndex]).MennyisegTarolo) - utalas) < 0)
                {
                    tranzakcioEngedely = false;
                    utalas = 0;
                    Console.WriteLine("A bank nem engedélyezi az átutalást! (Limit 0 EUR)");
                }
                else
                {
                    (((TakarekSzamla)arrayOfTakarekSzla[honnanIndex]).MennyisegTarolo) = (((TakarekSzamla)arrayOfTakarekSzla[honnanIndex]).MennyisegTarolo) - utalas;
                }               
            }
            
            
        
        public void NSzamlaHovaUtal(string szSzam, int utalas)
        {
            int hovaIndex = 0;            
            object[] arrayOfNormalSzla = fList.ToArray();        
                for (int i = 0; i < arrayOfNormalSzla.Length; i++)
                {
                    if (((NormalSzamla)arrayOfNormalSzla[i]).SzamlaSzamTarolo == szSzam)
                    {
                        hovaIndex = i;
                    }
                }               
                (((NormalSzamla)arrayOfNormalSzla[hovaIndex]).MennyisegTarolo) = (((NormalSzamla)arrayOfNormalSzla[hovaIndex]).MennyisegTarolo) + utalas;                               
            }
           
        
        public void TSzamlaHovaUtal(string szSzam, int utalas)
        {
            int hovaIndex = 0;            
            object[] arrayOfTakarekSzla = takarekList.ToArray();           
                for (int i = 0; i < arrayOfTakarekSzla.Length; i++)
                {
                    if (((TakarekSzamla)arrayOfTakarekSzla[i]).SzamlaSzamTarolo == szSzam)
                    {
                        hovaIndex = i;
                    }
                }                                   
                (((TakarekSzamla)arrayOfTakarekSzla[hovaIndex]).MennyisegTarolo) =  (((TakarekSzamla)arrayOfTakarekSzla[hovaIndex]).MennyisegTarolo) + utalas;          
        }

        public bool NormalSzamlaEllenor(string szSzam)
        {
            int hibaIndex = 0;
            object[] arrayOfNormalSzla = fList.ToArray();

            for (int i = 0; i < arrayOfNormalSzla.Length; i++)
            {
                if (((NormalSzamla)arrayOfNormalSzla[i]).SzamlaSzamTarolo != szSzam)
                {
                    hibaIndex++;
                }
            }
            if (hibaIndex != fList.Count)
            {           
               return false;                
            }
            else
            {
                Console.WriteLine("A számlaszám nem létezik!\n");
                tranzakcioEngedely = false;
                return true;                
            }
        }
        public bool TakarekSzamlaEllenor(string szSzam)
        {
            int hibaIndex = 0;
            object[] arrayOfTakarekSzla = takarekList.ToArray();

            for (int i = 0; i < arrayOfTakarekSzla.Length; i++)
            {
                if (((NormalSzamla)arrayOfTakarekSzla[i]).SzamlaSzamTarolo != szSzam)
                {
                    hibaIndex++;
                }
            }
            if (hibaIndex != takarekList.Count)
            {
                return false;
            }
            else
            {
                Console.WriteLine("A számlaszám nem létezik!\n");
                tranzakcioEngedely = false;
                return true;
            }
        }

      }
    }

    


