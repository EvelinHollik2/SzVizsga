using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis(); //adatbázis constructor-át meghívjuk
        static List<Dolgozo> dolgozok; //lista létrehozása az adatok felvételéhez --> inicializálás
        static void Main(string[] args)
        {
            //inicializálás
            dolgozok = db.getAllDolgozo(); //-> adatbázisba generálja
            feladat01();
            feladat02();
            feladat03();
            feladat04();

            Console.WriteLine("Program vége");
            Console.ReadLine();
        }

        private static void feladat04()
        {
            Console.WriteLine("4. feladat: Az asztalosműhely-ben dolgozók neve:");
            foreach (var item in dolgozok.FindAll(a=>a.reszleg== "asztalosműhely"))
            {
                Console.WriteLine($"\t {item.nev}");
            }
        }

        private static void feladat03()
        {
            Console.WriteLine("3. feladat:");
            foreach (var item in dolgozok.GroupBy(a => a.reszleg).Select(b => new { reszleg = b.Key, letszam = b.Count() }).OrderBy(c => c.reszleg))
            {
                Console.WriteLine($"\t {item.reszleg}: {item.letszam} fő");
            }
        }

        private static void feladat02()
        {
            int maxBer =dolgozok.Max(a => a.ber);
            Dolgozo dolgozo = dolgozok.Find(a => a.ber == maxBer); //adatdorrás megadása, majd a lamdával megadjuk az elvégezendő műveletet
            Console.WriteLine("2. feladat:");
            Console.WriteLine($"\tA legmagasabb keresetű dolgozó neve: {dolgozo.nev}");
        }

        private static void feladat01()
        {
            Console.WriteLine("1. feladat:");
            Console.WriteLine($"\tA dolgozók száma: {dolgozok.Count} fő");
        }
    }
}
