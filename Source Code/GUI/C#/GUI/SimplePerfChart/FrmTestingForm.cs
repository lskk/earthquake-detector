using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using GMap.NET;

using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System.IO;

namespace SimplePerfChart
{


    public partial class FrmTestingForm : Form
    {
        private object valueGenSync = new object();
        private Random randGen = new Random();
        //public static decimal data = 0;
        private int valueGenFrom = -5;
        private int valueGenTo = 5;
        private int valueGenTimerFrom = 100;
        private int valueGenTimerTo = 2000;
        public static string data = "";
        public static double defx;
        public static double defy;
        public static double defz;
        public static string amplitude_status;
        public static bool[] location_status = { false, false, false, false,false,false};
        public static string data_x;
        public static string data_y;
        public static string data_z;
        public static bool check_1 = false;
        public static bool check_2 = false;
        public static bool check_3 = false;
        public static bool check_4 = false;
        public static bool check_5 = false;
        public static bool check_6 = false;
        public static int count_1;
        public static int count_2;
        public static int count_3;
        public static int count_4;
        public static int count_5;
        public static int count_6;



        public struct accel
        {
            public decimal accel_x;
            public decimal accel_y;
            public decimal accel_z;
        }
        public FrmTestingForm()
        {
            InitializeComponent();
            //pictureBox1.Hide();
            //this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.Font = SystemInformation.MenuFont;
            // pictureBox1.Hide();            
            propGrid.SelectedObject = perfChart.PerfChartStyle;
            propGrid.SelectedObject = perfChart1.PerfChartStyle;
            propGrid.SelectedObject = perfChart2.PerfChartStyle;
            propGrid.SelectedObject = perfChart3.PerfChartStyle;
            propGrid.SelectedObject = perfChart4.PerfChartStyle;
            propGrid.SelectedObject = perfChart5.PerfChartStyle;
            propGrid.SelectedObject = perfChart6.PerfChartStyle;
            propGrid.SelectedObject = perfChart7.PerfChartStyle;
            propGrid.SelectedObject = perfChart8.PerfChartStyle;

            // Apply default Properties
            perfChart.TimerInterval = 1000;
            perfChart1.TimerInterval = 1000;
            perfChart2.TimerInterval = 1000;
            perfChart3.TimerInterval = 1000;
            perfChart4.TimerInterval = 1000;
            perfChart5.TimerInterval = 1000;
            perfChart6.TimerInterval = 1000;
            perfChart7.TimerInterval = 1000;
            perfChart8.TimerInterval = 1000;

            // Populate DrowDown Boxes
            foreach (String item in System.Enum.GetNames(typeof(Border3DStyle)))
            {
                cmbBxBorder.Items.Add(item);
            }
            foreach (String item in System.Enum.GetNames(typeof(SpPerfChart.ScaleMode)))
            {
                cmbBxScaleMode.Items.Add(item);
            }
            foreach (String item in System.Enum.GetNames(typeof(SpPerfChart.TimerMode)))
            {
                cmbBxTimerMode.Items.Add(item);
            }

            // Select default values
            cmbBxTimerMode.SelectedItem = perfChart.TimerMode.ToString();
            cmbBxTimerMode.SelectedItem = perfChart1.TimerMode.ToString();
            cmbBxTimerMode.SelectedItem = perfChart2.TimerMode.ToString();
            cmbBxTimerMode.SelectedItem = perfChart3.TimerMode.ToString();
            cmbBxTimerMode.SelectedItem = perfChart4.TimerMode.ToString();
            cmbBxTimerMode.SelectedItem = perfChart5.TimerMode.ToString();
            cmbBxTimerMode.SelectedItem = perfChart6.TimerMode.ToString();
            cmbBxTimerMode.SelectedItem = perfChart7.TimerMode.ToString();
            cmbBxTimerMode.SelectedItem = perfChart8.TimerMode.ToString();

            cmbBxScaleMode.SelectedItem = perfChart.ScaleMode.ToString();
            
            cmbBxScaleMode.SelectedItem = perfChart1.ScaleMode.ToString();
            cmbBxScaleMode.SelectedItem = perfChart2.ScaleMode.ToString();
            cmbBxScaleMode.SelectedItem = perfChart3.ScaleMode.ToString();
            cmbBxScaleMode.SelectedItem = perfChart4.ScaleMode.ToString();
            cmbBxScaleMode.SelectedItem = perfChart5.ScaleMode.ToString();
            cmbBxScaleMode.SelectedItem = perfChart6.ScaleMode.ToString();
            cmbBxScaleMode.SelectedItem = perfChart7.ScaleMode.ToString();
            cmbBxScaleMode.SelectedItem = perfChart8.ScaleMode.ToString();


            cmbBxBorder.SelectedItem = perfChart.BorderStyle.ToString();
            cmbBxBorder.SelectedItem = perfChart1.BorderStyle.ToString();
            cmbBxBorder.SelectedItem = perfChart2.BorderStyle.ToString();
            cmbBxBorder.SelectedItem = perfChart3.BorderStyle.ToString();
            cmbBxBorder.SelectedItem = perfChart4.BorderStyle.ToString();
            cmbBxBorder.SelectedItem = perfChart5.BorderStyle.ToString();
            cmbBxBorder.SelectedItem = perfChart6.BorderStyle.ToString();
            cmbBxBorder.SelectedItem = perfChart7.BorderStyle.ToString();
            cmbBxBorder.SelectedItem = perfChart8.BorderStyle.ToString();



        }

        



