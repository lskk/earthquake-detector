/*
   Earthquake Catcher Network v1.0
   Capstone Design by
    Christoporus Deo Putratama
    Kevin Shidqi
    Bramantio Yuwono

   Read seismic waves using IMU sensor
   Read location and exact time using GPS
   Sending those data using Wi-Fi using MQTT

*/


//====================================================//
//=================Library & Constant=================//
//====================================================//

#include <ESP8266WiFi.h>
#include <PubSubClient.h>
#include <SoftwareSerial.h>
#include <Wire.h>
#include <TinyGPS++.h>
#include <ArduinoJson.h>

#define SDA_PIN D1
#define SCL_PIN D2
#define PWR_MGMT 0x6B
#define RXPin D6
#define TXPin D5
#define GPSBaud 9600
#define NData 40 // Amount of Data per one second

const char* TIMEZONE = "Asia/Jakarta";
const char* PROP = "ITB";
const char* TYPE = "Point";
const String SensorID = "1";
const int SendPeriod = 1000; //in ms
const int WaitGPS = 10;
const int N = NData * (SendPeriod/1000); // Amount of Sample
//Initial Coordinate
static const double init_lat = -6.889916, init_lon = 107.61133;

//====================================================//
//==========Connection & Database Variables===========//
//====================================================//

const char* ssid = "Andromax-M3Z-FD9A";    //  network SSID (name)
const char* pass = "32194275";   // network password
//const char* ssid = "Hotspot ITB";
//const char* pass = "hotspotitb";
//const char* mqtt_server = "black-boar.rmq.cloudamqp.com"; //MQTT server
const char* mqtt_server = "167.205.7.226";
const char* server_topic = "amq.topic.ecn.2"; //MQTT server topic
String mqtt_clientID = "ECN-" + SensorID;
//String mqtt_user = "lsowqccg:lsowqccg";
//String mqtt_user = "guest";
String mqtt_user = "/disaster:sensor_gempa";
//String mqtt_password = "kbLv9YbzjQwxz20NH7Rfy98TTV2eK17j";
//String mqtt_password = "guest";
String mqtt_password = "12345";

int status = WL_IDLE_STATUS;
WiFiClient espClient;
PubSubClient client(espClient);

//====================================================//
//==================IMU & GPS Initiation==============//
//====================================================//

// I2C address of the MPU-9255
#define    MPU9250_ADDRESS            0x68
#define    MAG_ADDRESS                0x0C

#define    ACC_FULL_SCALE_2_G        0x00  
#define    ACC_FULL_SCALE_4_G        0x08
#define    ACC_FULL_SCALE_8_G        0x10
#define    ACC_FULL_SCALE_16_G       0x18

#define    ACC_FILTER_OFF            0x08
#define    ACC_FILTER_20HZ           0x0C

const float ACC_RES = 6.10388817677e-05;
const float MAG_RES = 0.149540696432;
const float G = 9.8;

float axg = 0.0;
float ayg = 0.0;
float azg = 0.0;

float axgf = 0.0;
float aygf = 0.0;
float azgf = 0.0;

float mxt = 0.0;
float myt = 0.0;
float mzt = 0.0;

float mxtf = 0.0;
float mytf = 0.0;
float mztf = 0.0;

float temperaturG = 0.0;

struct MPU9255 {
  float x;
  float y;
  float z;
  float temp;
  float magx;
  float magy;
  float magz;
};

struct times{
  long now;
  long gps;
  long imu;
  long mqtt;
};


MPU9255 data;
times t;

//TinyGPS++ Object
TinyGPSPlus gps;

// The serial connection to the GPS device
SoftwareSerial ss(RXPin, TXPin);


//===================================================//
//===================JSON OBJECT=====================//
//===================================================//
struct DataIMU {
  String x;
  String y;
  String z;
};

struct MessageData {
  String PointTime;
  String coordinates[2];
  DataIMU acc[N];
};

struct SensorSetting {
  String ClientID;
  String TimeZone;
  String Interval;
  String Properties;
};

struct MessageData payload_data;
struct SensorSetting payload_setting;

int i = 0, j = 0;
bool checkgps = false;

//====================================================//
//===================MAIN ALGORITHM===================//
//====================================================//


