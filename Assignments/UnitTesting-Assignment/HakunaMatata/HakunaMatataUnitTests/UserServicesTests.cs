using HakunaMatata.Models;
using NUnit.Framework;
using HakunaMatata.Services;
using HakunaMatata.Repositories;
using System.Collections.Generic;
using Moq;

namespace HakunaMatataUnitTests
{
    public class UserServicesTests
    {
        [TestFixture]
        public class LogInMethod
        {
            private UserServices _userService;

            [SetUp]
            public void Init()
            {
                _userService = new UserServices(
                        new UserRepository(
                        new List<User>
                            {
                            new User
                            {
                                Id = 1,
                                Email = "dean.crainic@gmail.com",
                                Password = "password123",
                                FirstName = "Dean",
                                LastName = "Alexandru"
                            },
                            new User
                            {
                                Id = 2,
                                Email = "anamaghear@gmail.com",
                                Password = "password1234",
                                FirstName = "Ana",
                                LastName = "Maghear"
                            },
                            new User
                            {
                                Id = 3,
                                Email = "serban.alexandru@gmail.com",
                                Password = "password",
                                FirstName = "Alexandru",
                                LastName = "Serban"
                            },
                            new User
                            {
                                Id = 4,
                                Email = "tocai.raul@yahoo.com",
                                Password = "parola231",
                                FirstName = "Raul",
                                LastName = "Tocai"
                            },
                            new User
                            {
                                Id = 5,
                                Email = "snowtheblackdog@gmail.com",
                                Password = "woof123",
                                FirstName = "Snow",
                                LastName = "The Black Dog"
                            }
                            }));
            }

            [Test]
            public void ReturnsTrueIfLogInWorks()
            {
                var email = "dean.crainic@gmail.com";
                var password = "password123";

                var result = _userService.LogIn(email, password);

                Assert.That(result, Is.True);
            }

            [TestCase("dean.crainic@gmail.com", "password12")]
            public void ReturnsFalseIfWrongPassword(string email, string password)
            {
                var result = _userService.LogIn(email, password);

                Assert.That(result, Is.False);
            }

            [TestCaseSource("WrongEmailCases")]
            public void ReturnsFalseIfWrongEmail(string email, string password)
            {
                var result = _userService.LogIn(email, password);

                Assert.That(result, Is.False);
            }

            static object[] WrongEmailCases =
            {
                new object[] { "dean.crainic@amdaris.com", "password123" },
                new object[] { "dean.crainic2@gmail.com", "password12" }
            };
        }
    }
}