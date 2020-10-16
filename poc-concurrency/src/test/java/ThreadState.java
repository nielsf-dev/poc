import org.junit.Test;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import javax.net.ssl.SSLContext;
import javax.net.ssl.SSLParameters;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;
import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.security.SecureRandom;
import java.security.cert.X509Certificate;

public class ThreadState {
     private static Logger logger = LoggerFactory.getLogger(ThreadState.class);

    private static void run() {
        try {
            TrustManager[] trustAllCerts = new TrustManager[] { new X509TrustManager() {
                public java.security.cert.X509Certificate[] getAcceptedIssuers() {
                    logger.trace("getting acccepted issures");
                    return null;
                }
                public void checkClientTrusted(X509Certificate[] certs, String authType) {
                    logger.trace("checkClientTrusted");
                }
                public void checkServerTrusted(X509Certificate[] certs, String authType) {
                    logger.trace("checkServerTrusted");
                }
            } };

            SSLContext sslContext = SSLContext.getInstance("SSL");
            sslContext.init(null, trustAllCerts, new SecureRandom());

            SSLParameters sslParameters = new SSLParameters();
            // This should prevent host validation
            sslParameters.setEndpointIdentificationAlgorithm("");

            HttpClient client = HttpClient.newBuilder()
                    .version(HttpClient.Version.HTTP_1_1)
                    .sslParameters(sslParameters)
                    .sslContext(sslContext)
                    .build();
//http://ipv4.download.thinkbroadband.com/512MB.zip
            HttpRequest request = HttpRequest.newBuilder()
                    .uri(URI.create("https://speed.hetzner.de/100MB.bin"))
                    .build();
            logger.trace("before request");
           HttpResponse<byte[]> response = client.send(request, HttpResponse.BodyHandlers.ofByteArray());
         //   Thread.sleep(1000*2);
            logger.trace("after request");
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
                case TERMINATED:
                    logger.trace("terminated");
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
       // thread.join();
    }

    private void threadFunction(){

    }
}
