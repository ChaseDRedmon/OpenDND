using System.Collections.Generic;

namespace OpenDND.Data.Models.App
{
    public class UserMutationData
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        
        internal static UserMutationData FromEntity(User entity) => new UserMutationData
        {
            Username = entity.Username,
            Password = entity.Password,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Role = entity.Role,
            Token = entity.Token,
            Campaigns = entity.Campaigns,
        };

        internal void ApplyTo(User entity)
        {
            entity.Username = Username;
            entity.Password = Password;
            entity.FirstName = FirstName;
            entity.LastName = LastName;
            entity.Role = Role;
            entity.Token = Token;
            entity.Campaigns = Campaigns;
        }
    }
}