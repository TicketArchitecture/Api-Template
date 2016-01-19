using log4net;
using NHibernate;

namespace Ticket.API.Shared.NH
{

    /// <summary>
    /// Grava as queries no output window do VS
    /// </summary>
    public class SQLDebugOutputLogger : EmptyInterceptor, IInterceptor
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(SQLDebugOutputLogger));
        public override NHibernate.SqlCommand.SqlString
           OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            System.Diagnostics.Debug.WriteLine("NH: " + sql);
            if (_log.IsDebugEnabled)
                _log.Debug(sql);
            return base.OnPrepareStatement(sql);
        }
    }
}
