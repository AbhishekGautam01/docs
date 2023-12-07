using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    internal class ExcelReport: ReportBuilder
    {
        public override void SetReportConetent()
        {
            report.ReportContent = "Excel Coontent";
        }
        public override void SetReportFooter()
        {
            report.ReportFooter = "Excel Footer";
        }

        public override void SetReportHeader()
        {
            report.ReportHeader = "Excel Header";
        }
        public override void SetReportType()
        {
            report.ReportType = "Excel";
        }
    }
}
