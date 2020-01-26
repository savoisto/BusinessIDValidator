using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessIdSpecification;

namespace BusinesssIdSpecUnitTests
{
    [TestClass]
    public class UnitTests
    {

        [TestMethod]
        public void SimpleIsSatisfiedFailsTest() {
            // Arrange
            string BID = "1234657-1324423";

            // Act & Assert 
            var b = new BusinessIdSpecification.BusinessIdSpecification();
            Assert.IsFalse(b.IsSatisfiedBy(BID));
        }

        [TestMethod]
        public void SimpleIsSatisfiedSucceedTest()
        {
            // Arrange
            string BID = "1234657-1";

            // Act & Assert 
            var b = new BusinessIdSpecification.BusinessIdSpecification();
            Assert.IsTrue(b.IsSatisfiedBy(BID));
        }

        [TestMethod]
        public void IsSatisfiedFailsWithNoData()
        {
            // Arrange
            string BID = "";

            // Act & Assert 
            var b = new BusinessIdSpecification.BusinessIdSpecification();
            Assert.IsFalse(b.IsSatisfiedBy(BID));
        }

        [TestMethod]
        public void IsSatisfiedFailsWithNullData()
        {
            // Arrange
            string BID = null;

            // Act & Assert 
            var b = new BusinessIdSpecification.BusinessIdSpecification();
            Assert.IsFalse(b.IsSatisfiedBy(BID));
        }
    }
}
