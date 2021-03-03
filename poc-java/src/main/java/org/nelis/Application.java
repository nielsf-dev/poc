package org.nelis;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.stream.Stream;

public class Application {

    private static final Logger logger = LoggerFactory.getLogger(Application.class);

    public static void main(String[] args)  {
        logger.info("NEluusss helemaal leip jonge bam");

        try{
            String directory = "C:\\work\\visi-backend\\core\\Service\\Raamwerken\\AuxSystem\\Functions\\OnViewTransactions";
            Stream<Path> pathStream = Files.list(Paths.get(directory));
            pathStream.forEach(path -> {
                try {
                    AuxFile auxFile = new AuxFile(path);
                    auxFile.insertNameProperty();
                }
                catch(Exception ex){
                    logger.error("Failed to insert name", ex);
                    throw new RuntimeException(ex);
                }
            });
        }
        catch (Exception ex){
            logger.error("Errruuurr",ex);
        }
    }
}
