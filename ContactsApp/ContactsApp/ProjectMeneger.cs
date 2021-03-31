using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ContactsApp
{
    public static class ProjectMeneger
    {
        /// <summary>
        /// Содержит имя файла <see cref="NAME"/>
        /// </summary>
        private const string NAME = @"\ContactsApp.json";

        /// <summary>
        /// Содержит стандартный путь в папку данных <see cref="_directory"/>
        /// </summary>
        private static readonly string _directory = 
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) 
            + @"\VladioINC\ContactsApp";

        /// <summary>
        /// Содержит путь до файла <see cref="_filePath"/>
        /// </summary>
        public static readonly string _filePath = _directory + NAME;

        /// <summary>
        /// Реализует сохранение файла
        /// </summary>
        /// <param name="project"></param>
        public static void Save(Project project, string path)
        {
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(_filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Сохраняет файл в папке
        /// </summary>
        /// <returns>
        /// Все данные файла
        /// </returns>
        public static Project Load(string path)
        {
            string directory = Path.GetDirectoryName(path);
            Project project = new Project();
            if (!Directory.Exists(directory))
            {
                return project;
            }

            if (!File.Exists(path))
            {
                return project;
            }

            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(_filePath))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    project = serializer.Deserialize<Project>(reader);
                    if (project == null)
                    {
                        return new Project();
                    }
                }
            }
            catch
            {
                return new Project();
            }

            return project;
        }

    }
}
