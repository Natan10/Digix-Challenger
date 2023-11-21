
using Digix.Domain.Entities;
using Digix.Domain.Handlers;

namespace Digix.Test.Entities
{
    public class FamilyAnalysisTest
    {

        /*
            FirstRule -  false
            SecondRule - false
            ThirdRule - false
            FourthRule - true
            Score - 3
        */
        [Fact(DisplayName = "Check valid analysis")]
        public void CheckHalfAnalysis()
        {
            var familyMemberOne = new Person(
             name: "Person one",
             cpf: "92961901006",
             birthDate: new DateTime(2010, 02, 24),
             income: 0
           );

            var familyMemberTwo = new Person(
                name: "Person two",
                cpf: "38471853060",
                birthDate: new DateTime(2006, 05, 20),
                income: 0
            );

            var familyMemberThree = new Person(
                name: "Person three",
                cpf: "25161537086",
                birthDate: new DateTime(2023, 01, 01),
                income: 0
            );

            var familyMemberFour = new Person(
                name: "Person four",
                cpf: "25161537086",
                birthDate: new DateTime(1997, 02, 24),
                income: 200
            );

            var familyMemberFive = new Person(
                name: "Person five",
                cpf: "39761723089",
                birthDate: new DateTime(1985, 06, 10),
                income: 1500,
                isSpouse: true
            );

            var family = new Family();

            family.AddFamilyMember(familyMemberOne);
            family.AddFamilyMember(familyMemberTwo);
            family.AddFamilyMember(familyMemberThree);
            family.AddFamilyMember(familyMemberFour);
            family.AddFamilyMember(familyMemberFive);

            var firstRuleHandler = new FirstRuleHandler();
            var secondRuleHandler = new SecondRuleHandler();
            var thirdRuleHandler = new ThirdRuleHandler();
            var fourthRuleHandler = new FourthRuleHandler();

            var handlerRules = new HandlerRules(firstRuleHandler, secondRuleHandler, thirdRuleHandler, fourthRuleHandler);

            var analysisRules = new AnalysisRules();

            var familyAnalysis = new FamilyAnalysis(family, analysisRules);


            // Act
            familyAnalysis.ExecuteAnalysis(handlerRules);

            // Assert
            Assert.Equal(3, familyAnalysis.Score);
        }


        /*
           FirstRule -  true
           SecondRule - false
           ThirdRule - true
           FourthRule - false
           Score - 8  
        */
        [Fact]    
        public void CheckFullAnalysis()
        {
            var familyMemberOne = new Person(
             name: "Person one",
             cpf: "92961901006",
             birthDate: new DateTime(2010, 02, 24),
             income: 0
           );

            var familyMemberTwo = new Person(
                name: "Person two",
                cpf: "25161537086",
                birthDate: new DateTime(1997, 02, 24),
                income: 0
            );

            var familyMemberThree = new Person(
                name: "Person five",
                cpf: "39761723089",
                birthDate: new DateTime(1985, 06, 10),
                income: 900,
                isSpouse: true
            );

            var family = new Family();

            family.AddFamilyMember(familyMemberOne);
            family.AddFamilyMember(familyMemberTwo);
            family.AddFamilyMember(familyMemberThree);


            var firstRuleHandler = new FirstRuleHandler();
            var secondRuleHandler = new SecondRuleHandler();
            var thirdRuleHandler = new ThirdRuleHandler();
            var fourthRuleHandler = new FourthRuleHandler();

            var handlerRules = new HandlerRules(firstRuleHandler, secondRuleHandler, thirdRuleHandler, fourthRuleHandler);

            var analysisRules = new AnalysisRules();

            var familyAnalysis = new FamilyAnalysis(family, analysisRules);


            // Act
            familyAnalysis.ExecuteAnalysis(handlerRules);

            // Assert
            Assert.Equal(8, familyAnalysis.Score);
        }
    }
}
