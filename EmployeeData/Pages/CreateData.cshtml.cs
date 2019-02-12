using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeData.Pages
{
    public class CreateDataModel : PageModel
    {
        public string Message { get; set; }
        public string[] dataEntered;

        public void OnGet()
        {
            string textBoxEntries = Request.QueryString.Value;
            if (textBoxEntries == null)
            {
                Message = "NO ENTRIES. TRY AGAIN";
            }
            else
            {
                string[] lines = System.IO.File.ReadAllLines("employeeData.dat");
                dataEntered = new string[4];
                dataEntered = textBoxEntries.Split("&");

                string Data = (lines.Length + 1).ToString();
                foreach (string item in dataEntered)
                {
                    Data = Data + "," + item.Split("=")[1];
                }

                System.IO.File.AppendAllText("employeeData.dat", Data + Environment.NewLine);
            }
        }
    }
}
