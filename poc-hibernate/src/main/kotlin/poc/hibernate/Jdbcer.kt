package poc.hibernate

import bitronix.tm.BitronixTransactionManager
import bitronix.tm.TransactionManagerServices
import bitronix.tm.resource.jdbc.PoolingDataSource
import com.zaxxer.hikari.HikariConfig
import com.zaxxer.hikari.HikariDataSource
import org.postgresql.xa.PGXADataSource
import java.sql.Connection
import java.sql.DriverManager

class Jdbcer{
    private val url = "jdbc:postgresql://localhost/mydb"
    private val user = "postgres"
    private val password = "toor"

    fun simpleQuery(){
        val connect = connect()
        println("Gelukt: " + connect.clientInfo.size)

        printProjects(connect)
        connect.close()
    }

    private fun printProjects(connect: Connection) {
        val statement = connect.createStatement()
        val resultSet = statement.executeQuery("select * from project")

        while (resultSet.next()) {
            val titel = resultSet.getString("titel_nl")
            println(titel)
        }

        resultSet.close()
        statement.close()
    }

    fun simpleTxInsert(){
        val connect = connect()
        connect.autoCommit = false
        connect.transactionIsolation = Connection.TRANSACTION_SERIALIZABLE

        val statement = connect.createStatement()
        statement.execute("insert into project (id, \"order\", titel_nl ) values (456, 36, 'doe rollback')")

        connect.rollback()
    }

    fun doDataSource(){
        val hikariConfig = HikariConfig()
        hikariConfig.username = user
        hikariConfig.password = password
        hikariConfig.jdbcUrl = url

        val hikariDataSource = HikariDataSource(hikariConfig)
        val connection = hikariDataSource.connection
        printProjects(connection)
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

    fun connect(): Connection {
        val conn = DriverManager.getConnection(url, user, password)
        return conn
    }
}