using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iverzer.Model.Entities
{
    public class OrderInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        
        [Required]
        public DateTime SubTime { get; set; }
        
        public int UserInfoId { get; set; }
    }
}
