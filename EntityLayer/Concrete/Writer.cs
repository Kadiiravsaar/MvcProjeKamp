using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key] // bunlara attribute denir
        public int WriterID { get; set; }

        [StringLength(50)] // bunlara attribute denir
        public string WriterName { get; set; }

        [StringLength(50)] // bunlara attribute denir
        public string WriterSurName { get; set; }

        [StringLength(100)]
        public string WriterAbout { get; set; }

        [StringLength(1000)]
        public string WriterImage { get; set; }

        [StringLength(100)]
        public string WriterMail { get; set; }

        [StringLength(100)]
        public string WriterPassword { get; set; }

        [StringLength(50)]
        public string WriterTitle{ get; set; }

        public ICollection<Heading> Heading { get; set; }
        public ICollection<Content> Content { get; set; }

    }
}
