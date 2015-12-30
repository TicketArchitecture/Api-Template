using NHibernate;

namespace Ticket.API.Shared.NH
{

    /// <summary>
    /// Grava as queries no output window do VS
    /// </summary>
    public class SQLDebugOutputLogger : EmptyInterceptor, IInterceptor
    {
        public override NHibernate.SqlCommand.SqlString
           OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            System.Diagnostics.Debug.WriteLine("NH: " + sql);
            return base.OnPrepareStatement(sql);
        }
    }
}
