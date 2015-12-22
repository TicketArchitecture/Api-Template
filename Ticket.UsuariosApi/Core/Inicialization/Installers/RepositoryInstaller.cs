using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Ticket.UsuariosApi.Core.Data;
using Ticket.UsuariosApi.Core.Data.NH.Repositories;

namespace Ticket.UsuariosApi.Core.Inicialization.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(ICommandRepository<>)).ImplementedBy(typeof(CommandRepository<>)));
            container.Register(Component.For(typeof(IReadOnlyRepository<>)).ImplementedBy(typeof(ReadOnlyRepository<>)));
        }
    }
}
