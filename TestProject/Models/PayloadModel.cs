namespace TestProject.Models;

public class PayloadModel {
  public int loadId { get; set; }

  public int x { get; set; }

  public int y { get; set; }

  public PayloadModel() {
    loadId = 0;
    x = -1;
    y = -1;
  }
}