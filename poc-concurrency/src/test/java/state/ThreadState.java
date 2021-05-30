package state;

import lombok.Getter;
import lombok.extern.slf4j.Slf4j;
import org.junit.jupiter.api.Test;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.concurrent.CompletableFuture;

@Slf4j
public class ThreadState {

    private static void run() {
        try {
            HttpClient client = HttpClient.newBuilder()
                    .version(HttpClient.Version.HTTP_1_1)
                    .build();

            HttpRequest request = HttpRequest.newBuilder()
                    //.uri(URI.create("http://percy:9048/slow/0"))
                    .uri(URI.create("https://www.google.nl"))
                    .build();

            log.trace("before request");
            CompletableFuture<HttpResponse<Void>> completableFuture = client.sendAsync(request, new SyncSubsriberHandler());
            //HttpResponse.BodyHandler<byte[]> responseBodyHandler = HttpResponse.BodyHandlers.ofByteArray();
        //    CompletableFuture<HttpResponse<byte[]>> completableFuture = client.sendAsync(request, responseBodyHandler);
            completableFuture.thenApply(HttpResponse::body);
            completableFuture.thenApply( reponse -> {
                log.trace("response received: " + reponse.body());
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
                    log.trace("Hijs blocked");
                    break;
                case WAITING:
                    log.trace("Hijs waiting");
                    break;
                case RUNNABLE:
                    log.trace("runnable");
                    break;
                case NEW:
                    log.trace("new");
                    break;
                case TIMED_WAITING:
                    log.trace("timed waiting");
                    break;
                default:
                    log.trace("Iets anders");
                    break;
            }

            Thread.sleep(500);
            state = thread.getState();
        }

        log.trace("thread terminated");
        // thread.join();
    }
}


