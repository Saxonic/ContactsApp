using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsApp.UnitTests
{
	[TestFixture]
	public class ProjectTests
	{
        private Project GetCorrectProject()
        {
            var project = new Project();
            project.Contacts = new List<Contact>()
            {
                new Contact("C", "C","C", "C",
                    new DateTime(2001, 11, 10),
                    new PhoneNumber(70000000000)),
                new Contact("B", "B","B", "B",
                    new DateTime(2010, 10, 10),
                    new PhoneNumber(70000000000)),
                new Contact("A", "A","A", "A",
                    new DateTime(2011, 12, 12),
                    new PhoneNumber(70000000000)),
            };
            return project;
        }

		[Test(Description = "Positive test of the Contacts setter")]
		public void ContactsSet_CurrentValue_DoesNotThrowException()
		{
			//setup
			Project project = new Project();
			var testList = new List<Contact>();

			//assert
			Assert.DoesNotThrow(
				() => { project.Contacts = testList; },
				"Positive test of the Contacts setter not passed");
		}

		[Test(Description = "Test the sort")]
		public void OrderBySurname_CorrectValue_ReturnOrderedList()
        {
            //setup
			var expected = new List<Contact>()
			{
                new Contact("A", "A","A", "A",
                    new DateTime(2011, 12, 12),
                    new PhoneNumber(70000000000)),
                new Contact("B", "B","B", "B",
                    new DateTime(2010, 10, 10),
                    new PhoneNumber(70000000000)),
				new Contact("C", "C","C", "C",
                    new DateTime(2001, 11, 10),
                    new PhoneNumber(70000000000)),
			};
            var actualProject= GetCorrectProject();

            //act
            var actual = actualProject.OrderBySurname();

			//assert
            Assert.AreEqual(expected,
				actual, "Dotes not sorted");
		}

		[Test(Description = "Test Sort without values")]
		public void OrderBySurname_WithoutValues_ReturnEmptyList()
		{
			//setup
			var project = new Project();
            var expected = new List<Contact>();

			//act
			var actual = project.OrderBySurname();

			//assert
			Assert.AreEqual(expected, actual,
				"Don't Contain Values");
		}

		[Test(Description = "Test the sort with substring")]
		public void FindByNameAndSurname_CorrectValueSubstring_ReturnCorrectList()
        {
            //setup
            var expected = new List<Contact>()
			{
				new Contact("C", "C","C", "C",
					new DateTime(2001, 11, 10),
					new PhoneNumber(70000000000)),
			};
            var project = GetCorrectProject();

			//act
            var actual = project.FindByNameAndSurname("C");

			//assert
			Assert.AreEqual(expected,
				actual, "Dotes not sorted");
		}

		[Test(Description = "Test Sort without values with substring")]
		public void FindByNameAndSurname_WithoutValuesSubstring_EmptyString()
		{
			//setup
			var project = new Project();
            var excepted = new List<Contact>();

			//act
			var actual = project.FindByNameAndSurname("A");

			//assert
			Assert.AreEqual(excepted, actual,
				"Don't Contain Values");
		}


		[Test(Description = "Birthday found")]
		public void FindBirthdayContacts_NoBirthdayInThisDate_ReturnEmptyList()
        {
			//setup
            var project = GetCorrectProject();
            var expected = new List<Contact>();

			//act
            var actual = project.FindBirthdayContacts(
				new DateTime(1900, 12, 31));

			//assert
			Assert.AreEqual(expected,
				actual, "Fail to find people's birthday");
		}

		[Test(Description = "Birthday found")]
		public void Test_FindBirthday_HasContacts()
        {
			//setup
            var project = GetCorrectProject();
            var expected =  new List<Contact>
			{
				new Contact("C", "C","C", "C",
					new DateTime(2001, 11, 10),
					new PhoneNumber(70000000000)),
			};

			//act
			var actual = project.FindBirthdayContacts(new DateTime(1999,11,10));

			//assert
			Assert.AreEqual(expected,
				actual, "Fail to find people's birthday");
		}

	}
}
