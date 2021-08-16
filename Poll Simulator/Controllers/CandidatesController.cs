using Microsoft.AspNetCore.Mvc;
using Poll_Simulator.Models;
using PollSimulator.Domain;
using PollSimulatorLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll_Simulator.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidateVote pollSimulatorLib;
        public CandidatesController(ICandidateVote libInstance)
        {
            pollSimulatorLib = libInstance;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public string CreateCandidate(Candidate c)
        {
            return pollSimulatorLib.CreateCandidate(c);
        }

      
    }
}
