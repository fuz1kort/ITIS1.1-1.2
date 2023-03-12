using System.Text;

namespace Lab2
{
    class Program
    {
        public static async Task Main()
        {
            //Segment s = new(0, 1, 2, 3);
            //Console.WriteLine(s);
            //Console.WriteLine(s.IsAngleX30());
            //Console.WriteLine(s.IsAngleX45());
            //Segment s1 = new(0, 1, 2, 3);
            //Segment s2 = new(1, 2, 3, 4);
            //Console.WriteLine(s.Equals(s1));
            //Console.WriteLine(s.Equals(s2));
            string path = @"C:\Users\gafar\OneDrive\Документы\GitHub\itiscs\Azat\mysegments.txt";

            using (FileStream file = File.OpenRead(path))
            {
                byte[] buffer = new byte[file.Length];
                await file.ReadAsync(buffer, 0, buffer.Length);
                string textfromfile = Encoding.Default.GetString(buffer);
                GraphicPic<Segment> segments = new GraphicPic<Segment>(textfromfile);
                segments.Show();
                Console.WriteLine("-------------");
                segments.Sort();
                segments.Show();
                Console.WriteLine("-------------");
                Segment s = new(0, 0, 1, 1);
                segments.Insert(s);
                var newanglesegments = segments.AngleList();
                newanglesegments.Show();
                Console.WriteLine("-------------");
                var newsegments = segments.LengthList(1, 3);
                newsegments.Show();
            }


        }
    }
}