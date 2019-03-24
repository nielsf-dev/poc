import java.util.*;

public class HelloClass{
  public static void main(String[] args) throws Exception {
    System.out.println("Hello");

    NewsStation newsStation = new NewsStation("Georgia");
    System.out.println(newsStation.broadCast());

    Properties properties = System.getProperties();
    for (String propertyName : properties.stringPropertyNames()) {
      System.out.println(propertyName + ": " + System.getProperty(propertyName));
    }

    System.in.read();
  }
}
