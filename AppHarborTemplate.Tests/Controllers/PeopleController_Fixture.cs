using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AppHarborTemplate.Models;

namespace AppHarborTemplate.Tests.Controllers
{
    [TestFixture, Ignore]
    public class PeopleController_Fixture
    {
        private AppHarborTemplateContext _appDb = new AppHarborTemplateContext();

        public PeopleController_Fixture()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppHarborTemplateContext>());
        }
        [Test]
        public void AddPerson_Should_IncreasePeopleCountBy1()
        {
            // Arrange
            var aPerson = new Person(){Name = "AddPersonTest"};
            var initialCount = _appDb.People.Count();

            // Act
            _appDb.People.Add(aPerson);
            _appDb.SaveChanges();
            
            // Assert
            var dbCount = _appDb.People.Count();
            Assert.That(dbCount, Is.EqualTo(initialCount + 1), "PeopleCount");
        }

        [Test]
        public void AddPeopleToGroup()
        {
            // Arrange
            var group = GetTestGroup();
            var initalGroupCount = _appDb.Groups.Count();
            var intialPeopleCount = _appDb.People.Count();
            
            // Act
            _appDb.Groups.Add(group);
            _appDb.SaveChanges();

            // Assert
            var finalGroupCount = _appDb.Groups.Count();
            var finalPeopleCount = _appDb.People.Count();
            Assert.That(initalGroupCount, Is.EqualTo(finalGroupCount - 1), "GroupCount");
            Assert.That(intialPeopleCount, Is.EqualTo(finalPeopleCount - 2), "PeopleCount");
        }

        [Test]
        public void AddDeedToPerson_Should_IncreaseActivityCountBy1()
        {
            // Arrange
            var group = GetTestGroup();
            _appDb.Groups.Add(group);
            
            _appDb.SaveChanges();

            // Act
            var firstPerson = group.Parters.First();
            var initalActivityCount = firstPerson.Deeds.Count();
            _appDb.SaveChanges();

            // Assert
            var finalActivityCount = _appDb.People.Where(person => person.Id == firstPerson.Id).Count();
            Assert.That(initalActivityCount, Is.EqualTo(finalActivityCount - 1), "GroupCount");
        }


        [Test]
        public void test()
        {
            var group = GetTestGroup();
            var person = group.Parters.First();
            person.Deeds.Add(new Deed(){Name = "test deed"});
            _appDb.SaveChanges();
            var acts = person.Deeds.FirstOrDefault().Acts;
            acts.Add(new Act() { });
            _appDb.SaveChanges();
        }

        private Couple GetTestGroup()
        {
            var dude = new Person() { Name = "Dude" };
            var chick = new Person() { Name = "Chick" };
            var group = new Couple();//(dude, chick);
            _appDb.Groups.Add(group);
            _appDb.SaveChanges();
            return group; 
        }
    }
}
