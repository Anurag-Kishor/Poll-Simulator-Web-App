using Microsoft.AspNetCore.Mvc;
using Poll_Simulator.Models;
using Poll_Simulator.Repository;
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

        public ResultController()
        {
            result = new ElectionResult();
        }
        public IActionResult Index()
        {
            return View(result);
        }
        [HttpPost]
        public IActionResult GenerateReport()
        {
            result.CandidateList = CandidatesRepository.GetCandidates();
            return View("Index", result);
        }

        [HttpPost]
        public IActionResult GenerateResult()
        {
            List<Candidate> SortedList = CandidatesRepository.GetCandidates().OrderByDescending(o => o.VoteCount).ToList();

            if(SortedList.Count != 0)
            {
                if (SortedList.Count >= 1)
                {
                    result.FirstCandidate = SortedList[0];
                }
                if(SortedList.Count >= 2)
                {
                    result.SecondCandidate = SortedList[1];
                }
            }
            return View("Index", result);
        }
    }
}
