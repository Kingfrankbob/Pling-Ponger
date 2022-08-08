
namespace PlingPong
{
    class Program
    {
        public static void Main()
        {

            var Ply1Paddle = new Paddle(3, 2, 30, 10);
            var Ply2Paddle = new Paddle(27, 2, 30, 10);

            var Ball = new Ball(0, 10);

            char[,] CanvasArray = new char[10, 30];

            Ply1Paddle.Iterate(CanvasArray);
            Ply2Paddle.Iterate(CanvasArray);

            Ball.Start(CanvasArray);

            print(CanvasArray);
            while (true)
            {
                while (Ball.start != true)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Ball.Iterate(CanvasArray);
                        Console.WriteLine("Started");
                        Ball.start = true;
                    }
                }
                if (Console.ReadKey().Key == ConsoleKey.UpArrow)
                {
                    CanvasArray = Ply2Paddle.Paddleup(CanvasArray);
                    print(CanvasArray);
                }

                if (Console.ReadKey().Key == ConsoleKey.DownArrow)
                {
                    CanvasArray = Ply2Paddle.Paddledown(CanvasArray);
                    print(CanvasArray);
                }

                if (Console.ReadKey().Key == ConsoleKey.W)
                {
                    CanvasArray = Ply1Paddle.Paddleup(CanvasArray);
                    print(CanvasArray);
                }

                if (Console.ReadKey().Key == ConsoleKey.S)
                {
                    CanvasArray = Ply1Paddle.Paddledown(CanvasArray);
                    print(CanvasArray);
                }

                Ball.Iterate(CanvasArray);
                print(CanvasArray);
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