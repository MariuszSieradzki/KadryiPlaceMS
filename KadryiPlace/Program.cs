using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace DzialKadrIPlac
{
    class Program
    {
        static void Main()
        {            
            BazaPracownikow bazaPracownikow = new BazaPracownikow();
            bazaPracownikow.WczytajZPliku("pracownicy.json");
            List<Pracownik> pracownicy = bazaPracownikow.GetPracownicy();
                        
            Console.WriteLine("DZIAL KADR I PLAC\n");
            Console.WriteLine("Lista pracownikow firmy:");
            for (int i = 0; i < pracownicy.Count; i++)
            {
                Console.WriteLine("  {0}. {1} {2}", i + 1, pracownicy[i].Imie, pracownicy[i].Nazwisko);
            }

            Console.Write("\n\nProsze podac numer pracownika: ");
            int num = Convert.ToInt32(Console.ReadLine()) - 1;
            Pracownik pracownik = pracownicy[num];
                        
            Console.WriteLine("\n{0} {1}", pracownik.Imie, pracownik.Nazwisko);
            Console.WriteLine("Stanowisko: {0}", pracownik.GetStanowiskoStr());
            Console.WriteLine("Stawka: {0:0.00}", pracownik.GetStawkaStr());
            Console.WriteLine("Ilosc dni przepracowanych: {0}", pracownik.DniPrzepracowane);
            Console.WriteLine("Ilosc dni na zwolnieniu: {0}", pracownik.DniNaZwolnieniu);
                        
            Console.Write("\nPodaj wysokosc premii dla pracownika: {0} {1}: ", pracownik.Imie, pracownik.Nazwisko);
            int premia = Convert.ToInt32(Console.ReadLine());

            pracownik.ObliczWynagrodzenie(premia);
                        
            Console.WriteLine("\n-----------------------------------------");
            Console.WriteLine("{0} {1}", pracownik.Imie, pracownik.Nazwisko);
            Console.WriteLine("Wynagrodzenie za {0}", DateTime.Now.ToString("MMMM yyyy"));
            Console.WriteLine("Premia uznaniowa: {0:0.00} PLN", pracownik.Premia);
            Console.WriteLine("Wynagrodzenie podstawowe brutto: {0:0.00} PLN", pracownik.WynagrodzeniePodstBrutto);
            Console.WriteLine("W tym:");
            Console.WriteLine("  Podatek dochodowy: {0:0.00} PLN", pracownik.PodatekDochodowy);
            Console.WriteLine("  Skladki ZUS: {0:0.00} PLN", pracownik.SkladkiZUS);
            Console.WriteLine("Wynagrodzenie podstawowe netto: {0:0.00} PLN", pracownik.WynagrodzeniePodstNetto);
            Console.WriteLine("Dodatek za warunki uciazliwe: {0:0.00} PLN", pracownik.DodatekZaWarunkiUciazliwe);
            Console.WriteLine("Lacznie do wyplaty na konto: {0:0.00} PLN", pracownik.Wynagrodzenie);
            Console.WriteLine("-----------------------------------------");
            Console.ReadLine();
        }
    }
}
