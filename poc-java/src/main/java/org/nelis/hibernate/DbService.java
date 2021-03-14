package org.nelis.hibernate;

import org.hibernate.reactive.stage.Stage;

import java.time.LocalDate;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.CompletionStage;
import java.util.function.Function;

import static java.lang.System.out;
import static java.time.Month.*;
import static javax.persistence.Persistence.createEntityManagerFactory;
import static org.hibernate.reactive.stage.Stage.fetch;

public class DbService {

    public static void gogo(){
        Stage.SessionFactory factory = createEntityManagerFactory( persistenceUnitName( new String[]{} ) )
                .unwrap(Stage.SessionFactory.class);

        Author author1 = new Author("Iain M. Banks");
        Author author2 = new Author("Neal Stephenson");
        Book book1 = new Book("1-85723-235-6", "Feersum Endjinn", author1, LocalDate.of(1994, JANUARY, 1));
        Book book2 = new Book("0-380-97346-4", "Cryptonomicon", author2, LocalDate.of(1999, MAY, 1));
        Book book3 = new Book("0-553-08853-X", "Snow Crash", author2, LocalDate.of(1992, JUNE, 1));
        author1.getBooks().add(book1);
        author2.getBooks().add(book2);
        author2.getBooks().add(book3);

        // obtain a reactive session
        CompletableFuture<Stage.Session> sessionCompletableFuture = factory.withTransaction(
                // persist the Authors with their Books in a transaction
                (session, tx) -> session.persist(author1, author2))
                // wait for it to finish
                .toCompletableFuture();
        sessionCompletableFuture.join();

        factory.withSession(
                // retrieve an Author
        session -> session.find(Author.class, author2.getId())
                // lazily fetch their books
                .thenCompose( author -> fetch(author.getBooks())
                         // print some info
                        .thenAccept( books -> {
                               out.println(author.getName() + " wrote " + books.size() + " books");
                               books.forEach( book -> out.println(book.getTitle()) );
                            } )
                        ))
                .toCompletableFuture().join();

    }

    /**
     * Return the persistence unit name to use in the example.
     *
     * @param args the first element is the persistence unit name if present
     * @return the selected persistence unit name or the default one
     */
    public static String persistenceUnitName(String[] args) {
        return args.length > 0 ? args[0] : "postgresql-example";
    }
}
