using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class GraphicPic<T>
    {
        private readonly List<Segment> segments = new();

        public GraphicPic() { }

        public GraphicPic(String filename)
        {
            foreach (var item in filename.Split('\n'))
            {
                int[] coordinates = new int[4];
                int i = 0;
                foreach (var coordinate in item.Split(' '))
                    coordinates[i++] = int.Parse(coordinate);
                var segment = new Segment(coordinates);
                segments.Add(segment);
            }
        }

        public GraphicPic(List<Segment> segments) => this.segments = segments;

        public void Show()
        {
            foreach (var segment in segments)
                Console.WriteLine(segment);
        }

        public void Insert(Segment s1)
        {
            foreach (var segment in segments)
            {
                if (s1.Equals(segment))
                    return;
            }

            segments.Add(s1);
        }

        public GraphicPic<Segment> AngleList()
        {
            List<Segment> newlistsegments = new();
            foreach (var segment in segments)
            {
                if (segment.IsAngleX45() || segment.IsAngleX30())
                    newlistsegments.Add(segment);
            }

            GraphicPic<Segment> newsegments = new(newlistsegments);
            return newsegments;
        }

        public GraphicPic<Segment> LengthList(int a, int b)
        {
            List<Segment> newlistsegments = new();
            foreach (var segment in segments)
            {
                if (b - segment.GetLength() > 0.00001
                   && segment.GetLength() - a > 0.00001)
                    newlistsegments.Add(segment);
            }

            GraphicPic<Segment> newsegments = new(newlistsegments);
            return newsegments;

        }

        public void Sort() => Quicksort(segments, 0, segments.Count - 1);

        private void Quicksort(List<Segment> list, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = Partition(list, start, end);
            Quicksort(list, start, pivot - 1);
            Quicksort(list, pivot + 1, end);
        }

        private int Partition(List<Segment> list, int start, int end)
        {
            int marker = start;
            for (int i = start; i < end; i++)
            {
                if (list[i].GetLength() < list[end].GetLength())
                {
                    (list[marker], list[i]) = (list[i], list[marker]);
                    marker += 1;
                }
            }

            (list[marker], list[end]) = (list[end], list[marker]);
            return marker;
        }
    }
}
