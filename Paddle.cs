namespace PlingPong
{
    public class Paddle
    {
        private int _x;
        private int _y;
        private int _xtray;
        private int _xlimit;
        private int _ylimit;
        private Boolean _Trygn = false;
        private Boolean _CT = false;
        public int btMd = 0;

        public Paddle(int ex, int wy, int exl, int wyl, Ball ball)
        {
            _x = ex;
            _y = wy;
            _xlimit = exl;
            _ylimit = wyl;
            _Trygn = ball.Trygn;
            _CT = ball.CT;
        }
        public char[,] Paddledown(char[,] Canvas)
        {
            if (_Trygn == true)
            {
                if (_CT == true)
                {
                    _Trygn = false;
                    Paddledown(Canvas);
                }
                _CT = false;
                if (_y - 1 < 0)
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
            else if (_CT == true)
            {
                _Trygn = false;
                // if (_y + 1 >= 5 || _xtray - 1 < 0)
                // {
                //     return Canvas;
                // }
                _y += 1;
                _xtray -= 1;
                Canvas[_y, _x] = '|';
                Canvas[_y, _x + 1] = '|';
                Canvas[_xtray, _x] = '|';
                Canvas[_xtray, _x + 1] = '|';
                Canvas[_y - 1, _x] = ' ';
                Canvas[_y - 1, _x + 1] = ' ';
                Canvas[_xtray + 1, _x] = ' ';
                Canvas[_xtray + 1, _x + 1] = ' ';


                return Canvas;
            }
            else
            {
                if (_y + 3 >= _ylimit)
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


        }

        // PADDLE UP ****************************************************************************
        public char[,] Paddleup(char[,] Canvas)
        {
            if (_Trygn == true)
            {
                if (_CT == true)
                {
                    _Trygn = false;
                    Paddleup(Canvas);
                }
                _CT = false;
                if (_y + 3 >= _ylimit)
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
            else if (_CT == true)
            {
                // if (_xtray + 1 >= 5 || _y - 1 < 0)
                // {
                //     return Canvas;
                // }
                _y -= 1;
                _xtray += 1;
                Canvas[_y, _x] = '|';
                Canvas[_y, _x + 1] = '|';
                Canvas[_xtray, _x] = '|';
                Canvas[_xtray, _x + 1] = '|';
                Canvas[_y + 1, _x] = ' ';
                Canvas[_y + 1, _x + 1] = ' ';
                Canvas[_xtray - 1, _x] = ' ';
                Canvas[_xtray - 1, _x + 1] = ' ';
                return Canvas;
            }
            else
            {
                if (_y - 1 < 0)
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

        public char[,] botIteration(char[,] Canvas, Ball ball)
        {

            if (btMd == 0)
                return Canvas;
            else
            {
                if (ball.Y == _y)
                {
                    return Canvas;
                }
                else if (ball.Y > _y)
                {
                    return Paddleup(Canvas);
                }
                else
                {
                    return Paddledown(Canvas);
                }
            }
        }


    }
}