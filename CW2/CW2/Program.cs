using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CW2
{
    class Program
    {
        static List<string> errors = new List<string>();
        public static async Task Main(string[] args)
        {
            try
            {
                string csvpath = Console.ReadLine(); // @C:\Users\Paweł\Desktop\dane.csv
                string targetPath = Console.ReadLine(); // @C:\Users\Paweł\Desktop\
                string format = Console.ReadLine(); // xml && json
                switch (format)
                {
                    case "xml":
                        if (File.Exists(csvpath) && Directory.Exists(targetPath))
                        {
                            proccesXml(csvpath, targetPath);
                        }
                        else
                        {
                            if (!File.Exists(csvpath))
                            {
                                throw new Exception("File does not exist");
                            }
                            else if (!Directory.Exists(targetPath))
                            {
                                throw new Exception("Such directory does not exist");
                            }
                        }
                        break;
                    case "json":
                        Console.WriteLine("Wybrano format JSON");
                        if (File.Exists(csvpath) && Directory.Exists(targetPath))
                        {
                            await proccesJson(csvpath, targetPath);
                        }
                        else
                        {
                            if (!File.Exists(csvpath))
                            {
                                throw new Exception("File does not exist");
                            }
                            else if (!Directory.Exists(targetPath))
                            {
                                throw new Exception("Such directory does not exist");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Wybrano niepoprawny format");
                        throw new Exception("Unsupported format");
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
            }
            finally
            {
                if (errors.Count != 0)
                {
                    ErrorLogging();
                }
            }
        }
        // Obsługa formatu XML
        public static void proccesXml(string sourcePath, string targetPath)
        {
            Console.WriteLine("Open XML");
            List<string> temp = File.ReadAllLines(sourcePath).ToList();
            List<string> source = new List<string>();
            foreach (string x in temp)
            {
                if (!isAlreadyXml(source, x))
                {
                    source.Add(x);
                }
            }
                XElement xml = new XElement("Uczelnia",
                from string str in source
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
            xml.Save(String.Concat(targetPath + "xmlout.xml"));
        }
        // Obsługa formatu JSON
        public static async Task proccesJson(string sourcePath, string targetPath)
        {
            string[] source = File.ReadAllLines(sourcePath);
            Uczelnia uczelnia = new Uczelnia();
            uczelnia.author = "Paweł Borowiec";
            uczelnia.createTime = DateTime.Now;
            uczelnia.studenci = new List<Student>();
            foreach (string x in source)
            {
                var fields = x.Split(',');
                if (fields.Length == 9)
                {
                    Student temp = new Student();
                    temp.Index = "s" + fields[4];
                    temp.fName = fields[0];
                    temp.lName = fields[1];
                    temp.birthDate = fields[5];
                    temp.email = fields[6];
                    temp.studies = new Studies();
                    temp.studies.name = fields[2];
                    temp.studies.mode = fields[3];
                    temp.mothersName = fields[7];
                    temp.fathersName = fields[8];
                    if (!isAlreadyJson(uczelnia.studenci,temp))
                    {
                        uczelnia.studenci.Add(temp);

                    }                    
                }
                else
                {
                    errors.Add("Not enough arguments in row: "+x);
                }
            }
            string response = JsonSerializer.Serialize(uczelnia);
            await File.WriteAllTextAsync(@"C:\Users\Paweł\Desktop\jsonout.json", response);
        }
        // Logi błędów z podniesionych wyjątków
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
        // Logi błędów z niewłaściwych rekordów
        public static void ErrorLogging()
        {
            string logpath = @"C:\Users\Paweł\Desktop\Log.txt";
            if (!File.Exists(logpath))
            {
                File.Create(logpath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(logpath))
            {
                foreach( string ex in errors)
                {
                    sw.WriteLine("Error logging");
                    sw.WriteLine("Start" + DateTime.Now);
                    sw.WriteLine("Error message: " + ex);
                    sw.WriteLine("End" + DateTime.Now);
                }
            }
        }
        // Sprawdzenie czy dany student znajduje się już w bazie
        public static bool isAlreadyJson(List<Student> list, Student temp)
        {
            foreach(Student x in list)
            {
                if (x.Index.Equals(temp.Index) && x.fName.Equals(temp.fName) && x.lName.Equals(temp.lName))
                {
                    errors.Add("Element " + JsonSerializer.Serialize(temp) + " sie powtarza");
                    return true;
                }
            }
            return false;
        }
        // Sprawdzenie czy dany student już się pojawił dla formatu xml, teoretycznie powinna byc jedna funkcja dla obydwu formatów ale juz tak w praniu wyszlo, ze są dwie
        public static bool isAlreadyXml(List<string> collection, string line)
        {
            string[] fields = line.Split(',');
            foreach (string x in collection)
            {
                string[] temp = x.Split(',');
                if (temp[4].Equals(fields[4]) && temp[0].Equals(fields[0]) && temp[1].Equals(fields[1]))
                {
                    errors.Add("Element " + line + " sie powtarza");
                    return true;
                }
            }
            return false;
        }
    }
}
