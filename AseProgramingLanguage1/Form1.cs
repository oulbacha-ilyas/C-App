﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AseProgramingLanguage1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            
            Console.WriteLine("key down");
            if (e.KeyCode==Keys.Enter)
            {
                Console.WriteLine("ENTER IS PRESSED");
            }
        }
    }
}