void setup()
{
  MPU9255_Init();
  payload_setting = InitJsonObject(payload_setting);
  WiFiConnect();
  client.setServer(mqtt_server, 1883);
  client.setCallback(callback);

  Serial.begin(115200);
  Serial.println();
  ss.begin(GPSBaud);
  Serial.printf("Wi-Fi mode set to WIFI_STA %s\n", WiFi.mode(WIFI_STA) ? "" : "Failed!");
  Serial.printf("Connection status: %d\n", WiFi.status());
  WiFi.printDiag(Serial);
  Serial.println("1");
  payload_data.coordinates[0] = String(init_lat);   
  payload_data.coordinates[1] = String(init_lon);
}


void loop()
{
  if(!client.loop()) 
  {
    //client.connect(mqtt_clientID.c_str(), mqtt_user.c_str(), mqtt_password.c_str());
    Serial.println(String(client.state()));
    reconnect_server();
    Serial.println(String(client.state()));
  }
  
  if (!client.connected()) {
    WiFiConnect();
    reconnect_server();
    i = 0;
  }
  else
  {
    t.now = millis();
    data = Acc_Read();
    t.imu = millis() - t.now ;
    
    payload_data.acc[i].x = String(data.x, 6);
    payload_data.acc[i].y = String(data.y, 6);
    payload_data.acc[i].z = String(data.z, 6);
    if(i==0)
    {
      Serial.println("2");
      t.now = millis();
      while (ss.available() > 0)
      {
        if (gps.encode(ss.read()))
        {
          displayInfo();
        }
          String YEAR = String(gps.date.year());
          String MONTH = String(gps.date.month());
          String DATE = String(gps.date.day());
          String HOUR = String(gps.time.hour());
          String MINUTE = String(gps.time.minute());
          String SECOND = String(gps.time.second());
          payload_data.PointTime = YEAR + "-" + MONTH + "-" + DATE + "T" + HOUR + ":" + MINUTE + ":" + SECOND + "Z";

      if (millis()-t.now > WaitGPS*1000 && gps.charsProcessed() < 10)
      {
        Serial.println(F("No GPS detected: check wiring."));
        //while(true);
        break;
      }
      }
      t.gps = millis() - t.now;
    }
    i++;
    if(i==N)
    {
      Serial.println("3");
      i = 0;
      String message = JsonToString(payload_data,payload_setting);
      char message_t[MQTT_MAX_PACKET_SIZE];
      message.toCharArray(message_t, MQTT_MAX_PACKET_SIZE);
      
      t.now = millis();
      bool test = client.publish(server_topic, message_t);
      t.mqtt = millis()-t.now;
      
      if(test){
        Serial.print("publish success ");
        Serial.print(String(t.imu));
        Serial.print(" ");
        Serial.print(String(t.mqtt));
        Serial.print(" ");
        Serial.print(String(t.gps));
        Serial.print(" ");
//        Serial.print(payload_data.PointTime);
//        Serial.print(" ");
//        Serial.print(payload_data.coordinates[0]);
//        Serial.print(" ");
//        Serial.println(payload_data.coordinates[1]);
      }
    }
  }
  if(t.imu < 25)
    delay((1000/NData)-t.imu);  
}

//====================================================//
//==================ENCODE JSON FUNCTION==============//
//====================================================//


struct SensorSetting InitJsonObject(struct SensorSetting msg)
{
  msg.ClientID = mqtt_clientID;
  msg.TimeZone = TIMEZONE;
  msg.Interval = String(SendPeriod);
  msg.Properties = PROP;
  return msg;
}


