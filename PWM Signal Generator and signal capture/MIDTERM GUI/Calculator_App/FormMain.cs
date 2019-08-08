/*c# CODE
 Ashish Khadka */ 
using System;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Calculator_App
{
    public partial class FormMain : Form
    {
        int first_num = 0;

        int count = 0;

        int i=0;

        private FormPortSettings _formPortSettings;
        private PortSettingsEntity _defaultSettings, _currentSettings;

        public FormMain()
        {
            InitializeComponent();
            tbDisplay.ReadOnly = true;
        }

        private void InitializeComPort(PortSettingsEntity handle)
        {
            handle.PortName = System.IO.Ports.SerialPort.GetPortNames()[0];  //Default com port is the first one on the list
            handle.BaudRate = 115200;
            handle.DataBits = 8;
            handle.StopBits = System.IO.Ports.StopBits.One;
            handle.Parity = System.IO.Ports.Parity.None;
        }

 

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Implement serial port connect
            //error shoul dpoint here
            if (!serialPort1.IsOpen)
            {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        serialPort1.Open();
                disconnectToolStripMenuItem.Enabled = true;
                connectToolStripMenuItem.Enabled = false;
            }
        }
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                //Disconnect serial port
                serialPort1.Close();
                connectToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = false;
                tbDisplay.ReadOnly = true;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _defaultSettings = new PortSettingsEntity();  //Object instance containing default settings
            _currentSettings = new PortSettingsEntity();  //Object instance storing current settings from user

            InitializeComPort(_defaultSettings);
            InitializeComPort(_currentSettings);

            //Initialize UI visual elements
            connectToolStripMenuItem.Enabled = true;
            disconnectToolStripMenuItem.Enabled = false;
        }

        private void FormSerialTx_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }
      


        //connect to seiral port
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_formPortSettings == null)
            {
                _formPortSettings = new FormPortSettings();
            }

            _formPortSettings.Initialize(_defaultSettings, _currentSettings);
            if (_formPortSettings.ShowDialog() == DialogResult.OK)
            {
                //apply settings
                _currentSettings = _formPortSettings.NewSettings;
            }
        }

        //send reset message to hardware
        private void BtnClear_Click(object sender, EventArgs e)
        {
            tbDisplay.Clear(); 
            EFDB.Clear();
            EDDB.Clear(); MFDB.Clear(); MPWDB.Clear(); MDCDB.Clear(); count = 0;
            serialPort1.Write("c");

        }

       
        //send number to hardware and display on text box1
        private void button_click(object sender, EventArgs e)
        {
            //printing on screen when serial port is on 
            Button button = (Button)sender;


            if (serialPort1.IsOpen)
            {
                             
               // serialPort1.Write(button.Text);

            
                tbDisplay.Text = tbDisplay.Text + button.Text;
                
               
                first_num = Convert.ToInt32(button.Text);
                serialPort1.Write(button.Text);
               
            }
          }


        //if hash or astrick is pressed send to hardware and 
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //op = Convert.ToChar(tbDisplay.Text);
          
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(button.Text);

            }
        }

        //Reading from Serial port and display  work display box
        public delegate void AddnewText(string str);
        public void AddTextToLabel(string str)
        {
            if (this.tbDisplay.InvokeRequired)
            {
                this.Invoke(new AddnewText(AddTextToLabel), str);
            }
            else
            {
                this.tbDisplay.Text = "";
                this.tbDisplay.Text += str;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Note: SerialPort object operates on a seperate thread.
            //      Therefore, DataReceived event can not interact directly with other WinForm controls.
            //      Doing so will cause cross-thread action exception.
            //      In order to display received data to UI, delegate method must be used.

            //Read data from serial port object
            string data = serialPort1.ReadExisting();
            //check if the received data is number or not
            bool bNum = int.TryParse(data, out i);
            if (bNum)
            {
                switch (count)
                {
                    case 0:
                       // count++;
                        AddTextToLabelReadFreqbox(data);
                        break;
                    case 1:
                       // count++;
                        AddTextToLabelRead_duty(data);
                        break;
                    case 2:
                      //  count++;
                        AddTextToLabelM_freq(data.ToString());
                        break;
                    case 3:
                        //count++;
                        AddTextToLabelM_Pulse(data.ToString());
                        break;
                    case 4:
                       // count++;
                        AddTextToLabelM_Duty(data.ToString());
                        break;
                    case 5:
                       // count++;
                        AddTextToLabelReadFreqbox(data.ToString());
                        break;
                }
               
            }
            else
            { 
                if (data != "a"){
                AddTextToLabel(data);
                }
             else if (data == "a")
            {

                count++;
                MessageBox.Show(count.ToString());
            }
            //TODO: display received string to Textbox
        }
  }

        public delegate void AddnewText1(string readFreq);
        public void AddTextToLabelReadFreqbox(string readFreq)
        {
            if (this.EFDB.InvokeRequired)
            {
                this.Invoke(new AddnewText1(AddTextToLabelReadFreqbox), readFreq);
            }
            else
            {
                //this.EFDB.Text = "";
                this.EFDB.Text += readFreq;
            }
        }


        
        //Reading from Serial port and display entered frequency display box
        private void EFDB_TextChanged(object sender, EventArgs e)
        {
            string freq_read = serialPort1.ReadExisting();
            AddTextToLabel(freq_read);
        }



        public delegate void AddnewText2(string readDuty);
        public void AddTextToLabelRead_duty(string readDuty)
        {
            if (this.EDDB.InvokeRequired)
            {
                this.Invoke(new AddnewText2(AddTextToLabelRead_duty), readDuty);
            }
            else
            {
                //this.EFDB.Text = "";
                this.EDDB.Text += readDuty;
            }
        }
        
        
        private void EDDB_TextChanged(object sender, EventArgs e)
        {
            string e_duty_c = serialPort1.ReadExisting();
            AddTextToLabelRead_duty(e_duty_c);

        }


       




        public delegate void AddnewText3(string M_freq);
        public void AddTextToLabelM_freq(string M_freq)
        {
            if (this.MFDB.InvokeRequired)
            {
                this.Invoke(new AddnewText3(AddTextToLabelM_freq), M_freq);
            }
            else
            {
                //this.EFDB.Text = "";
                this.MFDB.Text += M_freq;
            }
        }



        private void MFDB_TextChanged(object sender, EventArgs e)
        {
            string measured_f = serialPort1.ReadExisting();
            AddTextToLabelM_freq(measured_f);

        }




        public delegate void AddnewText4(string M_pulse);
        public void AddTextToLabelM_Pulse(string M_pulse)
        {
            if (this.MPWDB.InvokeRequired)
            {
                this.Invoke(new AddnewText4(AddTextToLabelM_Pulse), M_pulse);
            }
            else
            {
                //this.EFDB.Text = "";
                this.MPWDB.Text += M_pulse;
            }
        }

        private void MPWDB_TextChanged(object sender, EventArgs e)
        {
            string measured_pw = serialPort1.ReadExisting();
            AddTextToLabelM_Pulse(measured_pw);
        }



        public delegate void AddnewText5(string M_duty);
        public void AddTextToLabelM_Duty(string M_duty)
        {
            if (this.MDCDB.InvokeRequired)
            {
                this.Invoke(new AddnewText5(AddTextToLabelM_Duty), M_duty);
            }
            else
            {
                //this.EFDB.Text = "";
                this.MDCDB.Text += M_duty;
            }
        }


         private void MDCDB_TextChanged(object sender, EventArgs e)
        {
            string measured_dc = serialPort1.ReadExisting();
            AddTextToLabelM_Duty(measured_dc);
        }




    }

}