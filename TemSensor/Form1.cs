using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemSensor
{
    public partial class Form1 : Form
    {
        enum PowerStates { None, Off, On, Pause}

        private PowerStates _powerState = PowerStates.On;
        private Action _controlLoop = null;
        private const double TARGET_TEMP = 37.0;
        private const string TESTFILE = "random_temps.csv";
        private const int COUNT_THRESHOLD = 5;
        private int _numOver = 0;
        private bool _reachedTarget = false;
        private int _numUnder = 0;
        private List<float> lines;
        private int _index = 0;
        double bodyTemp = 0, mattressTemp = 0;
        bool updateData = false;

        public Form1()
        {
            InitializeComponent();
            // Open CSV test file.
            using(var reader = new StreamReader(TESTFILE)) {
                lines = new List<float>();
                
                while(!reader.EndOfStream) {
                    lines.Add(float.Parse(reader.ReadLine()));
                }
            }



            // Set controlLoop Action to preheat Control loop
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            btnStartPreHeat.Left = (this.ClientSize.Width - btnStartPreHeat.Width) / 2;
            btnStartPreHeat.Top = (this.ClientSize.Height - btnStartPreHeat.Height) / 2;

            label_bodyTemp.Visible = false;
            label_mattressTemp.Visible = false;

            //lblMainTemp.Text = $@"{_currentTemp}°C";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnStartPreHeat_Click(object sender, EventArgs e)
        {
            if (_powerState == PowerStates.On) 
            {
                DialogResult dialogResult =
                    MessageBox.Show("Do you want to start Pre-heat?", "Pre-heat", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    StartPreHeat();
                    //StartMainControl();
                }
            }
        }

        private void tempTimer_Tick(object sender, EventArgs e)
        {
            //prgBarPreHeat.Increment(1);
            _controlLoop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_powerState == PowerStates.On)
            {
                DialogResult dialogResult = MessageBox.Show("Power Off?", "", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    //TODO: Turn 
                    PowerOff();
                }
            }
            else
            {
                PowerOn();
            }
        }

        private void StartPreHeat()
        {
            btnStartPreHeat.Visible = false;
            btnStartPreHeat.Enabled = false;

            lblPreHeatStatus.Visible = true;
            prgBarPreHeat.Visible = true;

            lblMainTemp.Visible = true;
            lblTempType.Visible = true;

            label_bodyTemp.Visible = false;
            label_mattressTemp.Visible = false;

            lblTargetTemp.Visible = true;
            lblTarget.Visible = true;
            lblTarget.Text = $@"{TARGET_TEMP}°C";

            pictureBox2.Visible = true;
            pictureBox3.Visible = true;

            _controlLoop = PreheatControl;

            // start timer
            tempTimer.Enabled = true;
            tempTimer.Start();

        }

        private void PowerOff()
        {
            tempTimer.Stop();
            btnStartPreHeat.Visible = false;
            btnStartPreHeat.Enabled = false;

            lblPreHeatStatus.Visible = false;
            prgBarPreHeat.Visible = false;

            lblMainTemp.Visible = false;
            lblTempType.Visible = false;

            label_bodyTemp.Visible = false;
            label_mattressTemp.Visible = false;

            lblTargetTemp.Visible = false;
            lblTarget.Visible = false;

            pictureBox2.Visible = false;
            pictureBox3.Visible = false;

            // stop timer
            tempTimer.Enabled = false;
            this.BackColor = Color.Black;
            _powerState = PowerStates.Off;

            //close serial port
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }
        private void PauseStateGo()
        {
            tempTimer.Stop();
            btnStartPreHeat.Visible = false;
            btnStartPreHeat.Enabled = false;

            lblPreHeatStatus.Visible = false;
            prgBarPreHeat.Visible = false;

            lblMainTemp.Visible = false;
            lblTempType.Visible = false;

            label_bodyTemp.Visible = false;
            label_mattressTemp.Visible = false;

            lblTargetTemp.Visible = false;
            lblTarget.Visible = false;

            pictureBox2.Visible = false;

            // stop timer
            tempTimer.Enabled = false;
            this.BackColor = Color.Black;
            _powerState = PowerStates.Pause;

            //close serial port
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void PowerOn()
        {
            btnStartPreHeat.Visible = true;
            btnStartPreHeat.Enabled = true;
            _powerState = PowerStates.On;
            this.BackColor = Color.White;
        }

        private void lblPreHeatStatus_Click(object sender, EventArgs e)
        {

        }

        private void GPIOStates()
        {
            //gpio high -  red light off
            //gpio low - red light on
            //need to build function to determine high or low state of GPIO - check into this
        }

        private void PreheatControl()
        {
            
            if (_index < lines.Count)
            {
                float value = lines[_index];
                prgBarPreHeat.Value = (int)Math.Min(TARGET_TEMP, value);
                lblMainTemp.Text = string.Format("{0:N1}°C", value);
                _index++;

                // Increment counter if we are over
                if (value >= TARGET_TEMP)
                {
                    _numOver++;
                }

                if (_numOver >= COUNT_THRESHOLD && _reachedTarget == false)
                {
                    _numOver = 0;
                    _reachedTarget = true;
                    DialogResult result = MessageBox.Show("Preheat Complete. Is patient ready?", "Preheat Complete", MessageBoxButtons.YesNo); 
                    
                    if (result == DialogResult.Yes) {
                        tempTimer.Stop();
                        tempTimer.Enabled = false;
                        // Start patient control loop
                        StartMainControl();
                    }
                    else {
                        
                    }

                }
            }
        }

        private void StartMainControl()
        {
            btnStartPreHeat.Visible = false;
            btnStartPreHeat.Enabled = false;

            lblPreHeatStatus.Visible = false;
            prgBarPreHeat.Visible = false;

            lblMainTemp.Visible = false;
            lblTempType.Visible = false;

            label_bodyTemp.Visible = true;
            label_mattressTemp.Visible = true;

            lblTargetTemp.Visible = true;
            lblTarget.Visible = true;
            lblTarget.Text = $@"{TARGET_TEMP}°C";

            pictureBox2.Visible = true;

            //open serial port
            serialPort1.PortName = "COM3";
            //serialPort1.PortName = "/dev/ttyACM0";
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
            
            _controlLoop = MainControl;

            // start timer
            tempTimer.Enabled = true;
            tempTimer.Start();

        }

        private void MainControl()
        {
            //Console.log("Main Control test");
            
            //this is where we could split into different threads

            string dataIn = serialPort1.ReadTo("\n");
            Data_Parsing(dataIn);
            //this.BeginInvoke(new EventHandler(Show_Data));
            Show_Data();

            //if state involving 37 fahrenheit, heaton function

            // else heatoff

            // need to be in control loop to bounce back and forth

            serialPort1.DiscardOutBuffer();
            serialPort1.DiscardInBuffer();
        }

        //private void Show_Data(object sender, EventArgs e)
        private void Show_Data()
        {
            if (updateData == true)
            //if (true)
            {
                label_bodyTemp.Text = string.Format("Body Temperature = {0}°C", bodyTemp.ToString());
                label_mattressTemp.Text = string.Format("Mattress Temperature = {0}°C", mattressTemp.ToString());
            }
        }

        private void Data_Parsing(string dataIn)
        {
            sbyte indexOf_startDataCharacter = (sbyte)dataIn.IndexOf("@");
            sbyte indexOfA = (sbyte)dataIn.IndexOf("A");
            sbyte indexOfB = (sbyte)dataIn.IndexOf("B");

            //If character "A", "B", and "@" exist in the data Package
            if (indexOfA != -1 && indexOfB != -1 && indexOf_startDataCharacter != -1)
            {
                try
                {
                    string str_bodytemp = dataIn.Substring(indexOf_startDataCharacter + 1, (indexOfA - indexOf_startDataCharacter) - 1);
                    string str_mattresstemp = dataIn.Substring(indexOfA + 1, (indexOfB - indexOfA) - 1);

                    bodyTemp = Convert.ToDouble(str_bodytemp);
                    mattressTemp = Convert.ToDouble(str_mattresstemp);

                    updateData = true;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                updateData = false;
            }
        }

        private void heatLightOff()
        {
            pictureBox2.Visible = false;
        }

        private void heatLightOn()
        {
            pictureBox2.Visible = true;
        }

        private void heatOff()
        {
            //pinMode(A0, OUTPUT); may need to place within initialization values
            //digitalWrite(A0, LOW);
            heatLightOff();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (_powerState == PowerStates.On)
            {
                DialogResult dialogResult = MessageBox.Show("Pause? This will maintain current temp.", "", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    //TODO: Turn 
                    PauseStateGo();
                }
            }
            else
            {
                PowerOn();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void heatOn()
        {
            //pinMode(A0, OUTPUT); may need to place within initialization values
            //digitalWrite(A0, HIGH);
            heatLightOn();
        }
    }
}
