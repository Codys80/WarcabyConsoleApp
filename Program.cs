namespace WarcabyConsoleApp
{
    internal class Program
    {   // map[y, x]
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

        //******************
        //Nazwa funkcji: initializeMap
        //informacje: Funkcja inicjuj¹ca planszê do gry w warcaby
        //
        //Autor: Bartosz Semczuk
        //******************
        static void initializeMap()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    map[y, x] = 0;
                    if ((y == 7 || y == 5) && x % 2 ==0)    { map[y, x] = 1; playerOnePieces++; }
                    if (y == 6 && (x % 2 == 1) )  { map[y, x] = 1; playerOnePieces++; }

                    if ((y == 0 || y ==2 ) && x % 2 == 1) { map[y, x] = 2; playerTwoPieces++; }
                    if (y == 1 && (x % 2 == 0)) { map[y, x] = 2; playerTwoPieces++; }
                }
            }
        }

        //******************
        //Nazwa funkcji: capturePiece
        //informacje: Funkcja wykonuj¹ca bicie pionkiem na planszy
        //
        //Autor: Bartosz Semczuk
        //******************
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
                        systemMessage = "Wykonano ruch: " + piece[0] + "," + piece[1] + " na " + (move[0] - 1) + "," + (move[1] + 1); displayMap();
                        playerTwoPieces--;
                        playerTurn = 2;
                        tura++;
                    }
                }
                else if (playerTurn == 2)
                {
                    if (map[move[0] + 1, move[1] + 1] != 0) { systemMessage = "Bicie nie mo¿liwe P2 P"; displayMap(); }
                    else 
                    {
                        map[piece[0], piece[1]] = 0;
                        map[move[0], move[1]] = 0;
                        map[move[0] + 1, move[1] + 1] =  playerTurn;
                        systemMessage = "Wykonano ruch: " + piece[0] + "," + piece[1] + " na " + (move[0] + 1) + "," + (move[1] + 1); displayMap();
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
                    if (map[move[0] - 1, move[1] - 1] != 0) { systemMessage = "Bicie nie mo¿liwe P1 L"; displayMap(); }
                    else
                    {
                        map[piece[0], piece[1]] = 0;
                        map[move[0], move[1]] = 0;
                        map[move[0] - 1, move[1] - 1] =  playerTurn;
                        systemMessage = "Wykonano ruch: " + piece[0] + "," + piece[1] + " na " + (move[0] - 1) + "," + (move[1] - 1); displayMap();
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
                        systemMessage = "Wykonano ruch: " + piece[0] + "," + piece[1] + " na " + (move[0]+1) + "," + (move[1]-1); displayMap();
                        playerOnePieces--;
                        playerTurn = 1;
                        tura++;
                    }
                }
            }
        }

        //******************
        //Nazwa funkcji: moveCheck
        //informacje: Funkcja sprawdzaj¹ca poprawnoœæ ruchu pionkiem
        //
        //Autor: Bartosz Semczuk
        //******************
        static void moveCheck()
        {
            Console.Write("WprowadŸ ruch: ");
            bool validMove = false;
            int i = 0;
                while(i<2)
                {
                    ConsoleKeyInfo UserInput = Console.ReadKey();
                    if (char.IsDigit(UserInput.KeyChar))
                    {
                        move[i] = int.Parse(UserInput.KeyChar.ToString()); 
                        Console.Write(" ");
                        i++;
                    }
                    else
                    {
                        i = 0;
                        piece[0] = 0;
                        piece[1] = 0;
                        systemMessage = "Nieprawid³owa liczba: " + UserInput.KeyChar.ToString() + " wprowadŸ ponownie "; displayMap();
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
        }

        //******************
        //Nazwa funkcji: movePiece
        //informacje: Funkcja wykonuj¹ca ruch pionkiem na planszy
        //
        //Autor: Bartosz Semczuk
        //******************
        static void movePiece()
        {
            systemMessage = "Wykonano ruch: " + piece[0] + "," + piece[1] + " na " + move[0] + "," + move[1]; displayMap();
            map[piece[0], piece[1]] = 0;
            map[move[0], move[1]] = playerTurn;
            piece[0] = 0;
            piece[1] = 0;
            move[0] = 0;
            move[1] = 0;
            if (playerTurn == 1) playerTurn = 2; else playerTurn = 1;
            tura++;
        }

        //******************
        //Nazwa funkcji: displayMap
        //informacje: Funkcja wyœwietlaj¹ca aktualny stan planszy
        //
        //Autor: Bartosz Semczuk
        //******************
        static void displayMap()
        {
            Console.Clear();
            Console.WriteLine('\n'+"||SYSTEM INFO: " + systemMessage + " ||" + '\n');
            Console.Write("   ");
            
            for (int x = 0; x < 8; x++)
            {
                Console.Write(" "+ x +"  ");
            }
            Console.WriteLine(string.Empty);
            for (int x = 0; x < 34; x++)
            {
                Console.Write("_");
            }
            Console.WriteLine(string.Empty);
            for (int y = 0; y < 8; y++)
            {
                Console.Write( y + " | ");
                
                for (int x = 0; x < 8; x++)
                {
                    Console.Write(map[y, x] + "   ");
                }
                Console.WriteLine(string.Empty);
            }
            Console.WriteLine("Pionki gracza 1: " + playerOnePieces);
            Console.WriteLine("Pionki gracza 2: " + playerTwoPieces);
            Console.WriteLine("Tura gracza: " + playerTurn + " || Numer tury: " + tura);
            Console.Write("WprowadŸ wspó³rzêdne pionka: ");
        }

        //******************
        //Nazwa funkcji: gameProcess
        //informacje: G³ówna funkcja obs³uguj¹ca proces gry, m. in. wybór pionka
        //
        //Autor: Bartosz Semczuk
        //******************
        static void gameProcess()
        {

            bool validPiece = false;
            while (!validPiece)
            {
                int i = 0;
                while (i<2)
                {
                    ConsoleKeyInfo UserInput = Console.ReadKey();
                    if (char.IsDigit(UserInput.KeyChar) && int.Parse(UserInput.KeyChar.ToString()) <= 7)
                    {
                        piece[i] = int.Parse(UserInput.KeyChar.ToString()); 
                        Console.Write(" ");
                        i++;
                    }
                    else
                    {
                        i = 0;
                        piece[0] = 0;
                        piece[1] = 0;
                        systemMessage = "Nieprawid³owa liczba: " + UserInput.KeyChar.ToString() + " wprowadŸ ponownie "; displayMap();
                    }
                }
                Console.WriteLine(string.Empty);
                if (map[piece[0], piece[1]] == playerTurn && (map[piece[0] + 1, piece[1]] != playerTurn || map[piece[0] - 1, piece[1]] != playerTurn)) { validPiece = true; break; }
                { systemMessage = "Nieprawid³owy wybór pionka, wprowadŸ ponownie "; displayMap(); }
            }
            moveCheck();
        }
        
        //******************
        //Nazwa funkcji: checkGameEnd
        //informacje: Funcja sprawdzaj¹ca czy gra siê zakoñczy³a (czy któryœ z graczy nie straci³ wszystkich pionków)
        //
        //Autor: Bartosz Semczuk
        //******************
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
            Console.WriteLine("Jak graæ: W pierwszej kolejnoœci wybierz swój pionek, wpisuj¹c pozycjê na lewej osi (y), póŸniej na górnej (x), po czym wprowadŸ pozycjê na któr¹ chcesz go przenieœæ. Aby zbiæ wrogi pionek, wprowadŸ jego koordynaty. Bicia ³añcuchowe s¹ niedostêpne, bicia obowi¹zkowe s¹ niedostêpne, bicia w ty³ s¹ niedostêpne, tworzenie 'damek' jest niedostêpny. Gra koñczy siê gdy któryœ z graczy straci wszystkie pionki. Powodzenia.");
            Console.ReadKey();
            Console.Clear();
            initializeMap();
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
                        playerOnePieces = 0;
                        checkGameEnd();
                        break;
                }
            }
            if(playerOnePieces==0) Console.WriteLine("KONIEC GRY, ZWYCIÊ¯A GRACZ" + 2);
            else Console.WriteLine("KONIEC GRY, ZWYCIÊ¯A GRACZ" + 1);
        }
    }
}
