﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class ReportDirector
    {
        public Report MakeReport(ReportBuilder reportBuilder)
        {
            reportBuilder.CreateNewReport();
            reportBuilder.SetReportType();
            reportBuilder.SetReportHeader();
            reportBuilder.SetReportConetent();
            reportBuilder.SetReportFooter();

            return reportBuilder.GetReport();
        }
    }
}
