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

            Console.WriteLine();
            Console.WriteLine("-------PASSAGEIROS NO DESTINO FINAL--------");
            Console.WriteLine();

            foreach (var pessoa in aeronave.Pessoas)
            {
                Console.WriteLine(pessoa.Nome);
            }

            Console.ReadKey();

        }
        /// <summary>
        /// Este método realiza o embarque de pessoas da origem para o destino, usando a lógica de que sempre o ladrão será transportado no final
        /// </summary>
        /// <param name="origem">Local de Origem</param>
        /// <param name="destino">Local de Destino</param>
        static void TransportarPessoas(ILocal origem, ILocal destino)
        {
            var veiculo = new SmartForTwo();

            var motoristas = origem.Pessoas.Where(x => (x is IMotorista)).ToList();

            var passageiros = origem.Pessoas.OrderBy(x => Guid.NewGuid()).ToList();

            if (origem.Pessoas.Count() > 3)
            {
                motoristas = motoristas.Where(x => !(x is Policial)).ToList();
                passageiros = passageiros.Where(x => !(x is Policial) && !(x is Ladrao)).ToList();

                if (motoristas.Count == 1)
                {
                    var motoristaVolta = destino.Pessoas.Where(x => (x is IMotorista)).ToList().First();
                    origem.AdicionarPessoa(motoristaVolta);
                    destino.RemoverPessoa(motoristaVolta);
                    return;
                }

            }
            else
            {
                if (origem.Pessoas.Count() == 2)
                {
                    motoristas = motoristas.Where(x => (x is Policial)).ToList();
                    passageiros = passageiros.Where(x => (x is Ladrao)).ToList();
                }
                else
                {
                    motoristas = motoristas.Where(x => !(x is Policial)).ToList();
                    passageiros = passageiros.Where(x => !(x is Ladrao)).ToList();
                }
            }

            var motorista = motoristas.OrderBy(x => Guid.NewGuid()).FirstOrDefault() as IMotorista;
            var passageiro = passageiros.Where(x => x != motorista).FirstOrDefault();


            veiculo.EmbarcarMotorista(motorista);
            veiculo.EmbarcarPassageiro(passageiro);
            veiculo.ValidarEmbarqueSmartForTwo();
            Console.WriteLine("Veiculo: " + motorista.Nome + " - " + passageiro.Nome);
            Console.Write(string.Empty);

            origem.RemoverPessoa(motorista);
            origem.RemoverPessoa(passageiro);

            try
            {
                if (veiculo.passageiro is Policial)
                    veiculo.TrocarConsutor();

                if (veiculo.passageiro is Ladrao)
                {
                    destino.AdicionarPessoa(veiculo.DesembarcarMotorista());
                    destino.AdicionarPessoa(veiculo.DesembarcarPassageiro());
                    return;
                }

                destino.AdicionarPessoa(veiculo.DesembarcarPassageiro());



            }
            catch (ValidacaoException)
            {
                origem.AdicionarPessoa(veiculo.DesembarcarPassageiro());
            }

            origem.AdicionarPessoa(veiculo.DesembarcarMotorista());

            Console.WriteLine("Origem: ");
            foreach (var item in origem.Pessoas)
            {
                Console.WriteLine(" -" + item.Nome);
            }
            Console.Write(string.Empty);


            Console.WriteLine("Destino: ");
            foreach (var item in destino.Pessoas)
            {
                Console.WriteLine(" -" + item.Nome);
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine();
        }

    }
}
