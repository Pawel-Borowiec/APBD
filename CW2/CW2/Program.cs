using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CW2
{
    class Program
    {
        public static void ErrorLogging(Exception ex)
        {
            string logpath = @"C:\Users\Paweł\Desktop\Log.txt";
            if (!File.Exists(logpath))
            {
                File.Create(logpath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(logpath))
            {
                sw.WriteLine("Error logging");
                sw.WriteLine("Start" + DateTime.Now);
                sw.WriteLine("Error message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("End" + DateTime.Now);
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                string csvpath = @"C:\Users\Paweł\Desktop\dane.csv"; // @C:\Users\Paweł\Desktop\dane.csv
                string xmlpath = @"C:\Users\Paweł\Desktop\"; // @C:\Users\Paweł\Desktop\
                //string json = Console.ReadLine(); // @C:\Users\Paweł\Desktop
                string format = Console.ReadLine(); // xml && json

                if (format == "xml" && File.Exists(csvpath) && Directory.Exists(xmlpath))
                {
                    string[] source = File.ReadAllLines(csvpath);

                    XElement xml = new XElement("Uczelnia",
                        from str in source
                        let fields = str.Split(',')
                        select new XElement("studenci",
                            new XAttribute("student_indexNumber", "s" + fields[4]),
                            new XElement("fname", fields[0]),
                            new XElement("lname", fields[1]),
                            new XElement("birthdate", fields[5]),
                            new XElement("e-mails", fields[6]),
                            new XElement("mothersname", fields[7]),
                            new XElement("fathersname", fields[8]),
                            new XElement("studies",
                                new XElement("name", fields[2]),
                                new XElement("mode", fields[3])
                            )
                        )
                    );
                    xml.Save(String.Concat(xmlpath + "xmlout.xml"));

                }
                else
                {
                    if (format != "xml" && format != "json")
                    {
                        throw new Exception("unsupported format");
                    }
                    else if (!File.Exists(csvpath))
                    {
                        throw new Exception("File does not exist");
                    }
                    else if (!Directory.Exists(xmlpath))
                    {
                        throw new Exception("Such directory does not exist");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
            }
        }

    }
}
