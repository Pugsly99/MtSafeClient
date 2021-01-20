using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MtSafeClient.Models
{
  public class Report
  {
    public int ReportId {get; set;}
    [DisplayName("Add Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Date {get; set;}
    public string Condition {get; set;}
    public string Location {get; set;}
    public string Username {get; set;}

    public static List<Report> GetReports()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Report> reportList = JsonConvert.DeserializeObject<List<Report>>(jsonResponse.ToString());

      return reportList;
    }

    public static Report GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Report report = JsonConvert.DeserializeObject<Report>(jsonResponse.ToString());

      return report;
    }
    public static void Post(Report report)
    {
      string jsonReport = JsonConvert.SerializeObject(report);
      var apiCallTask = ApiHelper.Post(jsonReport);
    }
    public static void Put(Report report)
    {
      string jsonReport = JsonConvert.SerializeObject(report);
      var apiCallTask = ApiHelper.Put(report.ReportId, jsonReport);
    }

    public static void Delete (int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}