using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_enrolment
{
    internal class DataExporter
    {
        public static void Export<T>(List<T> list, string file)
        {
            var lines = GetLines(list);
            System.IO.File.WriteAllLines(file, lines);
        }
        private static IEnumerable<string> GetLines<T>(List<T> list)
        {
            var type = typeof(T);
            var props = type.GetProperties();
            var header = "";
            var firstDone = false;

            foreach (var prop in props)
            {
                if (!firstDone)
                {
                    header += prop.Name;
                    firstDone = true;
                }
                else
                {
                    header += "," + prop.Name;
                }
            }

            var lines = new List<string> { header };
            foreach (var obj in list)
            {
                firstDone = false;
                var line = "";
                foreach (var prop in props)
                {
                    var value = prop.GetValue(obj).ToString();

                    if (!firstDone)
                    {
                        line += value;
                        firstDone = true;
                    }
                    else
                    {
                        line += "," + value;
                    }
                }
                lines.Add(line);
            }
            return lines;
        }
	}
}
