using CodeItAirlines.App.Pessoas.Interfaces;
using System.Collections.Generic;

namespace CodeItAirlines.App
{
    public class Local
    {
        public string Nome { get; set; }
        public List<IPessoa> _pessoas { get; set; }

        public Local()
        {
            _pessoas = new List<IPessoa>();
        }

    }
}
