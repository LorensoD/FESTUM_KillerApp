using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FestumClasses.Objects;

namespace FESTUMTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private User user;

        [TestInitialize]
        public void TestInitialize()
        {
            User toAdd = new User(1, "Lorrie");
            this.user = toAdd;
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual("Lorrie", user.Gebruikersnaam, "The username and string are expected to be equal");
        }
    }
}
