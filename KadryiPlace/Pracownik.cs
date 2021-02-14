using System;
using System.Collections.Generic;
using System.Text;

namespace DzialKadrIPlac
{
    class Pracownik
    {
        public enum StanowiskoPracownika
        {
            PracownikFizyczny = 0,
            Dyrektor = 1,
            Kierownik = 2,
            UrzednikSredniegoSzczebla = 3,
            UrzednikNiskiegoSzczebla = 4
        }
        private static string[] stanowiskoStr = { "Pracownik fizyczny", "Dyrektor", "Kierownik", "Urzednik sredniego szczebla", "Urzednik wysokiego szczebla" };

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public StanowiskoPracownika Stanowisko { get; set; }
        public double StawkaGodzinowa { get; set; }
        public double StawkaStala { get; set; }
        public int DniPrzepracowane { get; set; }
        public int DniNaZwolnieniu { get; set; }


        public double WynagrodzeniePodstBrutto;
        public double WynagrodzeniePodstNetto;
        public double Premia;
        public double PodatekDochodowy;
        public double SkladkiZUS;
        public double DodatekZaWarunkiUciazliwe;
        public double Wynagrodzenie;


        public string GetStawkaStr()
        {
            if (Stanowisko == StanowiskoPracownika.PracownikFizyczny)
            {
                return StawkaGodzinowa + " PLN/h";
            }
            else
            {
                return StawkaStala + " PLN";
            }
        }
        public string GetStanowiskoStr()
        {
            return stanowiskoStr[(int)Stanowisko];
        }
        public void ObliczWynagrodzenie(int premia)
        {
            if (Stanowisko == StanowiskoPracownika.PracownikFizyczny)
            {
                WynagrodzeniePodstBrutto = (DniPrzepracowane + DniNaZwolnieniu * 0.8) * 8 * StawkaGodzinowa;
                DodatekZaWarunkiUciazliwe = 100;
            }
            else
            {
                WynagrodzeniePodstBrutto = StawkaStala;
                DodatekZaWarunkiUciazliwe = 0;
            }

            Premia = premia;
            WynagrodzeniePodstBrutto += (DniNaZwolnieniu == 0) ? Premia : (Premia * 0.5); // jesli byl na zwolnieniu otrzyma tylko polowe premii

            PodatekDochodowy = WynagrodzeniePodstBrutto * 0.2; // 20% podatek dochodowy
            SkladkiZUS = 600; // Skladki ZUS stale 600zl

            WynagrodzeniePodstNetto = WynagrodzeniePodstBrutto - PodatekDochodowy - SkladkiZUS;

            Wynagrodzenie = WynagrodzeniePodstNetto + DodatekZaWarunkiUciazliwe;
        }
    }
}
