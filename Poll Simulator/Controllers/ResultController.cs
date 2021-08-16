using Microsoft.AspNetCore.Mvc;
using Poll_Simulator.Models;
using PollSimulatorLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll_Simulator.Controllers
{
    public class ResultController : Controller
    {
        private readonly ElectionResult result;
        private readonly ICandidateVote pollSimulatorLib;
       
        public ResultController(ICandidateVote libInstance)
        {
            pollSimulatorLib = libInstance;
            result = new ElectionResult();
        }
        public IActionResult Index()
        {
            return View(result);
        }
        [HttpPost]
        public IActionResult GenerateReport()
        {
            result.CandidateList = pollSimulatorLib.GetAllCandidates();
            return View("Index", result);
        }

        [HttpPost]
        public IActionResult GenerateResult()
        {

            result.FirstCandidate = pollSimulatorLib.GetWinner();
            result.SecondCandidate = pollSimulatorLib.GetLoser();
            return View("Index", result);
        }
    }
}
