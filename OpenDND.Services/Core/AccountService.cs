using OpenDND.Data.Repositories.App;

namespace OpenDND.Services.Core
{
    public class AccountService
    {
        public AccountService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        
        protected internal IUserRepository UserRepository { get; }
    }
}