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
    public interface IAccessGroupCardRepository : IBaseRepository<int, AccessGroupCard>
    {
        AccessGroupCard CreateAccessGroupCard(CardAssignmentModel model);
        AccessGroupCard RemoveByPairId(CardAssignmentModel model);
        void RemoveByPairIds(List<CardAssignmentModel> models);
    }

    public class AccessGroupCardRepository : BaseRepository<int, AccessGroupCard>, IAccessGroupCardRepository
    {
        public AccessGroupCardRepository(IUnitOfWork uow, DbContext dbContext) : base(uow, dbContext)
        {
        }

        public AccessGroupCard CreateAccessGroupCard(CardAssignmentModel model)
        {
            var mapper = _uow.GetMapper();
            var accessGroupCard = mapper.Map<AccessGroupCard>(model);
            return Create(accessGroupCard);
        }

        public override AccessGroupCard Get(int id)
        {
            throw new NotImplementedException();
        }

        public AccessGroupCard RemoveByPairId(CardAssignmentModel model)
        {
            var entity = GetAll().FirstOrDefault(ac => ac.AccessGroupId == model.AccessGroupId && ac.CardId == model.CardId);
            return Remove(entity);
        }

        public void RemoveByPairIds(List<CardAssignmentModel> models)
        {
            foreach(var model in models)
            {
                RemoveByPairId(model);
            }
        }
    }
}
