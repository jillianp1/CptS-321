﻿using System.ComponentModel;

namespace SpreadSheetEngine
{
    public abstract class CellClass : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private readonly int rowIndex;
        private readonly char columnIndex;
        protected string text;
        protected string value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public CellClass(int row, char column)
        {
            rowIndex = row;
            columnIndex = column;
        }

        /// <summary>
        /// RowINdex getter returns field
        /// </summary>
        public int RowIndex
        {
            get { return rowIndex; }
        }

        /// <summary>
        /// Column Index Getter 
        /// </summary>
        public char ColumnIndex
        {
            get { return columnIndex; }
        }

        /// <summary>
        /// Text getter
        /// </summary>
        public string Text
        {
            get { return text;  }
            set
            {
                if (text != value)
                {
                    text = value;

                    // Notify subscribers that property has changed
                    PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Value getter. Value should be a getter only and only the spreadhseet class is allowed to set. 
        /// 
        /// </summary>
        public string Value
        {
            get { return value; }
        }

        

    }
}