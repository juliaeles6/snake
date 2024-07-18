using System.Windows.Media;

namespace Snake.ViewModel
{
    public class Field : ViewModelBase
    {
        private Brush _color;
        private int _row;
        private int _column;

        public Brush Color
        {
            get
            {
                return _color;
            }
            private set
            {
                _color = value;
                // OnPropertyChanged("Color");
                OnPropertyChanged(nameof(Color));
            }
        }

        public int Row
        {
            get
            {
                return _row;
            }
            private set
            {
                _row = value;
                OnPropertyChanged(nameof(Row));
            }
        }

        public int Column
        {
            get
            {
                return _column;
            }
            private set
            {
                _column = value;
                OnPropertyChanged(nameof(Column));
            }
        }

        public Field(Brush color, int row, int column)
        {
            Color = color;
            Row = row;
            Column = column;
        }
    }
}
