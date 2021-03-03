package org.nelis;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import javax.naming.spi.DirectoryManager;
import java.nio.file.Paths;

public class Application {

    private static final Logger logger = LoggerFactory.getLogger(Application.class);

    public static void main(String[] args){
        logger.info("NEluusss helemaal leip jonge bam");
        try{
            String filePath = "C:\\work\\visi-backend\\core\\Service\\Raamwerken\\AuxSystem\\Functions\\OnMessageSave\\MailSubject.cs";
            LineFile lineFile = new LineFile(Paths.get(filePath));
            lineFile.insertName();
        }
        catch (Exception ex){
            logger.error("Errruuurr",ex);
        }
    }
}
