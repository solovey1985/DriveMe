using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveMe.DAL.Identity.Models
{
    public abstract class DrivemeIdentity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50), MinLength(3)]
        public string Title { get; set; }
        [StringLength(20),MinLength(3)]
        public string ShortTitle { get; set; }
    }
}
