package state;

import org.junit.Test;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.concurrent.CompletableFuture;

public class ThreadState {
    private static Logger logger = LoggerFactory.getLogger(ThreadState.class);

    private static void run() {
        try {
            HttpClient client = HttpClient.newBuilder()
                    .version(HttpClient.Version.HTTP_1_1)
                    .build();

            HttpRequest request = HttpRequest.newBuilder()
                    //.uri(URI.create("http://percy:9048/slow/0"))
                    .uri(URI.create("http://localhost:9048/large"))
                    .build();

            logger.trace("before request");
            CompletableFuture<HttpResponse<Void>> completableFuture = client.sendAsync(request, new SyncSubsriberHandler());
            //HttpResponse.BodyHandler<byte[]> responseBodyHandler = HttpResponse.BodyHandlers.ofByteArray();
        //    CompletableFuture<HttpResponse<byte[]>> completableFuture = client.sendAsync(request, responseBodyHandler);
            completableFuture.thenApply(HttpResponse::body);
            completableFuture.thenApply( reponse -> {
                logger.trace("response received: " + reponse.body());
                return reponse;
            });
            completableFuture.get();
        }
        catch(Exception ex) {
            System.out.println("Fout in thread: " + ex);
        }
    }

    @Test
    public void test() throws Exception {

        Thread thread = new Thread(ThreadState::run);
        thread.start();

        Thread.State state = thread.getState();
        while(state != Thread.State.TERMINATED) {
            switch(state){
                case BLOCKED:
                    logger.trace("Hijs blocked");
                    break;
                case WAITING:
                    logger.trace("Hijs waiting");
                    break;
                case RUNNABLE:
                    logger.trace("runnable");
                    break;
                case NEW:
                    logger.trace("new");
                    break;
                case TIMED_WAITING:
                    logger.trace("timed waiting");
                    break;
                default:
                    logger.trace("Iets anders");
                    break;
            }

            Thread.sleep(500);
            state = thread.getState();
        }

        logger.trace("thread terminated");
        // thread.join();
    }
}


