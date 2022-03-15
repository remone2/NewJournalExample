using System.ComponentModel.DataAnnotations;

namespace NewJournalExample.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User Number")]
        public int UserNumber { get; set; }
        [StringLength(50, MinimumLength = 6)]
        public string UserName { get; set; }
        public ICollection<Journal> Journals { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public User()
        {
            Journals = new HashSet<Journal>();
            Comments = new HashSet<Comment>();
        }
    }
}
