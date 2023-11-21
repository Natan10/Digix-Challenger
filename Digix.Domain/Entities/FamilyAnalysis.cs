using Digix.Domain.Handlers;

namespace Digix.Domain.Entities
{
    public class FamilyAnalysis
    {
        public int Id { get; set; }

        public Family Family { get; set; }

        public int Score { get; private set; }

        public List<string> Notifications { get; set; } = new List<string>();

        public AnalysisRules Analysis { get; set; }

        public FamilyAnalysis(Family family, AnalysisRules analysisRules)
        {
            Family = family;
            Analysis = analysisRules;
        }

        public void ExecuteAnalysis(HandlerRules handler)
        {
            handler.ExecuteRules(this);
            Score = Analysis.GetScore();
        }
    }
}
