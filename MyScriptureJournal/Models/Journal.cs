using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class Journal
    {
        public int ID { get; set; }

        [Display(Name = "Book Name")]
        public string BookName { get; set; }


        [Display(Name = "Chapter:Verse")]
        public string ChapterVerse { get; set; }
        public string Notes { get; set; }

        public string Scripture { get; set; }

        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
    }
}
