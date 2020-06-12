using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZaventDotNetInterview.Models
{
    public abstract class BaseEntityModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
