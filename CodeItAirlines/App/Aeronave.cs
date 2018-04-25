using CodeItAirlines.App.Pessoas;
using CodeItAirlines.App.Pessoas.Exceptions;
using CodeItAirlines.App.Pessoas.Interfaces;
using System;

namespace CodeItAirlines.App
{
    public class Aeronave : Local, ILocal
    {
        public void AdicionarPessoa(IPessoa pessoa)
        {
            if (pessoa is ITripulante)
                new ValidadorTripulacao(_pessoas).Validar(pessoa);
            else
            {
                try
                {
                    _pessoas.Add(pessoa);
                    new ValidadorDePermanencia().Validar(_pessoas);
                }
                catch (ValidacaoException e)
                {
                    _pessoas.Remove(pessoa);
                }
                catch(Exception e)
                {
                    throw new Exception("Falha ao adicionar uma pessoa: " + e.Message);
                }
            }                
        }

        public void RemoverPessoa(IPessoa pessoa)
        {
            try
            {
                _pessoas.Remove(pessoa);
                new ValidadorDePermanencia().Validar(_pessoas);
            }
            catch (ValidacaoException e)
            {
                _pessoas.Add(pessoa);
            }
            catch (Exception e)
            {
                throw new Exception("Falha ao adicionar uma pessoa: " + e.Message);
            }
        }
    }
}
