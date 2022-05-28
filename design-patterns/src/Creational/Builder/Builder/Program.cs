using System;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Client Code 
            Report report; 
            ReportDirector director = new ReportDirector();

            //Construct and display report 
            PDFReport pDFReport = new PDFReport();
            report = director.MakeReport(pDFReport);
            report.DisplayReport();

            Console.WriteLine("----------------------");

            ExcelReport excelReport = new ExcelReport();
            report = director.MakeReport(excelReport);
            report.DisplayReport();

            Console.ReadKey();  

        }
    }
}
