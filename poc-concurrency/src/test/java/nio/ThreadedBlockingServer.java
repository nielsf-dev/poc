package nio;
import org.junit.jupiter.api.Test;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.UncheckedIOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.nio.charset.Charset;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.concurrent.atomic.AtomicLong;

public class ThreadedBlockingServer {

    static AtomicLong connections = new AtomicLong(0);
    static Logger logger = LoggerFactory.getLogger(ThreadedBlockingServer.class);

    public ThreadedBlockingServer() throws NoSuchAlgorithmException {
    }

    @Test
    public void test() throws IOException {
        final ServerSocket serverSocket = new ServerSocket(8080); // Creating the server on port 8080
        while (true) {
            // Accept means it will accept the incoming connection
            try {
                System.out.println("accepting..");
                final Socket socket = serverSocket.accept(); // Blocking until someone connects
                System.out.println("..after accept");
                //   System.out.println("Incoming connection " + connections);

                new Thread(() -> handle(socket)).start();
            }
            catch(Exception exception){
                System.out.println(exception);
            }
        }
    }

    /**
     * Read from socket and do operation and then write back on socket.
     */
    private static void handle(final Socket socket) {
        long l = connections.incrementAndGet();
        System.out.println("Handling connection " + l);

        while(true) {
            try  {
                InputStream inputStream = socket.getInputStream();
                OutputStream outputStream = socket.getOutputStream();

                String input = readString(inputStream);
                if(!input.isEmpty() && !input.isBlank()) {
                    MessageDigest messageDigest = MessageDigest.getInstance("MD5");
                    byte[] digest = messageDigest.digest(input.getBytes());
                    String md5 = toHexString(digest);
                    String output = input + " " + md5;

                    outputStream.write(output.getBytes());
                }
                else
                    logger.error("Ongeldige string gelezen: " + input);

            } catch (Exception e) {
                logger.error("Error in handlen van socket", e);
            }
        }
    }

    public static String toHexString(byte[] bytes) {
        StringBuilder hexString = new StringBuilder();

        for (int i = 0; i < bytes.length; i++) {
            String hex = Integer.toHexString(0xFF & bytes[i]);
            if (hex.length() == 1) {
                hexString.append('0');
            }
            hexString.append(hex);
        }

        return hexString.toString();
    }

    private static String readString(InputStream inputStream) throws IOException {
        int data;
        StringBuilder sb = new StringBuilder();
        while ((data = inputStream.read()) != -1) { // -1 -> end of stream
            // Data read from socket

            // Operation performed
            char chr = (char) data;
            sb.append(chr);

            if(chr == '\n')
                break;
        }

        return sb.toString();
    }

    private static int invertCase(final int data) {
        return Character.isUpperCase(data)
                ? Character.toLowerCase(data)
                : Character.toUpperCase(data);
    }
}
