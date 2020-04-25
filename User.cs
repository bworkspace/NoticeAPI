using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoardAPI.models
{
    public class User
    {
        
        [Key]
        public int U_id { get; set; }
        public string U_name { get; set; }
        public string U_password { get; set; }
    }
}
