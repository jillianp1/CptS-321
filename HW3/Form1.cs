// <copyright file="Form1.cs" company="Jillian Plahn 11713440">
// Copyright (c) Jillian Plahn. All rights reserved.
// </copyright>

using System;
using System.IO;

namespace HW3
{
    /// <summary>
    /// Form class with methods for when buttons are clicked.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Will Initialize components.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// When the save file option is selected by user.
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.savefiledialog?redirectedfrom=MSDN&view=windowsdesktop-7.0.
        /// </summary>
        /// <param name="sender"> sender param. </param>
        /// <param name="e"> e paramater. </param>
        private void SaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Make SaveFileDialog object for saving
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            // If user selects OK
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Open file user entered
                using (StreamWriter outfile = new StreamWriter(saveFileDialog1.FileName))
                {
                    // Write to that file
                    outfile.Write(this.textBox1.Text);
                }
            }
        }

        /// <summary>
        /// Generic loading function
        /// https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader.readtoend?redirectedfrom=MSDN&view=net-7.0#System_IO_TextReader_ReadToEnd.
        /// </summary>
        /// <param name="sr"> textReader parameter.
        /// </param>
        private void LoadText(TextReader sr)
        {
            // Reads all text through textreader and then prints output to text box
            this.textBox1.Text = sr.ReadToEnd();
        }

        /// <summary>
        /// If load from file is clicked from menu
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-7.0.
        /// </summary>
        /// <param name="sender"> sender param. </param>
        /// <param name="e"> e parameter. </param>
        private void LoadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // New open file dialog to load
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            // If user hits OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    this.LoadText(sr);
                }
            }
        }

        /// <summary>
        /// If user selects load first 50 fibonacci numbers.
        /// </summary>
        /// <param name="sender"> sender parameter.</param>
        /// <param name="e"> e parameter. </param>
        private void LoadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create new FibonacciTextReader object with 50 lines for first 50 fibonacci numbers
            FibonacciTextReader fiftyFib = new FibonacciTextReader(50);

            // Load the text
            this.LoadText(fiftyFib);
        }

        /// <summary>
        /// If user selects load first 100 fibonacci numbers.
        /// </summary>
        /// <param name="sender"> Sender parameter. </param>
        /// <param name="e"> e parameter. </param>
        private void LoadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create new FibonacciTextReader object with 50 lines for first 50 fibonacci numbers
            FibonacciTextReader hundredFib = new FibonacciTextReader(100);

            // Load the text
            this.LoadText(hundredFib);
        }
    }
}