using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2022_01_24_Fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fuvar> fuvarok = new List<Fuvar>();

            foreach (var sor in File.ReadAllLines("fuvar.csv").Skip(1))
            {
                fuvarok.Add(new Fuvar(sor));
            }

            //3. Feladat
            Console.WriteLine($"3. Feladat: {fuvarok.Count} fuvar");

            //4. Feladat
            double Bevétel = 0;
            int db = 0;
            foreach (var f in fuvarok)
            {
                if (f.TaxiId == 6185)
                {
                    Bevétel += f.Viteldíj + f.Borravaló;
                    db++;
                }
            }

            Console.WriteLine($"4. Feladat: {db} fuvar alatt: {Bevétel}$");

            //5. Feladat
            int bankkártyás = 0;
            int készpénz = 0;

            foreach (var f in fuvarok)
            {
                if (f.FizetésMód== "bankkártya")
                {
                    bankkártyás++;
                }
                if (f.FizetésMód=="készpénz")
                {
                    készpénz++;
                }
            }
            //....

            // 5.b
            Dictionary<string, int> stat = new Dictionary<string, int>();
            foreach (var f in fuvarok)
            {
                if (stat.ContainsKey(f.FizetésMód))
                {
                    stat[f.FizetésMód]++;
                }
                else
                {
                    stat.Add(f.FizetésMód, 1);
                }
            }
            Console.WriteLine($"5. Feladat");
            foreach (var s in stat)
            {
                Console.WriteLine($"\t{s.Key}: {s.Value} fuvar");
            }

            /*5.c
            Console.WriteLine($"5. Feladat");
            fuvarok
                .GroupBy(x => x.FizetésMód)
                .Select(g => new { fizetésmód = g.Key, db = g.Count() })
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.fizetésmód}: {x.db} fuvar"));*/

            //6. Feladat
            double össztávolság = 0;
            foreach (var f in fuvarok)
            {
                össztávolság += f.Távolság * 1.6;
            }

            Console.WriteLine($"6. Feladat: {össztávolság:0.00}km");

            //7. Feladat
            int leghosszabbIndex = 0;
            int length = fuvarok.Count;
            for (int i = 0; i < length; i++)
            {
                if (fuvarok[i].Időtartam > fuvarok[leghosszabbIndex].Időtartam)
                {
                    leghosszabbIndex = i;
                }
            }
            Console.WriteLine($"7. Feladat: Leghosszabb fuvar: " +
                $"\n\tFuvar hossza: {fuvarok[leghosszabbIndex].Időtartam} másodperc" +
                $"\n\tTaxi azonosító: {fuvarok[leghosszabbIndex].TaxiId} " +
                $"\n\tMegtett távolság: {fuvarok[leghosszabbIndex].Távolság} km " +
                $"\n\tViteldíj: {fuvarok[leghosszabbIndex].Viteldíj}$");


            //8. Feladat



            Console.ReadKey();
        }
    }
}
