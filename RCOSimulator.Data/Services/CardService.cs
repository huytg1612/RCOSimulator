using Microsoft.EntityFrameworkCore;
using RCOSimulator.Data.Globals;
using RCOSimulator.Data.Models;
using RCOSimulator.Data.Repositories;
using RCOSimulator.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCOSimulator.Data.Extensions;

namespace RCOSimulator.Data.Services
{
    public class CardService : BaseService
    {
        ICardRepository _repo;
        IAccessGroupCardRepository _repoAccessGroupCardRepository;
        IAccessGroupRepository _repoAccessGroupRepository;
        public CardService(IUnitOfWork uow) : base(uow)
        {
            _repo = _uow.GetService<ICardRepository>();
            _repoAccessGroupCardRepository = _uow.GetService<IAccessGroupCardRepository>();
            _repoAccessGroupRepository = _uow.GetService<IAccessGroupRepository>();
        }

        public CardModel Create(CardCreateModel model)
        {
            if (_repo.GetAll().AsNoTrackingWithIdentityResolution().FirstOrDefault(c => c.CardIdentity.Equals(model.CardIdentity)) != null)
                throw new Exception($"Card with identity{model.CardIdentity} is already existed");

            model.CardIdentityRaw = Encoding.ASCII.GetBytes(model.CardIdentity);
            var entity = _repo.CreateCard(model);
            var mapper = _uow.GetMapper();
            _uow.SaveChanges();
            return mapper.Map<CardModel>(entity);
        }

        public CardModel GetById(int id, bool isTracking = true)
        {
            var cards = _repo.GetAll();
            if (!isTracking)
                cards = cards.AsNoTrackingWithIdentityResolution();
            var card = cards.Include(c => c.User).Include(c => c.AccessGroups).ToList().FirstOrDefault(c => c.Id == id);
            if (card == null)
                return null;

            var mapper = _uow.GetMapper();
            return mapper.Map<CardModel>(card);
        }

        public List<CardModel> Get(QueryParameters parameters)
        {
            var cards = _repo.GetAll().Get(parameters).ToList();
            var mapper = _uow.GetMapper();
            return cards.ToList().Select(c => mapper.Map<CardModel>(c)).ToList();
        }

        public CardModel Update(CardUpdateMode model)
        {
            var mapper = _uow.GetMapper();
            var card = mapper.Map<Card>(model);
            card = _repo.Update(card);
            _uow.SaveChanges();
            return mapper.Map<CardModel>(card);
        }

        public CardModel AssignAccess(CardAssignmentModel model)
        {
            var mapper = _uow.GetMapper();
            var card = _repo.GetAll().Include(c => c.AccessGroups).FirstOrDefault(c => c.Id == model.CardId);
            var access = _repoAccessGroupRepository.Get(model.AccessGroupId);
            if (card == null || access == null)
                throw new Exception("Card or access not found");

            if (card.AccessGroups?.FirstOrDefault(a => a.Id == model.AccessGroupId) != null)
                return mapper.Map<CardModel>(card);

            _repoAccessGroupCardRepository.CreateAccessGroupCard(model);
            _uow.SaveChanges();
            card = _repo.GetAll().Include(c => c.AccessGroups).FirstOrDefault(c => c.Id == model.CardId);
            return mapper.Map<CardModel>(card);
        }

        public void RemoveAssignment(CardAssignmentModel model)
        {
            var card = _repo.Get(model.CardId);
            var access = _repoAccessGroupRepository.Get(model.AccessGroupId);
            if (card == null || access == null)
                throw new Exception("Card or access not found");

            var entity = _repoAccessGroupCardRepository.RemoveByPairId(model);
            _uow.SaveChanges();
            if (entity == null)
                throw new Exception("Remove access group card failed");
        }

        public void RemoveCard(CardModel model)
        {
            var cardAssignments = new List<CardAssignmentModel>();
            foreach(var accessgroup in model.AccessGroups)
            {
                cardAssignments.Add(new CardAssignmentModel
                {
                    AccessGroupId = accessgroup.Id,
                    CardId = model.Id
                });
            }

            _repoAccessGroupCardRepository.RemoveByPairIds(cardAssignments);

            var mapper = _uow.GetMapper();
            var card = mapper.Map<Card>(model);
            card = _repo.Remove(card);
            if (card == null)
                throw new Exception("Remove card failed");
            _uow.SaveChanges();
        }
    }
}
