using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1

{
    class Gateway
    {
        DeviceClient _CDSClient;

        public Gateway(DeviceClient cdsClient)
        {
            _CDSClient = cdsClient;
        }

        public void Run()
        {
            try
            {   
                /* Send Telemetry */
                SendTelemetry();

                /* Receive Cloud To Devce Message */
                //ReceiveCloudToDeviceMessageAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("InnerException: {0}", ex.InnerException.Message);
                    Console.WriteLine("InnerException StackTrace: {0}", ex.InnerException.StackTrace);
                }
            }
        }

        private async void SendTelemetry()
        {
           
                try
                {
                    List<Message> messages = getDeviceMessages();
                    await _CDSClient.SendEventBatchAsync(messages);                   
                    //Console.WriteLine("{0} > Sending message. Count={1}", DTNow, count);

                    //Task.Delay((int)(Form1.MessageSendInterval * 1000)).Wait();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SendAsync Exception: {0}", ex.ToString());
                }
            
        }

        private List<Message> getDeviceMessages()
        {
            string device01Msg = getEquipmentTelemetry();
            var message01 = new Message(Encoding.ASCII.GetBytes(device01Msg));
            message01.Properties.Add("MessageCatalogId", Form1.MessageCatalogId.ToString());
            message01.Properties.Add("Type", "Message");
            //string device02Msg = getEquipmentTelemetry("AirBox-02");
            //var message02 = new Message(Encoding.ASCII.GetBytes(device02Msg));
            //message02.Properties.Add("MessageCatalogId", "293");
            //message02.Properties.Add("Type", "Message");

            //string device03Msg = getEquipmentTelemetry("AirBox-03");
            //var message03 = new Message(Encoding.ASCII.GetBytes(device03Msg));
            //message03.Properties.Add("MessageCatalogId", "293");
            //message03.Properties.Add("Type", "Message");

            //string device04Msg = getEquipmentTelemetry("AirBox-04");
            //var message04 = new Message(Encoding.ASCII.GetBytes(device04Msg));
            //message04.Properties.Add("MessageCatalogId", "293");
            //message04.Properties.Add("Type", "Message");

            //string device05Msg = getEquipmentTelemetry("AirBox-05");
            //var message05 = new Message(Encoding.ASCII.GetBytes(device05Msg));
            //message05.Properties.Add("MessageCatalogId", "293");
            //message05.Properties.Add("Type", "Message");

            List<Message> messageList = new List<Message>();
            messageList.Add(message01);
            //messageList.Add(message02);
            //messageList.Add(message03);
            //messageList.Add(message04);
            //messageList.Add(message05);
            return messageList;        
        }

        private string getEquipmentTelemetry()
        {

            //MCM100 mcm100 = new MCM100();
            //mcm100.GetData(datas, scaledDatas, channelNumbers);
            //public List<Item> items
            //Console.WriteLine("Send message: {0}\n", Form1.topicName.ToString());

            return Form1.topicName.ToString();
        }   

        private async void ReceiveCloudToDeviceMessageAsync()
        {
            while (true)
            {
                try
                {
                    Message receivedMessage = await _CDSClient.ReceiveAsync();
                    if (receivedMessage == null)
                        continue;// It returns null after a specifiable timeout period (in this case, the default of one minute is used)

                    string msg = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                    await _CDSClient.CompleteAsync(receivedMessage);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Received message: {0}\n", msg);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}
