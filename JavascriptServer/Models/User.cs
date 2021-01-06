using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JavascriptServer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        
        public List<Adress> Adresses { get; set; }
    }
}