        private void chkBxTimerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxTimerEnabled.Checked && !bgWrkTimer.IsBusy)
            {
                RunTimer();
            }
            if (chkBxTimerEnabled.Checked && !backgroundWorker1.IsBusy)
            {
                RunTimer1();
            }
            if (chkBxTimerEnabled.Checked && !backgroundWorker2.IsBusy)
            {
                RunTimer2();
            }
            if (chkBxTimerEnabled.Checked && !backgroundWorker3.IsBusy)
            {
                RunTimer3();
            }
            if (chkBxTimerEnabled.Checked && !backgroundWorker4.IsBusy)
            {
                RunTimer4();
            }
            if (chkBxTimerEnabled.Checked && !backgroundWorker5.IsBusy)
            {
                RunTimer5();
            }
            if (chkBxTimerEnabled.Checked && !backgroundWorker6.IsBusy)
            {
                RunTimer6();
            }
        }

        private void RunTimer()
        {
            int waitFor = randGen.Next(valueGenTimerFrom, valueGenTimerTo);
            bgWrkTimer.RunWorkerAsync(waitFor);
        }

        private void RunTimer1()
        {
            int waitFor = randGen.Next(valueGenTimerFrom, valueGenTimerTo);
            backgroundWorker1.RunWorkerAsync(waitFor);                 
        }

        private void RunTimer2()
        {
            int waitFor = randGen.Next(valueGenTimerFrom, valueGenTimerTo);
            backgroundWorker2.RunWorkerAsync(waitFor);
        }

        private void RunTimer3()
        {
            int waitFor = randGen.Next(valueGenTimerFrom, valueGenTimerTo);
            backgroundWorker3.RunWorkerAsync(waitFor);
        }

        private void RunTimer4()
        {
            int waitFor = randGen.Next(valueGenTimerFrom, valueGenTimerTo);
            backgroundWorker4.RunWorkerAsync(waitFor);
        }

        private void RunTimer5()
        {
            int waitFor = randGen.Next(valueGenTimerFrom, valueGenTimerTo);
            backgroundWorker5.RunWorkerAsync(waitFor);
        }

        private void RunTimer6()
        {
            int waitFor = randGen.Next(valueGenTimerFrom, valueGenTimerTo);
            backgroundWorker6.RunWorkerAsync(waitFor);
        }

        private void RunTimer7()
        {
            int waitFor = randGen.Next(valueGenTimerFrom, valueGenTimerTo);
            backgroundWorker7.RunWorkerAsync(waitFor);
        }


        private void perfchart_pick(data pick, string queue)
        {            
            switch (queue)
            {
                case "ecn.1":
                    perfchart_fill1(pick, queue);
                    break;
                case "ecn.2":
                    perfchart_fill2(pick, queue);
                    break;
                case "ecn.3":
                    perfchart_fill3(pick, queue);
                    break;
                case "ecn.4":
                    perfchart_fill4(pick, queue);
                    break;
                case "ecn.5":
                    perfchart_fill5(pick, queue);
                    break;
                case "ecn.6":
                    perfchart_fill6(pick, queue);
                    break;

                default:
                    break;
            }
        }
     
        public static float rev_char_repr(string x)
        {
            char[] y = new char[2];
            byte[] z = new byte[2];
            short yz;
            float t;
                        
            y = x.ToCharArray();

            z[1] = (byte)(sbyte)y[0];
            z[0] = (byte)(sbyte)y[1];

            yz = (short)((z[1] << 8) | (z[0]));
            t = ((float)yz)/10000;

            return t;
        }

        private void perfchart_fill1(data accelReport, string queue)
        {
         
            double resultx_1;
            double resulty_1;
            double resultz_1;

            if (location_status[0] == false)
            {
                gMapControl1.BeginInvoke(new Action(() =>
                {
                    gMapControl1.Position = new GMap.NET.PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1]));
                    GMapOverlay markers = new GMapOverlay("markers");
                    GMapMarker marker = new GMarkerGoogle(
                        new PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1])),
                        GMarkerGoogleType.blue_pushpin);
                    markers.Markers.Add(marker);
                    gMapControl1.Overlays.Add(markers);
                }));
                location_status[0] = true;
            }


            for (int i = 0; i < 40; i++)
            {
                
                resultx_1 = ((double.Parse(accelReport.accelerations[i].x)));
                resulty_1 = ((double.Parse(accelReport.accelerations[i].y)));
                resultz_1 = ((double.Parse(accelReport.accelerations[i].z)));
                
                perfChart.AddValue((decimal)resultx_1);                
                perfChart1.AddValue((decimal)resulty_1);                
                perfChart2.AddValue((decimal)resultz_1);
                
                if ((resultx_1 > 9 || resulty_1 > 9 || resultz_1 > 9) && (check_1 == false))
                {                             
                    check_1 = true;
                    count_1 = 1;
                }
                Thread.Sleep(25);
            }            
        }

        private void perfchart_fill2(data accelReport, string queue)
        {            
            double resultx_2;
            double resulty_2;
            double resultz_2;
            //if (location_status[1] == false)
            //{
            //    gMapControl1.BeginInvoke(new Action(() => {
            //        gMapControl1.Position = new GMap.NET.PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1]));
            //        GMapOverlay markers = new GMapOverlay("markers");
            //        GMapMarker marker = new GMarkerGoogle(
            //            new PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1])),
            //            GMarkerGoogleType.blue_pushpin);
            //        markers.Markers.Add(marker);
            //        gMapControl1.Overlays.Add(markers);
            //    }));
            //    location_status[1] = true;
            //}
            for (int i = 0; i < 40; i++)
            {
                //resultx_2 = (rev_char_repr(accelReport.accelerations[i].x));
                //resulty_2 = (rev_char_repr(accelReport.accelerations[i].y));
                //resultz_2 = (rev_char_repr(accelReport.accelerations[i].z));
                resultx_2 = ((double.Parse(accelReport.accelerations[i].x)));
                resulty_2 = ((double.Parse(accelReport.accelerations[i].y)));
                resultz_2 = ((double.Parse(accelReport.accelerations[i].z)));
                //Console.WriteLine("Data wkwk {0}", accelReport.accelerations[i].x);
                //Console.WriteLine("Data wkwk {0}, {1}, {2}", result_2[0], result_2[1], result_2[2]);
                perfChart3.AddValue((decimal)resultx_2);
                perfChart4.AddValue((decimal)resulty_2);
                perfChart5.AddValue((decimal)resultz_2);
                if ((resultx_2 > 9 || resulty_2 > 9 || resultz_2 > 9) && (check_2 == false))
                {                    
                    check_2 = true;
                    count_2 = 1;
                }
                Thread.Sleep(25);

            }
            //if (check == true)
            //{
            //    textBox4.BeginInvoke(new Action(() => { textBox4.Text = "GEMPA"; }));
            //}

        }


        private void perfchart_fill3(data accelReport, string queue)
        {
            double resultx_3;
            double resulty_3;
            double resultz_3;
            //if (location_status[2] == false)
            //{
            //    gMapControl1.BeginInvoke(new Action(() => {
            //        gMapControl1.Position = new GMap.NET.PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1]));
            //        GMapOverlay markers = new GMapOverlay("markers");
            //        GMapMarker marker = new GMarkerGoogle(
            //            new PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1])),
            //            GMarkerGoogleType.blue_pushpin);
            //        markers.Markers.Add(marker);
            //        gMapControl1.Overlays.Add(markers);
            //    }));
            //    location_status[2] = true;
            //}

            for (int i = 0; i < 40; i++)
            {
                resultx_3 = ((double.Parse(accelReport.accelerations[i].x)));
                resulty_3 = ((double.Parse(accelReport.accelerations[i].y)));
                resultz_3 = ((double.Parse(accelReport.accelerations[i].z)));
                perfChart6.AddValue((decimal)resultx_3);
                perfChart7.AddValue((decimal)resulty_3);
                perfChart8.AddValue((decimal)resultz_3);
                if ((resultx_3 > 9 || resulty_3 > 9 || resultz_3 > 9) && (check_3 == false))
                {                    
                    check_3 = true;
                    count_3 = 1;
                }
                Thread.Sleep(25);

            }
            

        }

        private void perfchart_fill4(data accelReport, string queue)
        {
            double resultx_4;
            double resulty_4;
            double resultz_4;
            //if (location_status[3] == false)
            //{
            //    gMapControl1.BeginInvoke(new Action(() => {
            //        gMapControl1.Position = new GMap.NET.PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1]));
            //        GMapOverlay markers = new GMapOverlay("markers");
            //        GMapMarker marker = new GMarkerGoogle(
            //            new PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1])),
            //            GMarkerGoogleType.blue_pushpin);
            //        markers.Markers.Add(marker);
            //        gMapControl1.Overlays.Add(markers);
            //    }));
            //    location_status[3] = true;
            //}
            for (int i = 0; i < 40; i++)
            {
                resultx_4 = ((double.Parse(accelReport.accelerations[i].x)));
                resulty_4 = ((double.Parse(accelReport.accelerations[i].y)));
                resultz_4 = ((double.Parse(accelReport.accelerations[i].z)));
                perfChart9.AddValue((decimal)resultx_4);
                perfChart10.AddValue((decimal)resulty_4);
                perfChart11.AddValue((decimal)resultz_4);

                if ((resultx_4 > 9 || resulty_4 > 9 || resultz_4 > 9) && (check_4 == false))
                {                 
                    check_4 = true;
                    count_4 = 1;
                }
                Thread.Sleep(25);

            }

        }



        private void perfchart_fill5(data accelReport, string queue)
        {
            double resultx_5;
            double resulty_5;
            double resultz_5;
            //if (location_status[4] == false)
            //{
            //    gMapControl1.BeginInvoke(new Action(() => {
            //        gMapControl1.Position = new GMap.NET.PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1]));
            //        GMapOverlay markers = new GMapOverlay("markers");
            //        GMapMarker marker = new GMarkerGoogle(
            //            new PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1])),
            //            GMarkerGoogleType.blue_pushpin);
            //        markers.Markers.Add(marker);
            //        gMapControl1.Overlays.Add(markers);
            //    }));
            //    location_status[4] = true;
            //}
            for (int i = 0; i < 40; i++)
            {
                resultx_5 = ((double.Parse(accelReport.accelerations[i].x)));
                resulty_5 = ((double.Parse(accelReport.accelerations[i].y)));
                resultz_5 = ((double.Parse(accelReport.accelerations[i].z)));
                perfChart12.AddValue((decimal)resultx_5);
                perfChart13.AddValue((decimal)resulty_5);
                perfChart14.AddValue((decimal)resultz_5);
                //textBox1.BeginInvoke(new Action(() => { textBox1.Text = resultx.ToString(); }));
                //textBox2.BeginInvoke(new Action(() => { textBox2.Text = resulty.ToString(); }));
                //textBox3.BeginInvoke(new Action(() => { textBox3.Text = resultz.ToString(); ; }));
                if((resultx_5 > 9 || resulty_5 > 9 || resultz_5 > 9) && (check_5 == false))
                {
                    //pictureBox1.BeginInvoke(new Action(() => { pictureBox1.Show(); }));                    
                    check_5 = true;
                    count_5 = 1;
                }
                Thread.Sleep(25);

            }
        
        }


        private void perfchart_fill6(data accelReport, string queue)
        {

            double resultx_6;
            double resulty_6;
            double resultz_6;
            //if (location_status[5] == false)
            //{
            //    gMapControl1.BeginInvoke(new Action(() => {
            //        gMapControl1.Position = new GMap.NET.PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1]));
            //        GMapOverlay markers = new GMapOverlay("markers");
            //        GMapMarker marker = new GMarkerGoogle(
            //            new PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1])),
            //            GMarkerGoogleType.blue_pushpin);
            //        markers.Markers.Add(marker);
            //        gMapControl1.Overlays.Add(markers);
            //    }));
            //    location_status[5] = true;
            //}
            for (int i = 0; i < 40; i++)
            {
                resultx_6 = ((double.Parse(accelReport.accelerations[i].x)));
                resulty_6 = ((double.Parse(accelReport.accelerations[i].y)));
                resultz_6 = ((double.Parse(accelReport.accelerations[i].z)));
                perfChart15.AddValue((decimal)resultx_6);
                perfChart16.AddValue((decimal)resulty_6);
                perfChart17.AddValue((decimal)resultz_6);
                //textBox1.BeginInvoke(new Action(() => { textBox1.Text = resultx.ToString(); }));
                //textBox2.BeginInvoke(new Action(() => { textBox2.Text = resulty.ToString(); }));
                //textBox3.BeginInvoke(new Action(() => { textBox3.Text = resultz.ToString(); ; }));
                if ((resultx_6 > 9 || resulty_6 > 9 || resultz_6 > 9) && (check_6 == false))
                {                    
                    check_6 = true;
                    count_6 = 1;
                }
                Thread.Sleep(25);

            }
        }


        private void connect_msgserver(string key)
        {
            //consume_data();
            ConnectionFactory factory;
            using (StreamReader r = new StreamReader("config1.json"))
            {
                string json = r.ReadToEnd();
                Config config = JsonConvert.DeserializeObject<Config>(json);

                factory = new ConnectionFactory();// { HostName = config.host, UserName = config.user, VirtualHost = config.vhost, Password = config.password };                              
                factory.Uri = "amqp://sensor_gempa:12345@167.205.7.226/%2fdisaster";
            }

            factory.Protocol = Protocols.DefaultProtocol;
            factory.Port = AmqpTcpEndpoint.UseDefaultPort;

            //SENSOR ecn
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.BasicQos(0, 1, false);
                channel.QueueDeclare(queue: key , //"emergency_gui",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                channel.QueueBind(queue: key, //"emergency_gui",
                                     exchange: "amq.topic",
                                     routingKey: "amq.topic." + key //emergency"
                                     );

                Console.WriteLine("Queue Declare Emergency GUI" + key);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    //Console.WriteLine(" [x] Received {0}", message);
                    //Console.WriteLine(" ///////////////////////////////////////////////////////////////////////////////////////////////////");
                    data = message;
                    //accel_data = ParsingMessage(data);

                    try
                    {
                        //AccelerationReport accelReport = JsonConvert.DeserializeObject<AccelerationReport>(message);
                        data accelReport = JsonConvert.DeserializeObject<data>(message);
                        

                        Console.WriteLine(accelReport.pointTime);
                        Console.WriteLine(accelReport.timeZone);
                        Console.WriteLine(accelReport.interval);
                        Console.WriteLine(accelReport.clientID);
                        Console.WriteLine(accelReport.geojson.geometry.coordinates[0]);
                        Console.WriteLine(accelReport.geojson.geometry.coordinates[1]);
                        Console.WriteLine(accelReport.accelerations[0].x);
                        Console.WriteLine(accelReport.accelerations[0].y);
                        Console.WriteLine(accelReport.accelerations[0].z);

                        perfchart_pick(accelReport,key);
                                            
                        //gMapControl1.Position = new GMap.NET.PointLatLng(double.Parse(accelReport.geojson.geometry.coordinates[0]), double.Parse(accelReport.geojson.geometry.coordinates[1]));


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR wkwk: {0} {1}", ex, key);
                        //Thread.Sleep(1000);
                        
                    }

                };
                channel.BasicConsume(queue: key,
                                     noAck: true,
                                     consumer: consumer);

                Console.WriteLine("Already BasicConsume {0}", key);
                //Console.ReadLine();
            }

        
        }

        private void bgWrkTimer_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(Convert.ToInt32(e.Argument));
            
            RunTimer(); 
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            connect_msgserver("ecn.1");
            

            if (chkBxTimerEnabled.Checked)
            {
                RunTimer1();                                
            }
            
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            connect_msgserver("ecn.2");

            if (chkBxTimerEnabled.Checked)
            {
                RunTimer2();
            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            connect_msgserver("ecn.3");

            if (chkBxTimerEnabled.Checked)
            {
                RunTimer3();
            }
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            connect_msgserver("ecn.4");

            if (chkBxTimerEnabled.Checked)
            {
                RunTimer4();
            }
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
            connect_msgserver("ecn.5");

            if (chkBxTimerEnabled.Checked)
            {
                RunTimer5();
            }
        }

        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            connect_msgserver("ecn.6");

            if (chkBxTimerEnabled.Checked)
            {
                RunTimer6();
            }
        }

        private void backgroundWorker7_DoWork(object sender, DoWorkEventArgs e)
        {
            int total_count;
            total_count = count_1 + count_2 + count_3 + count_4 + count_5 + count_6;
            if (total_count > 3)
            {

            }
            


            if (chkBxTimerEnabled.Checked)
            {
                RunTimer7();
            }
        }



        public class Config
        {

            public string host;
            public string user;
            public string vhost;            
            public string password;            
            

        }

        private static void consume_data()
        {           
            
        }

        private void bgWrkTimer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            

            if (chkBxTimerEnabled.Checked)
            {                
                RunTimer();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (chkBxTimerEnabled.Checked)
            {
                RunTimer1();
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (chkBxTimerEnabled.Checked)
            {
                RunTimer2();
            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (chkBxTimerEnabled.Checked)
            {
                RunTimer3();
            }
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (chkBxTimerEnabled.Checked)
            {
                RunTimer4();
            }
        }

        private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (chkBxTimerEnabled.Checked)
            {
                RunTimer5();
            }
        }

        private void backgroundWorker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (chkBxTimerEnabled.Checked)
            {
                RunTimer6();
            }
        }

        private void backgroundWorker7_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (chkBxTimerEnabled.Checked)
            {
                RunTimer7();
            }
        }



        private void cmbBxBorder_SelectedIndexChanged(object sender, EventArgs e)
        {
            perfChart.BorderStyle = (Border3DStyle)Enum.Parse(
                typeof(Border3DStyle), cmbBxBorder.SelectedItem.ToString()
            );
            perfChart1.BorderStyle = (Border3DStyle)Enum.Parse(
                typeof(Border3DStyle), cmbBxBorder.SelectedItem.ToString()
            );
            perfChart2.BorderStyle = (Border3DStyle)Enum.Parse(
                typeof(Border3DStyle), cmbBxBorder.SelectedItem.ToString()
            );
            perfChart3.BorderStyle = (Border3DStyle)Enum.Parse(
                typeof(Border3DStyle), cmbBxBorder.SelectedItem.ToString()
            );
            perfChart4.BorderStyle = (Border3DStyle)Enum.Parse(
                typeof(Border3DStyle), cmbBxBorder.SelectedItem.ToString()
            );
            perfChart5.BorderStyle = (Border3DStyle)Enum.Parse(
                typeof(Border3DStyle), cmbBxBorder.SelectedItem.ToString()
            );
            perfChart6.BorderStyle = (Border3DStyle)Enum.Parse(
                typeof(Border3DStyle), cmbBxBorder.SelectedItem.ToString()
            );
            perfChart7.BorderStyle = (Border3DStyle)Enum.Parse(
                typeof(Border3DStyle), cmbBxBorder.SelectedItem.ToString()
            );
            perfChart8.BorderStyle = (Border3DStyle)Enum.Parse(
                typeof(Border3DStyle), cmbBxBorder.SelectedItem.ToString()
            );

        }

        private void cmbBxScaleMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            perfChart.ScaleMode = (SpPerfChart.ScaleMode)Enum.Parse(
                typeof(SpPerfChart.ScaleMode), cmbBxScaleMode.SelectedItem.ToString()
            );
            
            perfChart1.ScaleMode = (SpPerfChart.ScaleMode)Enum.Parse(
                typeof(SpPerfChart.ScaleMode), cmbBxScaleMode.SelectedItem.ToString()
            );
            perfChart2.ScaleMode = (SpPerfChart.ScaleMode)Enum.Parse(
                typeof(SpPerfChart.ScaleMode), cmbBxScaleMode.SelectedItem.ToString()
            );
            perfChart3.ScaleMode = (SpPerfChart.ScaleMode)Enum.Parse(
                typeof(SpPerfChart.ScaleMode), cmbBxScaleMode.SelectedItem.ToString()
            );

            perfChart4.ScaleMode = (SpPerfChart.ScaleMode)Enum.Parse(
                typeof(SpPerfChart.ScaleMode), cmbBxScaleMode.SelectedItem.ToString()
            );
            perfChart5.ScaleMode = (SpPerfChart.ScaleMode)Enum.Parse(
                typeof(SpPerfChart.ScaleMode), cmbBxScaleMode.SelectedItem.ToString()
            );
            perfChart6.ScaleMode = (SpPerfChart.ScaleMode)Enum.Parse(
                typeof(SpPerfChart.ScaleMode), cmbBxScaleMode.SelectedItem.ToString()
            );

            perfChart7.ScaleMode = (SpPerfChart.ScaleMode)Enum.Parse(
                typeof(SpPerfChart.ScaleMode), cmbBxScaleMode.SelectedItem.ToString()
            );
            perfChart8.ScaleMode = (SpPerfChart.ScaleMode)Enum.Parse(
                typeof(SpPerfChart.ScaleMode), cmbBxScaleMode.SelectedItem.ToString()
            );
        }

        private void cmbBxTimerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            perfChart.TimerMode = (SpPerfChart.TimerMode)Enum.Parse(
                typeof(SpPerfChart.TimerMode), cmbBxTimerMode.SelectedItem.ToString()
            );
            perfChart1.TimerMode = (SpPerfChart.TimerMode)Enum.Parse(
               typeof(SpPerfChart.TimerMode), cmbBxTimerMode.SelectedItem.ToString()
           );
            perfChart2.TimerMode = (SpPerfChart.TimerMode)Enum.Parse(
               typeof(SpPerfChart.TimerMode), cmbBxTimerMode.SelectedItem.ToString()
           );
            perfChart3.TimerMode = (SpPerfChart.TimerMode)Enum.Parse(
                typeof(SpPerfChart.TimerMode), cmbBxTimerMode.SelectedItem.ToString()
            );
            perfChart4.TimerMode = (SpPerfChart.TimerMode)Enum.Parse(
               typeof(SpPerfChart.TimerMode), cmbBxTimerMode.SelectedItem.ToString()
           );
            perfChart5.TimerMode = (SpPerfChart.TimerMode)Enum.Parse(
               typeof(SpPerfChart.TimerMode), cmbBxTimerMode.SelectedItem.ToString()
           );
            perfChart6.TimerMode = (SpPerfChart.TimerMode)Enum.Parse(
                typeof(SpPerfChart.TimerMode), cmbBxTimerMode.SelectedItem.ToString()
            );
            perfChart7.TimerMode = (SpPerfChart.TimerMode)Enum.Parse(
               typeof(SpPerfChart.TimerMode), cmbBxTimerMode.SelectedItem.ToString()
           );
            perfChart8.TimerMode = (SpPerfChart.TimerMode)Enum.Parse(
               typeof(SpPerfChart.TimerMode), cmbBxTimerMode.SelectedItem.ToString()
           );
        }

        private void numUpDnTimerInterval_ValueChanged(object sender, EventArgs e)
        {
            perfChart.TimerInterval = Convert.ToInt32(numUpDnTimerInterval.Value);
            perfChart1.TimerInterval = Convert.ToInt32(numUpDnTimerInterval.Value);
            perfChart2.TimerInterval = Convert.ToInt32(numUpDnTimerInterval.Value);
            perfChart3.TimerInterval = Convert.ToInt32(numUpDnTimerInterval.Value);
            perfChart4.TimerInterval = Convert.ToInt32(numUpDnTimerInterval.Value);
            perfChart5.TimerInterval = Convert.ToInt32(numUpDnTimerInterval.Value);
            perfChart6.TimerInterval = Convert.ToInt32(numUpDnTimerInterval.Value);
            perfChart7.TimerInterval = Convert.ToInt32(numUpDnTimerInterval.Value);
            perfChart8.TimerInterval = Convert.ToInt32(numUpDnTimerInterval.Value);

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            valueGenFrom = Convert.ToInt32(numUpDnValFrom.Value);
            valueGenTo = Convert.ToInt32(numUpDnValTo.Value);
            if (valueGenTo < valueGenFrom)
            {
                valueGenTo = valueGenFrom;
                numUpDnValTo.Value = valueGenTo;
            }

            valueGenTimerFrom = Convert.ToInt32(numUpDnFromInterval.Value);
            valueGenTimerTo = Convert.ToInt32(numUpDnToInterval.Value);
            if (valueGenTimerTo < valueGenTimerFrom)
            {
                valueGenTimerTo = valueGenTimerFrom;
                numUpDnToInterval.Value = valueGenTimerTo;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            perfChart.Clear();
            perfChart1.Clear();
            perfChart2.Clear();
            perfChart3.Clear();
            perfChart4.Clear();
            perfChart5.Clear();
            perfChart6.Clear();
            perfChart7.Clear();
            perfChart8.Clear();
        }

        

        private void FrmTestingForm_Load(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

            gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl1.Position = new GMap.NET.PointLatLng(-6.9175, 107.6191);


            gMapControl1.ShowCenter = false;
            GMapOverlay markers = new GMapOverlay("markers");
            GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(-6.890903, 107.610378),
                GMarkerGoogleType.blue_pushpin);
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);

        }

        private accel ParsingMessage(string messages)
        {
            accel accel_data;
            string data_x, data_y, data_z;
            char[] delimiters = { '<', '>' };
            string[] parseMessage = messages.Split(delimiters);
            data_x = parseMessage[1];
            data_y = parseMessage[2];
            data_z = parseMessage[3];
            accel_data.accel_x = (int)Math.Ceiling(float.Parse(data_x) * 1000);
            accel_data.accel_y = (int)Math.Ceiling(float.Parse(data_y) * 1000);
            accel_data.accel_z = (int)Math.Ceiling(float.Parse(data_z) * 1000);

            return accel_data;
        }

        private void perfChart_Load(object sender, EventArgs e)
        {
            //receive();
        }

        private void perfChart4_Load(object sender, EventArgs e)
        {

        }

        private void perfChart6_Load(object sender, EventArgs e)
        {

        }

        private void perfChart_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         //   pictureBox1.Hide();
            
            check_1 = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void perfChart3_Load(object sender, EventArgs e)
        {

        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

      

        private void tabControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //connect_msgserver("ecn.1");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int timer_1 = 0;
            int timer_2 = 0;
            int timer_3 = 0;
            int timer_4 = 0;
            int timer_5 = 0;
            //int timer_6 = 0;
            if (count_1 == 1)
            {
                timer_1++;                
            }
            if (timer_1 > 5)
            {
                count_1 = 0;
            }

            if (count_2 == 1)
            {
                timer_2++;
            }
            if (timer_2 > 5)
            {
                count_2 = 0;
            }

            if (count_3 == 1)
            {
                timer_3++;
            }
            if (timer_3 > 5)
            {
                count_3 = 0;
            }

            if (count_4 == 1)
            {
                timer_4++;
            }
            if (timer_4 > 5)
            {
                count_4 = 0;
            }

            if (count_5 == 1)
            {
                timer_5++;
            }
            if (timer_5 > 5)
            {
                count_5 = 0;
            }

            if (count_5 == 1)
            {
                timer_5++;
            }
            if (timer_5 > 5)
            {
                count_5 = 0;
            }
        }
    }



    class data
    {
        public string pointTime;
        public string timeZone;
        public string interval;
        public string clientID;
        public geojson geojson;
        public acc[] accelerations;
    };

    class geojson
    {        
        public geometry geometry;
        public prop property;
    };

    class geometry
    {
        public string type;
        public string[] coordinates;
    };

    class prop
    {
        public string name;
    };


    class acc
    {
        public string x;
        public string y;
        public string z;
    };
          
}
