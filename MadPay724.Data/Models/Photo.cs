using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MadPay724.Data.Models
{
    public class Photo :BaseEntity<string>
    {
        public Photo()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
        [Required]
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        [Required]
        public bool IsMain { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public User User { get; set; }

    }
}
