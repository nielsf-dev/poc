/*
 * This Java source file was generated by the Gradle 'init' task.
 */
package org.poc.applicationcontext;

import org.poc.applicationcontext.func.SuperService;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.util.Locale;
import java.util.ResourceBundle;

public class App {
    public String getGreeting() {
        return "Hello world.";
    }

    public static void main(String[] args) throws IOException {
        ApplicationContext ctx = new AnnotationConfigApplicationContext(AppConfig.class);
        SuperService bean = ctx.getBean(SuperService.class);

        Locale aDefault = Locale.getDefault();
        Locale.setDefault(new Locale("nl","NL"));
        Locale aDefault2 = Locale.getDefault();

        ResourceBundle messages = ResourceBundle.getBundle("messages");
        System.out.println(messages.getString("who_text"));
    }
}