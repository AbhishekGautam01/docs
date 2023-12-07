using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class Report
    {
        public string ReportType { get; set; }
        public string ReportHeader { get; set; }
        public string ReportFooter { get; set; }
        public string ReportContent { get; set; }
        public void DisplayReport()
        {
            Console.WriteLine("Report Type: " + ReportType);
            Console.WriteLine("Report Header: " + ReportHeader);
            Console.WriteLine("Report Conetent: " + ReportContent);
            Console.WriteLine("Report Footer: " + ReportFooter);
        }
    }
}
