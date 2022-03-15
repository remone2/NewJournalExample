using System.ComponentModel.DataAnnotations;

namespace NewJournalExample.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User Number")]
        public int UserNumber { get; set; }

    }
}
