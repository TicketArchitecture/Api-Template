using System;
using System.Resources;
using NHibernate.Exceptions;
using Ticket.API.Shared.Infrastructure;

namespace Ticket.API.Shared.NH
{
    public class SQLiteSqlExceptionConverter : ISQLExceptionConverter
    {
        private static ResourceManager _resource = new ResourceManager("Ticket.API.Shared.BusinessErrorsResource", typeof(BusinessErrorsResource).Assembly);

        public Exception Convert(AdoExceptionContextInfo exInfo)
        {
            var dbException = ADOExceptionHelper.ExtractDbException(exInfo.SqlException);


            var erro = ErrorDescription(dbException.Message);
            var campo = SQLiteErrorField(dbException.Message);


            // SQLite exception
            switch (dbException.ErrorCode)
            {
                case 19: // violação de constraint
                    return WorkOnExtendedError(erro, campo);

                default:
                    throw new InvalidOperationException(String.Format("Error code {0} não mapeado", dbException.ErrorCode));
                    //return SQLStateConverter.HandledNonSpecificException(exInfo.SqlException,
                    //exInfo.Message, exInfo.Sql);

            }


        }


        private string ErrorDescription(string erro)
        {
            //descricao original: constraint failed\r\nNOT NULL constraint failed: Tabela.Coluna
            erro = erro.Replace("constraint failed", "");
            erro = erro.Replace("\r\n", "");

            var last = erro.IndexOf(":");
            erro = erro.Substring(0, last);
           
            return erro.Trim();
        }

        private string SQLiteErrorField(string erro)
        {
            var inicioDispensavel = erro.IndexOf(".") + 1;
            erro = erro.Remove(0, inicioDispensavel).Trim();
            return erro;
        }

       
        private BusinessException WorkOnExtendedError(string erro, string campo)
        {
            var textoResource = String.Empty;
            switch (erro)
            {
                case "UNIQUE":
                    textoResource = _resource.GetString("DadoDuplicadoNaoPermitido"); //Repetição não permitida para o campo {0}.
                    return new BusinessException(campo, textoResource);//DadoDuplicadoNaoPermitido

                case "NOT NULL":
                    textoResource = _resource.GetString("ValorNuloNaoPermitido");
                    return new BusinessException(campo, textoResource);//DadoDuplicadoNaoPermitido

                case "PRIMARY KEY":
                    goto case "NOT NULL";
                default:
                    throw new InvalidOperationException(String.Format("ExtendedError {0} não mapeado", erro));
            }

        }



    }
}
