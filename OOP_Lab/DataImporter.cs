using System;
using System.Collections.Generic;
using System.Linq;

namespace student_enrolment
{
    public class DataImporter
    {
        public List<T> Import<T>(string dataFile)
        {
            var list = new List<T>();
            var lines = System.IO.File.ReadAllLines(dataFile);
            var headerLine = lines.First();
            var columns = headerLine.Split(',').ToList().Select((v, i) => new { Position = i, Name = v });
         
            var dataLines = lines.Skip(1).ToList();
            var type = typeof(T);

            var properties = type.GetProperties();
            dataLines.ForEach(line => {
                var obj = (T)Activator.CreateInstance(type);
                var data = line.Split(',').ToList();
                foreach (var property in properties)
                {
                    var column = columns.SingleOrDefault(c => c.Name == property.Name);
                    var value = data[column.Position];
                    var typeOfProp = property.PropertyType;
                    property.SetValue(obj, Convert.ChangeType(value, typeOfProp));
                }
                list.Add(obj);
            });
            return list;
        }
    }
}