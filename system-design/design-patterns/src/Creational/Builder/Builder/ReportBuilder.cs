using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public abstract class ReportBuilder
    {
        protected Report report;
        public abstract void SetReportType();
        public abstract void SetReportHeader();
        public abstract void SetReportConetent();
        public abstract void SetReportFooter();

        public void CreateNewReport()
        {
            report = new Report();
        }

        public Report GetReport()
        {
            return report;
        }
    }
}
