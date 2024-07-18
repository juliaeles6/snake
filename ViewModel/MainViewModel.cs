using Snake.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace Snake.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Table _table;
        private System.Timers.Timer _timer;
        private System.Timers.Timer _timerLabel;
        private DateTime _start;
        private int[] _intervals = { 1500, 1000, 750 };

        public string ScoreLabel
        {
            get
            {
                return "Score: " + _table.Score;
            }
            private set
            {

            }
        }

        public string TimeLabel
        {
            get
            {
                return "Time: " + (DateTime.Now - _start).ToString("mm\\:ss");
            }
            private set
            {

            }
        }

        public DelegateCommand NewGame { get; private set; }

        public DelegateCommand KeyPressedCommand { get; private set; }

        public ObservableCollection<Field> GameTable { get; private set; }

        public MainViewModel()
        {
            _table = new Table();
            _timer = new System.Timers.Timer();

            NewGame = new DelegateCommand(param => MakeGame(int.Parse(param.ToString())));
            KeyPressedCommand = new DelegateCommand(param => _table.Turn(int.Parse(param.ToString())));

            _start = DateTime.Now;

            _timerLabel = new System.Timers.Timer(1000);
            _timerLabel.Start();
            _timerLabel.Elapsed += UpdateLabel;
        }

        private void MakeGame(int level)
        {
            _table = new Table();
            _table.GameOver += OnGameOver;

            _start = DateTime.Now;

            _timer = new System.Timers.Timer(_intervals[level]);
            _timer.Elapsed += OnElapsed;

            _timer.Start();
        }

        private void UpdateLabel(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(TimeLabel));
        }

        private void OnElapsed(object? sender, EventArgs e)
        {
            _table.MoveSnake();
            OnPropertyChanged(nameof(ScoreLabel));
            RefreshTable();
        }

        private void RefreshTable()
        {
            GameTable = new ObservableCollection<Field>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Tuple<int, int> pos = new Tuple<int, int>(i, j);
                    Brush brush = Brushes.White;

                    if (pos.Equals(_table.Snake.Head))
                    {
                        brush = Brushes.DeepSkyBlue;
                    }
                    else if (_table.Snake.Tail.Any(item => item.Equals(pos)))
                    {
                        if ((i + j) % 2 == 0)
                        {
                            brush = Brushes.LightSkyBlue;
                        }
                        else
                        {
                            brush = Brushes.SkyBlue;
                        }
                    }
                    else if (pos.Equals(_table.Apple))
                    {
                        brush = Brushes.Red;
                    }

                    GameTable.Add(new Field(brush, i, j));
                }
            }

            OnPropertyChanged(nameof(GameTable));
        }

        private void OnGameOver(object? sender, int e)
        {
            _timer.Stop();
            MessageBox.Show("Your score: " + e, "Game Over", MessageBoxButton.OK);
        }
    }
}