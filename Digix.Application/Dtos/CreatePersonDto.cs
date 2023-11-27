namespace Digix.Application.Dtos
{
    public class CreatePersonDto
    {
        public string Cpf { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal Income { get; set; } = 0;

        public bool IsSpouse { get; set; } = false;

    }
}
