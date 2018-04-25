using CodeItAirlines.App.Pessoas.Interfaces;
using System.Collections.Generic;

namespace CodeItAirlines.App
{
    public class Terminal : Local, ILocal
    {
        public Terminal()
        {
            _pessoas = new List<IPessoa>();
        }

        public void AdicionarPessoa(IPessoa pessoa)
        {
            _pessoas.Add(pessoa);
        }

        public void RemoverPessoa(IPessoa passageiro)
        {
            _pessoas.Remove(passageiro);
        }
    }
}
