using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewJournalExample.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User Number")]
        public int UserNumber { get; set; }
        [StringLength(50, MinimumLength = 6)]
        public string UserName { get; set; }

        [InverseProperty("User")]
        public ICollection<Journal> Journals { get; set; }
        public ICollection<Comment> Comments { get; set; }

        [InverseProperty("Editor")]
        public ICollection<Journal> EditorJournals { get; set; }
        public User()
        {
            Journals = new HashSet<Journal>();
            Comments = new HashSet<Comment>();
        }
    }
}
