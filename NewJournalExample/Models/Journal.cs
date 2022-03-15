using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewJournalExample.Models
{
    public class Journal
    {
        [Key]
        [Display(Name = "Journal Entry #")]
        public int JournalNumber { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }
        [StringLength(100, MinimumLength = 10)]
        public string Content { get; set; }

        [ForeignKey("UserNumber")]
        public User User { get; set; }
        public int UserNumber { get; set; }

        public ICollection<Comment> Comments { get; set; }


        public Journal()
        {
            Comments = new HashSet<Comment>();
        }
    }
}
