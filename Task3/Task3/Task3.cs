using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using System.IO;
namespace Task3
{
    internal class Task3
    {
        public static void ResultTests(string pathValues, string pathTests, string pathReport)
        {
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(File.ReadAllText(pathTests));
            RootValues myDeserializedClassValues = JsonConvert.DeserializeObject<RootValues>(File.ReadAllText(pathValues));

            foreach (Test test in myDeserializedClass.tests)
            {
                foreach (ValueValues vv in myDeserializedClassValues.values)
                {
                    if (test.id == vv.id)
                    {
                        test.value = vv.value;
                        break;
                    }
                }
                if (test.values != null)
                {
                    foreach (Value value in test.values)
                    {
                        foreach (ValueValues vv in myDeserializedClassValues.values)
                        {
                            if (value.id == vv.id)
                            {
                                value.value = vv.value;
                                break;
                            }
                        }

                        if (value.values != null)
                        {
                            foreach (Value value2 in value.values)
                            {
                                foreach (ValueValues vv in myDeserializedClassValues.values)
                                {
                                    if (value2.id == vv.id)
                                    {
                                        value2.value = vv.value;
                                        break;
                                    }
                                }

                                if (value2.values != null)
                                {
                                    foreach (Value value3 in value2.values)
                                    {
                                        foreach (ValueValues vv in myDeserializedClassValues.values)
                                        {
                                            if (value3.id == vv.id)
                                            {
                                                value3.value = vv.value;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            string report = JsonConvert.SerializeObject(myDeserializedClass);

            File.WriteAllText(pathReport, report);
            Console.WriteLine(report);
        }
        public class Root
        {
            public List<Test> tests { get; set; }
        }
        public class Test
        {
            public int id { get; set; }
            public string title { get; set; }
            public string value { get; internal set; }
            public List<Value> values { get; set; }
        }
        public class Value
        {
            public int id { get; set; }
            public string title { get; set; }
            public string value { get; set; }
            public List<Value> values { get; set; }
        }
        public class RootValues
        {
            public List<ValueValues> values { get; set; }
        }
        public class ValueValues
        {
            public int id { get; set; }
            public string value { get; set; }
        }

    }
}
