import java.io.IOException;
import java.net.Socket;

public class SimulateHeavyLoad {
    public static void main(String[] args) throws InterruptedException {
        final Socket[] sockets = new Socket[18000]; // Create 3000 connections
        for (int x = 0; x < sockets.length; x++) {
            try {
                sockets[x] = new Socket("localhost", 8080);
            } catch (final IOException e) {
                System.err.println(e);
            }
        }
        // To enable the sockets to live. for awhile
        Thread.sleep(Long.MAX_VALUE);
    }
}
