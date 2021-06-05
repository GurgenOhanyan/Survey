using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survey.Models;
using Survey.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    [ApiController]
    [Route("Participant")]
    public class ParticipantController : Controller
    {
        private IParticipantRepository participantRepository;
        public ParticipantController(IParticipantRepository participantRepository)
        {
            this.participantRepository = participantRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult<Participant> PostParticipant(Participant participant)
        {
            if (!ModelState.IsValid)
                return View(participant);

            try 
            {
                this.participantRepository.Create(participant);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to create record:  {ex.Message}");
                return View(participant);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
