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
		[Test(Description = "Positive test of the Contacts setter")]
		public void Test_ContactsSet_CurrentValue()
		{
			Project project = new Project();
			var testList = new List<Contact>();

			Assert.DoesNotThrow(
				() => { project.Contacts = testList; },
				"Positive test of the Contacts setter not passed");
		}

		[Test(Description = "Test the sort")]
		public void Test_Sort_CorrectValue()
		{
			var project = new Project();
			project.Contacts = new List<Contact>()
			{
				new Contact("C", "C","C", "C",
					new DateTime(2001, 12, 12),
					new PhoneNumber(70000000000)),
				new Contact("B", "B","B", "B",
					new DateTime(2010, 12, 12),
					new PhoneNumber(70000000000)),
				new Contact("A", "A","A", "A",
					new DateTime(2011, 12, 12),
					new PhoneNumber(70000000000)),
			};

			var expectedList = new Project();
			expectedList.Contacts = new List<Contact>()
			{
				new Contact("A", "A","A", "A",
					new DateTime(2011, 12, 12),
					new PhoneNumber(70000000000)),
				new Contact("B", "B","B", "B",
					new DateTime(2010, 12, 12),
					new PhoneNumber(70000000000)),
				new Contact("C", "C","C", "C",
					new DateTime(2001, 12, 12),
					new PhoneNumber(70000000000)),
			};
			var expected = JsonConvert.SerializeObject(expectedList);

			var actualList = new Project();
			actualList.Contacts = project.AlphabetSort();
			var actual = JsonConvert.SerializeObject(actualList);

			Assert.AreEqual(expected,
				actual, "Dotes not sorted");
		}

		[Test(Description = "Test Sort without values")]
		public void Test_Sort_WithoutValues()
		{
			var project = new Project();

			var excepted = new List<Contact>();

			var actual = project.AlphabetSort();

			Assert.AreEqual(excepted, actual,
				"Don't Contain Values");
		}

		[Test(Description = "Test the sort with substring")]
		public void Test_Sort_CorrectValueSubstring()
		{
			var project = new Project();
			project.Contacts = new List<Contact>()
			{
				new Contact("C", "C","C", "C",
					new DateTime(2001, 12, 12),
					new PhoneNumber(70000000000)),
				new Contact("B", "B","B", "B",
					new DateTime(2010, 12, 12),
					new PhoneNumber(70000000000)),
				new Contact("A", "A","A", "A",
					new DateTime(2011, 12, 12),
					new PhoneNumber(70000000000)),
			};

			var expected = new Project();
			expected.Contacts = new List<Contact>()
			{
				new Contact("C", "C","C", "C",
					new DateTime(2001, 12, 12),
					new PhoneNumber(70000000000)),
			};

			var actual = new Project();
			actual.Contacts = project.AlphabetSort("C");

			Assert.AreEqual(expected.Contacts[0].Surname,
				actual.Contacts[0].Surname, "Dotes not sorted");
		}

		[Test(Description = "Test Sort without values with substring")]
		public void Test_Sort_WithoutValuesSubstring()
		{
			var project = new Project();

			var excepted = new List<Contact>();

			var actual = project.AlphabetSort("A");

			Assert.AreEqual(excepted, actual,
				"Don't Contain Values");
		}


		[Test(Description = "Birthday found")]
		public void Test_FindBirthday_HasNotContacts()
		{
			var project = new Project();
			project.Contacts = new List<Contact>();

			var expected = new List<Contact>();

			var actual = project.FindBirthdayContacts(
				new DateTime(1900, 12, 31));

			Assert.AreEqual(expected,
				actual, "Fail to find people's birthday");
		}

		[Test(Description = "Birthday found")]
		public void Test_FindBirthday_HasContacts()
        {
			var project = new Project();
			project.Contacts = new List<Contact>()
			{
				new Contact("C", "C","C", "C",
					new DateTime(2001, 12, 12),
					new PhoneNumber(70000000000)),
				new Contact("B", "B","B", "B",
					new DateTime(2010, 9, 12),
					new PhoneNumber(70000000000)),
				new Contact("A", "A","A", "A",
					new DateTime(2011, 2, 12),
					new PhoneNumber(70000000000)),
			};
			var expected = new Project();
			expected.Contacts = new List<Contact>()
			{
				new Contact("C", "C","C", "C",
					new DateTime(2001, 12, 12),
					new PhoneNumber(70000000000)),
			};
			var actual = project.FindBirthdayContacts(new DateTime(1999,12,12));
			Assert.AreEqual(expected.Contacts[0].Surname,
				actual[0].Surname, "Fail to find people's birthday");
		}

	}
}
