using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    internal class PDFReport: ReportBuilder
    {
        public override void SetReportConetent()
        {
            report.ReportContent = "PDF Coontent";
        }
        public override void SetReportFooter()
        {
            report.ReportFooter = "PDF Footer";
        }

        public override void SetReportHeader()
        {
            report.ReportHeader = "PDF Header";
        }
        public override void SetReportType()
        {
            report.ReportType = "PDF";
        }
    }
}
