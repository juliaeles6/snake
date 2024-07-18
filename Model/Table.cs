namespace Snake.Model
{
    public class Table
    {
        private Snake _snake;
        private Tuple<int, int> _apple;
        private int _score;
        private Random _random;

        public event EventHandler<int> GameOver;

        public Snake Snake
        {
            get
            {
                return _snake;
            }
            private set
            {

            }
        }

        public Tuple<int, int> Apple
        {
            get
            {
                return _apple;
            }
            private set
            {

            }
        }

        public int Score
        {
            get
            {
                return _score;
            }
            private set
            {

            }
        }

        public Table()
        {
            _random = new Random();
            // _random.Next(0, 10);
            _apple = new Tuple<int, int>(_random.Next(0, 10), _random.Next(0, 10));
            _snake = new Snake(new Tuple<int, int>(_random.Next(0, 10), _random.Next(0, 10)));
            _snake.GameOver += OnGameOver;

            _score = 0;
        }

        public void Turn(int dir)
        {
            _snake.Turn(dir);
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