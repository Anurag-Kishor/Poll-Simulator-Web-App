using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poll_Simulator.Models;
using PollSimulator.Domain;
using PollSimulatorLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Poll_Simulator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICandidateVote pollSimulatorLib;

        public HomeController(ILogger<HomeController> logger, ICandidateVote libInstance)
        {
            pollSimulatorLib = libInstance;
            _logger = logger;
        }
      

        public IActionResult Index()
        {
            CandidatesForElection cfe = new CandidatesForElection();
            cfe.AllCandidates = pollSimulatorLib.GetAllCandidates();
            return View(cfe);
        }

        //POST /home
        [HttpPost]
        public IActionResult Index(CandidatesForElection c)
        {

            if (string.IsNullOrEmpty(c.SelectedCandidate))
            {
                c.VoteStatus = "You did not select any candidate";
                return View("Index", c);
            }
            if (string.IsNullOrEmpty(c.StudentIdOfVoter))
            {
                c.VoteStatus= "You need to enter your student ID to cast a vote";
                return View("Index", c);
            }
            c.AllCandidates = pollSimulatorLib.GetAllCandidates();
            c.VoteStatus = pollSimulatorLib.VoteTo(c.StudentIdOfVoter, c.SelectedCandidate);
            return View("Index", c);

        }
      

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
