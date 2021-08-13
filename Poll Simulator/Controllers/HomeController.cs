using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poll_Simulator.Models;
using Poll_Simulator.Repository;
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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CandidatesForElection cfe = new CandidatesForElection();
            return View(cfe);
        }

      
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

            List<string> CandidateList = CandidatesRepository.GetVotersList();


            if (CandidateList.Count != 0)
            {
                if (CandidateList.Exists(x => x == c.StudentIdOfVoter))
                {
                    c.VoteStatus = c.StudentIdOfVoter + ", you have already voted!";
                    return View("Index", c);
                }
            }

            CandidatesRepository.AddVoters(c.StudentIdOfVoter);
            CandidatesRepository.IncrementVote(c.SelectedCandidate);
            c.VoteStatus = c.StudentIdOfVoter + ", your vote has been recorded successfully.";
            return View("Index", c);

        }
      

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
