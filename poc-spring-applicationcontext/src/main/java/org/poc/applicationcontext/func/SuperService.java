package org.poc.applicationcontext.func;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class SuperService {

    @Autowired
    Clock clock;

    public String doSomethingAwesome(){
        int theTime = clock.getTheTime();
        return "It is " + theTime + " o'clock!";
    }
}
