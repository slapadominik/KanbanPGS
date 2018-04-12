using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pgs.Kanban.Domain.Dtos;
using Pgs.Kanban.Domain.Models;

namespace Pgs.Kanban.Domain.Services
{
    public class BoardService
    {
        private readonly KanbanContext _context;

        public BoardService()
        {
            _context = new KanbanContext();
        }

        public BoardDto GetBoard()
        {
            var board = _context.Boards
                .Include(b => b.Lists)
                .LastOrDefault();

            if (board == null)
            {
                return null;
            }

            var boardDto = new BoardDto()
            {
                Id = board.Id,
                Name = board.Name,
                Lists = board.Lists.Select(l => new ListDto()
                {
                    Id = l.Id,
                    BoardId = l.BoardId,
                    Name = l.Name
                }).ToList()
            };

            return boardDto;
        }

        public BoardDto CreateBoard(CreateBoardDto createBoardDto)
        {
            var board = new Board()
            {
                Name = createBoardDto.Name
            };

            _context.Boards.Add(board);
            _context.SaveChanges();

            var boardDto = new BoardDto()
            {
                Id = board.Id,
                Name = board.Name
            };

            return boardDto;
        }
    }
}