using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
	[TestFixture]
	class ContactTests
	{
		private Contact CreateEmptyContact()
		{
			return new Contact(" ", " ", " ", " ", DateTime.Now,
				new PhoneNumber(70000000000));
		}

		//Test Name start
		[Test(Description = "Positive test of the Name getter")]
		public void TestNameGet_ReturnCorrectValue()
		{
            //setup
			var expected = "Name";
			var contact = CreateEmptyContact();
			
			//act
			contact.Name = expected;

			//assert
            var actual = contact.Name;
            Assert.AreEqual(expected, actual);
		}

		[Test(Description = "Negative test of Name setter")]
		public void NameSet_EmptyName_ArgumentException()
		{
            //setup
            var contact = CreateEmptyContact();
            var emptyName = "";

			//assert
            Assert.Throws<ArgumentException>(
				() => { contact.Name = emptyName; });
		}

        [Test(Description = "Negative test of Name setter")]
        public void NameSet_ToLongName_ArgumentException()
        {
            //setup
            var contact = CreateEmptyContact();
            var emptyName = "MichailMichailMichailMichailMichailMichailMichailMichailMichailMichail";

            //assert
            Assert.Throws<ArgumentException>(
                () => { contact.Name = emptyName; });
        }

		[Test(Description = "Positive test of the Name setter")]
		public void NameSet_CorrectValue_DoesNotThrowException()
		{
			//setup
			var contact = CreateEmptyContact();
			var name = "Name";

			//assert
			Assert.DoesNotThrow(
				() => { contact.Name = name; });
		}
		//Test Name end

		//Test Surname start
		[Test(Description = "Positive test of the Surname getter")]
		public void SurnameGet_ReturnCorrectSurname()
		{
			//setup
			var expected = "Surname";
            var contact = CreateEmptyContact();
			contact.Surname = expected;

			//act
			var actual = contact.Surname;
			
			//assert
			Assert.AreEqual(expected, actual,
				"Getter Surname returns incorrect value");
		}
		
		[Test(Description = "Negative test of Surname setter")]
		public void TestSurnameSet_EmptySurname_ArgumentException()
		{
            //setup
			var contact = CreateEmptyContact();
            var wrongSurname = "";

			//assert
			Assert.Throws<ArgumentException>(
				() => { contact.Surname = wrongSurname; });
		}

        [Test(Description = "Negative test of Surname setter")]
        public void TestSurnameSet_ToLongSurname_ArgumentException()
        {
            //setup
            var contact = CreateEmptyContact();
            var wrongSurname = "MichalkovMichalkovMichalkovMichalkovMichalkovMichalkovMichalkovMichalkov";

            //assert
            Assert.Throws<ArgumentException>(
                () => { contact.Surname = wrongSurname; });
        }

		[Test(Description = "Positive test of the Surname setter")]
		public void SurnameSet_CorrectValue_DoesNotThrowException()
		{
            //setup
			var contact = CreateEmptyContact();
			var surname = "Surname";

            //assert
			Assert.DoesNotThrow(
				() => { contact.Surname = surname; });
		}


        [Test(Description = "Positive test of the Email getter")]
		public void EmailGet_ReturnCorrectValue()
		{
			//setup
			var expected = "Email";
            var contact = CreateEmptyContact();
			contact.Email = expected;

			//act
			var actual = contact.Email;

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test(Description ="Negative test of email setter")]
		public void EmailSet_EmptyEmail_ArgumentException()
		{
			//setup
			var contact = CreateEmptyContact();
            var emptyEmail = "";

			//assert
			Assert.Throws<ArgumentException>(
				() => { contact.Email = emptyEmail; });
		}

        [Test(Description = "Negative test of email setter")]
        public void EmailSet_ToLongEmail_ArgumentException()
        {
            //setup
            var contact = CreateEmptyContact();
            var emptyEmail = "parenparparenparenenparenparenparenparparenparenenp@gmail.com";

            //assert
            Assert.Throws<ArgumentException>(
                () => { contact.Email = emptyEmail; });
        }

		[Test(Description = "Positive test of the Email setter")]
		public void EmailSet_CorrectValue_DoesNotThrowException()
		{
            //setup
			var contact = CreateEmptyContact();
			var email = "Email";

			//assert
			Assert.DoesNotThrow(
				() => { contact.Email = email; });
		}

        //Test VkID start
		[Test(Description = "Positive test of the VKID getter")]
		public void VKIDGet_ReturnCorrectValue()
		{
			//setup
			var expected = "VKID";
            var contact = CreateEmptyContact();
			contact.VkID = expected;

            //act
			var actual = contact.VkID;

			//assert
			Assert.AreEqual(expected, actual);
		}

        [Test(Description = "Negative VkID setter test")]
		public void VKIDSet_EmptyVkId_ArgumentException()
		{
			//setup
			var contact = CreateEmptyContact();
            var emptyVkId = "";

            //assert
			Assert.Throws<ArgumentException>(
                () => { contact.VkID = emptyVkId; });
		}

        [Test(Description = "Negative VkID setter test")]
        public void VKIDSet_LongVkId_ArgumentException()
        {
            //setup
            var contact = CreateEmptyContact();
            var LongVkId = "vkIDvkIDvkIDvkIDvkIDvkIDvkID";

            //assert
            Assert.Throws<ArgumentException>(
                () => { contact.VkID = LongVkId; });
        }

		[Test(Description = "Positive test of the VKID setter")]
		public void VKIDSet_CorrectValue_DoesNotTrowException()
		{
			//setup
			var contact = CreateEmptyContact();
			var vkid = "VKID";

			//Assert
			Assert.DoesNotThrow(
				() => { contact.Name = vkid; });
		}

		[Test(Description = "Positive test of the PhoneNumber getter")]
		public void PhoneNumberGet_ReturnCorrectValue()
        {
            //setup
			var expected = new PhoneNumber(78005553535);
            var contact = CreateEmptyContact();
			contact.PhoneNumber = expected;

			//act
			var actual = contact.PhoneNumber;

			//assert
			Assert.AreEqual(expected, actual,
				"Getter PhoneNumber returns incorrect value");
		}

		[Test(Description = "Negative test of PhoneNumber setter")]
		public void PhoneNumber_NumberWithoutSevenInStart_ArgumentException()
		{
			//setup
			var contact = CreateEmptyContact();
            var wrongNumber = 21234567890;

			//assert
			Assert.Throws<ArgumentException>(
				() => { contact.PhoneNumber = new PhoneNumber(wrongNumber); });
		}


        [Test(Description = "Negative test of PhoneNumber setter")]
        public void PhoneNumber_IncorrectNumberLength_ArgumentException()
        {
            //setup
            var contact = CreateEmptyContact();
            var wrongNumber = 71234567;

            //assert
            Assert.Throws<ArgumentException>(
                () => { contact.PhoneNumber = new PhoneNumber(wrongNumber); });
        }

		[Test(Description = "Positive test of the PhoneNumber setter")]
		public void PhoneNumberSet_CorrectValue()
		{
			//setup
			var contact = CreateEmptyContact();
            var phoneNumber = new PhoneNumber(78005553535);
			
			//assert
            Assert.DoesNotThrow(
				() => { contact.PhoneNumber = phoneNumber; },
				"Positive test of the PhoneNumber setter not passed");
		}

		[Test(Description = "Positive test of the Birthday getter")]
		public void BirthdayGet_ReturnCorrectValue()
		{
			//setup
			var expected = new DateTime(2000, 12, 12);
            var contact = CreateEmptyContact();
			contact.Birthday = expected;

			//act
			var actual = contact.Birthday;

			//assert
			Assert.AreEqual(expected, actual);
		}

		[Test(Description = "Negative Test of Birthday setter")]
		public void BirthdaySet_FutureDate_ArgumentException()
		{
			//setup
			var contact = CreateEmptyContact();
            var wrongValue = DateTime.Now.AddDays(1);

			//assert
            Assert.Throws<ArgumentException>(
                () => { contact.Birthday = wrongValue; });
        }

        [Test(Description = "Negative Test of Birthday setter")]
        public void BirthdaySet_PastDate_ArgumentException()
        {
            //setup
            var contact = CreateEmptyContact();
            var wrongValue = new DateTime(1899,1,1);

            //assert
            Assert.Throws<ArgumentException>(
                () => { contact.Birthday = wrongValue; });
        }


		[Test(Description = "Positive test of the Birthday setter")]
		public void BirthdaySet_ReturnCorrectValue()
		{
			//setup
			var contact = CreateEmptyContact();
            var dateTime = new DateTime(2000, 12, 21);

			//assert
            Assert.DoesNotThrow(
				() => { contact.Birthday = dateTime; });
		}

		[Test(Description = "Test constructor")]
		public void TestConstructor()
		{
			var expectedName = "Name";
			var expectedSurname = "Surname";
			var expectedPhoneNumber = new PhoneNumber(78005553535);
			var expectedBirthday = new DateTime(2000, 12, 12);
			var expectedEmail = "Email";
			var expectedVkId = "VkId";

			Assert.DoesNotThrow(() =>
            {
                var contact = new Contact(expectedName, expectedSurname, expectedEmail,
                    expectedVkId, expectedBirthday, expectedPhoneNumber);
            });
		}
    }
}