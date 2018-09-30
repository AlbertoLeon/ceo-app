using CeoApi.Shares;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Linq;

namespace Ceo.Shares.Tests
{
    [TestClass]
    public class ConstitutionDefinitionTests
    {
        [TestMethod]
        public void First_Addition_of_Share_Holder__Number_of_Shares_Equal_To_Cents_Paid()
        {
            // Arrange
            CultureInfo ci = new CultureInfo("es-es");
            int shareValue = 1; // €0.01
            string investorName = "Alberto Leon";
            float investmentAmount = 1000; // €1,000.00
            var definition = new ConstitutionDefinition(shareValue);
            int investedCents = (int)(investmentAmount * 100); // Euros to cents

            // Act
            definition.AddHolder(investorName, investmentAmount); // Alberto invested €1,000

            // Assert
            definition.NumberOfShares.Should().Be(investedCents,
                "Because one share cost {0} cent and {1} paid {2} that is a total of cents of {3}",
                shareValue, investorName, investmentAmount.ToString("c", ci), investedCents);
        }

        [TestMethod]
        public void First_Addition_of_Share_Holder__Companys_Book_Value_Equal_To_Amount_Paid()
        {
            // Arrange
            CultureInfo ci = new CultureInfo("es-es");
            int shareValue = 1; // €0.01
            string investorName = "Alberto Leon";
            float investmentAmount = 1000; // €1,000.00
            var definition = new ConstitutionDefinition(shareValue);

            // Act
            definition.AddHolder(investorName, investmentAmount); // Alberto invested €1,000

            // Assert
            definition.BookValue.Should().Be(investmentAmount,
                "Because {0} is the first contribution to the company and the previous value was 0",
                investmentAmount.ToString("c", ci));
        }

        [TestMethod]
        public void First_Addition_of_Share_Holder__Unique_Share_Holder_Owns_All_Shares()
        {
            // Arrange
            int bookShareValue = 1; // €0.01
            string investorName = "Alberto Leon";
            float investmentAmount = 1000; // €1,000.00
            var definition = new ConstitutionDefinition(bookShareValue);

            // Act
            definition.AddHolder(investorName, investmentAmount); // Alberto invested €1,000

            // Assert
            var uniqueHolder = definition.ShareHolders.First();
            uniqueHolder.OwnedShares.Should().Be(definition.NumberOfShares,
                "Because the constitution shares are the onces owned by the share holders and there is only one share holder");
        }

        [TestMethod]
        public void First_Addition_of_Share_Holder__Unique_Share_Holder_Owns_The_100_percentage()
        {
            // Arrange
            int bookShareValue = 1; // €0.01
            string investorName = "Alberto Leon";
            float investmentAmount = 1000; // €1,000.00
            var definition = new ConstitutionDefinition(bookShareValue);
            float expectedPercentage = 100;

            // Act
            definition.AddHolder(investorName, investmentAmount); // Alberto invested €1,000

            // Assert
            var uniqueHolder = definition.ShareHolders.First();
            uniqueHolder.Percentage.Should().Be(expectedPercentage,
                "Because there are only the shares of the holders and there is only one holder");
        }
    }
}
