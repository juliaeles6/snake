namespace Snake.Model
{
    public class Utils
    {
        public static Tuple<int, int> Add(Tuple<int, int> a, Tuple<int, int> b)
        {
            int ax = a.Item1 + b.Item1;
            int ay = a.Item2 + b.Item2;

            if (ax < 0)
            {
                ax = 9;
            }

            if (ax > 9)
            {
                ax = 0;
            }

            if (ay < 0)
            {
                ay = 9;
            }

            if (ay > 9)
            {
                ay = 0;
            }

            return new(ax, ay);
        }
    }
}
