using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class UserModel 
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthorizationLevel { get; set; }
        public UserModel()
        {
        }
     
    }
}
