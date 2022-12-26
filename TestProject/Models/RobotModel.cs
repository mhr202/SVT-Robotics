namespace TestProject.Models;

public class RobotModel {
  public int robotId { get; set; }

  public int batteryLevel { get; set; }

  public int x { get; set; }

  public int y { get; set; }

  public RobotModel() {
    robotId = 0;
    batteryLevel = 0;
    x = 0;
    y = 0;
  }

  public RobotModel Equals(RobotModel Robot) {
    robotId = Robot.robotId;
    batteryLevel = Robot.batteryLevel;
    x = Robot.x;
    y = Robot.y;
    return this;
  }

}