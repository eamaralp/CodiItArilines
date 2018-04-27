using System;

namespace CodeItAirlines.App.Pessoas.Exceptions
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException()
            : base()
        {
        }

        public ValidacaoException(String mensagem)
            : base(mensagem)
        {
        }
    }
}
