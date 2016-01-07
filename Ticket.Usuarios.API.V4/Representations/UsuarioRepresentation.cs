using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Ticket.Usuarios.API.V4.Representations
{
    public class UsuarioRepresentation
    {
        [JsonProperty(PropertyName = "id")]
        public virtual int Id { get; set; }
        [JsonProperty(PropertyName =  "nome")]
        public virtual string Nome { get; set; }
        [JsonProperty(PropertyName =  "email")]
        public virtual string Email { get; set; }
        [JsonProperty(PropertyName =  "aceitoMkt")]
        public virtual bool AceitoMkt { get; set; }
        [JsonProperty(PropertyName =  "statusValidacao")]
        public virtual int StatusValidacao { get; set; }
        [JsonProperty(PropertyName =  "links")]
        public virtual List<LinkRelation> Links { get; set; }
        [JsonProperty(PropertyName =  "telefone")]
        public virtual AparelhoTelefoneRepresentation Telefone { get; set; }
            
    }

    public class AparelhoTelefoneRepresentation
    {

        [JsonProperty(PropertyName =  "numero")]
        public virtual string Numero { get; private set; }
        [JsonProperty(PropertyName = "idAparelho")]
        public virtual string UUID { get; private set; }
        [JsonProperty(PropertyName = "sistemaOperacional")]
        public virtual string SistemaOperacional { get; private set; }
        [JsonProperty(PropertyName = "validado")]
        public virtual bool Validado { get; private set; }
    }
}
