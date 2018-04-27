using CodeItAirlines.App;
using CodeItAirlines.App.Pessoas;
using CodeItAirlines.App.Pessoas.Exceptions;
using CodeItAirlines.App.Pessoas.Interfaces;
using System;
using System.Linq;

namespace CodeItAirlines
{
    class Program
    {
        static void Main(string[] args)
        {
            var terminal = new Local("Terminal");
            var aeronave = new Local("Aeronave");

            terminal.AdicionarPessoa(new Piloto());
            terminal.AdicionarPessoa(new Oficial());
            terminal.AdicionarPessoa(new Oficial());
            terminal.AdicionarPessoa(new ChefeDeServico());
            terminal.AdicionarPessoa(new Comissaria());
            terminal.AdicionarPessoa(new Comissaria());
            terminal.AdicionarPessoa(new Policial());
            terminal.AdicionarPessoa(new Ladrao());

            while (terminal.Pessoas.Any())
            {
                try
                {
                    TransportarPessoas(terminal, aeronave);
                }
                catch (ValidacaoException)
                {
                    continue;
                }
            }

            foreach (var pessoa in aeronave.Pessoas)
            {
                Console.WriteLine(pessoa.Nome);
            }

            Console.ReadKey();

        }

        static void TransportarPessoas(ILocal origem, ILocal destino)
        {
            var veiculo = new SmartForTwo();

            var motoristas = origem.Pessoas.Where(x => (x is IMotorista)).ToList();

            var motorista = motoristas.OrderBy(x => Guid.NewGuid()).FirstOrDefault() as IMotorista;

            var passageiro = origem.Pessoas.OrderBy(x => Guid.NewGuid()).Where(x => x != motorista).FirstOrDefault();


            veiculo.EmbarcarMotorista(motorista);
            veiculo.EmbarcarPassageiro(passageiro);
            veiculo.ValidarEmbarqueSmartForTwo();

            origem.RemoverPessoa(motorista);
            origem.RemoverPessoa(passageiro);


            destino.AdicionarPessoa(veiculo.DesembarcarPassageiro());
            origem.AdicionarPessoa(veiculo.DesembarcarMotorista());
        }

    }
}
