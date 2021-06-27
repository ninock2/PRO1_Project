using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zival;
using System.IO;

namespace Seminarska_Naloga
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Zivali> ziv = new List<Zivali>();

            do
            {
                Zivali.Meni();
                int x = int.Parse(Console.ReadLine());

                switch (x)
                {
                    case 1: //Dodajanje
                        Zivali z = new Zivali();
                        Console.WriteLine();
                        Console.Write("Ime zivali: ");
                        z.ImeZivali = Console.ReadLine();
                        Console.Write("Starost zivali: ");
                        z.StarostZivali = int.Parse(Console.ReadLine());
                        Console.Write("Vrsta zivali: ");
                        z.VrstaZivali = Console.ReadLine();
                        ziv.Add(z);
                        break;
                    case 2: //Izbris izbrane zivali
                        Console.Write("Izbrises lahko zivali med 0 in {0}.Katero zelis izbrisat? ", ziv.Count-1);
                        int izbris = int.Parse(Console.ReadLine());
                        if (izbris > ziv.Count || izbris < 0)
                        {
                            Console.WriteLine("Zival ne tem mestu ne obstaja!!!");
                            break;
                        }
                        else
                        {
                            ziv.RemoveAt(izbris);
                            Console.WriteLine("Izbrana zival je bila izbrisana!");
                            break;
                        }
                    case 3: //Spremeni izbran objekt
                        Console.Write("Spremenis lahko zivali med 0 in {0}.Katero zelis spremenit? ", ziv.Count-1);
                        int spremeni = int.Parse(Console.ReadLine());
                        if (spremeni > ziv.Count || spremeni < 0)
                        {
                            Console.WriteLine("Zival ne tem mestu ne obstaja!");
                            break;
                        }
                        else
                        {
                            ziv.RemoveAt(spremeni);
                            Zivali z1 = new Zivali();
                            Console.Write("Ime zivali: ");
                            z1.ImeZivali = Console.ReadLine();
                            Console.Write("Starost zivali: ");
                            z1.StarostZivali = int.Parse(Console.ReadLine());
                            Console.Write("Vrsta zivali: ");
                            z1.VrstaZivali = Console.ReadLine();
                            ziv.Insert(spremeni, z1);
                            Console.WriteLine("Zival na mestu {0} je bila spremenjena!", spremeni);
                            break;
                        }
                    case 4: //Nalozi list v datoteko !!
                        string path = @"C:\\Users\\Nino PR\\Desktop\\PRO2\\txt\\text.txt";
                        int zi = 1;
                        using (TextWriter tw = new StreamWriter(path))
                        {
                            foreach (var item in ziv)
                            {
                                tw.WriteLine("{0}. Zival:",zi);
                                tw.WriteLine(item.ToString());
                                tw.WriteLine();
                                zi++;
                            }
                            tw.Close();
                        }
                        Console.WriteLine("Zivali so bile nalozene v datoteko!");
                        break;
                    case 5: //Nalozi datoteko v list !! 
                        Console.WriteLine();
                        Console.WriteLine("Za vstavljanje zivali v datoteko moramo uporabiti >vejico< kot locilo v naslednjiem vrstnem redu.");
                        Console.WriteLine("Primer: ImeZivali,StarostZivali,VrstaZivali");
                        Console.WriteLine("Ce razumete pritisnite ENTER za nadaljevanje!");
                        string pathDat = @"C:\\Users\\Nino PR\\Desktop\\PRO2\\txt\\zivaliVen.txt";
                        int m = 0;
                        using (TextReader sr = new StreamReader(pathDat))
                        {
                            string linja = sr.ReadLine();
                            if(linja == null)
                            {
                                Console.WriteLine("Datoteka je prazna! Nalozeno ni bilo nic!");
                                break;
                            }
                            else { }

                            while (linja != null)
                            {
                                Zivali zDat = new Zivali();
                                string[] lines = linja.Split(',');
                                zDat.ImeZivali = lines[0];
                                zDat.StarostZivali = Int32.Parse(lines[1]);
                                zDat.VrstaZivali = lines[2];
                                ziv.Add(zDat);
                                linja = sr.ReadLine();
                                m++;
                            };
                        }
                        Console.WriteLine("Zivali so bile nalozene iz datoteke!");
                        break;
                    case 6: //Izpis vseh zivali
                        int i = 1;
                        if (ziv.Count <= 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("List zivali je prazen, nemorem nic izpisati!");
                        }
                        else
                        {
                            Console.WriteLine("Izpis Vseh zivali: ");
                            foreach (var zival in ziv)
                            {
                                Console.WriteLine("{0}. Zival:", i);
                                zival.IzpisiZival();
                                Console.WriteLine();
                                i++;
                            }
                        }
                        break;
                    case 7: //Izpis izbrane zivali
                        Console.Write("Izpises lahko zivali med 0 in {0}.Katero zelis izpisat? ", ziv.Count-1);
                        int izpisi = int.Parse(Console.ReadLine());
                        if (izpisi >= ziv.Count || izpisi < 0)
                        {
                            Console.WriteLine("Zivali ne tem mestu ne obstaja!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Zival na {0}, mestu: ", izpisi);
                            ziv[izpisi].IzpisiZival();
                            break;
                        }

                    case 8: //Izbrisi vse objekte
                        ziv.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Vse zivali v listu so bile izbrisane. Zdaj je list prazen");
                        break;
                    case 9: //Izpis stevila objektov
                        Console.WriteLine();
                        Console.WriteLine("V list je trenutno {0} shranjenih zivali.", ziv.Count());
                        break;
                    case 10: //Sortiranje objektov po dolocenem kriteriju
                        Zivali.Sortiranja();
                        int sort = int.Parse(Console.ReadLine());
                        switch (sort)
                        {
                            case 1: //Starost naracajoce
                                ziv.Sort((j, y) => j.StarostZivali.CompareTo(y.StarostZivali));
                                Console.WriteLine("List zivali je zdaj sortirano po starosti narascajoce.");
                                break;
                            case 2: //Startost padajoce
                                ziv = ziv.OrderByDescending(t => t.StarostZivali).ToList();
                                Console.WriteLine("List zivali je zdaj sortirano po starosti padajoce.");
                                break;
                            case 3: //Ime A->Z
                                ziv.Sort((j, y) => j.ImeZivali.CompareTo(y.ImeZivali));
                                Console.WriteLine("List zivali je zdaj sortirano po imenih A->Z.");
                                break;
                            case 4://Ime Z->A
                                ziv.Sort((j, y) =>y.ImeZivali.CompareTo(j.ImeZivali));
                                Console.WriteLine("List zivali je zdaj sortirano po imenih Z->A.");
                                break;
                                //Sortiranje po vecih atributih
                            case 5: //To sortiranje pride v upostev ce je vec zivali z istim imenom ali isto starostjo
                                ziv = ziv.OrderBy(y => y.StarostZivali).ThenBy(y => y.ImeZivali).ToList();
                                Console.WriteLine("Zivali bodo prvo sortirane po strosti padajoce potem po imenih A-Z.");
                                break;
                            case 6: //To sortiranje pride v upostev ce je vec zivali z istim imenom ali isto starostjo
                                ziv = ziv.OrderBy(y => y.ImeZivali).ThenBy(y => y.StarostZivali).ToList();
                                Console.WriteLine("Zivali bodo prvo sortirane po imenu A-Z potem po letih padajoce.");
                                break;
                            default:
                                Console.WriteLine("Sortiranje z to predstevilko ne obstaja!!!");
                                break;
                        }
                        break;
                    case 11: //Zakljuci program
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Moznost z to stevilko ne obsataja!");
                        break;

                }
                Console.WriteLine();
                Console.WriteLine("Po pregledu rezultata pritisnite katerokoli tipko za nadaljevanje!");
                Console.ReadKey(true);
            } while (true);

        }
    }
}
