using System;
using System.Collections.Generic;
using System.Text;

namespace Pgs.Kanban.Domain.Dtos
{
    public class CardDto
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public int ListId { get; set; }
    }
}
