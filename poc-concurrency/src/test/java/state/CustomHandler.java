package state;

import java.net.http.HttpResponse;
import java.nio.charset.Charset;

public class CustomHandler implements HttpResponse.BodyHandler<String> {
    @Override
    public HttpResponse.BodySubscriber<String> apply(HttpResponse.ResponseInfo responseInfo) {
        if (responseInfo.statusCode() == 200)
            return HttpResponse.BodySubscribers.ofString(Charset.defaultCharset());
        else {
            System.out.println("no bueno");
            return null;
        }
    }
}
