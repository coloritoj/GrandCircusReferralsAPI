namespace GrandCircusReferralsAPI.Models
{
    public class UpdateApplicationStatusModel
    {
        public int CandidateID { get; set; }

        public int InterestFlag { get; set; }

        public int Applicationstatus { get; set; }

        public string Note { get; set; }
    }
}
