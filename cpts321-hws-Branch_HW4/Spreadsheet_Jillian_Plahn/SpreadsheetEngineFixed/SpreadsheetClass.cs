// <copyright file="SpreadsheetClass.cs" company="Jillian Plahn">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadSheetEngine
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Creates cells in the spreadhseet. Stores 2D array of cells in Spreadsheet.
    /// </summary>
    public class SpreadsheetClass
    {
        // Cell property changed event handler
        public event PropertyChangedEventHandler CellPropertyChanged = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetClass"/> class.
        /// Constructor for SpreadSheet class.
        /// </summary>
        /// <param name="numColumns" >Number of columns. </param>
        /// <param name="numRows" >Number of rows. </param>
        public SpreadsheetClass(int numRows, int numColumns)
        {
            // Initialize array
            this.cells = new CellClass[numRows, numColumns];

            // Loop through each cell
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    // Convert j column to char
                    char letterJ = (char)(j + 64);

                    // Create new cell
                    this.cells[i, j] = new BaseCell(i + 1, letterJ);

                    // Subscribe to cells property changed event
                    this.cells[i, j].PropertyChanged += this.CellPropertyChanged1;
                }
            }

            this.rowCount = numRows;
            this.columnCount = numColumns;
        }

        /// <summary>
        /// 2D array of cells.
        /// </summary>
        private CellClass[,] cells;

        /// <summary>
        /// Column and row count properies.
        /// </summary>
        private int columnCount;
        private int rowCount;

        /// <summary>
        /// Gets or sets number of columns in spreadsheet.
        /// </summary>
        public int ColumnCount
        {
            get { return this.columnCount; }
            set { this.columnCount = value; }
        }

        /// <summary>
        /// Gets or sets number of rows in spreadhseet.
        /// </summary>
        public int RowCount
        {
            get { return this.rowCount; }
            set { this.rowCount = value; }
        }

        /// <summary>
        /// This will set the values of cells. Creates base cells.
        /// Inherits from the cell class.
        /// </summary>
        private class BaseCell : CellClass
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BaseCell"/> class.
            /// Constructor for base cell.
            /// </summary>
            /// <param name="row"> row param. </param>
            /// <param name="column">column parameter. </param>
            public BaseCell(int row, char column)
                : base(row, column)
            {
            }
        }

        /// <summary>
        /// This is the cellPropertyChanged event
        /// Property changed method this updates the cells value.
        /// It takes the value from the cell and copies it to the other cells value.
        /// </summary>
        /// <param name="sender"> Sender parameter. </param>
        /// <param name="e"> e parameter. </param>
        public void CellPropertyChanged1(object sender, PropertyChangedEventArgs e)
        {
            // If text property changed
            if (e.PropertyName == "Text")
            {
                BaseCell baseCell = sender as BaseCell;

                // Check if the text of the doesnt cell starts with =
                if (baseCell.Text[0] != '=')
                {
                    // Then value is set to the text
                    baseCell.Value = baseCell.Text;
                }

                // Otherwise we need to update the cells value to compute the formula that comes after =
                else
                {
                    // Get column char and convert to int
                    char columnChar = baseCell.Text[1];
                    int columnNum = columnChar - 65;

                    // Get the row and convert to an int
                    // Row is the rest of the text
                    // https://learn.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-7.0
                    string rowString = baseCell.Text.Substring(2);
                    int rowNum = int.Parse(rowString);

                    // Get the cell that we will copy from
                    CellClass temp = this.GetCell(rowNum, columnNum);

                    // Make sure not null.
                    if (temp != null)
                    {
                        // Set value to text of temp cell.
                        baseCell.Value = temp.Text;
                    }
                    else
                    {
                        baseCell.Value = baseCell.Text;
                    }
                }
            }

            // Notify subscribers that this cell changed.
            this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Value"));
        }

        /// <summary>
        /// GetCell method that returns the cell at the given column and row indexes.
        /// </summary>
        /// <param name="rowIndex"> Index of row. </param>
        /// <param name="columnIndex">Index of column. </param>
        /// <returns> Returns a cell. </returns>
        public CellClass GetCell(int rowIndex, int columnIndex)
        {
            if (this.cells[rowIndex, columnIndex] == null)
            {
                return null;
            }
            else
            {
                return this.cells[rowIndex, columnIndex];
            }
        }
    }
}
