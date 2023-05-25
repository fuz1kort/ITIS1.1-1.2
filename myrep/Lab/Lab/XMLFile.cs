using System.Xml.Serialization;

namespace Lab
{
    public class XMLFile: ISavingApp
    {
        public delegate void XmlFileHandler(string message);

        public event XmlFileHandler? Notify;
        public string FileCompany { get; set; }
        public string FileTimeboard { get; set; }

        public XMLFile(string fileComp, string fileTime)
        {
            FileCompany = fileComp;
            FileTimeboard = fileTime;
        }
        public void SaveComp(MyCompany c)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyCompany));
            using FileStream fs = new FileStream(FileCompany, FileMode.OpenOrCreate);
            xmlSerializer.Serialize(fs, c);
            Console.WriteLine();
            Notify?.Invoke("Данные о компании были успешно сохранены");
        }

        public void SaveTimeboard(Timeboard t)
        {
            Notify?.Invoke("Данные о таблицы не были сохранены");
        }


        public MyCompany ReadComp()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyCompany));
            using FileStream fs = new FileStream(FileCompany, FileMode.OpenOrCreate);
            if(fs.Length != 0)
                return xmlSerializer.Deserialize(fs) as MyCompany;
            return new MyCompany();
        }

        public Timeboard ReadTimeboard()
        {
            return new();
        }
    }
}
