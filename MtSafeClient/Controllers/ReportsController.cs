using MtSafeClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MtSafeClient.Controllers
{
  public class ReportsController : Controller
  { 
    public IActionResult Index()
  {
    List<Report> allReports = Report.GetReports();
    return View(allReports);
  }
  }
}