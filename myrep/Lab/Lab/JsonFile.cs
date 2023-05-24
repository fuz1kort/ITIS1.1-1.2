using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Serialization;

namespace Lab
{
    public class JsonFile: ISavingApp
    {
        public string FileCompany { get; set; }
        public string FileTimeboard { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        public JsonFile(string fileWayComp, string fileWayTime)
        {
            FileCompany = fileWayComp;
            FileTimeboard = fileWayTime;
        }
        public void SaveComp(MyCompany с) => File.WriteAllText(FileCompany, JsonSerializer.Serialize(с, _options));

        public void SaveTimeboard(Timeboard t) => File.WriteAllText(FileTimeboard, JsonSerializer.Serialize(t, _options));


        public MyCompany ReadComp()
        {
            using FileStream fs = new FileStream(FileCompany, FileMode.OpenOrCreate);
            if (fs.Length != 0)
                return JsonSerializer.Deserialize<MyCompany>(fs);
            return new MyCompany();
        }

        public Timeboard ReadTimeboard()
        {
            using FileStream fs = new FileStream(FileTimeboard, FileMode.OpenOrCreate);
            if (fs.Length != 0)
                return JsonSerializer.Deserialize<Timeboard>(fs);
            return new Timeboard();
        }
    }
}
