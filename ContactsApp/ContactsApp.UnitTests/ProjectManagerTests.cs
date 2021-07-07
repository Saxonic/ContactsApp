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
        private static readonly string _fileName = "Reference.json";

        /// <summary>
        /// Folder for tests data
        /// </summary>
        private static readonly string _folder = @"TestData\";

        /// <summary>
        /// Folder for tests output
        /// </summary>
        private static readonly string _output = @"Output";

        /// <summary>
        /// All path for tests
        /// </summary>
        private static readonly string _path = Path.Combine(_folder, _fileName);

        /// <summary>
        /// 
        /// </summary>
        private static readonly string _outputPath = Path.Combine(_output, _fileName);

        /// <summary>
        /// Reference path file for tests
        /// </summary>
        private static readonly string _referencePath = @"TestData\Reference.json";

        /// <summary>
        /// Reference path broken file for tests
        /// </summary>
        private static readonly string _referenceBrokenPath = @"TestData\ReferenceBroken.json";


        private static readonly string _nonexistentFile = @"TestData\NonexistentFile.json";

        public Project GetProject()
        {
            var expectedProject = new Project();
            var contact = new Contact("Vlad",
                "Stepankov",
                "norm.parya@gmail.com",
                "Snax",
                new DateTime(2001, 1, 6),
                new PhoneNumber(71234567890)
            );
            expectedProject.Contacts.Add(contact);
            contact = new Contact(
                "Alesha",
                "Popovich",
                "Popa@gmail.com",
                "AlePop",
                new DateTime(1988, 11, 12),
                new PhoneNumber(70987654321)
            );
            expectedProject.Contacts.Add(contact);
            ProjectManager._filePath = _referencePath;

            return expectedProject;
        }

        [Test(Description = "Read correct file")]
        public void ReadProject_CorrectData_LoadedProject()
        {
            //setup
            var expected = GetProject();
            ProjectManager._filePath = _path;

            //act
            var actual = ProjectManager.Load(ProjectManager._filePath);

            //assert
            Assert.AreEqual(expected.Contacts, actual.Contacts,
                "Values are not the same");
        }

        [Test(Description = "Read broken  file")]
        public void Test_ReadProject_BrokenData()
        {
            //setup
            var expected = new Project();
            ProjectManager._filePath = _referenceBrokenPath;

            //act
            var actual = ProjectManager.Load(ProjectManager._filePath);

            //assert
            Assert.AreEqual(expected.Contacts, actual.Contacts);
        }

        [Test(Description = "Try to read nonexistent file")]
        public void TestReadProject_NonExistentFile()
        {
            //setup
            var expected = new Project();
            ProjectManager._filePath = _nonexistentFile;

            //act
            var actual = ProjectManager.Load(ProjectManager._filePath);

            //assert
            Assert.AreEqual(expected.Contacts, actual.Contacts,
                "Actual project is existent");
        }

        [Test(Description = "Test to write in the file without file")]
        public void TestSaveProject_WithoutCreatedFile()
        {
            ProjectManager._filePath = _outputPath;
            var expected = File.ReadAllText(_referencePath);
            var savingObject = GetProject();
            if (Directory.Exists(_output))
            {
                Directory.Delete(_output,true);
            }

            //act
            ProjectManager.Save(savingObject, _outputPath);

            //assert
            var actual = File.ReadAllText(_outputPath);
            Assert.AreEqual(expected, actual,
                "Values are not the same");
        }

        [Test(Description = "Test to write in the file")]
        public void TestSaveProject_WithCreatedFile()
        {
            //setup
            ProjectManager._filePath = _outputPath;
            var expected = File.ReadAllText(_referencePath);
            var savingObject = GetProject();
            if (File.Exists(_outputPath))
            {
                File.Delete(_outputPath);
            }
            Directory.CreateDirectory(_output);
            File.Create(_outputPath).Close();
            File.WriteAllText(_outputPath, expected);

            //act
            ProjectManager.Save(savingObject, ProjectManager._filePath);

            //assert
            var actual = File.ReadAllText(_outputPath);
            Assert.AreEqual(expected, actual,
                "Values are not the same");

        }
    }
}