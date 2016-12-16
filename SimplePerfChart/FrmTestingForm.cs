using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using GMap.NET;

using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;



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
        private int valueGenTimerTo = 1000;
        public static string data = "";

        public struct accel
        {
            public decimal accel_x;
            public decimal accel_y;
            public decimal accel_z;
        }
        public FrmTestingForm() {
            InitializeComponent();
            
            this.Font = SystemInformation.MenuFont;

            propGrid.SelectedObject = perfChart.PerfChartStyle;

            // Apply default Properties
            perfChart.TimerInterval = 1000;

            // Populate DrowDown Boxes
            foreach (String item in System.Enum.GetNames(typeof(Border3DStyle))) {
                cmbBxBorder.Items.Add(item);
            }
            foreach (String item in System.Enum.GetNames(typeof(SpPerfChart.ScaleMode))) {
                cmbBxScaleMode.Items.Add(item);
            }
            foreach (String item in System.Enum.GetNames(typeof(SpPerfChart.TimerMode))) {
                cmbBxTimerMode.Items.Add(item);
            }

            // Select default values
            cmbBxTimerMode.SelectedItem = perfChart.TimerMode.ToString();
            cmbBxScaleMode.SelectedItem = perfChart.ScaleMode.ToString();
            cmbBxBorder.SelectedItem = perfChart.BorderStyle.ToString();
        }



        private void chkBxTimerEnabled_CheckedChanged(object sender, EventArgs e) {
            if (chkBxTimerEnabled.Checked && !bgWrkTimer.IsBusy) {
                RunTimer();
            }
        }

        private void RunTimer() {
            int waitFor = randGen.Next(valueGenTimerFrom, valueGenTimerTo);
            bgWrkTimer.RunWorkerAsync(waitFor);
        }

        private void bgWrkTimer_DoWork(object sender, DoWorkEventArgs e) {
            Thread.Sleep(Convert.ToInt32(e.Argument));
        }

        private void bgWrkTimer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            accel accel_data;
            int genValue = randGen.Next(valueGenFrom, valueGenTo);
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                   // Console.WriteLine(" [x] Received {0}", message);
                    data = message;
                    accel_data = ParsingMessage(data);
                    Console.WriteLine("{0} {1} {2}", accel_data.accel_x, accel_data.accel_y, accel_data.accel_z);
                    perfChart.AddValue(accel_data.accel_x);
                    perfChart1.AddValue(accel_data.accel_y);
                    perfChart2.AddValue(accel_data.accel_z);

                };
                channel.BasicConsume(queue: "hello",
                                     noAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
            
            if (chkBxTimerEnabled.Checked) {
                //Simply restart, if still enabled
                RunTimer();
            }
        }

        private void cmbBxBorder_SelectedIndexChanged(object sender, EventArgs e) {
            perfChart.BorderStyle = (Border3DStyle)Enum.Parse(
                typeof(Border3DStyle), cmbBxBorder.SelectedItem.ToString()
            );
        }

        private void cmbBxScaleMode_SelectedIndexChanged(object sender, EventArgs e) {
            perfChart.ScaleMode = (SpPerfChart.ScaleMode)Enum.Parse(
                typeof(SpPerfChart.ScaleMode), cmbBxScaleMode.SelectedItem.ToString()
            );
        }

        private void cmbBxTimerMode_SelectedIndexChanged(object sender, EventArgs e) {
            perfChart.TimerMode = (SpPerfChart.TimerMode)Enum.Parse(
                typeof(SpPerfChart.TimerMode), cmbBxTimerMode.SelectedItem.ToString()
            );
        }

        private void numUpDnTimerInterval_ValueChanged(object sender, EventArgs e) {
            perfChart.TimerInterval = Convert.ToInt32(numUpDnTimerInterval.Value);
        }

        private void btnApply_Click(object sender, EventArgs e) {
            valueGenFrom = Convert.ToInt32(numUpDnValFrom.Value);
            valueGenTo = Convert.ToInt32(numUpDnValTo.Value);
            if (valueGenTo < valueGenFrom) {
                valueGenTo = valueGenFrom;
                numUpDnValTo.Value = valueGenTo;
            }

            valueGenTimerFrom = Convert.ToInt32(numUpDnFromInterval.Value);
            valueGenTimerTo = Convert.ToInt32(numUpDnToInterval.Value);
            if (valueGenTimerTo < valueGenTimerFrom) {
                valueGenTimerTo = valueGenTimerFrom;
                numUpDnToInterval.Value = valueGenTimerTo;
            }
        }

        private void btnClear_Click(object sender, EventArgs e) {
            perfChart.Clear();
        }

        public static void receive()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "data", type: "fanout");
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                channel.QueueBind(queue: "hello",
                              exchange: "data",
                              routingKey: "");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                    //data = Convert.ToDecimal(message);
                };
                channel.BasicConsume(queue: "hello",
                                     noAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
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
            receive();
        }
    }



   
    }
