public class NewsStation{
  private String location;

  public NewsStation(String location){
    this.location = location;
  }

  public String broadCast(){
    return "Another broadcast from " + location;
  }
}
