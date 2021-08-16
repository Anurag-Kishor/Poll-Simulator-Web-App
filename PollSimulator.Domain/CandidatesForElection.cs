using System;
using System.Collections.Generic;
using System.Text;

namespace PollSimulator.Domain
{
   public class CandidatesForElection
    {
        public string SelectedCandidate { get; set; }
        public string StudentIdOfVoter { get; set; }
        public string VoteStatus { get; set; } = "";
        public List<Candidate> AllCandidates { get; set; }
    }
}
