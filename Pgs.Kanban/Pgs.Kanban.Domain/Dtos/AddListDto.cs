using System.ComponentModel.DataAnnotations;

namespace Pgs.Kanban.Domain.Dtos
{
    public class AddListDto
    {
        [Required]
        public int BoardId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
