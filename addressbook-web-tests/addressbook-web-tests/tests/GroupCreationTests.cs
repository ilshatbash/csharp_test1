using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTest : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(50),
                    Footer = GenerateRandomString(50)
                });                    
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv", Encoding.Default);
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }



        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>)).
                Deserialize(new StreamReader(@"groups.xml"));
        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>
                (File.ReadAllText(@"groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;

            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;
        }



        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTests(GroupData group)
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            app.Groups.Create(group);
            //Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData>newGroups= GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
        }


        [Test]
        public void TestDBConnectivity()
        {
            DateTime start1 = DateTime.Now;
            List<GroupData>fromUI= app.Groups.GetGroupList();
            DateTime end1 = DateTime.Now;
            System.Console.Out.WriteLine("UI-"+ end1.Subtract(start1));

            DateTime start2 = DateTime.Now;
            List<GroupData> fromDB = GroupData.GetAll();            
            DateTime end2 = DateTime.Now;
            System.Console.Out.WriteLine("DB-"+ end2.Subtract(start2));
           
        }
        [Test]
        public void TestDBConnectivity2()
        {
            System.Console.Out.WriteLine("В группу ввхояд следующие контакты:");
            foreach (ContactData contact in GroupData.GetAll()[1].GetContacts())
            {
                System.Console.Out.WriteLine(contact);
            }

        }

    }
}