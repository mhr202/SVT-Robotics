using TestProject.Models;
using System.Net.Http.Headers;

namespace TestProject.Helpers.Api;

public static class HttpHelper
{
  public static async Task<string> ConsumeApi(string Baseurl)
  {
    using (var client = new HttpClient())
    {
      List<RobotModel> RoboInfo = new List<RobotModel>();

      client.BaseAddress = new Uri(Baseurl);
      client.DefaultRequestHeaders.Clear();

      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      HttpResponseMessage Res = await client.GetAsync("robots");

      if (Res.IsSuccessStatusCode)
      {
        var RoboResponse = Res.Content.ReadAsStringAsync().Result;
        return RoboResponse;
      }
    }
    return "Error!";
  }
}