using NUnit.Framework;
using System;

namespace ContactsApp.UnitTests
{
		[TestFixture]
		public class ValidatorTests
		{
			 [Test(Description = "BirthdayValidator negative test")]
			public void BirthdayValidator_FutureDate_ArgumentException()
			{
				//setup
				var date = DateTime.Now.AddDays(1);

				//assert
                Assert.Throws<ArgumentException>(() =>
                {
                    DateValidator.AssertDate(date);
                });
            }

            [Test(Description = "BirthdayValidator negative test")]
            public void BirthdayValidator_ToPastDate_ArgumentException()
            {
                //setup
                var date = new DateTime(1899,1,1);

                //assert
                Assert.Throws<ArgumentException>(() =>
                {
                    DateValidator.AssertDate(date);
                });
            }

		[Test(Description = "Correct value of date")]
			public void BirthdayValidator_CorrectValue_DoesNotThrowException()
        {
            //setup
            var date = new DateTime(2000, 12, 12);
			
			//assert
            Assert.DoesNotThrow(() =>
				{
					DateValidator.AssertDate(date);
				});
			}

			[Test(Description = "Negative AssertStringLength test")]
			public void AssertStringLength_EmptyValue_ArgumentException()
            {
                //setup
                var emptyValue = "";
                var maxCount = 5;

				//assert
                Assert.Throws<ArgumentException>(() =>
				{
					StringValidator.AssertStringLength(null, emptyValue
					    , maxCount);
                });
            }

            [Test(Description = "Negative AssertStringLength test")]
            public void AssertStringLength_MoreMaxCountValue_ArgumentException()
            {
				//setup
                var emptyValue = "valera";
                var maxCount = 5;

				//assert
                Assert.Throws<ArgumentException>(() =>
                {
                    StringValidator.AssertStringLength(null, emptyValue
                        , maxCount);
                });
            }

		[Test(Description = "Correct value of date")]
			public void AssertStringLength_CorrectValue_DoesNotThrowException()
            {
                var value = "valera";
                var maxValue = 10;
				Assert.DoesNotThrow(() =>
				{
					StringValidator.AssertStringLength(null,
                        value, maxValue);
				});
			}

			[Test(Description = "Return empty string through GetClearPhoneNumber")]
			public void GetClearPhoneNumber_StringWithoutNumbers_EmptyString()
			{
				//setup
				var number = "adfasdasdfasdfasdf";
                var expected = "";

				//act
				var actual = StringValidator.GetClearNumber(number);

				//assert
				Assert.AreEqual(expected, actual,
					"Actual is not empty sting");
			}

			[Test(Description = "Return number through GetClearPhoneNumber")]
			public void GetClearPhoneNumber_StringWithNumbers_CorrectNumber()
			{
				//setup
				var number = "a8d800fa555s3d5a35sdfasdfasdf";
                var expected = "88005553535";
			
				//act
				var actual = StringValidator.GetClearNumber(number);

				//assert
				Assert.AreEqual(expected, actual,
					"Actual is not empty sting");
			}

			[Test(Description = "AssertPhoneNumber negative test")]
			public void AssertPhoneNumber_StartNotFromSeven_ThrowsException()
            {
			    //setup
                var wrongNumber = 12345678990;
                var maxLength = 11;

				//assert
				Assert.Throws<ArgumentException>(() =>
				{
					StringValidator.AssertNumber(wrongNumber,
                        maxLength);
				});
			}

            [Test(Description = "AssertPhoneNumber negative test")]
            public void AssertPhoneNumber_NotEqualMaxLength_ThrowsException()
            {
                //setup
                var wrongNumber = 723456;
                var maxLength = 11;

                //assert
                Assert.Throws<ArgumentException>(() =>
                {
                    StringValidator.AssertNumber(wrongNumber,
                        maxLength);
                });
            }

            [Test(Description = "Correct number")]
			public void AssertPhoneNumber_CorrectValue_DoesNotThrowException()
            {
				//setup
                var value = 71234567890;
                var maxLength = 11;

				//assert
				Assert.DoesNotThrow(() =>
				{
					StringValidator.AssertNumber(value, maxLength);
				});
			}
		}
	}

