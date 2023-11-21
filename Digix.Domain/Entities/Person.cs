namespace Digix.Domain.Entities
{
    public class Person
    {
        public string Cpf { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal Income { get; set; } = 0;

        public bool IsSpouse { get; set; } = false;

        public Person(string name, string cpf, DateTime birthDate, decimal income, bool? isSpouse = false)
        {
            ValidCpf(cpf);
            Cpf = cpf;
            Name = name;
            Income = income;
            BirthDate = birthDate;
            IsSpouse = isSpouse ?? false;
        }

        private static void ValidCpf(string cpf)
        {
            if (cpf.Length != 11)
            {
                throw new Exception("Cpf inválido");
            }
        }
    }
}
