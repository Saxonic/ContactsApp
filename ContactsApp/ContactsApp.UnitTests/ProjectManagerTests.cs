using System;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Newtonsoft.Json;

namespace ContactsApp.UnitTests
{
	[TestFixture]
	public class ProjectManagerTests
	{
		/// <summary>
		/// File name for tests
		/// </summary>
		private static readonly string _fileName = "TestFile.txt";

		/// <summary>
		/// Folder for tests
		/// </summary>
		private static readonly string _folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestData\";

		/// <summary>
		/// All path for tests
		/// </summary>
		private static readonly string _path = _folder + _fileName;

		/// <summary>
		/// Reference path file for tests
		/// </summary>
		private static readonly string _referencePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestData\Reference.json";

		/// <summary>
		/// Reference path broken file for tests
		/// </summary>
		private static readonly string _referenceBrokenPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestData\ReferenceBroken.json";

		private static readonly string _nonexistentFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestData\NonexistentFile.json";

		[TearDown]
		public void DeleteFile()
		{
			if (File.Exists(_path))
			{
				File.Delete(_path);
			}
		}

		[Test(Description = "Read correct file")]
		public void Test_ReadProject_Set_CorrectData()
		{
			ProjectManager._filePath = _path;
			var expected = File.ReadAllText(_referencePath);
			if (File.Exists(_path))
			{
				File.Delete(_path);
			}
			File.Create(_path).Close();
			File.WriteAllText(_path, expected);
			if (File.Exists(_path))
			{
				var actualObject = ProjectManager.Load(ProjectManager._filePath);
				var actual = JsonConvert.SerializeObject(actualObject);
				Assert.AreEqual(expected, actual,
					"Values are not the same");
			}
		}

		[Test(Description = "Read broken  file")]
		public void Test_ReadProject_BrokenData()
		{
			var expected = JsonConvert.SerializeObject(new Project());

			ProjectManager._filePath = _referenceBrokenPath;
			var actualObject = ProjectManager.Load(ProjectManager._filePath);
			var actual = JsonConvert.SerializeObject(actualObject);

			Assert.AreEqual(expected, actual);
		}

		[Test(Description = "Try to read nonexistent file")]
		public void TestReadProject_NonexistentFile()
		{
			var expected = JsonConvert.SerializeObject(new Project());

			ProjectManager._filePath = _nonexistentFile;
			var actual = JsonConvert.SerializeObject(
				ProjectManager.Load(ProjectManager._filePath));

			Assert.AreEqual(expected, actual,
				"Actual project is existent");
		}

		[Test(Description = "Test to write in the file")]
		public void TestSaveProject_WithCreatedFile()
		{

			ProjectManager._filePath = _path;
			if (File.Exists(_path))
			{
				File.Delete(_path);
			}
			File.Create(_path).Close();
			var expected = File.ReadAllText(_referencePath);
			var expectedObject = JsonConvert.DeserializeObject<Project>(
				expected);
			ProjectManager.Save(expectedObject, ProjectManager._filePath);
			if (File.Exists(_path))
			{
				var actual = File.ReadAllText(_path);
				Assert.AreEqual(expected, actual,
					"Values are not the same");
			}
		}

		[Test(Description = "Test to write in the file without file")]
		public void TestSaveProject_WithoutCreatedFile()
		{

			ProjectManager._filePath = _path;
			if (File.Exists(_path))
			{
				File.Delete(_path);
			}
			var expected = File.ReadAllText(_referencePath);
			var expectedObject = JsonConvert.DeserializeObject<Project>(
				expected);
			ProjectManager.Save(expectedObject, ProjectManager._filePath);
			if (File.Exists(ProjectManager._filePath))
			{
				var actual = File.ReadAllText(
					ProjectManager._filePath);
				Assert.AreEqual(expected, actual,
					"Values are not the same");
			}
		}
	}
}