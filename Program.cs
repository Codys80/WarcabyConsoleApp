namespace WarcabyConsoleApp
{
    internal class Program
    {   //i=x j=y map[x,y]
        static int[,] map = new int[8, 8];
        static bool gameEnd = false;
        //
        static int tura = 1;
        static int playerTurn = 1;
        //
        static int[] move = new int[2];
        static int[] piece = new int[2];
        //
        static int playerOnePieces = 0;
        static int playerTwoPieces = 0;
        static void initializeMap()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    map[x, y] = 0;
                    if ((x == 7 || x == 5) && y % 2 ==0)    { map[x, y] = 1; playerOnePieces++; }
                    if (x == 6 && (y % 2 == 1) )  { map[x, y] = 1; playerOnePieces++; }

                    if ((x == 0 || x ==2 ) && y % 2 == 0) { map[x, y] = 2; playerTwoPieces++; }
                    if (x == 1 && (y % 2 == 1)) { map[x, y] = 2; playerTwoPieces++; }
                }
            }

        }
        static void capturePiece()
        {
            //7-2
            //map[piece[0], piece[1]] = 0;
            //map[move[0], move[1]] = playerTurn;
            map[move[0], move[1]] = 0;
            //if((move[0])
            //playerOnePieces
        }
        static void moveCheck()
        {
            //Console.WriteLine("WprowadŸ wspó³rzêdne ruchu: ");
            //Console.WriteLine("START OF TEST");
            //Console.WriteLine(move[1]);
            //Console.WriteLine(piece[1] + 1);
            //Console.WriteLine("END OF TEST");
            bool validMove = false;
            while (!validMove)
            {
            move[0] = Convert.ToInt32(Console.ReadLine());
            move[1] = Convert.ToInt32(Console.ReadLine());
            switch (playerTurn)
            {
                case 1:

                    //Console.WriteLine(move[0] == piece[0] + 1);
                    //Console.WriteLine(move[0] == piece[0] - 1);
                    //Console.WriteLine(piece[1] == move[1] + 1);
                    //Console.WriteLine(move[1]);
                    if ( (move[1] == piece[1] + 1 || move[1] == piece[1] - 1) && (piece[0] == move[0] + 1) )
                    {
                        validMove = true;
                        if ((map[move[0], move[1]]) == 0)
                        {
                            
                            movePiece();
                        }
                        else if ((map[move[0], move[1]]) == 2)
                        {
                            capturePiece();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawid³owy ruch, wprowadŸ ponownie: ");
                        break;
                    }
                    break;
                case 2:
                    if ((move[1] == piece[1] + 1 || move[1] == piece[1] - 1) && piece[0] == move[0] - 1)
                    {
                        validMove = true;
                        if ((map[move[0], move[1]]) == 0)
                        {
                            movePiece();
                        }
                        else if ((map[move[0], move[1]]) == 1)
                        {
                             capturePiece();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawid³owy ruch, wprowadŸ ponownie: ");
                        break;
                    }
                    break;
                }
            }
        }
        //if ((map[move[0], move[1]]) == 1 || (map[move[0], move[1]]) == 2)
        //            {

        //            }
        static void movePiece()
        {
            map[piece[0], piece[1]] = 0;
            map[move[0], move[1]] = playerTurn; 
        }
        static void displayMap()
        {
            Console.Clear();
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
                Console.Write( x + " | ");
                
                for (int y = 0; y < 8; y++)
                {
                    Console.Write(map[x, y] + "   ");
                }
                Console.WriteLine(string.Empty);
            }
        }
        static void gameProcess()
        {
            Console.WriteLine("Tura gracza: " + playerTurn + " || Numer tury: " + tura);
            Console.Write("WprowadŸ wspó³rzêdne pionka: ");
            //piece[0] = Console.Read().parseInt();
            //piece[1] = Console.Read().parseInt();
            piece[0] = Convert.ToInt32(Console.ReadLine());
            piece[1] = Convert.ToInt32(Console.ReadLine());
            // SPRAWDZIÆ CZY PION JEST WYBRANY
            //if (map[piece[0], piece[1]] != 1)
            //{
            //    Console.WriteLine("Nieprawid³owy wybór pionka, wprowadŸ ponownie: ");
            //    break;
            //}
            Console.Write("WprowadŸ ruch: ");
            moveCheck();
            //Console.WriteLine("TEST INPUT: ");
            //Console.WriteLine(piece[0]);
            //Console.WriteLine(piece[1]);
            //Console.ReadKey();





        }
        static void checkGameEnd()
        {
            if(playerOnePieces == 0 || playerTwoPieces == 0)
            {
                gameEnd = true;
            }
        }
        static void Main(string[] args)
        { 
            initializeMap();
            while(!gameEnd)
            {
                Console.WriteLine("|| WARCABY ||");
                displayMap();
                switch (playerTurn)
                {
                    case 1:
                        gameProcess();
                        checkGameEnd();
                        playerTurn = 2;
                        tura++;
                        break;
                    case 2:
                        gameProcess();
                        checkGameEnd();
                        playerTurn = 1;
                        tura++;
                        break;
                }
            }
        }
    }
}
