using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadSheetEngine;


namespace Spreadsheet_Jillian_Plahn
{
    /// <summary>
    /// Form class creates spreadsheet object. 
    /// </summary>
    public partial class Form1 : Form
    {
        // Spreadsheet object 
        private SpreadsheetClass spreadsheet; 

        /// <summary>
        /// Form will initialize all components and crate intitial spreadsheet. 
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Initialize spreadhseet with 26 columns and 50 rows
            spreadsheet = new SpreadsheetClass(50, 26);

            // Subscribe to CellPropertyChanged event 
            spreadsheet.CellPropertyChanged += Spreadsheet_CellPropertyChanged;

        }

        /// <summary>
        /// This method will load the form and calls the initialize method for the spreadsheet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDataGrid();
        }

        /// <summary>
        /// Cell property changed event. When a cells value changes it is updated in the DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spreadsheet_CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Cell to update: 
            CellClass updateCell = sender as CellClass;

            if (e.PropertyName == "Value")
            {
                if (updateCell != null)
                {
                    // Convert column to an integer
                    char column = updateCell.ColumnIndex;
                    int columnNum = (int)(updateCell.ColumnIndex - 64);

                    // Update the cell.
                    // Set row property and value property. 
                    dataGridView1.Rows[updateCell.RowIndex-1].Cells[columnNum].Value = updateCell.Value;
                }
            }
        }

        /// <summary>
        /// Creates 50 rows and columns A-Z. 
        /// </summary>
        public void InitializeDataGrid()
        {
            // Clear any columns already made 
            dataGridView1.Columns.Clear();

            // Create columns A to Z with code 
            char alphaHeader = 'A';
            for (int i = 0; i < 26; i++, alphaHeader++)
            {
                dataGridView1.Columns.Add(alphaHeader.ToString(), alphaHeader.ToString());
            }

            // Clear any rows made
            dataGridView1.Rows.Clear(); 

            // Create rows 1-50
            for (int i = 1; i <= 50; i++)
            {
                // Add the rows
                dataGridView1.Rows.Add();
                // Add the row headers 
                dataGridView1.Rows[i - 1].HeaderCell.Value = i.ToString(); 
            }
           
        }

        /// <summary>
        /// When user presses demo button the following method will be used.
        /// The demo illustrates the changing cells in the worksheet object triggers a proper UI update.
        /// https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-7.0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void demoButton_Click(object sender, EventArgs e)
        {
            // Random object
            Random rand = new Random();

            // Set the text in 50 random cells
            for (int i = 0; i < 50; i++)
            {
                int randRow = rand.Next(0, 50);

                int randColumn = rand.Next(0, 26);
                // char randColumn = num - 65

                // Set value of cell
                CellClass current = spreadsheet.GetCell(randRow, randColumn);
                current.Text = "Hello World!";
            }

            // Set every cell in column B
            for (int i = 0; i < 50; i++)
            {
                // B is column 1
                CellClass current = spreadsheet.GetCell(i, 1);
                current.Text = "This is cell B" + (i + 1);
            }

            // Set text in cells in A to =B#
            // Every cell in column A will be equal to cell to the right of it in column B
            for (int i = 0; i < 50; i++)
            {
                // Column A is column 0
                CellClass current = spreadsheet.GetCell(i, 0);
                current.Text = "=B" + i;

            }
        }
    }
}
