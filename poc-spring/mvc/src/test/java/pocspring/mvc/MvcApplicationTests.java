package pocspring.mvc;

import org.junit.jupiter.api.Test;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.test.context.SpringBootTest;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.nio.file.Files;
import java.nio.file.Path;

@SpringBootTest
class MvcApplicationTests {

    Logger logger = LoggerFactory.getLogger(MvcApplicationTests.class);

    @Test
    void contextLoads() throws IOException {

        HttpClient httpClient = HttpClient.newBuilder()
                .version(HttpClient.Version.HTTP_1_1)
                .build();

        //Path path = Path.of("C:\\work\\poc\\poc-spring\\mvc\\gradlew");
        Path path = Path.of("C:\\Users\\Niels\\Downloads\\adwcleaner_8.0.5.exe");
        byte[] bytes = Files.readAllBytes(path);

        try {
            HttpRequest request = HttpRequest.newBuilder()
                    .uri(URI.create("http://localhost:5188/api/file/binary"))
                    .setHeader("Content-Type", "application/json")
                    .POST(HttpRequest.BodyPublishers.ofByteArray(bytes))
                    .build();

            HttpResponse<String> response = httpClient.send(request, HttpResponse.BodyHandlers.ofString());
            String body = response.body();
            System.out.println(body);
        } catch (Exception ex) {
            logger.error(ex.getMessage());
        }
    }

}
