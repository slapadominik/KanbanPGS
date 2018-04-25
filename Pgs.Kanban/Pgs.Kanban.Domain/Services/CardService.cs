using System;
using System.Collections.Generic;
using System.Text;
using Pgs.Kanban.Domain.Dtos;
using Pgs.Kanban.Domain.Models;

namespace Pgs.Kanban.Domain.Services
{
    public class CardService
    {
        private readonly KanbanContext _context;

        public CardService()
        {
            _context = new KanbanContext();
        }

        public CardDto AddCard(AddCardDto addCardDto)
        {
            var card = new Card
            {
                CardName = addCardDto.CardName,
                ListId = addCardDto.ListId
            };
            _context.Add(card);
            _context.SaveChanges();
            var cardDto = new CardDto
            {
                CardId = card.CardId,
                CardName = card.CardName,
                ListId = card.ListId
            };
            return cardDto;
        }

    }
}
