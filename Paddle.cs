namespace PlingPong
{
    public class Paddle
    {
        private int _x;
        private int _y;
        private int _xlimit;
        private int _ylimit;

        public Paddle(int ex, int wy, int exl, int wyl)
        {
            _x = ex;
            _y = wy;
            _xlimit = exl;
            _ylimit = wyl;
        }
        public char[,] Paddledown(char[,] Canvas)
        {
            if(_y + 3 >= _ylimit)
            {
                return Canvas;
            }
            _y += 1;
            Canvas[_y, _x] = '|';
            Canvas[_y, _x + 1] = '|';
            Canvas[_y + 1, _x] = '|';
            Canvas[_y + 1, _x + 1] = '|';
            Canvas[_y - 1, _x] = ' ';
            Canvas[_y - 1, _x + 1] = ' ';
            return Canvas;
        }
        public char[,] Paddleup(char[,] Canvas)
        {
            if(_y - 1 < 0)
            {
                return Canvas;
            }
            _y -= 1;
            Canvas[_y, _x] = '|';
            Canvas[_y, _x + 1] = '|';
            Canvas[_y + 1, _x] = '|';
            Canvas[_y + 1, _x + 1] = '|';
            Canvas[_y + 2, _x] = ' ';
            Canvas[_y + 2, _x + 1] = ' ';
            return Canvas;
        }
        public char[,] Iterate(char[,] Canvas)
        {

            Canvas[_y, _x] = '|';
            Canvas[_y, _x + 1] = '|';
            Canvas[_y + 1, _x] = '|';
            Canvas[_y + 1, _x + 1] = '|';
            Canvas[_y + 2, _x] = ' ';
            Canvas[_y + 2, _x + 1] = ' ';
            return Canvas;
        }


    }
}