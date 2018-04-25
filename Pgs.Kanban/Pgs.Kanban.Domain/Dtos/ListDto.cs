using System;
using System.Collections.Generic;
using System.Text;

namespace Pgs.Kanban.Domain.Dtos
{
    public class ListDto
    {
        public ListDto()
        {
            Cards = new List<CardDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }
        public List<CardDto> Cards { get; set; }

    }
}