String JsonToString(struct MessageData msg, struct SensorSetting set)
{
  String a = "";

  a = a + "{" + " \"pointTime\": " +  "\"" + msg.PointTime + "\"" + ",";
  a = a + "\"timeZone\":" + "\"" + set.TimeZone + "\"" + ",";
  a = a + "\"interval\":" + "\"" + set.Interval  + "\"" + ",";
  a = a + "\"clientID\":" + "\"" + set.ClientID  + "\"" + ",";
  a = a + "\"geojson\" :" + "{";

  //a = a + "\"type\":" + "\"" + msg.geometry.type + "\"" + ",";
  a = a + "\"geometry\":" + "{";

  a = a + "\"type\":" + "\"" + TYPE + "\"" + ",";
  a = a + "\"coordinates\": [ " + msg.coordinates[0] + ",";
  a = a + msg.coordinates[1] + "]";
  a = a + "},";

  a = a + "\"properties\":" + "{";
  a = a + "\"name\":" + "\"" + set.Properties + "\"";
  a = a + "}";

  a = a + "},";

  a = a + "\"accelerations\": [";

  for (int i = 0; i < N; i++)
  {
    if (i != (N-1))
    {
      a = a + "{";
      a = a + "\"x\": " + msg.acc[i].x  + ",";
      a = a + "\"y\": " + msg.acc[i].y  + ",";
      a = a + "\"z\": " + msg.acc[i].z  ;
      a = a + "},";
    }
    else
    {
      a = a + "{";
      a = a + "\"x\": " + msg.acc[i].x  + ",";
      a = a + "\"y\": " + msg.acc[i].y  + ",";
      a = a + "\"z\": " + msg.acc[i].z  ;
      a = a + "}";
    }   

  }


  a = a + "]";

  a = a + "}";

       //Serial.println(a);
  return a;
}


//====================================================//
//======Wi-Fi Connection & MQTT Function Procedure====//
//====================================================//
void WiFiConnect()
{
  // We start by connecting to a WiFi network
  WiFi.begin(ssid, pass);
  while (WiFi.status() != WL_CONNECTED)
  {
    delay(500);
  }
  randomSeed(micros());
}

void reconnect_server() {
  // Loop until we're reconnected
  while (!client.connected())
  {
//    Serial.print("Attempting MQTT connection...");
    // Attempt to connect
    //if you MQTT broker has clientID,username and password
    //please change following line to    if (client.connect(clientId,userName,passWord))
    if (client.connect(mqtt_clientID.c_str(), mqtt_user.c_str(), mqtt_password.c_str()))
    {
      Serial.println("connected");
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.print(" try again in " );
      Serial.print(String(SendPeriod/1000));
      Serial.println(" s");
      // Wait 1 Sending Period before retrying
      delay(SendPeriod);
    }
  }
} //end reconnect()

void callback(char* topic, byte* payload, unsigned int length)
{

  
}

//====================================================//
//==============IMU & GPS Function Procedure==========//
//====================================================//
// Tiefpassfilter

double Filter(double In, double OutLPS, int FZK)
{
  if(FZK > 0)
  {
    double schritt1 = OutLPS - In;
    double schritt2 = 1.0/FZK;
    double schritt3 = schritt1 * schritt2;
    double wert = OutLPS - schritt3;
    
    return wert;
  }
  else
  {
    return (In);
  }
}                 

// This function read Nbytes bytes from I2C device at address Address. 
// Put read bytes starting at register Register in the Data array. 
void I2Cread(uint8_t Address, uint8_t Register, uint8_t Nbytes, uint8_t* Data)
{
  // Set register address
  Wire.beginTransmission(Address);
  Wire.write(Register);
  Wire.endTransmission();
  
  // Read Nbytes
  Wire.requestFrom(Address, Nbytes); 
  uint8_t index=0;
  while (Wire.available())
    Data[index++]=Wire.read();
}


// Write a byte (Data) in device (Address) at register (Register)
void I2CwriteByte(uint8_t Address, uint8_t Register, uint8_t Data)
{
  // Set register address
  Wire.beginTransmission(Address);
  Wire.write(Register);
  Wire.write(Data);
  Wire.endTransmission();
}

void MPU9255_Init()
{
  Wire.begin(SDA_PIN,SCL_PIN);
  
  // Set accelerometers low pass filter at 5Hz
  I2CwriteByte(MPU9250_ADDRESS,29,ACC_FILTER_20HZ);

  // Configure accelerometers range
  I2CwriteByte(MPU9250_ADDRESS,28,ACC_FULL_SCALE_2_G);

  // Set by pass mode for the magnetometers
  I2CwriteByte(MPU9250_ADDRESS,0x37,0x02);
  
  // Request continuous magnetometer measurements in 16 bits
  I2CwriteByte(MAG_ADDRESS,0x0A,0x16);

}

struct MPU9255 Acc_Read()
{
  struct MPU9255 data;

  // ____________________________________
  // :::  accelerometer and gyroscope ::: 

