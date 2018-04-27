using System.Collections.Generic;

namespace CodeItAirlines.App.Pessoas.Interfaces
{
    public interface ILocal
    {
        List<IPessoa> Pessoas { get; set; }

        void AdicionarPessoa(IPessoa pessoa);

        void RemoverPessoa(IPessoa pessoa);
    }
}
