using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pgs.Kanban.Domain.Models
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        [Required]
        public string CardName { get; set; }
        public List List{ get; set; }
        public int ListId { get; set; }
    }
}
