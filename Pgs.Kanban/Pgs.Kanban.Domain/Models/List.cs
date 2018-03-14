using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pgs.Kanban.Domain.Models
{
    public class List
    {
        [Key]
        public int Id { get; set; }

        public int BoardId { get; set; }

        public virtual Board Board { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
