namespace Digix.Domain.Entities
{
    public class Family
    {

        public Guid FamilyId { get; set; } = Guid.NewGuid();

        public List<Person> FamilyMembers { get; private set; } = new List<Person>();

        public int TotalMembers => FamilyMembers.Count;

        public decimal FamilyIncome => FamilyMembers.Sum(p => p.Income);


        public Person? GetSpouse()
        {
            return FamilyMembers.FirstOrDefault(p => p.IsSpouse);
        }

        public void AddFamilyMember(Person person)
        {
            var spousePerson = GetSpouse();

            if (spousePerson != null && person.IsSpouse)
            {
                throw new Exception("A Família já possui um cônjuge");
            }

            FamilyMembers.Add(person);
        }

        public List<Person> GetDependents()
        {
            return FamilyMembers.FindAll(e => !e.IsSpouse && CompareDates(e.BirthDate) < 18);
        }

        private static double CompareDates(DateTime date)
        {
            var currentDate = DateTime.Now;
            var comparison = currentDate.Subtract(date);

            return Math.Truncate(comparison.TotalDays / 365);
        }
    }
}
