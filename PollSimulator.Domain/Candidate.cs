using System;

namespace PollSimulator.Domain
{
    public class Candidate
    {
        public string StudentID { get; set; }
        public string Name { get; set; }
        public int VoteCount { get; set; }
    }
}
