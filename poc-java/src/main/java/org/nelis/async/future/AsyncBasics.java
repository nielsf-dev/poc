package org.nelis.async.future;

import java.util.concurrent.*;
import java.util.function.Consumer;
import java.util.function.Function;

public class AsyncBasics {

    // https://www.baeldung.com/java-future
    public void basicFuture() throws InterruptedException, ExecutionException {

        Future<Integer> integerFuture = Executors.newCachedThreadPool().submit(() -> {
            System.out.println("Sleeping...");
            Thread.sleep(5000);
            System.out.println("Done sleeping!");
            return 10 * 10;
        });

        Integer result = integerFuture.get();

        while(!integerFuture.isDone()) {
            System.out.println("Calculating...");
            Thread.sleep(300);
        }

        System.out.println("Result = " + result);
    }

    public void basicCompletableFuture() throws InterruptedException, ExecutionException {
        Future<String> stringFuture = calculateAsync();
        String s = stringFuture.get();

        CompletableFuture<String> completableFuture = CompletableFuture.supplyAsync(() -> {
            try {
                Thread.sleep(600);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            return "Yolo";
        });

        Function<String, String> stringStringFunction = s1 -> s1 + " to the ";
        CompletableFuture<String> stringCompletableFuture = completableFuture.thenApply(stringStringFunction);

        Consumer<String> stringConsumer = s1 -> System.out.println(s1);
        stringCompletableFuture.thenAccept(stringConsumer);
    }

    private Future<String> calculateAsync() throws InterruptedException {
        CompletableFuture<String> completableFuture = new CompletableFuture<>();

        Executors.newCachedThreadPool().submit(() -> {
            Thread.sleep(500);
            completableFuture.complete("Hello");
            return null;
        });

        return completableFuture;
    }

    public void myFuture(){

    }

    private void slowFunction(String id, Long milliSeconds){
        try {

            Thread.sleep(milliSeconds);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}

