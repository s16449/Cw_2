using Cw_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Serialization;

namespace Cw_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileInput = args.Length > 0 ? args[0] : @"C:\Users\Manius83pl\source\repos\Cw_2\Cw_2\Data\dane.csv";
            string fileOutputPath = args.Length > 1 ? args[1] : @"C:\Users\Manius83pl\source\repos\Cw_2\Cw_2\Data\";
            string dataFormat = args.Length > 2 ? args[2] : "xml"; //domyslny xml
            string logPath = @"C:\Users\Manius83pl\source\repos\Cw_2\Cw_2\Data\log.txt";



          //  Console.WriteLine(fileInput + "\n" + fileOutputPath + "\n" + dataFormat);

            try
            {
                if (!File.Exists(fileInput))
                {

                    throw new FileNotFoundException("File does not exist");
                }
                if (!Directory.Exists(fileOutputPath))
                {
                    throw new ArgumentException("Wrong path");
                }

                var list = new List<Student>();
                University uczelnia = new University()
                {
                    Author = "Mariusz Polak"
                };

                using (var stream = new StreamReader(File.OpenRead(fileInput)))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] student = line.Split(',');
                        //  Console.WriteLine(line);
                        var st = new Student
                        {
                            Index = student[4],
                            First_Name = student[0],
                            Last_Name = student[1],
                            Birth_Date = student[5],
                            Email = student[6],
                            Mother_Name = student[7],
                            Father_Name = student[8],
                            Studies_Info = new Studies
                            {
                                Studies_Name = student[2],
                                Studies_Mode = student[3]
                            }

                        };
                        // Console.WriteLine(student.Length.ToString());
                        if (student.Contains(""))
                        {
                            Console.WriteLine(st.ToString());
                            File.AppendAllText(logPath, st.ToString() + " : empty space in record\n");
                        }
                        else if (student.Length > 9)
                        {
                            File.AppendAllText(logPath, st + " : not enough data\n");
                        }
                        else
                        {
                            uczelnia.Students.Add(st);
                        }

                        if (uczelnia.Active_Studies != null)
                        {
                            foreach (ActiveStudies ac in uczelnia.Active_Studies)
                            {
                                if (ac.Name_of_Studies == student[2])
                                    Console.WriteLine(ac);
                            }

                        }
                        else
                        {
                            var activeStudies = new ActiveStudies
                            {
                                Name_of_Studies = student[2],
                                Number_Of_Students = 1

                            };
                            //uczelnia.Active_Studies.Add(activeStudies);
                        }
                    }
                }
                if (dataFormat.Equals("json"))
                {

                    var jsonString = JsonSerializer.Serialize(list);
                    File.WriteAllText(fileOutputPath + "dane.json", jsonString);

                }
                else
                {
                    FileStream writer = new FileStream(fileOutputPath + "dane.xml", FileMode.Create);
                    XmlSerializer serializer = new XmlSerializer(typeof(University));
                    serializer.Serialize(writer, uczelnia);
                }
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine("Wrong path");
                File.AppendAllText(logPath, fileOutputPath + " : wrong path");

            }
            catch (FileNotFoundException exx)
            {
                Console.WriteLine("File does not exist");
                File.AppendAllText(logPath, fileInput + " : missing file");
            }
        }
    }
}
