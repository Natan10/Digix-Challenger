
using Digix.Domain.Entities;

namespace Digix.Test.Entities
{
    public class PersonTest
    {

        [Fact(DisplayName = "Create Family Person with valid cpf")]
        public void ValidCreatedPerson()
        {
            // Arrange
            var name = "Person 1";
            var cpf = "87991774040";
            var birthDate = new DateTime(1997, 02, 24);
            var income = 0;
            var isSpouse = false;

            // Act
            Action createFamilyPerson = () =>
            {
                Person person = new Person(name, cpf, birthDate, income, isSpouse);
            };

            // Assert
            Assert.NotNull(createFamilyPerson);
        }

        [Fact(DisplayName = "Try create person with invalid cpf")]
        public void InvalidCreatedPerson()
        {
            // Arrange
            var name = "Person 1";
            var cpf = "8799177404055";
            var birthDate = new DateTime(1997, 02, 24);
            var income = 0;
            var isSpouse = false;

            // Act
            Action createFamilyPerson = () => new Person(name, cpf, birthDate, income, isSpouse);
        
            var exception = Assert.Throws<Exception>(createFamilyPerson);

            // Assert
            Assert.Equal("Cpf inválido", exception.Message);
            
        }
    }
}
