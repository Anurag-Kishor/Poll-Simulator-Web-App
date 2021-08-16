using PollSimulator.Domain;
using PollSimulatorLibrary.Interfaces;
using PollSimulatorLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PollSimulatorLibrary
{
    public class CandidateVote : ICandidateVote
    {
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
        public List<Candidate> GetAllCandidates()
        {
            return CandidatesRepository.GetCandidates();
        }

        public Candidate GetLoser()
        {
            List<Candidate> SortedList = CandidatesRepository.GetCandidates().OrderByDescending(o => o.VoteCount).ToList();

            if (SortedList.Count != 0)
            {
                if (SortedList.Count >= 2)
                {
                    return SortedList[1];
                }
            }
            return null;
        }

        public Candidate GetWinner()
        {
            List<Candidate> SortedList = CandidatesRepository.GetCandidates().OrderByDescending(o => o.VoteCount).ToList();

            if (SortedList.Count != 0)
            {
                if (SortedList.Count >= 1)
                {
                    return SortedList[0];
                }
            }
            return null;
        }

        public string VoteTo(string VoterId, string CandidateId)
        {
            List<string> CandidateList = CandidatesRepository.GetVotersList();
            if (CandidateList.Count != 0)
            {
                if (CandidateList.Exists(x => x == VoterId))
                {
                   return VoterId + ", you have already voted!";
                    
                }
            }
            CandidatesRepository.AddVoters(VoterId);
            CandidatesRepository.IncrementVote(CandidateId);
            return VoterId + ", your vote has been recorded successfully.";
        }
    }
}
