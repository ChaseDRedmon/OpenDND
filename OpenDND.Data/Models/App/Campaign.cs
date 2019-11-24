using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OpenDND.Data.Utilities;

namespace OpenDND.Data.Models.App
{
    public class Campaign
    {
        public int CampaignID { get; set; }
        public string Name { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
        public virtual ICollection<Session> Sessions { get; set; }
        
        [OnModelCreating]
        internal static void OnModelCreating(ModelBuilder modelBuilder)
        {
            // uint datatype has a conversion to int
            /*modelBuilder
                .Entity<Customer>()
                .Property(x => x.CustomerID)
                .HasConversion<int>();*/
            
            // Create a required many to one relationship from Customer to Invoices. A customer has many sales. 
            modelBuilder
                .Entity<Campaign>()
                .HasMany(s => s.Sessions)
                .WithOne(x => x.Campaign)
                .HasForeignKey(y => y.SessionId);
        }
    }
}