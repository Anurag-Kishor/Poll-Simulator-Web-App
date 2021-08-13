using Poll_Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll_Simulator.Repository
{
    public static class CandidatesRepository
    {
        public static List<Candidate> CandidateList { get; set; }
        public static List<string> VotersID { get; set; }

        static CandidatesRepository()
        {
            CandidateList = new List<Candidate>();
            VotersID = new List<string>();
        }
        public static void AddCandidate(Candidate c)
        {
            CandidateList.Add(c);
        }

        public static List<Candidate> GetCandidates()
        {
            return CandidateList;
        }
        public static void AddVoters(string c)
        {
            VotersID.Add(c);
        }

        public static void IncrementVote(string id)
        {
            Candidate c = CandidateList.Find(x => x.StudentID == id);
            c.VoteCount++;
        }

        public static List<string> GetVotersList()
        {
            return VotersID;
        }

       
    }
}
