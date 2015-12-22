using System.Collections.Generic;
using System.Resources;

namespace Ticket.API.Shared.Infrasctructure { 

    public static class BusinessValidator
    {
        private static ResourceManager _resource;

        static BusinessValidator()
        {
            _resource = new ResourceManager("Ticket.API.Shared.BusinessErrorsResource", typeof(BusinessErrorsResource).Assembly);


        }
        public static void ThrowBusinessExceptionIfNeeded(ICollection<string> businessErrorsResourceNames)
        {
            if (businessErrorsResourceNames == null || businessErrorsResourceNames.Count == 0)
                return;

            var dicionarioErros = new Dictionary<string, string>();
            var textoResource = string.Empty;

            foreach (var erro in businessErrorsResourceNames)
            {
               dicionarioErros.Add(erro, TextoResource(erro));
            }

            throw new BusinessException(dicionarioErros);
        }

        public static void ThrowBusinessExceptionWithResourcesMessage(string resourceErrorMessageName)
        {
            if (resourceErrorMessageName == null)
                throw new System.ArgumentNullException("resourceErrorMessageName não pode ser nulo");
            throw new BusinessException(resourceErrorMessageName, TextoResource(resourceErrorMessageName));
        }

        private static string TextoResource(string nome)
        {
            var textoResource = _resource.GetString(nome);
            if (textoResource == null)
                textoResource = _resource.GetString("Erro.Padrao");

            return textoResource;
        }
    }
}
