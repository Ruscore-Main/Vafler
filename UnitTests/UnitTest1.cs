using ArmREST;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class TestRegistration
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(ValidateTest.ValidateRegistration("lg", "1234", "FIO"), "Длина логина должна быть больше 3х символов");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(ValidateTest.ValidateRegistration("login", "123", "FIO"), "Длина пароля должна быть больше 4х символов");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(ValidateTest.ValidateRegistration("login", "12345", "Surname Name"), "ФИО должно состоять из 3х слов");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(ValidateTest.ValidateRegistration("login", "12345", "Surname Name Patronymic"), "Успешно");
        }
    }
}
