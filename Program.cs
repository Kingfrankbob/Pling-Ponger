
namespace PlingPong
{
    class Program
    {
        public static void Main()
        {
            var ball = new Ball(0, 10);
            main(ball);
            Ball.restart(ball);
        }

        public static void main(Ball ball)
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