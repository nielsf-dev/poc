package org.poc.heavyload;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.IOException;
import java.io.InputStream;
import java.net.Socket;
import java.nio.Buffer;
import java.nio.charset.Charset;
import java.util.Arrays;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.concurrent.atomic.AtomicLong;

@Component
public class Runner implements CommandLineRunner {
    Logger logger = LoggerFactory.getLogger(Runner.class);

    static AtomicLong connections = new AtomicLong(0);
    static AtomicLong reads = new AtomicLong(0);
    static AtomicLong readTimeTotal = new AtomicLong(0);
    static AtomicLong writes = new AtomicLong(0);
    static AtomicLong writeTimeTotal = new AtomicLong(0);
    long totalElapsed = 0;

    static AtomicBoolean shutDown = new AtomicBoolean(false);

    @Override
    public void run(String... args) throws Exception {
        ExecutorService executorService = Executors.newFixedThreadPool(30000);

        final Socket[] sockets = new Socket[Integer.parseInt(args[0])]; // Create 3000 connections
        for (int x = 0; x < sockets.length; x++) {
            try {
                long l = connections.incrementAndGet();

                long start = System.nanoTime();
                Socket socket = new Socket(args[1], Integer.parseInt(args[2]));
                long elapsed = System.nanoTime() - start;

                System.out.println("Connected " + l + " took " + elapsed/1000000 + "ms");
                totalElapsed += elapsed;

                sockets[x] = socket;
                executorService.submit(() -> handleSocket(socket, l));
                
            } catch (final IOException e) {
                System.err.println(e);
            }
        }

        System.out.println("Connected " + sockets.length + " sockets. Average: " + (totalElapsed/sockets.length)/1000000 + "ms");

        long readsNow = reads.longValue();
        System.out.println("ReadTime total = " + readTimeTotal);
        System.out.println(readsNow + " reads. Average: " + (readTimeTotal.get()/ readsNow)/1000000 + "ms");

        long writesnow = writes.longValue();
        System.out.println("WriteTime total = " + writeTimeTotal);
        System.out.println(writesnow + " writes. Average: " + (writeTimeTotal.get()/ writesnow)/1000000 + "ms");

        shutDown.set(true);
        executorService.shutdown();
        executorService.awaitTermination(55, TimeUnit.MILLISECONDS);
    }

    private void handleSocket(Socket socket, long connection)  {
        int error = 0;
        while(!shutDown.get()){
            try {
                long startWrite = System.nanoTime();
                String s1 = "King Niels aan de macht super cool kickken HATERS GONNA GATE THE END";
                byte[] bytesTHatGoIn = s1.getBytes();
                socket.getOutputStream().write(bytesTHatGoIn);
                writeTimeTotal.addAndGet(System.nanoTime() - startWrite);
                writes.incrementAndGet();

                long startRead = System.nanoTime();
                InputStream inputStream = socket.getInputStream();
                byte[] buffer = new byte[s1.length()];
                byte read = (byte) inputStream.read(buffer,0,buffer.length);
                readTimeTotal.addAndGet(System.nanoTime() - startRead);
                reads.incrementAndGet();

                byte[] readBytes = Arrays.copyOf(buffer, read);
                String readFromSocket = new String(readBytes);
                logger.info("Read from socket on connection " + connection + ": " + readFromSocket);

                Thread.sleep(50);
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