  // Read accelerometer and gyroscope
  uint8_t Buf[14];
  I2Cread(MPU9250_ADDRESS,0x3B,8,Buf);
  
  // Create 16 bits values from 8 bits data
  
  // Accelerometer
  int16_t ax=Buf[0]<<8 | Buf[1];
  int16_t ay=Buf[2]<<8 | Buf[3];
  int16_t az=Buf[4]<<8 | Buf[5];

  // Temperatur
  int16_t temperatur=Buf[6]<<8 | Buf[7];

  //Acc in G
  axg = ax * ACC_RES;
  ayg = ay * ACC_RES;
  azg = az * ACC_RES;

  axgf = axg;//Filter(axg,axgf,30);
  aygf = ayg;//Filter(ayg,aygf,30);
  azgf = azg;//Filter(azg,azgf,30);

  // Temp in Grad
  
  temperaturG = temperatur * 1;
  temperaturG = temperaturG / 100;
  
  // _____________________
  // :::  Magnetometer ::: 

  
  // Read register Status 1 and wait for the DRDY: Data Ready
  
  uint8_t ST1;
  do
  {
    I2Cread(MAG_ADDRESS,0x02,1,&ST1);
  }
  while (!(ST1&0x01));

  // Read magnetometer data  
  uint8_t Mag[7];  
  I2Cread(MAG_ADDRESS,0x03,7,Mag);
  

  // Create 16 bits values from 8 bits data
  
  // Magnetometer
  int16_t mx=Mag[3]<<8 | Mag[2];
  int16_t my=Mag[1]<<8 | Mag[0];
  int16_t mz=Mag[5]<<8 | Mag[4];

  //Mag in uT
  mxt = mx * MAG_RES;
  myt = my * MAG_RES;
  mzt = mz * MAG_RES;

  mxtf = mxt;//Filter(mxt,mxtf,300);
  mytf = myt;//Filter(myt,mytf,300);
  mztf = mzt;//Filter(mzt,mztf,300);

  data.x = axgf * G;
  data.y = aygf * G;
  data.z = azgf * G;
  data.temp = temperaturG;
  data.magx = mxtf;
  data.magy = mytf;
  data.magz = mztf;

  float xh,yh,ayf,axf,var_compass;

  axf = atan( data.x / (sqrt(sq(data.y) + sq(data.z))));
  ayf = atan( data.y / (sqrt(sq(data.x) + sq(data.z))));
  
  axf *= 180.00;   ayf *= 180.00;  
  axf /= 3.141592; ayf /= 3.141592; 
  
  xh=mxtf*cos(ayf)+mytf*sin(ayf)*sin(axf)-mztf*cos(axf)*sin(ayf);
  yh=mytf*cos(axf)+mztf*sin(axf);
 
  var_compass=atan2((double)yh,(double)xh) * (180 / PI) -90; // angle in degrees
  if (var_compass>0){var_compass=var_compass-360;}
  var_compass=360+var_compass;  

  data.x = axgf*G*cos(var_compass) - aygf*G*sin(var_compass);
  data.y = axgf*G*sin(var_compass) + aygf*G*cos(var_compass);
  
  return data;
}

void displayInfo()
{
  if (gps.location.isValid())
  {
    payload_data.coordinates[0] = String (gps.location.lat(), 6);
    payload_data.coordinates[1] = String (gps.location.lng(), 6);
  }
  else
  {
    payload_data.coordinates[0] = String (init_lon, 6);
    payload_data.coordinates[1] = String (init_lat, 6);
  }
}


String char_repr(float x)
{
  uint8_t *temp;
  char z[2];
  int16_t y = (int16_t) (x*10000.00);
  z[0] = (char) lowByte(y);
  z[1] = (char) highByte(y);
  String t = String(z[1]) + String(z[0]);

  return t;
}

float rev_char_repr(String x)
{
  char y[2];
  byte z[2];
  int16_t yz;
  float t;
  int len,i,j,k;

  len = x.length();
  x.toCharArray(y,len+1);

  z[1] = (int8_t) y[0];
  z[0] = (int8_t) y[1];
  
  yz = (int16_t)((z[1]<<8)|(z[0]));
  t = ((float)yz*0.0001);

  return t;
}

