using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace HMI
{
    public partial class Form1 : Form
    {
        int RedPos;
        int BluePos;
        int GreenPos;
        int LatestCube;
        Color NewColor;
        Color RedColor;
        Color GreenColor;
        Color BlueColor;
        Color OriginalColor;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OriginalColor = Cube1_Button.BackColor;
            NewColor = OriginalColor;
            RedColor = Red_Button.BackColor;
            GreenColor = Green_Button.BackColor;
            BlueColor = Blue_Button.BackColor;
            string[] PortList = SerialPort.GetPortNames(); //mejorar aqui
            Port_ComboBox.Items.AddRange(PortList);

            string[] BaudRatesList = { "9600", "38400", "57600", "115200" };
            BaudRate_ComboBox.DataSource = BaudRatesList;
        }


        private void OpenSerial_Button_Click(object sender, EventArgs e)
        {
            try
            {
            SerialPortConnection.PortName = Port_ComboBox.Text;
            SerialPortConnection.BaudRate = Convert.ToInt32(BaudRate_ComboBox.Text);
            SerialPortConnection.Open();
            ProgressBar.Value = 100;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void Refresh_Button_Click(object sender, EventArgs e)
        {
            string[] PortList = SerialPort.GetPortNames(); //mejorar aqui
            Port_ComboBox.Items.AddRange(PortList);
        }
        private void CloseSerial_Port_Click(object sender, EventArgs e)
        {
            if (SerialPortConnection.IsOpen)
            {
                try
                {
                    SerialPortConnection.Close();
                    ProgressBar.Value = 0;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void EnableButtons(bool Enabled_Disabled)
        {
            Red_Button.Enabled = Enabled_Disabled;
            Green_Button.Enabled = Enabled_Disabled;
            Blue_Button.Enabled = Enabled_Disabled;
            Reset_Button.Enabled = Enabled_Disabled;
            Start_Button.Enabled = Enabled_Disabled;
            Cube1_Button.Enabled = Enabled_Disabled;
            Cube2_Button.Enabled = Enabled_Disabled;
            Cube3_Button.Enabled = Enabled_Disabled;
            Cube4_Button.Enabled = Enabled_Disabled;
            Cube5_Button.Enabled = Enabled_Disabled;
            Cube6_Button.Enabled = Enabled_Disabled;
            Cube7_Button.Enabled = Enabled_Disabled;
            Cube8_Button.Enabled = Enabled_Disabled;
            Cube9_Button.Enabled = Enabled_Disabled;
            Cube10_Button.Enabled = Enabled_Disabled;
        }

        private void Red_Button_Click(object sender, EventArgs e)
        {
            NewColor = Red_Button.BackColor;
        }

        private void Green_Button_Click(object sender, EventArgs e)
        {
            NewColor = Green_Button.BackColor;
        }

        private void Blue_Button_Click(object sender, EventArgs e)
        {
            NewColor = Blue_Button.BackColor;
        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            Cube1_Button.BackColor = OriginalColor;
            Cube2_Button.BackColor = OriginalColor;
            Cube3_Button.BackColor = OriginalColor;
            Cube4_Button.BackColor = OriginalColor;
            Cube5_Button.BackColor = OriginalColor;
            Cube6_Button.BackColor = OriginalColor;
            Cube7_Button.BackColor = OriginalColor;
            Cube8_Button.BackColor = OriginalColor;
            Cube9_Button.BackColor = OriginalColor;
            Cube10_Button.BackColor = OriginalColor;
        }
        private void Start_Button_Click(object sender, EventArgs e)
        {
            if ((RedPos > 0) && (GreenPos > 0 ) && (BluePos > 0) && (RedPos < 11) && (GreenPos < 11) && (BluePos < 11))
            {
                try
                {
                SerialPortConnection.WriteLine("(" + RedPos.ToString() + "," + GreenPos.ToString() + "," + BluePos.ToString() + ")");
                MessageBox.Show("(" + RedPos.ToString() + "," + GreenPos.ToString() + "," + BluePos.ToString() + ")");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("Favor colocar todos los colores en la piramide de cubos.");
            }
        }

        private void ResetPosition(int NewPosition)
        {
            if (RedColor == NewColor) { RedPos = NewPosition; }
            else if (GreenColor == NewColor) { GreenPos = NewPosition; }
            else if (BlueColor == NewColor) { BluePos = NewPosition; }
        }

        private void ResetPreviousColor()
        {
            if(Cube1_Button.BackColor == NewColor) { Cube1_Button.BackColor = OriginalColor; }
            else if(Cube2_Button.BackColor == NewColor) { Cube2_Button.BackColor = OriginalColor; }
            else if (Cube3_Button.BackColor == NewColor) { Cube3_Button.BackColor = OriginalColor; }
            else if (Cube4_Button.BackColor == NewColor) { Cube4_Button.BackColor = OriginalColor; }
            else if (Cube5_Button.BackColor == NewColor) { Cube5_Button.BackColor = OriginalColor; }
            else if (Cube6_Button.BackColor == NewColor) { Cube6_Button.BackColor = OriginalColor; }
            else if (Cube7_Button.BackColor == NewColor) { Cube7_Button.BackColor = OriginalColor; }
            else if (Cube8_Button.BackColor == NewColor) { Cube8_Button.BackColor = OriginalColor; }
            else if (Cube9_Button.BackColor == NewColor) { Cube9_Button.BackColor = OriginalColor; }
            else if (Cube10_Button.BackColor == NewColor) { Cube10_Button.BackColor = OriginalColor; }
        }

        private void Cube1_Button_Click(object sender, EventArgs e)
        {
            ResetPreviousColor();
            Cube1_Button.BackColor = NewColor;
            ResetPosition(1);
        }

        private void Cube2_Button_Click(object sender, EventArgs e)
        {
            ResetPreviousColor();
            Cube2_Button.BackColor = NewColor;
            ResetPosition(2);
        }
        private void Cube3_Button_Click(object sender, EventArgs e)
        {
            ResetPreviousColor();
            Cube3_Button.BackColor = NewColor;
            ResetPosition(3);
        }

        private void Cube4_Button_Click(object sender, EventArgs e)
        {
            ResetPreviousColor();
            Cube4_Button.BackColor = NewColor;
            ResetPosition(4);
        }

        private void Cube5_Button_Click(object sender, EventArgs e)
        {
            ResetPreviousColor();
            Cube5_Button.BackColor = NewColor;
            ResetPosition(5);
        }

        private void Cube6_Button_Click(object sender, EventArgs e)
        {
            ResetPreviousColor();
            Cube6_Button.BackColor = NewColor;
            ResetPosition(6);
        }

        private void Cube7_Button_Click(object sender, EventArgs e)
        {
            ResetPreviousColor();
            Cube7_Button.BackColor = NewColor;
            ResetPosition(7);
        }

        private void Cube8_Button_Click(object sender, EventArgs e)
        {
            ResetPreviousColor();
            Cube8_Button.BackColor = NewColor;
            ResetPosition(8);
        }

        private void Cube9_Button_Click(object sender, EventArgs e)
        {
            ResetPreviousColor();
            Cube9_Button.BackColor = NewColor;
            ResetPosition(9);
        }

        private void Cube10_Button_Click(object sender, EventArgs e)
        {
            ResetPreviousColor();
            Cube10_Button.BackColor = NewColor;
            ResetPosition(10);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(SerialPortConnection.IsOpen)
            {
                try
                {
                    SerialPortConnection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

    }
}
