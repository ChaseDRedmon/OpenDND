using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenDND.Data.Models.App;
using OpenDND.Data.Utilities;

namespace OpenDND.Data.Repositories.App
{
    public interface IUserRepository
    {
        Task<bool> CreateItemAsync(User userItem);
        Task<bool> TryUpdateItemAsync(long customerId, Action<UserMutationData> updateAction);
        Task<User> ReadItemAsync(long userId);
        Task<User> ReadItemByUsername(string userLogin);
        Task<bool> DeleteItemAsync(long userId);
    }
    
    /// <summary>
    /// Repository for creating, updating, read, and deleting information from the database.
    /// Repository handles all interactions with the data storage layer of the application
    /// </summary>
    public sealed class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(OpenDNDContext capstoneContext) : base(capstoneContext)
        {
        }

        public async Task<bool> CreateItemAsync(User userItem)
        {
            if (userItem == null)
            {
                throw new ArgumentNullException(nameof(userItem));
            }

            await OpenDndContext.Users.AddAsync(userItem);
            await OpenDndContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> TryUpdateItemAsync(long userId, Action<UserMutationData> updateAction)
        {
            if (userId == 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var entity = await OpenDndContext.Users
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (entity == null)
            {
                return false;
            }

            var data = UserMutationData.FromEntity(entity);
            updateAction.Invoke(data);
            data.ApplyTo(entity);
            
            OpenDndContext.UpdateProperty(entity, x => x.Username);
            OpenDndContext.UpdateProperty(entity, x => x.Password);
            OpenDndContext.UpdateProperty(entity, x => x.FirstName);
            OpenDndContext.UpdateProperty(entity, x => x.LastName);
            OpenDndContext.UpdateProperty(entity, x => x.Role);
            OpenDndContext.UpdateProperty(entity, x => x.Token);
            OpenDndContext.UpdateProperty(entity, x => x.Campaigns);

            await OpenDndContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> ReadItemAsync(long userId)
        {
            var entity = await OpenDndContext.Users
                .FirstOrDefaultAsync(x => x.UserId == userId);

            return entity;
        }

        public async Task<User> ReadItemByUsername(string userLogin)
        {
            var entity = await OpenDndContext.Users
                .FirstOrDefaultAsync(x => x.Username == userLogin);

            return entity;
        }

        public async Task<bool> DeleteItemAsync(long userId)
        {
            var entity = await OpenDndContext.Users
                .FirstOrDefaultAsync(x => x.UserId == userId);

            OpenDndContext.Users.Remove(entity);
            await OpenDndContext.SaveChangesAsync();

            return true;
        }
    }
}