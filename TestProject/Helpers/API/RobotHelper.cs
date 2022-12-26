using Newtonsoft.Json;
using TestProject.Models;

namespace TestProject.Helpers.Api;

public static class RobotHelper {
  private static double CalculateDistance(RobotModel Robot, int x, int y) {
    var xCor = Robot.x - x;
    var yCor = Robot.y - y;
    xCor = xCor * xCor;
    yCor = yCor * yCor;
    return Math.Sqrt(xCor + yCor);
  }

  private static RobotModel MaxBattery(List < RobotModel > RobotList) {
    RobotModel Robo = new RobotModel();
    int Max = 0;
    foreach(var Robots in RobotList) {
      if (Robots.batteryLevel > Max) {
        Max = Robots.batteryLevel;
        Robo = Robots;
      }
    }
    return Robo;
  }

  private static RobotModel CalculateNearestRobot(List < RobotModel > RoboInfo, PayloadModel payload) {
    RobotModel Robo = new RobotModel();
    double Min = 2147483647;
    List < RobotModel > RoboList = new List < RobotModel > ();

    foreach(var Robot in RoboInfo) {
      var Distance = RobotHelper.CalculateDistance(Robot, payload.x, payload.y);
      if (Distance < Min) {
        Min = Distance;
        Robo = Robot;
      }
      if (Distance < 10) {
        RoboList.Add(Robot);
      }
    }
    if (RoboList.Count() > 1) {
      Robo = RobotHelper.MaxBattery(RoboList);
    }
    return Robo;
  }

  public static string ReturnResultPayload(List < RobotModel > RoboInfo, PayloadModel payload) {
    RobotModel Robo = new RobotModel();
    
    Robo = RobotHelper.CalculateNearestRobot(RoboInfo, payload);
    ResultModel ResultPayload = new ResultModel(Robo.robotId, RobotHelper.CalculateDistance(Robo, payload.x, payload.y), Robo.batteryLevel);

    return JsonConvert.SerializeObject(ResultPayload);
  }

}