using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Database
{
    public static class Program
    {
        public static string[] timestamp;
        public static string empty = "-";
        public static string[][] words1 = new string[6][];
        public static string[][] words = new string[6][];
        public static string[] messages;
        public static int count = 0;
        public static int count1 = 0;
        public static MySqlCommand command_add;
        public static MySqlConnection con = new MySqlConnection();

        public static void Main(string[] args)
        {
            connect_database();
            Console.ReadLine();
            Timer t1 = new Timer(TimerCallback, null, 0, 1000);
            Timer t2 = new Timer(TimerCallback, null, 0, 1000);
            Timer t3 = new Timer(TimerCallback, null, 0, 1000);
            Timer t4 = new Timer(TimerCallback, null, 0, 1000);
            Timer t5 = new Timer(TimerCallback, null, 0, 1000);
            Timer t6 = new Timer(TimerCallback, null, 0, 1000);
            Console.ReadLine();
        }

        

        public static void connect_msgserver(string key, int index)
        {           
            ConnectionFactory factory;
            using (StreamReader r = new StreamReader("config1.json"))
            {
                string json = r.ReadToEnd();
                Config config = JsonConvert.DeserializeObject<Config>(json);

                factory = new ConnectionFactory();
                factory.Uri = "amqp://sensor_gempa:12345@167.205.7.226/%2fdisaster";
            }

            factory.Protocol = Protocols.DefaultProtocol;
            factory.Port = AmqpTcpEndpoint.UseDefaultPort;

            //SENSOR ecn
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                channel.BasicQos(0, 1, false);
                channel.QueueDeclare(queue: "ecn",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                channel.QueueBind(queue: "ecn",
                                     exchange: "amq.topic",
                                     routingKey: "amq.topic." + key
                                     );
                

                Console.WriteLine("Queue Declare Emergency GUI");
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);  
                                     
                    try
                    {                                                                        
                        data accelReport = JsonConvert.DeserializeObject<data>(message);
                        
                        words[index][1] = accelReport.timeZone;
                        words[index][2] = accelReport.interval;
                        words[index][3] = accelReport.clientID;
                        words[index][4] = accelReport.geojson.geometry.coordinates[0];
                        words[index][5] = accelReport.geojson.geometry.coordinates[1];
                        string searchString = "[{";
                        int startIndex = message.IndexOf(searchString);
                        string substring = message.Substring(startIndex);
                        words[index][6] = substring;


                        Console.WriteLine("success");
                    }
                    catch (Exception ex)
                    {                                             
                        Console.WriteLine("Failed");                        
                    }

                };
                channel.BasicConsume(queue: "ecn", //"emergency_gui",
                                     noAck: true,
                                     consumer: consumer);

                Console.WriteLine("Already BasicConsume");                
            }
        }

        public static void connect_msgserver2(string key, int index_key)
        {
            //consume_data();
            ConnectionFactory factory;            
            factory = new ConnectionFactory();
            factory.Uri = "amqp://sensor_gempa:12345@167.205.7.226/%2fdisaster";
            factory.Protocol = Protocols.DefaultProtocol;
            factory.Port = AmqpTcpEndpoint.UseDefaultPort;

            //SENSOR ecn
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                channel.BasicQos(0, 1, false);
                channel.QueueDeclare(queue: "ecn", //"emergency_gui",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                channel.QueueBind(queue: "ecn", //"emergency_gui",
                                     exchange: "amq.topic",
                                     routingKey: "amq.topic.ecn" //emergency"
                                     );


                Console.WriteLine("Queue Declare Emergency GUI");
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    try
                    {                                                
                        words1[index_key][1] = message;
                        Console.WriteLine(message);
                    }
                    catch (Exception ex)
                    {                                                
                        Console.WriteLine("Failed");        
                    }

                };
                channel.BasicConsume(queue: "ecn", //"emergency_gui",
                                     noAck: true,
                                     consumer: consumer);

                Console.WriteLine("Already BasicConsume");
                //Console.ReadLine();
            }
        }

        public static void connect_database()
        {
            string server_host = "localhost";
            string server_password = "MySQLRoot";
            string server_name = "root";
            
            try
            {
                con.ConnectionString = "server=" + server_host + ";user id=" + server_name + ";password=" + server_password + ";database=earthquake";
                con.Open();
                //MessageBox.Show("Connected to " + server);

            }
            catch (Exception e1)
            {
                Console.WriteLine("Connection failed due to " + e1.ToString());
            }
        }

        private static void write_database(string[] data)
        {        
            command_add = con.CreateCommand();            
            try
            {
                command_add.CommandText = "INSERT INTO store_id (point_time, time_zone_id, interval_id, client_id, lattitude_id, longitude_id) VALUES('" + data[0] + "', '" + data[1] + "', '" + data[2] + "', '" + data[3] + "', '" + data[4] + "', '" + data[5] + "')";
                command_add.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                try
                {
                    command_add.CommandText = "INSERT INTO store_id (point_time, time_zone_id, interval_id, client_id, lattitude_id, longitude_id) VALUES('" + timestamp + "','" + empty + "','" + empty + "','" + empty + "','" + empty + "','" + empty + "')";
                    command_add.ExecuteNonQuery();
                }
                catch
                {                    
                }
                
            }

            //Reset connection to avoid exception
            try
            {
                con.Close();
            }
            catch
            {
                try
                {                    
                    con.Close();
                }
                catch
                {                    
                    con.Close();
                }
                
            }

            try
            {
                con.Open();
            }
            catch
            {                
                con.Close();
            }
            
        }

        private static void write_database_test(string[] data)
        {
            command_add = con.CreateCommand();
            try
            {
                command_add.CommandText = "INSERT INTO test_id (point_time_console, point_time_message) VALUES('" + data[0] + "', '" + data[1] + "')";
                command_add.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                try
                {
                    command_add.CommandText = "INSERT INTO test_id (point_time_console, point_time_message) VALUES('" + timestamp + "','" + empty + "')";
                    command_add.ExecuteNonQuery();
                }
                catch
                {
                }

            }

            //Reset connection to avoid exception
            try
            {
                con.Close();
            }
            catch
            {
                //Thread.Sleep(2000);
                con.Close();
            }

            try
            {
                con.Open();
            }
            catch
            {
                //Thread.Sleep(2000);
                con.Close();                
            }


            //Thread.Sleep(1000);

        }


        private static void TimerCallback(Object o)
        {
            words[0][0] = "";
            words1[0][0] = "";
            timestamp[0] = "";
            // Display the date/time when this method got called.
            //Console.WriteLine("In TimerCallback: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //connect_msgserver();
            timestamp[0] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            words[0][0] = timestamp[0];
            words1[0][0] = timestamp[0];
            connect_msgserver("ecn.1",0);
            //connect_msgserver2();
            Console.WriteLine(timestamp[0]);
            write_database(words[0]);
            //write_database_test(words1[0]);
            //count++;
            // Force a garbage collection to occur for this demo.
            GC.Collect();
            
            
        }

        private static void TimerCallback1(Object o)
        {
            words[1][0] = "";
            words1[1][0] = "";
            timestamp[1] = "";
            // Display the date/time when this method got called.
            //Console.WriteLine("In TimerCallback: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //connect_msgserver();
            timestamp[1] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            words[1][0] = timestamp[1];
            words1[1][0] = timestamp[1];
            connect_msgserver("ecn.2", 1);
            //connect_msgserver2();
            Console.WriteLine(timestamp[1]);
            write_database(words[1]);
            //write_database_test(words1[0]);
            //count++;
            // Force a garbage collection to occur for this demo.
            GC.Collect();         
        }

        private static void TimerCallback2(Object o)
        {
            words[2][0] = "";
            words1[2][0] = "";
            timestamp[2] = "";
            // Display the date/time when this method got called.
            //Console.WriteLine("In TimerCallback: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //connect_msgserver();
            timestamp[2] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            words[2][0] = timestamp[2];
            words1[2][0] = timestamp[2];
            connect_msgserver("ecn.3", 2);
            //connect_msgserver2();
            Console.WriteLine(timestamp[2]);
            write_database(words[2]);
            //write_database_test(words1[0]);
            //count++;
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }

        private static void TimerCallback3(Object o)
        {
            words[3][0] = "";
            words1[3][0] = "";
            timestamp[3] = "";
            // Display the date/time when this method got called.
            //Console.WriteLine("In TimerCallback: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //connect_msgserver();
            timestamp[3] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            words[3][0] = timestamp[3];
            words1[3][0] = timestamp[3];
            connect_msgserver("ecn.4", 3);
            //connect_msgserver2();
            Console.WriteLine(timestamp[3]);
            write_database(words[3]);
            //write_database_test(words1[0]);
            //count++;
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }

        private static void TimerCallback4(Object o)
        {
            words[4][0] = "";
            words1[4][0] = "";
            timestamp[4] = "";
            // Display the date/time when this method got called.
            //Console.WriteLine("In TimerCallback: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //connect_msgserver();
            timestamp[4] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            words[4][0] = timestamp[4];
            words1[4][0] = timestamp[4];
            connect_msgserver("ecn.5", 4);
            //connect_msgserver2();
            Console.WriteLine(timestamp[4]);
            write_database(words[4]);
            //write_database_test(words1[0]);
            //count++;
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }

        private static void TimerCallback5(Object o)
        {
            words[5][0] = "";
            words1[5][0] = "";
            timestamp[5] = "";
            // Display the date/time when this method got called.
            //Console.WriteLine("In TimerCallback: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //connect_msgserver();
            timestamp[5] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            words[5][0] = timestamp[5];
            words1[5][0] = timestamp[5];
            connect_msgserver("ecn.6", 5);
            //connect_msgserver2();
            Console.WriteLine(timestamp[5]);
            write_database(words[5]);
            //write_database_test(words1[0]);
            //count++;
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }

        public class Config
        {
            public string host;
            public string user;
            public string vhost;
            //public string port;
            public string password;
        }


    }
    public class data
    {
        public string pointTime;
        public string timeZone;
        public string interval;
        public string clientID;
        public geojson geojson;
        public acc[] accelerations;
    };
    public class geojson
    {
        public geometry geometry;
        public prop property;
    };
    public class geometry
    {
        public string type;
        public string[] coordinates;
    };
    public class prop
    {
        public string name;
    };
    public class acc
    {
        public string x;
        public string y;
        public string z;
    };
}
