using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model
{
    public class ListProperty
    {
        [Key]
        public int ListID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ListName { get; set; }

        [Required]
        [MaxLength(400)]
        public string ListDesc { get; set; }
    }
}
