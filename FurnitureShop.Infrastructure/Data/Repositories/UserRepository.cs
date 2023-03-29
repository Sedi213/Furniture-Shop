using FurnitureShop.Core.Interface.RepositoryInterfaces;
using FurnitureShop.Core.Models;

namespace FurnitureShop.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _dbContext as ApplicationDbContext; }
        }
    }
}
