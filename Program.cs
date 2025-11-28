namespace WarcabyConsoleApp
{
    internal class Program
    {   //i=x j=y map[x,y]
        static string systemMessage = "Rozpoczyna siê gra!";
        static int[,] map = new int[9, 9];
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
            if (move[1] == piece[1] + 1) // ruch w prawo
            {
                if (playerTurn == 1)
                {
                    if (map[move[0] - 1, move[1] + 1] != 0) { systemMessage = "Bicie nie mo¿liwe P1 P"; displayMap(); }
                    else
                    {
                        map[piece[0] , piece[1]] = 0;
                        map[move[0], move[1]] = 0;
                        map[move[0] - 1, move[1] + 1] = playerTurn;
                        playerTwoPieces--;
                        playerTurn = 2;
                        tura++;
                    }
                }
                else if (playerTurn == 2)
                {
                    if (map[move[0] + 1, move[1] - 1] != 0) { systemMessage = "Bicie nie mo¿liwe P2 P"; displayMap(); }
                    else
                    {
                        map[piece[0], piece[1]] = 0;
                        map[move[0], move[1]] = 0;
                        map[move[0] + 1, move[1] - 1] = playerTurn;
                        playerOnePieces--;
                        playerTurn = 1;
                        tura++;
                    }
                }
            }
            else if (move[1] == piece[1] - 1) // ruch w lewo
            {
                if (playerTurn == 1)
                {
                    if (map[move[0] - 1, move[1] + 1] != 0) { systemMessage = "Bicie nie mo¿liwe P1 L"; displayMap(); }
                    else
                    {
                        map[piece[0], piece[1]] = 0;
                        map[move[0] - 1, move[1] - 1] = 0;
                        map[move[0], move[1]] = 0;
                        map[move[0] - 1, move[1] + 1] = playerTurn;
                        playerTwoPieces--;
                        playerTurn = 2;
                        tura++;
                    }
                }
                else if (playerTurn == 2)
                {
                    if (map[move[0] + 1, move[1] - 1] != 0) { systemMessage = "Bicie nie mo¿liwe P2 L"; displayMap(); }
                    else
                    {
                        map[piece[0], piece[1]] = 0;
                        map[move[0], move[1]] = 0;
                        map[move[0] + 1, move[1] - 1] = playerTurn;
                        playerOnePieces--;
                        playerTurn = 1;
                        tura++;
                    }
                }
            }
        }
        static void moveCheck()
        {
            bool validMove = false;
            //while (!validMove)
            //{
                for(int i = 0; i<2; i++)
                {
                    ConsoleKeyInfo UserInput = Console.ReadKey();
                    if (char.IsDigit(UserInput.KeyChar))
                    {
                        move[i] = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                        Console.Write(" ");
                    }
                    else
                    {
                        move[0] = 0;  // Else we assign a default value
                    }
                }
                Console.WriteLine(string.Empty);
                switch (playerTurn)
            {
                case 1:
                    if ( (move[1] == piece[1] + 1 || move[1] == piece[1] - 1) && (piece[0] == move[0] + 1) )
                    {
                        if (map[move[0], move[1]] == playerTurn) { validMove = false; systemMessage = "Nieprawid³owy ruch, jest tam twój pionek, wprowadŸ ponownie"; displayMap();  break; }
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
                        systemMessage = "Nieprawid³owy ruch, wprowadŸ ponownie";
                        break;
                    }
                    break;
                case 2:
                    if ((move[1] == piece[1] + 1 || move[1] == piece[1] - 1) && piece[0] == move[0] - 1)
                    {
                        
                        if (map[move[0], move[1]] == playerTurn) { validMove = false; systemMessage = "Nieprawid³owy ruch, wprowadŸ ponownie"; displayMap();  break; }
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
                            systemMessage = "Nieprawid³owy ruch, wprowadŸ ponownie"; displayMap(); 
                        break;
                    }
                    break;
                }
            //}
        }
        static void movePiece()
        {
            map[piece[0], piece[1]] = 0;
            map[move[0], move[1]] = playerTurn;
            piece[0] = 0;
            piece[1] = 0;
            move[0] = 0;
            move[1] = 0;
            if (playerTurn == 1) playerTurn = 2; else playerTurn = 1;
            tura++;
        }
        static void displayMap()
        {
            Console.Clear();
            Console.WriteLine('\n'+"||SYSTEM INFO: " + systemMessage + " ||" + '\n');
            //systemMessage = string.Empty;
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
            //Console.WriteLine("Pozycja wybranego pionka: "+piece[0]+ " " + piece[1]);
            Console.WriteLine("Pionki gracza 1: " + playerOnePieces);
            Console.WriteLine("Pionki gracza 2: " + playerTwoPieces);
            Console.WriteLine("Tura gracza: " + playerTurn + " || Numer tury: " + tura);
            Console.Write("WprowadŸ wspó³rzêdne pionka: ");
        }
        static void gameProcess()
        {

            bool validPiece = false;
            while (!validPiece)
            {
                for (int i = 0; i < 2; i++)
                {
                    ConsoleKeyInfo UserInput = Console.ReadKey();
                    if (char.IsDigit(UserInput.KeyChar))
                    {
                        piece[i] = int.Parse(UserInput.KeyChar.ToString()); 
                        Console.Write(" ");
                    }
                    else
                    {
                        piece[0] = 0;
                    }
                }
                Console.WriteLine(string.Empty);
                if (map[piece[0], piece[1]] == playerTurn && (map[piece[0] + 1, piece[1]] != playerTurn || map[piece[0] - 1, piece[1]] != playerTurn)) { validPiece = true; break; }
                { systemMessage = "Nieprawid³owy wybór pionka, wprowadŸ ponownie "; displayMap(); }
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
            Console.WriteLine('\t' + "|| WARCABY ||");
            Console.WriteLine("Jak graæ: W pierwszej kolejnoœci wybierz swój pionek, wpisuj¹c pozycjê na lewej osi (y), póŸniej na górnej (x), po czym wprowadŸ pozycjê na któr¹ chcesz go przenieœæ. Aby zbiæ wrogi pionek, wprowadŸ jego koordynaty. Bicia ³añcuchowe s¹ niedostêpny, bicia obowi¹zkowe s¹ niedostêpne, tworzenie 'damek' jest niedostêpny. Gra koñczy siê gdy któryœ z graczy straci wszystkie pionki. Powodzenia.");
            Console.ReadKey();
            Console.Clear();
            initializeMap();
            map[5, 2] = 2; ;// test bicia
            while (!gameEnd)
            {
                Console.WriteLine('\t'+"|| WARCABY ||");
                displayMap();
                switch (playerTurn)
                {
                    case 1:
                        gameProcess();
                        checkGameEnd();
                        break;
                    case 2:
                        gameProcess();
                        checkGameEnd();
                        break;
                }
            }
            if(playerOnePieces==0) Console.WriteLine("KONIEC GRY, ZWYCIÊ¯A GRACZ" + 2);
            else Console.WriteLine("KONIEC GRY, ZWYCIÊ¯A GRACZ" + 1);
        }
    }
}
