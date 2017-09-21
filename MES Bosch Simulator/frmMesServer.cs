using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MES_Bosch_Simulator
{
    public partial class frmMesServer : Form
    {
        private TcpListener Listener = null;
        private int tcpPort = 3550;
        private string ReceivedData = "";
        private string IP = "";
        private string Telegram = "";
        private string Message = "";
        private int label = 0;

        public frmMesServer()
        {
            InitializeComponent();
            cboxLabelType.SelectedIndex = 0;
            OpenPort();
        }

        private void OpenPort()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                Listener = new TcpListener(IPAddress.Any, tcpPort);
                Listener.Start();

                Thread th = new Thread(Listening);
                th.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ReceiveFromTcp(string text)
        {
            ReceivedData = text;
        }

        int counter;
        private void Listening()
        {
            counter = 0;
            while (true)
            {
                counter += 1;
                TcpClient clientSocket = Listener.AcceptTcpClient();
                IP = ((IPEndPoint)clientSocket.Client.RemoteEndPoint).Address.ToString();
                Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " started!");
                startClient(clientSocket, Convert.ToString(counter));
            }

        }

        TcpClient clientSocket;
        string clNo;

        public void startClient(TcpClient inClientSocket, string clineNo)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            Thread ctThread = new Thread(doChat);
            ctThread.Start();
        }
        private void doChat()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            string rCount = null;
            requestCount = 0;

            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    Array.Clear(bytesFrom, 0, bytesFrom.Length);
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom).Replace("\0", "");
                    ReceiveFromTcp(dataFromClient);
                    string response = ProcessTelegram(dataFromClient);

                    sendBytes = Encoding.ASCII.GetBytes(response);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" >> " + ex.ToString());
                }
            }
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            txtReceive.Text = ReceivedData;
            label = cboxLabelType.SelectedIndex + 1;
            lblIP.Text = "IP: " + IP;
            lblTelegram.Text = "Telegram: " + Telegram;
            lblMessage.Text = Message;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        Random r = new Random();
        string ccsDutLabelPara1 = "";
        string ccsDutLabelPara2 = "8W0907063E";
        string ccsDutLabelPara3 = "215";
        string ccsDutLabelPara4 = "012";
        string ccsDutLabelPara5 = "8W0907063E";
        string ccsFazitstring = "RB6-90501.12.0800030240";

        public string ProcessTelegram(string receivedTelegram)
        {
            string response = "";

            XMLParser parser = new XMLParser();
            parser.Code = receivedTelegram;
            XMLParser parserRes = new XMLParser();

            string eventId = "";
            // Header
            string lineNo = "";
            string statNo = "";
            string statIdx = "";
            string fuNo = "";
            string workPos = "";
            string toolPos = "";
            string processNo = "";
            string processName = "";
            string application = ""; 
            
            string identifier = ""; 
            string typeNo = "";
            string typeVar = "";


            string LabelType = label.ToString();

            try
            {
                eventId = parser.GetAttribute("eventId");

                lineNo = parser.GetAttribute("lineNo");
                statNo = parser.GetAttribute("statNo");
                statIdx = parser.GetAttribute("statIdx");
                fuNo = parser.GetAttribute("fuNo");
                workPos = parser.GetAttribute("workPos");
                toolPos = parser.GetAttribute("toolPos");
                processNo = parser.GetAttribute("processNo");
                processName = parser.GetAttribute("processName");
                application = parser.GetAttribute("application");


                if (parser.Code.Contains("partReceived"))
                {
                    Telegram = "partReceived";

                    identifier = parser.GetAttribute("identifier");
                    typeNo = parser.GetAttribute("typeNo");
                    typeVar = parser.GetAttribute("typeVar");

                    parserRes.Load("xmls\\partReceived_response.xml");

                    /// Header
                    parserRes.SetAttribute("eventId", eventId);
                    parserRes.SetAttribute("lineNo",lineNo);
                    parserRes.SetAttribute("statNo",statNo);
                    parserRes.SetAttribute("statIdx",statIdx);
                    parserRes.SetAttribute("fuNo",fuNo);
                    parserRes.SetAttribute("workPos",workPos);
                    parserRes.SetAttribute("toolPos",toolPos);
                    parserRes.SetAttribute("processNo",processNo);
                    parserRes.SetAttribute("processName",processName);
                    parserRes.SetAttribute("application",application);

                    /// Body
                    parserRes.SetAttribute("identifier",identifier);
                    parserRes.SetAttribute("typeNo",typeNo);
                    parserRes.SetAttribute("typeVar",typeVar);


                    /// Label Data
                    ccsDutLabelPara1 = r.Next(100000, 9999999).ToString();
                    ccsDutLabelPara2 = "8W0907063E";
                    ccsDutLabelPara3 = "215";
                    ccsDutLabelPara4 = "012";
                    ccsDutLabelPara5 = "8W0907063E";
                    ccsFazitstring = "RB6-90501.12.0800030240";


                    parserRes.SetAttribute("ccsDutLabelPara1", ccsDutLabelPara1);
                    parserRes.SetAttribute("ccsDutLabelPara2", ccsDutLabelPara2);
                    parserRes.SetAttribute("ccsDutLabelPara3", ccsDutLabelPara3);
                    parserRes.SetAttribute("ccsDutLabelPara4", ccsDutLabelPara4);
                    parserRes.SetAttribute("ccsDutLabelPara5", ccsDutLabelPara5);
                    parserRes.SetAttribute("ccsFazitstring", ccsFazitstring);

                    response = parserRes.Code;
                }


                if (parser.Code.Contains("partProcessed"))
                {
                    Telegram = "partProcessed";

                    identifier = parser.GetAttribute("identifier");
                    typeNo = parser.GetAttribute("typeNo");
                    typeVar = parser.GetAttribute("typeVar");

                    string tccsDutLabelPara1 = parser.GetAttribute("name=\"ccsDutLabelPara1\" value");
                    string tccsDutLabelPara2 = parser.GetAttribute("name=\"ccsDutLabelPara2\" value");
                    string tccsDutLabelPara3 = parser.GetAttribute("name=\"ccsDutLabelPara3\" value");
                    string tccsDutLabelPara4 = parser.GetAttribute("name=\"ccsDutLabelPara4\" value");
                    string tccsDutLabelPara5 = parser.GetAttribute("name=\"ccsDutLabelPara5\" value");
                    string tField17_DMC = parser.GetAttribute("name=\"Field17_DMC\" value"); ;
                    string tccsFazitstring = parser.GetAttribute("name=\"ccsFazitstring\" value");

                    bool returnCode = tccsDutLabelPara1.Contains(ccsDutLabelPara1) &&
                                      tccsDutLabelPara2.Contains(ccsDutLabelPara2) &&
                                      tccsDutLabelPara3.Contains(ccsDutLabelPara3) &&
                                      tccsDutLabelPara4.Contains(ccsDutLabelPara4) &&
                                      tccsDutLabelPara5.Contains(ccsDutLabelPara5) &&
                                      //tField17_DMC.Contains(Field17_DMC) &&
                                      tccsFazitstring.Contains(ccsFazitstring);

                    parserRes.Load("xmls\\partProcessed_response.xml");
                    parserRes.SetAttribute("eventId", eventId);
                    parserRes.SetAttribute("lineNo",lineNo);
                    parserRes.SetAttribute("statNo",statNo);
                    parserRes.SetAttribute("statIdx",statIdx);
                    parserRes.SetAttribute("fuNo",fuNo);
                    parserRes.SetAttribute("workPos",workPos);
                    parserRes.SetAttribute("toolPos",toolPos);
                    parserRes.SetAttribute("processNo",processNo);
                    parserRes.SetAttribute("processName",processName);
                    parserRes.SetAttribute("application",application);
                    
                    parserRes.SetAttribute("returnCode", returnCode ? "0" : "1");
                    //parserRes.SetAttribute("returnCode", "0");
                    response = parserRes.Code;
                }

                if (parser.Code.Contains("plcChangeOverStarted"))
                {
                    Telegram = "plcChangeOverStarted";

                    typeNo = parser.GetAttribute("typeNo");
                    typeVar = parser.GetAttribute("typeVar");

                    parserRes.Load("xmls\\plcChangeOverStarted_response.xml");


                    /// Header
                    parserRes.SetAttribute("eventId", eventId);
                    parserRes.SetAttribute("lineNo",lineNo);
                    parserRes.SetAttribute("statNo",statNo);
                    parserRes.SetAttribute("statIdx",statIdx);
                    parserRes.SetAttribute("fuNo",fuNo);
                    parserRes.SetAttribute("workPos",workPos);
                    parserRes.SetAttribute("toolPos",toolPos);
                    parserRes.SetAttribute("processNo",processNo);
                    parserRes.SetAttribute("processName",processName);
                    parserRes.SetAttribute("application",application);

                    /// Body
                    parserRes.SetAttribute("LabelType", LabelType);

                    parserRes.SetAttribute("returnCode", chkAcceptChangeModel.Checked ? "0" : "1");

                    response = parserRes.Code;
                }
            }
            catch(Exception ex)
            {
                Message = ex.Message + ex.StackTrace;
            }

            Message = "";
            return response;
        }

        private void frmMesServer_Load(object sender, EventArgs e)
        {

        }
    }
}
