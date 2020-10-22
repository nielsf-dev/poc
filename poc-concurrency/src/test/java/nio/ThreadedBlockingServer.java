package nio;

import org.junit.Test;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.UncheckedIOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.concurrent.atomic.AtomicLong;

public class ThreadedBlockingServer {

    static AtomicLong connections = new AtomicLong(0);

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

        try (InputStream inputStream = socket.getInputStream();
             OutputStream outputStream = socket.getOutputStream()) {
            int data;
            while ((data = inputStream.read()) != -1) { // -1 -> end of stream
                // Data read from socket

                // Operation performed
                data = Character.isLetter(data) ? invertCase(data) : data;

                // Changed output written back to socket
                outputStream.write(data);
            }
        } catch (final IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    private static int invertCase(final int data) {
        return Character.isUpperCase(data)
                ? Character.toLowerCase(data)
                : Character.toUpperCase(data);
    }
}
