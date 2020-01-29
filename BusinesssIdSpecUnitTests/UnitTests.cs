using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BusinesssIdSpecUnitTests
{
    [TestClass]
    public class UnitTests
    {

        private List<string> getReasonList(BusinessIdSpecification.BusinessIdSpecification BIClass)
        {

            List<string> reasonList = BIClass.ReasonsForDissatisfaction.ToList();
            return reasonList;
        }

        [TestMethod]
        public void SimpleIsSatisfiedFailsTest() {
            // Arrange
            string BID = "1234657-1324423";
            var b = new BusinessIdSpecification.BusinessIdSpecification();

            // Act & Assert 
            Assert.IsFalse(b.IsSatisfiedBy(BID));
        }

        [TestMethod]
        public void SimpleIsSatisfiedSucceedTest()
        {
            // Arrange
            string BID = "1234657-1";
            var b = new BusinessIdSpecification.BusinessIdSpecification();

            // Act & Assert 
            Assert.IsTrue(b.IsSatisfiedBy(BID));
        }

        [TestMethod]
        public void IsSatisfiedFailsWithNoData()
        {
            // Arrange
            string BID = "";
            var b = new BusinessIdSpecification.BusinessIdSpecification();

            // Act & Assert 
            Assert.IsFalse(b.IsSatisfiedBy(BID));
        }

        [TestMethod]
        public void IsSatisfiedFailsWithNullData()
        {
            // Arrange
            string BID = null;
            var b = new BusinessIdSpecification.BusinessIdSpecification();

            // Act & Assert 
            Assert.IsFalse(b.IsSatisfiedBy(BID));
        }
        [TestMethod]
        public void ReasonForDissatisfactionWithNullData()
        {
            // Arrange
            string BID = null;
            var b = new BusinessIdSpecification.BusinessIdSpecification();

            // Act
            b.IsSatisfiedBy(BID);
            
            // Assert
            Assert.AreEqual("No value provided", getReasonList(b)[0]);
        }
        [TestMethod]
        public void ReasonForDissatisfactionWithTooShortData()
        {
            // Arrange
            string BID = "1234-4";
            var b = new BusinessIdSpecification.BusinessIdSpecification();

            // Act
            b.IsSatisfiedBy(BID);

            // Assert
            Assert.AreEqual("Value too short", getReasonList(b)[0]);
        }
        [TestMethod]
        public void ReasonForDissatisfactionWithTooLongData()
        {
            // Arrange
            string BID = "1234234234234-4";
            var b = new BusinessIdSpecification.BusinessIdSpecification();

            // Act
            b.IsSatisfiedBy(BID);

            // Assert
            Assert.AreEqual("Value too long", getReasonList(b)[0]);
        }
        [TestMethod]
        public void ReasonForDissatisfactionWithNonNumericalValues()
        {
            // Arrange
            string BID = "1234s6d-5";
            var b = new BusinessIdSpecification.BusinessIdSpecification();

            // Act
            b.IsSatisfiedBy(BID);

            // Assert
            Assert.AreEqual("ID or the control mark contains non numeric values", getReasonList(b)[0]);
        }
        [TestMethod]
        public void ReasonForDissatisfactionWithIncorrectFormatting()
        {
            // Arrange
            string BID = "123456-52";
            var b = new BusinessIdSpecification.BusinessIdSpecification();

            // Act
            b.IsSatisfiedBy(BID);

            // Assert
            Assert.AreEqual("Value formatting is incorrect", getReasonList(b)[0]);
        }
        [TestMethod]
        public void ReasonForDissatisfactionWithIncorrectFormattingTooManyDashes()
        {
            // Arrange
            string BID = "12-456-52";
            var b = new BusinessIdSpecification.BusinessIdSpecification();

            // Act
            b.IsSatisfiedBy(BID);

            // Assert
            Assert.AreEqual("Value formatting is incorrect", getReasonList(b)[0]);
        }
        [TestMethod]
        public void ReasonForDissatisfactionWithIncorrectFormattingTooManyDashes2()
        {
            // Arrange
            string BID = "---------";
            var b = new BusinessIdSpecification.BusinessIdSpecification();

            // Act
            b.IsSatisfiedBy(BID);

            // Assert
            Assert.AreEqual("ID or the control mark contains non numeric values", getReasonList(b)[0]);
            Assert.AreEqual("Value formatting is incorrect", getReasonList(b)[1]);
        }
    }
}
