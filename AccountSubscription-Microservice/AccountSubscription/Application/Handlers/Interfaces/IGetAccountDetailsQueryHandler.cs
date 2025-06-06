using DittoBox.API.AccountSubscription.Application.Queries;
using DittoBox.API.AccountSubscription.Application.Resources;

namespace DittoBox.API.AccountSubscription.Application.Handlers.Interfaces
{
    public interface IGetAccountDetailsQueryHandler
    {
        public Task<AccountResource?> Handle(GetAccountDetailsQuery query);
    }
}
