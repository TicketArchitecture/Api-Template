namespace Ticket.UsuariosApi.Core
{
    public class FriendlyErrorMessage
    {
        private string _info;
        private string _detail;

        public FriendlyErrorMessage(string info, string detail)
        {
            this._info = info;
            this._detail = detail;
        }
    }
}