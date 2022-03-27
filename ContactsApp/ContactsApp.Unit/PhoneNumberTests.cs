using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
	[TestFixture]
	public class PhoneNumberTests
	{
		private PhoneNumber CreateClearPhoneNumber()
		{
			return new PhoneNumber(70000000000);
		}

		[Test(Description = "Positive test of the Number getter")]
		public void NumberGet_ReturnCorrectValue()
		{
			//setup
			var expected = 78005553535;
            var phoneNumber = CreateClearPhoneNumber();
			phoneNumber.Number = expected;
			
            //act
			var actual = phoneNumber.Number;

			//assert
			Assert.AreEqual(expected, actual,
				"Getter Number returns incorrect value");
		}

		[Test(Description = "Negative number setter test")]
		public void NumberSet_StartNotFromSeven_ArgumentException()
        {
            //setup
            var phoneNumber = CreateClearPhoneNumber();
            var wrongNumber = 21234567890;

			//assert
            Assert.Throws<ArgumentException>(
				() => { phoneNumber.Number = wrongNumber; });
		}


        [Test(Description = "Negative number setter test")]
        public void NumberSet_IncorrectLength_ArgumentException()
        {
            //setup
            var phoneNumber = CreateClearPhoneNumber();
            var wrongNumber = 2123456;

            //assert
            Assert.Throws<ArgumentException>(
                () => { phoneNumber.Number = wrongNumber; });
        }

		[Test(Description = "Positive test of the Number setter")]
        public void NumberSet_CorrectValue()
		{
			//setup
			var number = 78005553535;
            var phoneNumber = CreateClearPhoneNumber();

			//assert
            Assert.DoesNotThrow(
				() => { phoneNumber.Number = number; });
		}

		[Test(Description = "Positive test of the Constructor")]
		public void TestConstructorPhoneNumber_CorrectValue()
		{
			var number = 78005553535;
			Assert.DoesNotThrow(
				() => { new PhoneNumber(number); });
		}
	}
}
