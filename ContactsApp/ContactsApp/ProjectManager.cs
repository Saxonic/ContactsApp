using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс <see cref="ProjectManager"/> вполняет сохранение и
    /// загрузку <see cref="Project"/> в файл.
    /// </summary>
    public static class ProjectManager
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
        public static string _filePath = _directory + NAME;

        /// <summary>
        /// Реализует сохранение файла
        /// </summary>
        /// <param name="project"></param>
        /// <param name="path"></param>
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
        /// Загружает файл из папки
        /// </summary>
        /// <returns>
        /// Все данные проекта
        /// </returns>
        public static Project Load(string path)
        {
            Project project = new Project();

            if (!File.Exists(path))
            {
                return project;
            }

            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(path))
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
