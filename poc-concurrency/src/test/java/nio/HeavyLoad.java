package nio;

import org.junit.Test;

import java.io.IOException;
import java.net.Socket;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.atomic.AtomicLong;

public class HeavyLoad {
    static AtomicLong connections = new AtomicLong(0);

    @Test
    public void main() throws InterruptedException {
        ExecutorService executorService = Executors.newFixedThreadPool(30000);

        final Socket[] sockets = new Socket[30000]; // Create 3000 connections
        for (int x = 0; x < sockets.length; x++) {
            try {
                Socket socket = new Socket("localhost", 8080);
                sockets[x] = socket;

                executorService.submit(() -> handleSocket(socket));
            } catch (final IOException e) {
                System.err.println(e);
            }
        }
        // To enable the sockets to live. for awhile
        Thread.sleep(Long.MAX_VALUE);
    }

    private void handleSocket(Socket socket)  {
        long l = connections.incrementAndGet();
        while(true){
            try {
                socket.getOutputStream().write("a".getBytes());
                byte read = (byte)socket.getInputStream().read();
                String s = String.valueOf(read);
                System.out.println(s + " from thread " + l);
            }
            catch(Exception ex){
                System.out.println(ex);
            }
        }
    }
}
