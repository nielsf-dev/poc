package org.nelis.chat;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.OutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.nio.charset.StandardCharsets;

public class Application {
    private static final Logger logger = LoggerFactory.getLogger(Application.class);

    public static void main(String[] args) {
        try{
            logger.info("Starting server..");
            int port = 18717;
            ServerSocket serverSocket = new ServerSocket(port);
            logger.info("Server started: " + port);
            logger.info("Listening..");

            Socket incoming = serverSocket.accept();

            int chr;
            StringBuffer stringBuffer = new StringBuffer();
            while((chr = incoming.getInputStream().read()) != -1){
                stringBuffer.append((char)chr);
                if(chr == 13) {
                    String input = stringBuffer.toString().toUpperCase();
                    String reply = "CHAT: " + input + "\r\n";

                    OutputStream outputStream = incoming.getOutputStream();
                    byte[] bytes = reply.getBytes(StandardCharsets.UTF_8);
                    for (byte bt : bytes) {
                        outputStream.write(bt);
                    }
                    stringBuffer.delete(0, stringBuffer.length()-1);
                }
            }

        }
        catch (Exception ex){
            logger.error("Errur", ex);
        }


    }
}
