using Digix.Domain.Entities;

namespace Digix.Test.Entities
{
    public class FamilyTest
    {
        [Fact(DisplayName = "Create valid family")]
        public void CreateValidFamily()
        {
            // Arrange 
            var familyMemberOne = new Person(
              name: "Person one",
              cpf: "92961901006",
              birthDate: new DateTime(2010, 02, 24),
              income: 0
            );

            var familyMemberTwo = new Person(
              name: "Person two",
              cpf: "39024493064",
              birthDate: new DateTime(2002, 02, 24),
              income: 500
            );

            var familyMemberThree = new Person(
              name: "Person three",
              cpf: "39024493064",
              birthDate: new DateTime(1990, 06, 10),
              income: 900,
              isSpouse: true
            );

            var family = new Family();

            // Act
            family.AddFamilyMember(familyMemberOne);
            family.AddFamilyMember(familyMemberTwo);
            family.AddFamilyMember(familyMemberThree);


            // Assert
            Assert.NotNull(family);
            Assert.Equal(3, family.TotalMembers);
        }


        [Fact(DisplayName = "Try to create family with two or more Spouses")]
        public void CreateInvalidFamily()
        {
            // Arrange
            var familyMemberOne = new Person(
            name: "Person one",
            cpf: "92961901006",
            birthDate: new DateTime(2010, 02, 24),
            income: 0
          );

            var familyMemberTwo = new Person(
              name: "Person two",
              cpf: "39024493064",
              birthDate: new DateTime(2002, 02, 24),
              income: 500,
              isSpouse: true
            );

            var familyMemberThree = new Person(
              name: "Person three",
              cpf: "39024493064",
              birthDate: new DateTime(1990, 06, 10),
              income: 900,
              isSpouse: true
            );

            var family = new Family();

            // Act
            Action createFamily = new Action(() =>
            {
                family.AddFamilyMember(familyMemberOne);
                family.AddFamilyMember(familyMemberTwo);
                family.AddFamilyMember(familyMemberThree);
            });

            // Assert
            var exception = Assert.Throws<Exception>(createFamily);

            Assert.Equal("A Família já possui um cônjuge", exception.Message);
        }


        [Fact(DisplayName = "Check family income")]
        public void CheckFamilyIncomeBySpouse()
        {
            // Arrange 
            var familyMemberOne = new Person(
              name: "Person one",
              cpf: "92961901006",
              birthDate: new DateTime(2010, 02, 24),
              income: 0
            );

            var familyMemberTwo = new Person(
              name: "Person two",
              cpf: "39024493064",
              birthDate: new DateTime(2002, 02, 24),
              income: 500
            );

            var familyMemberThree = new Person(
              name: "Person three",
              cpf: "39024493064",
              birthDate: new DateTime(1990, 06, 10),
              income: 900,
              isSpouse: true
            );

            var family = new Family();
            family.AddFamilyMember(familyMemberOne);
            family.AddFamilyMember(familyMemberTwo);
            family.AddFamilyMember(familyMemberThree);


            // Act
            var familyIncome = family.FamilyIncome;

            // Assert 
            Assert.Equal(1400, familyIncome);
        }


        [Fact(DisplayName = "Check family dependents")]
        public void CheckFamilyDependents()
        {
            // Arrange 
            var familyMemberOne = new Person(
              name: "Person one",
              cpf: "92961901006",
              birthDate: new DateTime(2010, 02, 24),
              income: 0
            );

            var familyMemberTwo = new Person(
              name: "Person two",
              cpf: "39024493064",
              birthDate: new DateTime(2006, 02, 24),
              income: 0
            );

            var familyMemberThree = new Person(
              name: "Person three",
              cpf: "79364431006",
              birthDate: new DateTime(1997, 02, 24),
              income: 0
            );

            var familyMemberFour = new Person(
              name: "Person four",
              cpf: "93614199002",
              birthDate: new DateTime(1995, 10, 12),
              income: 0
            );

            var familyMemberFive = new Person(
              name: "Person three",
              cpf: "49785714055",
              birthDate: new DateTime(1975, 11, 11),
              income: 2000,
              isSpouse: true
            );

            var family = new Family();
            family.AddFamilyMember(familyMemberOne);
            family.AddFamilyMember(familyMemberTwo);
            family.AddFamilyMember(familyMemberThree);
            family.AddFamilyMember(familyMemberFour);
            family.AddFamilyMember(familyMemberFive);

            // Act
            var familyDependents = family.GetDependents();

            // Assert
            Assert.Equal(2, familyDependents.Count);

        }

    }
}
