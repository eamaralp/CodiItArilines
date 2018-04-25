using CodeItAirlines.App.Pessoas;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeItAirlines.App
{
    public class Local
    {
        public string nome { get; set; }
        public Tripulacao tripulacao {get; set;}
        public List<Pessoa> passageiros { get; set; }
    }
}
