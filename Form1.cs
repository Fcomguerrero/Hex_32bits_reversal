using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hex_32bits_reversal
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private string hex2binary(string hexvalue)
        {
            string binaryval = "";
            binaryval = Convert.ToString(Convert.ToInt32(hexvalue, 16), 2);
            return binaryval;
        }
        public static string Reverse(string s)
        {                        
            int numCaracteres = s.Length;
            if (numCaracteres < 32)
            {
                for (int var = s.Length; var < 32; ++var)
                {
                    s = "0" + s;    //si el numero tiene menos de 32 bits agregamos ceros a la izquierda
                }
            }                     
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private string binary2hex(string hexvalue)
        {
            string binaryval = "";
            binaryval = Convert.ToString(Convert.ToInt32(hexvalue, 2), 16);
            return binaryval;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToInt16(Keys.Enter))
                {
                    String hexstring = textBox1.Text.ToString();                     
                    String res = binary2hex(Reverse(hex2binary(hexstring)));                    
                    textBox2.Text = res.ToUpper().ToString();
                    e.Handled = true;
                    textBox1.Text = "";
                }
                if (e.KeyChar == Convert.ToInt16(Keys.Escape))
                {
                    textBox1.Text = "";
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//displaying the error in a message box
            }
        }
    }
}
