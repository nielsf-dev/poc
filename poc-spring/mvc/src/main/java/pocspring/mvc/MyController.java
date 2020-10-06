package pocspring.mvc;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.nio.file.Path;

@RestController
public class MyController {
    Logger logger = LoggerFactory.getLogger(MyController.class);

    @GetMapping("/")
    public String test() throws IOException, InterruptedException {
        HttpClient httpClient = HttpClient.newHttpClient();
        Path path = Path.of("C:\\work\\poc\\poc-spring\\mvc\\gradlew");

        try {
            HttpRequest request = HttpRequest.newBuilder()
                    .uri(URI.create("http://localhost:5188/api/file/binary"))
                    .setHeader("Content-Type","application/json")
                    .POST(HttpRequest.BodyPublishers.ofFile(path))
                    .build();

            HttpResponse<String> response = httpClient.send(request, HttpResponse.BodyHandlers.ofString());
            return response.body();
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            return "error";
        }
    }
}
