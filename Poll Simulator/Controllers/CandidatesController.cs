using Microsoft.AspNetCore.Mvc;
using Poll_Simulator.Models;
using Poll_Simulator.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll_Simulator.Controllers
{
    public class CandidatesController : Controller
    {
        public CandidatesController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public string CreateCandidate(Candidate c)
        {
            if (CandidatesRepository.GetCandidates().Exists(x => x.StudentID == c.StudentID))
            {
                return "Candidate with that ID already exists";
            }
            if (c.Name != null && c.StudentID != null)
            {
                c.VoteCount = 0;
                CandidatesRepository.AddCandidate(c);
                return "Candidate Created Successfully!";
            }
            else if (c.Name == null)
            {
                return "You need to enter a name!";
            }
            else
            {
                return "You need to enter the Student ID";
            }
        }

      
    }
}
