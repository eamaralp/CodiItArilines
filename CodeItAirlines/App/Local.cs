using CodeItAirlines.App.Pessoas;
using CodeItAirlines.App.Pessoas.Exceptions;
using CodeItAirlines.App.Pessoas.Interfaces;
using System.Collections.Generic;
using System.Transactions;

namespace CodeItAirlines.App
{
    public class Local : ILocal
    {
        public string Nome { get; set; }
        public List<IPessoa> Pessoas { get; set; }

        public Local(string Nome)
        {
            this.Nome = Nome;
            Pessoas = new List<IPessoa>();
        }

        public void AdicionarPessoa(IPessoa pessoa)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    this.Pessoas.Add(pessoa);
                    new ValidadorDePermanencia().Validar(this.Pessoas);
                    new ValidadorTripulacao(this.Pessoas).Validar(pessoa);
                    scope.Complete();
                }
                catch (ValidacaoException)
                {
                    scope.Dispose();
                }
            }
        }

        public void RemoverPessoa(IPessoa pessoa)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    this.Pessoas.Remove(pessoa);
                    new ValidadorDePermanencia().Validar(this.Pessoas);
                    new ValidadorTripulacao(this.Pessoas).Validar(pessoa);
                    scope.Complete();
                }
                catch (ValidacaoException)
                {
                    scope.Dispose();
                }
            }            
        }

    }
}
