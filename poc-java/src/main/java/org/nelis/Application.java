package org.nelis;

import org.nelis.hibernate.DbService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.Console;
import java.io.IOException;
import java.nio.ByteBuffer;
import java.nio.channels.AsynchronousFileChannel;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.Future;
import java.util.stream.Stream;

public class Application {

    private static final Logger logger = LoggerFactory.getLogger(Application.class);

    public static void main(String[] args)  {
        logger.info("NEluusss helemaal leip jonge bam");

        try{

            asyncFileRead();
            //         DbService.gogo();

            System.in.read();
        }
        catch (Exception ex){
            logger.error("Errruuurr",ex);
        }
    }

    private static void asyncFileRead() throws IOException {
        Path path = Paths.get("C:\\work\\poc\\poc-java\\src\\main\\resources\\META-INF\\persistence.xml");
        AsynchronousFileChannel fileChannel = AsynchronousFileChannel.open(path, StandardOpenOption.READ);

        ByteBuffer buffer = ByteBuffer.allocate(1024);
        long position = 0;

        Future<Integer> operation = fileChannel.read(buffer, position);
        while(!operation.isDone());

        buffer.flip();
        byte[] data = new byte[buffer.limit()];
        buffer.get(data);
        System.out.println(new String(data));
        buffer.clear();
    }

    private static void changeAux() throws IOException {
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
}
