package org.poc.heavyload;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;
import java.util.Arrays;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.concurrent.atomic.AtomicLong;

@Component
public class Runner implements CommandLineRunner {
    Logger logger = LoggerFactory.getLogger(Runner.class);

    long connections = 0;

    static AtomicLong requests = new AtomicLong(0);
    static AtomicLong requestTimeTotal = new AtomicLong(0);
    long totalElapsed = 0;

    static AtomicBoolean shutDown = new AtomicBoolean(false);

    @Override
    public void run(String... args) throws Exception {
        int nConnections = Integer.parseInt(args[0]);
        ExecutorService executorService = Executors.newFixedThreadPool(nConnections);

        final Socket[] sockets = new Socket[nConnections]; // Create n connections
        for (int x = 0; x < sockets.length; x++) {
            try {


                long start = System.nanoTime();
                Socket socket = new Socket(args[1], Integer.parseInt(args[2]));
                long elapsed = System.nanoTime() - start;

                System.out.println("Connected " + ++connections + " took " + elapsed/1000000 + "ms");
                totalElapsed += elapsed;

                sockets[x] = socket;
                Future<?> future = executorService.submit(() -> handleSocket(socket, connections));

            } catch (final IOException e) {
                System.err.println(e);
            }
        }

        System.out.println("Connected " + sockets.length + " sockets. Average: " + (totalElapsed/sockets.length)/1000000 + "ms");

        while(true) {
            long writesnow = requests.longValue();
            System.out.println(writesnow + " Requests. Average: " + (requestTimeTotal.get() / writesnow) / 1000000 + "ms");

            requests.set(0);
            requestTimeTotal.set(0);
            Thread.sleep(1000 * 3);
        }

//        shutDown.set(true);
//        executorService.shutdown();
//        executorService.awaitTermination(55, TimeUnit.MILLISECONDS);
    }

    private void handleSocket(Socket socket, long connection)  {
        int error = 0;
        while(!shutDown.get()){
            try {
                OutputStream outputStream = socket.getOutputStream();
                InputStream inputStream = socket.getInputStream();

                long startWrite = System.nanoTime();
                String s1 = "King Niels aan de macht super cool kickken HATERS GONNA GATE THE END\n";
                byte[] bytesTHatGoIn = s1.getBytes();
                outputStream.write(bytesTHatGoIn);

                byte[] buffer = new byte[s1.length() + 33];
                byte read = (byte) inputStream.read(buffer,0,buffer.length);
                if(read == -1)
                    System.out.println("viel niks te lezen na een write op connection " + connection);
                else {
                    requestTimeTotal.addAndGet(System.nanoTime() - startWrite);
                    requests.incrementAndGet();

                    byte[] readBytes = Arrays.copyOf(buffer, read);
                    String readFromSocket = new String(readBytes);
                    logger.info("Read from socket on connection " + connection + ": " + readFromSocket);
                }
            }
            catch(Exception ex){
                if(ex instanceof InterruptedException) {
                    try {
                        socket.close();
                    } catch (IOException e) {
                    }
                    return;
                }

                if(error == 0)
                    System.out.println(ex);
                error++;
            }
        }
    }
}
