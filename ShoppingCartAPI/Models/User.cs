using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartAPI.Models
{
    public class User:IdentityUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
