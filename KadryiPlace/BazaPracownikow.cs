using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace DzialKadrIPlac
{
    class BazaPracownikow
    {
        private List<Pracownik> pracownicy;

        public BazaPracownikow() { }


        public void WczytajZPliku(string jsonstr)
        {            
            string zawartosc = File.ReadAllText(jsonstr);
            pracownicy = JsonConvert.DeserializeObject<List<Pracownik>>(zawartosc);

        }

        public List<Pracownik> GetPracownicy()
        {
            return pracownicy;
        }
    }
}
