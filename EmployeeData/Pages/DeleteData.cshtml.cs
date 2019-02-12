using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeData.Pages
{
    public class DeleteDataModel : PageModel
    {
        public string Message { get; set; }
        public string[] savedData;
        public string[] data = new string[4];

        public List<string> id = new List<string> { };
        public List<string> name = new List<string> { };
        public List<string> designation = new List<string> { };
        public List<string> contact = new List<string> { };
        public int toDelete = 0;

        public void OnGet()
        {
            string ID = Request.QueryString.Value;
            if (ID == null)
            {
                Message = "Looks like you didn't enter an ID";
            }
            else
            {

                savedData = System.IO.File.ReadAllLines("employeeData.dat");

                foreach (var line in savedData)
                {
                    data = line.Split(",");

                    id.Add(data[1]);
                    name.Add(data[2]);
                    designation.Add(data[3]);
                    contact.Add(data[4]);
                }

                int n = 0;
                foreach (string j in id)
                {
                    if (j == ID.Split("=")[1])
                    {
                        toDelete = n;
                        break;
                    }
                    n++;
                }

                if (toDelete == n)
                {
                    Message = "Data Deleted!";
                    List<string> lines = System.IO.File.ReadAllLines("employeeData.dat").ToList();
                    lines.RemoveAt(n);
                    System.IO.File.WriteAllLines("employeeData.dat", lines);
                }
                else
                {
                    Message = "No Employee ID with entered text found.";
                }

            }
        }
    }
}