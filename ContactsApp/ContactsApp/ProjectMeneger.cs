using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    public static class ProjectMeneger
    {
        /// <summary>
        /// Содержит имя файла <see cref="NAME"/>
        /// </summary>
        private const string NAME = "ContactsApp.notes";
        /// <summary>
        /// Содержит стандартный путь в папку данных <see cref="_derictory"/>
        /// </summary>
        private static readonly string _derictory = 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ContactsApp";
        /// <summary>
        /// Содержит путь до файла <see cref="_filePath"/>
        /// </summary>
        private static readonly string _filePath = _derictory + NAME;

        /// <summary>
        /// Реализует сохранение файла
        /// </summary>
        /// <param name="project"></param>
        public static void Save(Project project)
        {
            if (!Directory.Exists(_derictory))
            {
                Directory.CreateDirectory(_derictory);
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(_filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer,project);
            }
        }
        /// <summary>
        /// Сохраняет файл в папке
        /// </summary>
        /// <returns>
        /// Все данные файла
        /// </returns>
        public static Project Load()
        {
            Project project = new Project();
            if (!File.Exists(_filePath))
            {
                return project;
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(_filePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = (Project) serializer.Deserialize<Project>(reader);
            }

            return project;
        }

    }
}
