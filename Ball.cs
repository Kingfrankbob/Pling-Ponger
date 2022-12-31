namespace PlingPong
{
    public class Ball
    {
        private int _x;
        private int _y;
        private int _ymin;
        private int _ymax;
        private int _stx;
        private int _sty;
        private string _momentum = "";
        //public string debug = "";
        public Boolean start = false;
        public Int64 count = 0;
        public Boolean Trygn = false;
        public Boolean CT = false;
        private int _prevx;
        private int _prevy;
        public Ball(int ymini, int ymaxi)
        {
            _x = 15;
            _y = 5;
            _stx = _x;
            _sty = _y;
            _ymin = ymini;
            _ymax = ymaxi;
            var rnd = new Random();
            switch (rnd.Next(1, 4))
            {
                case 1:
                    _momentum = "LU";
                    break;
                case 2:
                    _momentum = "LD";
                    break;
                case 3:
                    _momentum = "RU";
                    break;
                case 4:
                    _momentum = "RD";
                    break;
            }
        }
        private void Check(char[,] Canvas, int x, int y)
        {
            try
            {
                //debug = (Canvas[y, x + 2] + "," + Canvas[y, x - 2]);
                if (y - 1 < _ymin)
                {
                    Bounce(1);
                    return;
                }
                if (y + 2 > _ymax)
                {
                    Bounce(2);
                    return;
                }
                if (Canvas[y, x + 2] == '|')
                {
                    Bounce(3);
                    return;
                }
                if (Canvas[y, x - 2] == '|')
                {
                    Bounce(4);
                    return;
                }
            }
            catch (Exception)
            {
                if (_x <= 0)
                    Console.WriteLine("Player 2 Wins!");
                else
                    Console.WriteLine("Player 1 Wins!");
                _x = _stx;
                _y = _sty;
                start = false;
                restart(this);
            }
        }
        public char[,] Iterate(char[,] Canvas)
        {
            _prevx = _x;
            _prevy = _y;
            Check(Canvas, _x, _y);
            switch (_momentum)
            {
                case "LU":
                    Check(Canvas, _x, _y);
                    _x -= 1;
                    _y -= 1;
                    break;
                case "LD":
                    Check(Canvas, _x, _y);
                    _x -= 1;
                    _y += 1;
                    break;
                case "RU":
                    Check(Canvas, _x, _y);
                    _x += 1;
                    _y -= 1;
                    break;
                case "RD":
                    Check(Canvas, _x, _y);
                    _x += 1;
                    _y += 1;
                    break;
            }

            Canvas[_y, _x] = '+';
            Canvas[_prevy, _prevx] = ' ';
            return Canvas;
        }
        public char[,] Start(char[,] Canvas)
        {
            Canvas[_y, _x] = '+';
            return Canvas;
        }
        private void Bounce(int Case)
        {
            switch (Case)
            {
                case 1:
                    if (_momentum == "LU")
                        _momentum = "LD";
                    if (_momentum == "RU")
                        _momentum = "RD";
                    break;
                case 2:
                    if (_momentum == "LD")
                        _momentum = "LU";
                    if (_momentum == "RD")
                        _momentum = "RU";
                    break;
                case 3:
                    if (_momentum == "RD")
                        _momentum = "LD";
                    if (_momentum == "RU")
                        _momentum = "LU";
                    break;
                case 4:
                    if (_momentum == "LU")
                        _momentum = "RU";
                    if (_momentum == "LD")
                        _momentum = "RD";
                    break;

            }
        }
        public static void restart(Ball ball)
        {
            Console.WriteLine(@"Please select a valid option:
                1. Restart
                2. Try Again
                3. Replay
                4. Exit
                ");
            switch (Console.ReadKey().Key)
            {
                case (ConsoleKey.D1):
                    Program.main(ball);
                    break;
                case ConsoleKey.D2:
                    ball.Trygn = true;
                    Program.main(ball);
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Sorry thats not possible atm!");
                    restart(ball);
                    break;
                case ConsoleKey.D4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Goodbye!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Beep(100, 500);
                    break;
                case ConsoleKey.Insert:
                    ball.CT = true;
                    Program.main(ball);
                    break;
                default:
                    Console.WriteLine("Try Again!");
                    restart(ball);
                    break;
            }
        }
    }
}