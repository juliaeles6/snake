namespace Snake.Model
{
    public class Snake
    {
        private Tuple<int, int> _head;
        private List<Tuple<int, int>> _tail;
        private int _direction;
        private Tuple<int, int>[] _aux = { new Tuple<int, int>(0, -1), new Tuple<int, int>(-1, 0), new Tuple<int, int>(0, 1), new Tuple<int, int>(1, 0) };

        public event EventHandler GameOver;

        public Tuple<int, int> Head
        {
            get
            {
                return _head;
            }
            private set
            {

            }
        }

        public List<Tuple<int, int>> Tail
        {
            get
            {
                return _tail;
            }
            private set
            {

            }
        }

        public Snake(Tuple<int, int> head)
        {
            _head = head;
            _direction = 0;
            _tail = [Utils.Add(_head, new Tuple<int, int>(0, 2)), Utils.Add(_head, new Tuple<int, int>(0, 1))];
        }

        public void Move(bool grow)
        {
            _tail.Add(_head);

            if (!grow)
            {
                _tail.RemoveAt(0);
            }

            _head = Utils.Add(_head, _aux[_direction]);

            if (_tail.Any(item => item.Equals(_head)))
            {
                GameOver.Invoke(this, EventArgs.Empty);
            }
        }

        private void TurnLeft()
        {
            _direction = _direction - 1;
            if (_direction < 0)
            {
                _direction = 3;
            }
        }

        private void TurnRight()
        {
            _direction = _direction + 1;
            if (_direction > 3)
            {
                _direction = 0;
            }
        }
    }
}