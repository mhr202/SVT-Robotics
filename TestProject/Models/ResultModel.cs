namespace TestProject.Models;

public class ResultModel {
  public int robotId { get; set; }

  public double distanceToGoal { get; set; }

  public int batteryLevel { get; set; }

  public ResultModel(int roboId = 0, double distanceToGoal = 0.0, int batteryLevel = 0) {
    this.robotId = roboId;
    this.distanceToGoal = distanceToGoal;
    this.batteryLevel = batteryLevel;
  }
}