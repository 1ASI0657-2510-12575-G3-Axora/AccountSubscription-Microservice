using DittoBox.API.AccountSubscription.Domain.Models.Aggregates;
using DittoBox.API.AccountSubscription.Domain.Repositories;
using DittoBox.API.Shared.Infrastructure;
using DittoBox.API.Shared.Infrastructure.Repositories;

namespace DittoBox.API.AccountSubscription.Infrastructure.Repositories
{
    public class AccountRepository(ApplicationDbContext context) : BaseRepository<Account>(context), IAccountRepository
    {
    }
}
