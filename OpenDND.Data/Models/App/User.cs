using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using OpenDND.Data.Utilities;

namespace OpenDND.Data.Models.App
{
    public class User
    {
        public User(int userId, string firstName, string lastName, string username, string password, Role role, string token)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Role = role;
            Token = token;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public Role Role { get; set; }
        
        [Required]
        public string Token { get; set; }
        
        public virtual ICollection<Campaign> Campaigns { get; set; }
        
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
                .Entity<User>()
                .HasMany(s => s.Campaigns)
                .WithOne(c => c.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}