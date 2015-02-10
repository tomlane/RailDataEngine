using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RailDataEngine.ScheduleConsole
{
    public static class StreamReaderExtensions
    {
        public static List<string> ReadLines(this StreamReader reader, int count)
        {
            var stringList = new List<string>();

            for (int i = 0; i < count; i++)
            {
                if ((reader.ReadLine()) != null)
                    stringList.Add(reader.ReadLine());
            }

            return stringList;
        }
    }
}
