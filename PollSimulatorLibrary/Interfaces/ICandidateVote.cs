using PollSimulator.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PollSimulatorLibrary.Interfaces
{
    public interface ICandidateVote
    {
        public List<Candidate> GetAllCandidates();
        public string VoteTo(string VoterId, string CandidateId);
        public string CreateCandidate(Candidate c);
        public Candidate GetWinner();
        public Candidate GetLoser();
    }
}
