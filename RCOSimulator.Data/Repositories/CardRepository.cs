using Microsoft.EntityFrameworkCore;
using RCOSimulator.Data.Globals;
using RCOSimulator.Data.Models;
using RCOSimulator.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Repositories
{
    public interface ICardRepository : IBaseRepository<int, Card> 
    {
        Card CreateCard(CardCreateModel model);
    }
    public class CardRepository : BaseRepository<int, Card>, ICardRepository
    {
        public CardRepository(IUnitOfWork uow, DbContext dbContext) : base(uow, dbContext)
        {
        }

        public Card CreateCard(CardCreateModel model)
        {
            var mapper = _uow.GetMapper();
            var card = mapper.Map<Card>(model);
            return Create(card);
        }

        public override Card Get(int id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

    }
}
