using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCOSimilator.API.RCOAuthentication;
using RCOSimulator.Data.Globals;
using RCOSimulator.Data.Services;
using RCOSimulator.Data.ViewModels;

namespace RCOSimilator.API.Controllers
{
    [Route("/api/card")]
    [ApiController]
    public class CardController : BaseController
    {
        CardService _service;

        public CardController(IUnitOfWork uow) : base(uow)
        {
            _service = _uow.GetService<CardService>();
        }

        [HttpPost]
        [ApiKey]
        public IActionResult Create(CardCreateModel model)
        {
            try
            {
                var entity = _service.Create(model);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [ApiKey]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        [HttpGet("{id}")]
        [ApiKey]
        public IActionResult GetDetail(int id) 
        {
            var result = _service.GetById(id);
            if (result == null)
                return NotFound("Card not found");
            return Ok(result);
        }

        [HttpPatch("{id}")]
        [ApiKey]
        public IActionResult UpdateCard(int id, [FromBody]CardUpdateMode cardModel)
        {
            var card = _service.GetById(id, false);
            if (card == null)
                return NotFound("Card not found");
            cardModel.Id = id;
            var result = _service.Update(cardModel);
            return Ok(result);
        }

        [HttpPut("{CID}/accessgroup/{AID}")]
        [ApiKey]
        public IActionResult AssignAccess(int CID, int AID)
        {
            var service = _uow.GetService<CardService>();
            return Ok(service.AssignAccess(new CardAssignmentModel { CardId = CID, AccessGroupId = AID }));
        }

        [HttpDelete("{CID}/accessgroup/{AID}")]
        [ApiKey]
        public IActionResult DeleteAssignment(int CID, int AID)
        {
            var service = _uow.GetService<CardService>();
            service.RemoveAssignment(new CardAssignmentModel { CardId = CID, AccessGroupId = AID });
            return Ok(true);
        }

        [HttpDelete("{id}")]
        [ApiKey]
        public IActionResult DeleteCard(int id)
        {
            var card = _service.GetById(id, false);
            if(card == null)
                return NotFound("Card not found");

            _service.RemoveCard(card);
            return Ok(true);
        }
    }
}
