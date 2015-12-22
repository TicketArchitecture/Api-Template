using System;
using Ticket.UsuariosApi.Core.Domain;

namespace Ticket.UsuariosApi.Core.Data.NH.Entities
{
    public class Entity : BusinessValidator
    {
        public virtual int Id { get; set; }

        public virtual int Versao { get; protected set; }

        public virtual DateTime DataCriacao { get; set; }

        public virtual DateTime? DataAlteracao { get; set; }

        public Entity()
        {
            DataCriacao = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;
            if (other == null) return false;
            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            if (Id == 0) return base.GetHashCode();
            var stringRepresentation = this.GetType().FullName + "#" + this.Id; 
            return stringRepresentation.GetHashCode();
        }
    }
}
