using System;
using System.Resources;
using NHibernate.Exceptions;
using Ticket.API.Shared.Infrastructure;

namespace Ticket.API.Shared.NH
{
    public class SQLServerSqlExceptionConverter : ISQLExceptionConverter
    {
        private static ResourceManager _resource = new ResourceManager("Ticket.API.Shared.BusinessErrorsResource", typeof(BusinessErrorsResource).Assembly);

        public Exception Convert(AdoExceptionContextInfo exInfo)
        {
            //var dbException = ADOExceptionHelper.ExtractDbException(exInfo.SqlException);
            //var textoResource = String.Empty;


            //// SQLite exception
            //switch (dbException.ErrorCode)
            //{
            //    case 2601://Cannot insert duplicate key row in object '%.*ls' with unique index '%.*ls'. The duplicate key value is %ls.
            //        textoResource = _resource.GetString("DadoDuplicadoNaoPermitido"); //Repetição não permitida para o campo {0}.
            //        //return new BusinessException(campo, erro);//DadoDuplicadoNaoPermitido

            //    case 233:
            //        textoResource = _resource.GetString("ValorNuloNaoPermitido");
            //        //return new BusinessException(campo, erro);//DadoDuplicadoNaoPermitido


            //    default:
            //        throw new InvalidOperationException(String.Format("ExtendedError {0} não mapeado", erro));

            //}

            throw new NotImplementedException();

        }
    }
}
