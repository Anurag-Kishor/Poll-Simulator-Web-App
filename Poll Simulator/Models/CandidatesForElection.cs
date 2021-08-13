using Poll_Simulator.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll_Simulator.Models
{
    public class CandidatesForElection
    {
        public string SelectedCandidate { get; set; }
        public string StudentIdOfVoter { get; set; }
        public string VoteStatus { get; set; } = "";
        public List<Candidate> AllCandidates
        {
            get
            {
                return CandidatesRepository.GetCandidates();
            }
        }
    }
}
