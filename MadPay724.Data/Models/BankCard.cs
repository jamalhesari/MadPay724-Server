﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MadPay724.Data.Models
{
    public class BankCard:BaseEntity<string>
    {
        public BankCard()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
        [Required]
        public string BankName { get; set; }
        public string Shaba { get; set; }
        [Required]
        [Range(2, 2)]
        public string CardNumber { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string ExpireDateMonth { get; set; }
        [Required]
        [StringLength(2, MinimumLength =2)]
        public string ExpireDateYear { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public User User { get; set; }
    }
}
