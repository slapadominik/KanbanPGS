using System.ComponentModel.DataAnnotations;

namespace Pgs.Kanban.Domain.Dtos
{
    public class CreateBoardDto
    {
        [Required]
        public string Name { get; set; }
    }
}
