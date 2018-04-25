using CodeItAirlines.App.Pessoas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeItAirlines.App.Pessoas
{
    public class Ladrao : Pessoa, IPassageiro
    {
        public Ladrao()
        {
            Nome = "Ladrao";
        }
    }
}
