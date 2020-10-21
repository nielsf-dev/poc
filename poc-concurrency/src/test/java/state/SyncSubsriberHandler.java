package state;

import java.net.http.HttpResponse;
import java.nio.ByteBuffer;
import java.nio.CharBuffer;
import java.nio.charset.StandardCharsets;
import java.util.List;
import java.util.Map;

public class SyncSubsriberHandler implements HttpResponse.BodyHandler<Void> {

    @Override
    public HttpResponse.BodySubscriber<Void> apply(HttpResponse.ResponseInfo responseInfo) {
        Map<String, List<String>> map = responseInfo.headers().map();
        SyncSubscriber<List<ByteBuffer>> subscriber = new SyncSubscriber<List<ByteBuffer>>() {
            @Override
            protected boolean whenNext(List<ByteBuffer> element) {
                ByteBuffer byteBuffer = element.get(0);


                CharBuffer decode = StandardCharsets.UTF_8.decode(byteBuffer);
                String s2 = decode.toString();

                System.out.println(element.size());
                System.out.println(s2);
                return true;
            }
        };

        HttpResponse.BodySubscriber<Void> bodySubscriber = HttpResponse.BodySubscribers.fromSubscriber(subscriber);
        return bodySubscriber;
    }
}
