using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewJournalExample.Models
{
    public class Comment
    {
        [Key]
        public int CommentNumber { get; set; }

        [StringLength(1000, MinimumLength = 5)]
        public string Content { get; set; }


        [ForeignKey("UserNumber")]
        public User User { get; set; }
        public int UserNumber { get; set; }

        [ForeignKey("JournalNumber")]
        public Journal Journal { get; set; }
        public int JournalNumber { get; set; }
    }
}
