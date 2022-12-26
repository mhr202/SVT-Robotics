using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using Newtonsoft.Json;
using TestProject.Helpers.Api;

namespace TestProject.Controllers;

public class APIController : Controller
{
  private readonly ILogger<APIController> _logger;

  public APIController(ILogger<APIController> logger)
  {
    _logger = logger;

  }

  string Baseurl = "https://60c8ed887dafc90017ffbd56.mockapi.io/";

  [Route("/api/robots/closest")]
  [HttpPost]
  public async Task<string> closest([FromBody] PayloadModel payload)
  {

    if (payload.loadId != 0 && payload.x != -1 && payload.y != -1)
    {
      List<RobotModel> RoboInfo = new List<RobotModel>();

      using (var client = new HttpClient())
      {
        RoboInfo = JsonConvert.DeserializeObject<List<RobotModel>>(await HttpHelper.ConsumeApi(Baseurl));

        return RobotHelper.ReturnResultPayload(RoboInfo, payload);

      }
      //returning the Roboloyee list to view
    }
    return "Correct Payload is not being fed";
  }
}