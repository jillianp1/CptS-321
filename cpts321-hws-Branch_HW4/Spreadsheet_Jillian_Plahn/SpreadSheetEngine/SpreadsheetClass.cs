using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetEngine
{
    /// <summary>
    /// Creates cells in the spreadhseet. Stores 2D array of cells in Spreadsheet. 
    /// </summary>
    public class SpreadsheetClass
    {
        // Cell property changed event handler
        public event PropertyChangedEventHandler CellPropertyChanged = delegate { };

        /// <summary>
        /// 2D array of cells
        /// </summary>
        public CellClass[,] cells;

        /// <summary>
        /// Column and row count properies
        /// </summary>
        private int columnCount;
        private int rowCount;

        /// <summary>
        /// Returns number of columns in spreadsheet
        /// </summary>
        public int ColumnCount
        {
            get { return columnCount; }
            set { columnCount= value; }
        }

        /// <summary>
        /// Returns number of rows in spreadhseet
        /// </summary>
        public int RowCount
        {
            get { return rowCount; }
            set { rowCount= value; }
        }

        /// <summary>
        /// Constructor for SpreadSheet class
        /// </summary>
        /// <param name="numColumns"
        /// <param name="numRows"
        public SpreadsheetClass(int numRows, int numColumns) 
        {

            // Initialize array
            cells = new CellClass[numRows, numColumns];

            // Loop through each cell
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    // Convert j column to char 
                    char letterJ = (char)(j + 64);

                    // Create new cell
                    cells[i, j] = new BaseCell(i + 1, letterJ);

                    // Subscribe to cells property changed event 
                    cells[i, j].PropertyChanged += PropertyChanged;
                }
            }

            rowCount = numRows;
            columnCount = numColumns;
        }

        /// <summary>
        /// This will set the values of cells. Creates base cells.
        /// Inherits from the cell class
        /// </summary>
        private class BaseCell: CellClass
        {
            /// <summary>
            /// Constructor for BaseCell.
            /// </summary>
            /// <param name="row"></param>
            /// <param name="column"></param>
            public BaseCell(int row, char column) : base(row, column)
            {

            }
            public void SetValue(string newValue)
            {
                value = newValue;
                PropertyChanged("Value");
            }
        }

        /// <summary>
        /// This is the cellPropertyChanged event 
        /// Property changed method this updates the cells value. 
        /// It takes the value from the cell and copies it to the other cells value. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PropertyChanged (object sender, PropertyChangedEventArgs e)
        {
            // If text property changed
            if (e.PropertyName == "Text")
            {
                BaseCell baseCell = sender as BaseCell;

                // Check if the text of the doesnt cell starts with =
                if (baseCell.Text[0] != '=')
                {
                    // Then value is set to the text 
                    baseCell.SetValue(baseCell.Text);
                }
                // Ptherwise we need to update the cells value to cpmpute the formula that comes after = 
                else
                {
                    // Get column char and convert to int
                    char columnChar = baseCell.Text[1];
                    int columnNum = columnChar - 65;

                    // Get the row and convert to an int
                    // Row is the rest of the text 
                    // https://learn.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-7.0

                    string rowString = baseCell.Text.Substring(2);
                    int rowNum = Int32.Parse(rowString);

                    // Get the cell that we will copy from
                    CellClass temp = GetCell(rowNum, columnNum);
                    //string newValue = cells[rowNum, columnNum].Value;

                    // Set the value to value of the cell
                    baseCell.SetValue(temp.Text);
                }
            }

            // Notify subscribers that this cell changed 
            CellPropertyChanged(sender, new PropertyChangedEventArgs("Value"));
        }

        /// <summary>
        /// GetCell method that returns the cell at the given column and row indexes
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public CellClass GetCell(int rowIndex, int columnIndex)
        {
            if (cells[rowIndex,columnIndex] == null)
            {
                return null; 
            }   
            else
            {
                return cells[rowIndex, columnIndex];
            }
        }


    }
}
