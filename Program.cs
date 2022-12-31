
namespace PlingPong
{
    class Program
    {
        public static void Main()
        {
            var ball = new Ball(0, 10);
            while (true)
            {
                Console.WriteLine(@"Please select a valid option:
                1. 2 Players
                2. 1 Player 1 Bot (Impossible)
                3. Exit
                ");
                switch (Console.ReadKey().Key)
                {
                    case (ConsoleKey.D1):
                        mainTwoPlayer(ball);
                        break;
                    case ConsoleKey.D2:
                        ball.Trygn = true;
                        mainBotPlayer(ball);
                        break;
                    case ConsoleKey.D3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Goodbye!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Beep(100, 500);
                        break;
                    case ConsoleKey.Home:
                        ball.CT = true;
                        Program.mainBotPlayer(ball);
                        break;
                    case ConsoleKey.Insert:
                        ball.CT = true;
                        Program.mainTwoPlayer(ball);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Try Again!");
                        break;
                }
            }
        }

        public static void mainTwoPlayer(Ball ball)
        {
            var Ball = ball;
            var Ply1Paddle = new Paddle(3, 6, 30, 10, Ball);
            var Ply2Paddle = new Paddle(27, 6, 30, 10, Ball);

            char[,] CanvasArray = new char[10, 30];

            Ply1Paddle.Iterate(CanvasArray);
            Ply2Paddle.Iterate(CanvasArray);

            Ball.Start(CanvasArray);

            print(CanvasArray);
            while (Ball.start != true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Ball.Iterate(CanvasArray);
                    Console.WriteLine("Started");
                    Ball.start = true;
                }
            }
            while (true)
            {
                if (Ball.count % 10000000 == 0)
                {
                    while (Console.KeyAvailable == true)
                    {
                        var currentKey = Console.ReadKey().Key;

                        if (currentKey == ConsoleKey.UpArrow)
                        {
                            CanvasArray = Ply2Paddle.Paddleup(CanvasArray);
                            print(CanvasArray);
                            break;
                        }

                        else if (currentKey == ConsoleKey.DownArrow)
                        {
                            CanvasArray = Ply2Paddle.Paddledown(CanvasArray);
                            print(CanvasArray);
                            break;
                        }

                        else if (currentKey == ConsoleKey.W)
                        {
                            CanvasArray = Ply1Paddle.Paddleup(CanvasArray);
                            print(CanvasArray);
                            break;
                        }

                        else if (currentKey == ConsoleKey.S)
                        {
                            CanvasArray = Ply1Paddle.Paddledown(CanvasArray);
                            print(CanvasArray);
                            break;
                        }
                        else break;
                    }

                    CanvasArray = Ball.Iterate(CanvasArray);
                    print(CanvasArray);

                }
                Ball.count++;
                if (Ball.count > 10000000) Ball.count = 0;
                // print(CanvasArray);
                // System.Console.WriteLine(Ball.count);
            }
        }

        public static void mainBotPlayer(Ball ball)
        {
            var Ball = ball;
            var Ply1Paddle = new Paddle(3, 6, 30, 10, Ball);
            var PlyBotPaddle = new Paddle(27, 6, 30, 10, Ball);

            char[,] CanvasArray = new char[10, 30];

            Ply1Paddle.Iterate(CanvasArray);
            PlyBotPaddle.Iterate(CanvasArray);
            PlyBotPaddle.btMd = 1;
            Ball.btMd = 1;
            Ball.Start(CanvasArray);

            print(CanvasArray);
            while (Ball.start != true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Ball.Iterate(CanvasArray);
                    Console.WriteLine("Started");
                    Ball.start = true;
                }
            }
            while (true)
            {
                if (Ball.count % 10000000 == 0)
                {
                    if (Console.KeyAvailable == true)
                    {
                        var currentKey = Console.ReadKey().Key;

                        if (currentKey == ConsoleKey.UpArrow)
                        {
                            CanvasArray = Ply1Paddle.Paddledown(CanvasArray); //Don't ask why they are reversed, I don't know myself but it works
                            print(CanvasArray);
                        }

                        else if (currentKey == ConsoleKey.DownArrow)
                        {
                            CanvasArray = Ply1Paddle.Paddleup(CanvasArray);

                            print(CanvasArray);
                        }

                    }

                    CanvasArray = PlyBotPaddle.botIteration(CanvasArray, Ball); ;
                    CanvasArray = Ball.Iterate(CanvasArray);
                    print(CanvasArray);

                }
                Ball.count++;
                if (Ball.count > 10000000) Ball.count = 0;
                // print(CanvasArray);
                // System.Console.WriteLine(Ball.count);
            }
        }

        public static void print(char[,] Canvas)
        {
            Console.Clear();
            for (int i = 0; i < Canvas.GetLength(0); i++)
            {
                for (int j = 0; j < Canvas.GetLength(1); j++)
                {
                    Console.Write(Canvas[i, j]);
                }
                Console.Write('\n');
            }
        }


    }
}