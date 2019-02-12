using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeData.Pages
{
    public class ViewModel : PageModel
    {
        public string Message { get; set; }
        public string[] savedData;
        public string[] localData = new string[4];

        public List<string> id = new List<string> { };
        public List<string> name = new List<string> { };
        public List<string> designation = new List<string> { };
        public List<string> contact = new List<string> { };

        public void OnGet()
        {
            savedData = System.IO.File.ReadAllLines("employeeData.dat");


            foreach (var line in savedData)
            {
                localData = line.Split(",");

                id.Add(localData[1]);
                name.Add(localData[2]);
                designation.Add(localData[3]);
                contact.Add(localData[4]);
            }
        }
    }
}
