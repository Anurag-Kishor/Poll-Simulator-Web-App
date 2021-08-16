using PollSimulator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll_Simulator.Models
{
    public class ElectionResult
    {
        public List<Candidate> CandidateList { get; set; } = null;
        public Candidate FirstCandidate { get; set; } = null;
        public Candidate SecondCandidate { get; set; } = null;

    }
}
