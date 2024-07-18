namespace Snake.Model
{
    public class Table
    {
        private Snake _snake;
        private Tuple<int, int> _apple;
        private int _score;
        private Random _random;

        public event EventHandler<int> GameOver;

        public Table()
        {
            _random = new Random();
            // _random.Next(0, 10);
            _apple = new Tuple<int, int>(_random.Next(0, 10), _random.Next(0, 10));
            _snake = new Snake(new Tuple<int, int>(_random.Next(0, 10), _random.Next(0, 10)));
            _snake.GameOver += OnGameOver;

            _score = 0;
        }

        public void MoveSnake()
        {
            //_snake.Move();
            if (_snake.Head.Equals(_apple))
            {
                _score = _score + 1;
                _snake.Move(true);
                GenerateApple();
            }
            else
            {
                _snake.Move(false);
            }
        }

        private void GenerateApple()
        {
            _apple = new Tuple<int, int>(_random.Next(0, 10), _random.Next(0, 10));
            while (_apple.Equals(_snake.Head) || _snake.Tail.Any(item => item.Equals(_apple)))
            {
                _apple = new Tuple<int, int>(_random.Next(0, 10), _random.Next(0, 10));
            }
        }

        private void OnGameOver(object? sender, EventArgs e)
        {
            GameOver.Invoke(this, _score);
        }
    }
}