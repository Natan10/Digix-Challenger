namespace Digix.Application.Dtos
{
    public class FamilyAnalysisDto
    {
        public int Id { get; set; }

        public int Score { get; private set; }

        public FamilyDto Family { get; set; }
    }
}
