package poc.hibernate

import bitronix.tm.TransactionManagerServices
import bitronix.tm.resource.jdbc.PoolingDataSource
import com.zaxxer.hikari.HikariConfig
import com.zaxxer.hikari.HikariDataSource
import java.io.PrintWriter
import java.sql.Connection
import java.sql.DriverManager
import net.ttddyy.dsproxy.support.ProxyDataSourceBuilder
import net.ttddyy.dsproxy.listener.logging.SLF4JQueryLoggingListener
import java.util.concurrent.TimeUnit
import net.ttddyy.dsproxy.listener.logging.SystemOutQueryLoggingListener
import javax.sql.DataSource
import net.ttddyy.dsproxy.listener.logging.DefaultQueryLogEntryCreator
import org.postgresql.ds.PGSimpleDataSource
import java.sql.SQLData


class Jdbcer{
    private val url = "jdbc:postgresql://localhost/mydb"
    private val user = "postgres"
    private val password = "toor"

    fun simpleQuery(){
        //val connection = getConnectionFromDriverManager()
        val dataSource = getDataSource()
        val connection = dataSource.connection
        connection.autoCommit = false
        println("Gelukt: " + connection.clientInfo.size)

        printProjects(connection)
    }

    private fun printProjects(connection: Connection) {
        val statement = connection.createStatement()
        connection.autoCommit = false
        val resultSet = statement.executeQuery("select * from project")

        while (resultSet.next()) {
            val titel = resultSet.getString("titel")
            println(titel)
        }

        resultSet.close()
        statement.close()

        connection.commit()
        connection.close()
    }

    fun simpleTxInsert(){
        //val connect = getConnectionFromDriverManager()
        val connect = getDataSource().connection
        connect.autoCommit = false
        connect.transactionIsolation = Connection.TRANSACTION_SERIALIZABLE

        val statement = connect.createStatement()
        statement.execute("insert into project (id, \"order\", titel ) values (45336, 3336, 'commit moet samen met close? NOPE')")
        connect.commit()
       // connect.close()
    }

    fun doDataSource(){
        val hikariConfig = HikariConfig()
        hikariConfig.username = user
        hikariConfig.password = password
        hikariConfig.jdbcUrl = url
        hikariConfig.minimumIdle = 10
        hikariConfig.maximumPoolSize = 20

        val hikariDataSource = HikariDataSource(hikariConfig)
        val connection = hikariDataSource.connection
        printProjects(connection)
    }

    private fun getDataSource(): DataSource {
        val dataSource = PGSimpleDataSource()
        dataSource.user = "postgres"
        dataSource.password = "toor"
        dataSource.databaseName = "mydb"
        return dataSource;
    }

    private fun getDataSourceProxy(): DataSource {
        // use pretty formatted query with multiline enabled
        val creator = PrettyQueryEntryCreator()
        creator.setMultiline(true)
        val listener = SystemOutQueryLoggingListener()
        listener.queryLogEntryCreator = creator

        // Create ProxyDataSource
        return ProxyDataSourceBuilder.create(getH2DataSource())
                .name("ProxyDataSource")
                .countQuery()
                .multiline()
                .listener(listener)
                .logSlowQueryToSysOut(1, TimeUnit.MINUTES)
                .build()
    }

    private fun getH2DataSource(): DataSource {
        val ds = PGSimpleDataSource()
        ds.setURL(url)
        ds.setUser(user)
        ds.setPassword(password)
        return ds
    }

    fun transactionalInsert(){
        val poolingDatasource = PoolingDataSource()
        poolingDatasource.className = "org.postgresql.xa.PGXADataSource"
        poolingDatasource.uniqueName = "postgresql"
        poolingDatasource.allowLocalTransactions = true
        poolingDatasource.driverProperties.setProperty("user",user)
        poolingDatasource.driverProperties.setProperty("password",password)
        poolingDatasource.driverProperties.setProperty("serverName","localhost")
        poolingDatasource.driverProperties.setProperty("databaseName","mydb")
        poolingDatasource.minPoolSize = 10
        poolingDatasource.maxPoolSize = 20
        poolingDatasource.init()

        //PGXADataSource
        val configuration = TransactionManagerServices.getConfiguration()
        val transactionManager = TransactionManagerServices.getTransactionManager()
        transactionManager.begin()

        val connection = poolingDatasource.connection
        val statement = connection.createStatement()
        statement.execute("insert into project (id, \"order\", titel_nl ) values (189, 36, 'bitronix werkt wel')")

        transactionManager.commit()
    }

    fun getConnectionFromDriverManager(): Connection {
        DriverManager.setLogWriter(PrintWriter(System.out))
        val conn = DriverManager.getConnection(url, user, password)
        return conn
    }
}

private class PrettyQueryEntryCreator : DefaultQueryLogEntryCreator() {
    override fun formatQuery(query: String): String {
        return query
    }
}