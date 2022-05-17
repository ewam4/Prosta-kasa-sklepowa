using System;
using System.Collections.Generic;

namespace Ewa_Maraszkiewicz
{

    struct Artykul
    {
        //tworzenie struktury
        public string nazwa_artykulu;
        public int id_artykulu;
        public int liczba;
        public decimal cena_Jednostkowa;
        public bool czyZaSztuke;
    }

    class Program
    {//przypisanie zmiennych
        static Artykul wypelnijArtykul( string nazwa_artykulu, int id_artykulu, int cena_Jednostkowa, bool czyZaSztuke)
        {
            Artykul artykul = new Artykul();
            artykul.nazwa_artykulu = nazwa_artykulu;
            artykul.id_artykulu = id_artykulu;
            artykul.cena_Jednostkowa = cena_Jednostkowa;
            artykul.czyZaSztuke = czyZaSztuke;
            artykul.liczba = 0;

            return artykul;
        }

        // funkcja wypełniania tablicy danymi
        static void WypelnijAsortyment(Artykul[] asortyment)
        {
        

            asortyment[0] = wypelnijArtykul( "Ziemniaki", 1, 2, false);
            asortyment[1] = wypelnijArtykul( "Buraki", 2, 3, false); 
            asortyment[2] = wypelnijArtykul( "Banany", 3, 6, false); 
            asortyment[3] = wypelnijArtykul( "Jabłka", 4, 3, false);
            asortyment[4] = wypelnijArtykul( "Mango", 5, 10, false); 

        }
        //funkcja wypisywania artykulow na ekran
        static void WypiszArtykuly(Artykul[] asortyment)
        {
            for (int i = 0; i < asortyment.Length; i++)
            {
                var artykul = asortyment[i];
                Console.WriteLine($" Nazwa: {artykul.nazwa_artykulu} Id: {artykul.id_artykulu} " +
                    $"Cena za kilo: {artykul.cena_Jednostkowa}, Cena za sztuke: {artykul.cena_Jednostkowa / 100}");
                    
            }
        }
      
        //funkcja kupowania arktykulu 
        private static void KupArtykul(Artykul[] asortyment, int id)
        {
            Console.WriteLine("Wciśnij 1 jesli kupujesz produkt na kilogramy, 2 jeśli kupujesz na sztuki");
            int jakamiara = Convert.ToInt32(Console.ReadLine());

            if (jakamiara == 1)
            {
                Console.WriteLine("Ile kilo?");
            }
            else if (jakamiara == 2)
            {
                Console.WriteLine("Ile sztuk?");
            }
           
            asortyment[id].liczba = int.Parse(Console.ReadLine());
            asortyment[id].czyZaSztuke = jakamiara == 2;
        }
        // funkcja licząca koszt artykułu

        private static void DrukujParagon(Artykul[] asortyment)
        {
            decimal suma = 0;
            foreach (var artykul in asortyment)
            {
                if (artykul.liczba > 0)
                {
                    string jedn = artykul.czyZaSztuke ? "szt" : "kg";
                    decimal cena = artykul.cena_Jednostkowa * artykul.liczba;
                    if (artykul.czyZaSztuke)
                        cena /= 100;

                    Console.WriteLine($" Nazwa: {artykul.nazwa_artykulu} Id: {artykul.id_artykulu} " +
                                      $" Liczba: {artykul.liczba } Jednostka: {jedn} Cena: {cena}");
                    suma += cena;
                }
            }

            Console.WriteLine($"Cena calosciowa: {suma}");
        }
        static void Main(string[] args)
        {
            int liczbaArtykulow = 5;
            Artykul[] asortyment = new Artykul[liczbaArtykulow];
            WypelnijAsortyment(asortyment);

            Console.WriteLine("Dzień dobry, zapraszamy do naszego sklepu");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Nasz asortyment:");
            

            WypiszArtykuly(asortyment);
            Console.ReadKey();
            Console.Clear();

            do
            {
                do
                {
                    Console.WriteLine("Podaj id artykulu lub 0 jesli chcesz wydrukowac paragon");
                    int id = int.Parse(Console.ReadLine());

                    if (id == 0)
                        break;

                    KupArtykul(asortyment, id);
                } while (true);
                // drukujemy paragon
                DrukujParagon(asortyment);
                
                //czyszczenie ekranu
                Console.WriteLine("Nowy klient? T/N");
               
            } while (Console.ReadLine() == "T");

        }
    }
}
