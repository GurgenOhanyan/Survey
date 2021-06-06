using Microsoft.AspNetCore.Mvc;
using Survey.Models;
using Survey.Models.Repository;

namespace Survey.Controllers
{

    public class ParticipantController : Controller
    {
        private IParticipantRepository participantRepository;
        public ParticipantController(IParticipantRepository participantRepository)
        {
            this.participantRepository = participantRepository;
        }


        public ActionResult Index()
        {
            var partisipants = this.participantRepository.ReadAll();
            return View(partisipants);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Participant participant = this.participantRepository.ReadById(id);
            return View(participant);
        }

        [HttpPost]
        public ActionResult Edit(Participant participant)
        {
            if (!ModelState.IsValid)
                return View(participant);

            this.participantRepository.Update(participant);
            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind("FirstName, LastName, BirthDate")] Participant participant)
        {
            if (ModelState.IsValid)
                this.participantRepository.Add(participant);

            return RedirectToAction(nameof(Index));

        }

        //[HttpPost]
        ////[Route("create")]
        //public ActionResult Create([Bind(include: "FirstName, Lastname, BirthDate")] Participant participant)
        //{
        //    Participant p = new Participant();
        //    if (!ModelState.IsValid)
        //    {
        //        participantRepository.Create(participant);
        //    }

        //    return View(participant);
        //}

        ////[HttpGet]
        ////[Route("all")]
        ////public IActionResult AllParticipants()
        ////{
        ////    var partisipants = this.participantRepository.ReadAll();
        ////    return View(partisipants);
        ////}
    }
}
