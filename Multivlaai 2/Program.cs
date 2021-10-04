using System;
using System.Globalization;
using System.Data;
using System.Linq;
using System.Collections.Generic;


namespace Multivlaai2
{
    class Program
    {

        public class Klant
        {
            public string Id { get; set; }
            public string Naam { get; set; }
        }

        public class Achtenaam
        {
            public string Id { get; set; }
            public string KlantId { get; set; }
            public string geboortenaam { get; set; }
        }

        public class Straatnaam
        {
            public string Id { get; set; }
            public string AchternaamId { get; set; }
            public string straat { get; set; }
        }

        public class Wonen
        {
            public string Id { get; set; }
            public string StraatnaamId { get; set; }
            public string wonen { get; set; }
        }



        static string check()
        {
            var vraag = Console.ReadLine();       // singel point of definition
            if (vraag == "")
            {
                Console.WriteLine("geef nog een keer");
                vraag = Console.ReadLine();

            }
            return vraag;
        }


        static void Main(string[] args)
        {

            //Medewerkers

            Console.Write("geef aub het aantal medewerkers op:");
            var aantal = Console.ReadLine();
            var aantalmedewerkers = int.Parse(aantal);

            var ID = new int[aantalmedewerkers];
            var namen = new string[aantalmedewerkers];
            var achternaaam = new string[aantalmedewerkers];
            var functie = new string[aantalmedewerkers];
            var geboortedatum = new string[aantalmedewerkers];
            var leeftijd = new int[aantalmedewerkers];



            for (int i = 0; i < ID.Length; i++)
            {
                Console.WriteLine("geef aub naam van medewerker op", i);
                namen[i] = Console.ReadLine();
                Console.WriteLine("geef aub achternamen van medewerker op", i);
                achternaaam[i] = Console.ReadLine();
                Console.WriteLine("geef aub functie van medewerker op", i);
                functie[i] = Console.ReadLine();

                var nlCulture = new CultureInfo("nl-NL");
                Console.WriteLine("geboorte datum van medewerker op " + " dd-mm-yyyy", nlCulture.DateTimeFormat.ShortDatePattern, i);
                DateTime Date = DateTime.Today;
                DateTime Datum = Convert.ToDateTime(geboortedatum[i]);




                try
                {
                    geboortedatum[i] = Console.ReadLine();
                    Console.WriteLine("geef aub ID van medewerker op", i);
                    ID[i] = int.Parse(Console.ReadLine());

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Je hebt geen cijfer op gegeven");
                }


            }

            Console.WriteLine("ID:    \t |  Naam:     \t |  Achternaam:    \t |  geboortedatum:   \t | Functie:  ");
            for (int i = 0; i < ID.Length; i++)
            {
                Console.WriteLine("  {0}  \t |    {1}   \t |  {2}   \t\t |   {3}  \t |   {4}", ID[i], namen[i], achternaaam[i], geboortedatum[i], functie[i]);
            }

            Console.WriteLine("\n");





            //Klanten

            Console.WriteLine("aantalklanten: ");
            string input = Console.ReadLine();
            int id;
            Int32.TryParse(input, out id);


            for (int b = 0; b < id; b++)

            {

                Console.WriteLine("geef naam");
                var naam = check();

                Console.WriteLine("geef achternaam");
                var achternaam = check();

                Console.WriteLine("geef straatnaam");
                var straatnaam = check();

                Console.WriteLine("geef woonplaats");
                var woonplaats = check();


                Console.WriteLine("\n");

                Console.WriteLine($"{naam} U kunt uw betelling op geven!");

                Console.WriteLine("\n");


                string naam1 = naam;
                var klant = new List<Klant>()
            {
                 new Klant()
                 {
                    Id = Guid.NewGuid().ToString(),
                    Naam = naam1
                 }
            };

                string achternaam1 = achternaam;
                var geboortenaam = new List<Achtenaam>()
            {
            new Achtenaam()
                 {
                     Id = Guid.NewGuid().ToString(),
                     KlantId = klant[0].Id,
                     geboortenaam = achternaam1
                  }
            };

                string straatnaam1 = straatnaam;
                var straat = new List<Straatnaam>()
            {
            new Straatnaam()
                 {
                     Id = Guid.NewGuid().ToString(),
                     AchternaamId = geboortenaam[0].Id,
                     straat = straatnaam1
                  }
            };

                string woonplaats1 = woonplaats;
                var wonen = new List<Wonen>()
            {
            new Wonen()
                 {
                     Id = Guid.NewGuid().ToString(),
                     StraatnaamId = straat[0].Id,
                     wonen = woonplaats1
                  }
            };

                var result = from k in klant
                             join a in geboortenaam on k.Id equals a.KlantId
                             join s in straat on a.Id equals s.AchternaamId
                             join w in wonen on s.Id equals w.StraatnaamId
                             select new
                             {
                                 k.Naam,
                                 a.geboortenaam,
                                 s.straat,
                                 w.wonen
                             };

                foreach (var resultItem in result)
                {
                    Console.WriteLine($"{resultItem.Naam} {0,-5} \t{""} {"||"}  {resultItem.geboortenaam} \t{""} {"||"} {resultItem.straat} \t{""} {"||"} {resultItem.wonen}");
                }

            }
        }

    }
}
