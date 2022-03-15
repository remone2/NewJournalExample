using System.ComponentModel.DataAnnotations;

namespace NewJournalExample.Models
{
    public class Journal
    {
        [Key]
        [Display(Name = "Journal Entry #")]
        public int JournalNumber { get; set; }

    }
}
