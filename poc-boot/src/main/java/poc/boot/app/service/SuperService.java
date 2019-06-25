package poc.boot.app.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class SuperService {

    @Autowired
    Clock clock;

    public String doSomethingAwesome(){
        int theTime = clock.getTheTime();
        String text = "It is " + theTime + " o'clock!";
        System.out.println(text);
        return text;
    }
}
