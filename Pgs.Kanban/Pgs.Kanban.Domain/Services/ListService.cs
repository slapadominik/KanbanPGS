using System.Linq;
using Pgs.Kanban.Domain.Dtos;
using Pgs.Kanban.Domain.Models;

namespace Pgs.Kanban.Domain.Services
{
    public class ListService
    {
        private readonly KanbanContext _context;

        public ListService()
        {
            _context = new KanbanContext();
        }

        public ListDto AddList(AddListDto addListDto)
        {
            if (!_context.Boards.Any(x => x.Id == addListDto.BoardId))
            {
                return null;
            }

            var list = new List
            {
                Name = addListDto.Name,
                BoardId = addListDto.BoardId
            };

            _context.Lists.Add(list);
            _context.SaveChanges();

            var listDto = new ListDto
            {
                Id = list.Id,
                BoardId = list.BoardId,
                Name = list.Name
            };

            return listDto;
        }

        public bool EditListName(EditListNameDto editListNameDto)
        {
            if (!_context.Boards.Any(x => x.Id == editListNameDto.BoardId))
            {
                return false;
            }

            var list = _context.Lists.SingleOrDefault(l => l.Id == editListNameDto.ListId);
            if (list == null || list.Name == editListNameDto.Name)
            {
                return false;
            }

            list.Name = editListNameDto.Name;
            //edytowanie obiektow z bazy danych mozna updatowac w ten sposob, ze pobieramy obiekt z contextu
            //nastepnie zmieniamy tylko property ktore chcemy zmienic i robimy saveChanges na 
            var result = _context.SaveChanges();

            return result > 0;

        }
    }
}
