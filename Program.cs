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

                    if ((x == 0 || x ==2 ) && y % 2 == 1) { map[x, y] = 2; playerTwoPieces++; }
                    if (x == 1 && (y % 2 == 0)) { map[x, y] = 2; playerTwoPieces++; }
                }
            }

        }
        static void capturePiece()
        {
            Console.WriteLine("Bicie!");
            //7-2
            //map[piece[0], piece[1]] = 0;
            //map[move[0], move[1]] = playerTurn;
            //map[move[0], move[1]] = 0;

            if (move[1] == piece[1] + 1) // ruch w prawo
            {
                if (playerTurn == 1)
                {
                    map[move[0] - 1, move[1] + 1] = 0; // -/+?
                    map[move[0] - 2, move[1] + 2] = 1;
                    Console.WriteLine("p1 w prawo!");
                    Console.WriteLine("KORDY: " + (move[0] - 2)+ " " + (move[1] + 2) );
                    playerTwoPieces--;
                }
                else if (playerTurn == 2)
                {
                    map[move[0] + 1, move[1] + 1] = 0;
                    playerOnePieces--;
                }
            }
            else if (move[1] == piece[1] - 1) // ruch w lewo
            {
                if (playerTurn == 1)
                {
                    Console.WriteLine("p1 w lewo!");
                    map[move[0] - 1, move[1] - 1] = 0;
                    playerTwoPieces--;
                }
                else if (playerTurn == 2)
                {
                    map[move[0] + 1, move[1] - 1] = 0;
                    playerOnePieces--;
                }
            }
        }
        static void moveCheck()
        {
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
                            //validMove = true;
                        if (map[move[0], move[1]] == playerTurn) { validMove = false; Console.WriteLine("Nieprawid³owy ruch, jest tam twój pionek, wprowadŸ ponownie: "); break; }
                        if ((map[move[0], move[1]]) == 0)
                        {
                            validMove = true;
                            movePiece();
                        }
                        else if ((map[move[0], move[1]]) == 2)
                        {
                            validMove = true;
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
                        
                        if (map[move[0], move[1]] == playerTurn) { validMove = false; Console.WriteLine("Nieprawid³owy ruch, jest tam twój pionek, wprowadŸ ponownie: "); break; }
                        if ((map[move[0], move[1]]) == 0)
                        {
                            validMove = true;
                            movePiece();
                        }
                        else if ((map[move[0], move[1]]) == 1)
                        {
                            validMove = true;
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
        static void movePiece()
        {
            map[piece[0], piece[1]] = 0;
            map[move[0], move[1]] = playerTurn;
            piece[0] = 0;
            piece[1] = 0;
            move[0] = 0;
            move[1] = 0;
        }
        static void displayMap()
        {
            //Console.Clear();
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
            bool validPiece = false;
            //piece[0] = Convert.ToInt32(Console.ReadLine());
            //piece[1] = Convert.ToInt32(Console.ReadLine());
            //if ( map[piece[0], piece[1]] == playerTurn && (map[piece[0] + 1, piece[1]] != playerTurn || map[piece[0] - 1, piece[1]]  != playerTurn) ) validPiece = true;
            while (!validPiece)
            {
                piece[0] = Convert.ToInt32(Console.ReadLine());
                piece[1] = Convert.ToInt32(Console.ReadLine());
                if (map[piece[0], piece[1]] == playerTurn && (map[piece[0] + 1, piece[1]] != playerTurn || map[piece[0] - 1, piece[1]] != playerTurn)) { validPiece = true; break; }
                Console.WriteLine("Nieprawid³owy wybór pionka, wprowadŸ ponownie: ");
            }
            Console.Write("WprowadŸ ruch: ");
            moveCheck();
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
            map[7, 0] = 0; // test bicia
            map[7, 1] = 1;
            map[5, 2] = 2;
            while (!gameEnd)
            {
                Console.WriteLine('\t'+"|| WARCABY ||");
                displayMap();
                Console.WriteLine("Pionki gracza 1: " + playerOnePieces);
                Console.WriteLine("Pionki gracza 2: " + playerTwoPieces);
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
