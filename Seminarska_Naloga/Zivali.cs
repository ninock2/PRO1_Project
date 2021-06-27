using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seminarska_Naloga;
using System.IO;

namespace Zival
{
    class Zivali
    {
        private int starostZivali;
        private string vrstaZivali;
        private string imeZivali;

        public int StarostZivali
        {
            get { return starostZivali; }
            set { starostZivali = value; }
        }
        public string VrstaZivali
        {
            get { return vrstaZivali; }
            set { vrstaZivali = value; }
        }
        public string ImeZivali
        {
            get { return imeZivali; }
            set { imeZivali = value; }
        }

        public Zivali() //Privzeti
        {
            StarostZivali = 0;
            VrstaZivali = null;
            ImeZivali = null;
        }
        public Zivali(int starostZivali, string vrstaZivali, string imeZivali) //Pretvorbeni
        {
            StarostZivali = starostZivali;
            VrstaZivali = vrstaZivali;
            ImeZivali = imeZivali;
        }
        public Zivali(Zivali ziv) //Kopirni
        {
            StarostZivali = ziv.StarostZivali;
            VrstaZivali = ziv.VrstaZivali;
            ImeZivali = ziv.ImeZivali;
        }
        ~Zivali() //Destruktor
        {
            if (StarostZivali != 0) starostZivali = StarostZivali;
            else if (VrstaZivali != null) vrstaZivali = VrstaZivali;
            else if (ImeZivali != null) imeZivali = ImeZivali;

            Console.WriteLine("Zival- Ime: {0}, Vrsta: {1}, Starost: {2}. Je bila izbrisana!",imeZivali,vrstaZivali,starostZivali);
        }

    
        //ToString() override
        public override string ToString()
        {
            return "Ime zivali: " + ImeZivali + "\nStarost zivali: " + StarostZivali.ToString() + 
                "\nVrsta zivali: " + VrstaZivali + ".";
        }
        
        //Metode       
        public void IzpisiZival()
        {
                Console.WriteLine("Ime: {0}", imeZivali);
                Console.WriteLine("Starost: {0}", starostZivali);
                Console.WriteLine("Vrsta zivali: {0}", vrstaZivali);      
        }

        public static void Meni() //Meni
        {
            Console.WriteLine();
            Console.WriteLine("1. Dodaj novo zival");
            Console.WriteLine("2. Izbrisi izbrano zival");
            Console.WriteLine("3. Spremeni izbran objekt");
            Console.WriteLine("4. Shrani zivali v datoteko");
            Console.WriteLine("5. Nalozi datoteko v list zivali");
            Console.WriteLine("6. Izpis vseh zivali");
            Console.WriteLine("7. Izpis izbrano zival");
            Console.WriteLine("8. Izbrisi vse zivali iz lista");
            Console.WriteLine("9. Izpis stevilo vpisanih objektov");
            Console.WriteLine("10. Uporaba podmenija za sortiranje");
            Console.WriteLine("11. Koncaj program");
            Console.WriteLine();
            Console.Write("Vpisi stevilko pred izbrano moznostjo: ");
        }
        public static void Sortiranja() //Podmeni
        {
            Console.WriteLine();
            Console.WriteLine("1. Po letih narascajoce");
            Console.WriteLine("2. Po letih padajoce");
            Console.WriteLine("3. Po imenu (A->Z)");
            Console.WriteLine("4. Po imenu (Z->A)");
            Console.WriteLine("5. Prvo po starosti padajoce nato pa se po imenu A-Z");
            Console.WriteLine("6. Prvo po imenu A-Z nato pa se po starosti padajoce");
            Console.Write("Katero sortiranje zelis izbrati?");
        }

        
    }
}
