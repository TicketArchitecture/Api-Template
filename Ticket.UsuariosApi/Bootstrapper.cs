using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using Nancy.Diagnostics;
using NHibernate;
using NHibernate.Context;
using Ticket.UsuariosApi.Core.Inicialization.Installers;

namespace Ticket.UsuariosApi
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get
            {
                return new DiagnosticsConfiguration { Password = "1" };
            }
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);
            existingContainer.Install(new NHibernateInstaller(), new RepositoryInstaller());
            RegisterFacades(existingContainer);
        }

        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            ConfigureNHibernateSessionPerRequest(container, pipelines);

            //algum serviço
            //container.Resolve<Barista>();

        }

        private void ConfigureNHibernateSessionPerRequest(IWindsorContainer container, IPipelines pipelines)
        {
            pipelines.BeforeRequest += ctx => CreateSession(container);
            pipelines.AfterRequest += ctx => CommitSession(container);
            pipelines.OnError += (ctx, ex) => RollbackSession(container);
            //pipelines.OnError += InvalidOrderOperationHandler;
        }
        private Response RollbackSession(IWindsorContainer container)
        {
            var sessionFactory = container.Resolve<ISessionFactory>();
            if (CurrentSessionContext.HasBind(sessionFactory))
            {
                var requestSession = sessionFactory.GetCurrentSession();
                requestSession.Transaction.Rollback();
                CurrentSessionContext.Unbind(sessionFactory);
                requestSession.Dispose();
            }
            return null;
        }

        private Response CreateSession(IWindsorContainer container)
        {
            var sessionFactory = container.Resolve<ISessionFactory>();
            var requestSession = sessionFactory.OpenSession();
            CurrentSessionContext.Bind(requestSession);
            requestSession.BeginTransaction(System.Data.IsolationLevel.Snapshot);

            return null;
        }

        private AfterPipeline CommitSession(IWindsorContainer container)
        {
            var sessionFactory = container.Resolve<ISessionFactory>();
            if (CurrentSessionContext.HasBind(sessionFactory))
            {
                var requestSession = sessionFactory.GetCurrentSession();
                requestSession.Transaction.Commit();
                CurrentSessionContext.Unbind(sessionFactory);
                requestSession.Dispose();
            }
            return null;
        }

        private void RegisterFacades(IWindsorContainer container)
        {
            container.Register(
                Classes.FromThisAssembly().InNamespace("Ticket.UsuariosApi.V1.Application", true)
                .WithService.AllInterfaces()
                .LifestyleTransient());
        }
    }
}
