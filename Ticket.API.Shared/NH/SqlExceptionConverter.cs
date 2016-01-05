using System;
using System.Resources;
using NHibernate.Exceptions;
using Ticket.API.Shared.Infrastructure;

namespace Ticket.API.Shared.NH
{
    public class SqlExceptionConverter : ISQLExceptionConverter
    {
        private static ResourceManager _resource = new ResourceManager("Ticket.API.Shared.BusinessErrorsResource", typeof(BusinessErrorsResource).Assembly);

        public Exception Convert(AdoExceptionContextInfo exInfo)
        {
            var dbException = ADOExceptionHelper.ExtractDbException(exInfo.SqlException);

            var ns = dbException.GetType().Namespace ?? string.Empty;
            if (ns.ToLowerInvariant().StartsWith("system.data.sqlite"))
            {
                var erro = SQLiteErrorTypeDescription(dbException.Message);
                var field = SQLiteErrorField(dbException.Message);

                // SQLite exception
                switch (dbException.ErrorCode)
                {
                    case 19: // violação de constraint
                        var textoPadrao = _resource.GetString("Dado.Duplicado.Nao.Permitido"); //Repetição não permitida para o campo {0}.
                        erro = String.Format(textoPadrao, field);
                        return new BusinessException(field, erro);//Dado.Duplicado.Nao.Permitido

                }
            }

            if (ns.ToLowerInvariant().StartsWith("system.data.sqlclient"))
            {
                // MS SQL Server
                switch (dbException.ErrorCode)
                {
                    case -2146232060:
                        //TODO: mapear erros e mensagem SQLServer
                        throw new BusinessException("nome?", dbException.Message);
                }
            }

            return SQLStateConverter.HandledNonSpecificException(exInfo.SqlException,
                exInfo.Message, exInfo.Sql);
        }


        private string SQLiteErrorTypeDescription(string erro)
        {
            erro = erro.Replace("constraint failed\r\n","");
            var last = erro.IndexOf(":");
            erro = erro.Substring(0, last);

            return erro;
        }

        private string SQLiteErrorField(string erro)
        {
            var inicioDispensavel = erro.IndexOf(".")+1;
            erro = erro.Remove(0, inicioDispensavel).Trim();
            return erro;
        }

    }

   

}
