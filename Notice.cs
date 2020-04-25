using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoardAPI.models
{
    public class Notice
    {
        [Key]
        public int N_id { get; set; }
        public string N_message { get; set; }
        public DateTime N_startDate { get; set; }
        public DateTime N_endDate { get; set; }
        public DateTime N_postDate { get; set; }
        // public ICollection<User> Users { get; set; }

        [ForeignKey("U_id")]
        public virtual User Users { get; set; }

        [Display(Name = "Users")]
        public virtual int U_id { get; set; }

    }
}
