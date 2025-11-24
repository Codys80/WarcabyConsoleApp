namespace WarcabyConsoleApp
{
    internal class Program
    {   //i=x j=y
        static int[,] map = new int[8, 8];
        bool gameEnd = false;
        int playerTurn = 1;
        static void initializeMap()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    map[x, y] = 0;
                    if (x == 7 && y % 2 ==0)    { map[x, y] = 1; }
                    if (x == 6 && (y%2 == 1) )  { map[x, y] = 1; }
                    if (x == 5 && y % 2 == 0)   { map[x, y] = 1; }

                    if (x == 0 && y % 2 == 0) { map[x, y] = 2; }
                    if (x == 1 && (y % 2 == 1)) { map[x, y] = 2; }
                    if (x == 2 && y % 2 == 0) { map[x, y] = 2; }
                }
            }

        }
        void movePiece(int player, int piece)
        {

        }
        static void displayMap()
        {
            Console.Write("   ");
            for (int y = 0; y < 8; y++)
            {
                Console.Write(" "+y +"  ");
            }
            Console.WriteLine(string.Empty);
            for (int y = 0; y < 34; y++)
            {
                Console.Write("_");
            }
            Console.WriteLine(string.Empty);
            for (int x = 0; x < 8; x++)
            {
                Console.Write(x+" | ");
                
                for (int y = 0; y < 8; y++)
                {
                    Console.Write(map[x, y] + "   ");
                }
                Console.WriteLine(string.Empty);
            }
        }
        static void Main(string[] args)
        {
            initializeMap();
            displayMap();
            //Console.WriteLine("a, World!");
        }
    }
}
