Console.OutputEncoding = System.Text.Encoding.UTF8;

// setup
string secretWord = "Computer";
List<char> guessedLetters = [];
int lives = 10;

Console.Clear();
Info("\nWelcome to Hangman!😊");

// Play game

while (lives > 0)
{
    
    // Ask for a letter

    Info("\n\n✍️");
    Console.WriteLine();
    DisplayMaskedWord(secretWord, guessedLetters);

    

    InfoLine($"\nLives: {lives}");
    Info("\nGuess a letter: ");
    char guess = Console.ReadKey().KeyChar;
    Console.WriteLine($"\nYou guessed: {guess}!");

    //Validate
    if (!IsAllowedGuess(guess))
    {
        WarningLine("Please enter a letter.");
        continue;
    }
    if (guessedLetters.Contains(guess))
    {
        lives--;
        WarningLine("You've already guessed that letter.");
        continue;
    }

    //Check if correct

    guessedLetters.Add(guess);

    if (secretWord.Contains(guess))
    {
        SuccessLine("Correct! ");
    }
    else
    {
        lives -= 2;
        ErrorLine("Wrong! ");
    }

    if (IsWordGuessed(secretWord, guessedLetters))
    {
        // player won
        SuccessLine("\n\nCongratulations, you've won!");
        InfoLine("\nThe word was: ");
        DisplayMaskedWord(secretWord, guessedLetters);
        InfoLine();
        return;
    }

    // player lost / Hints
    switch (lives)
    {
        case 6:
        InfoLine("Maybe it is something you are using right now.");
        break;

        case <= 0:
        ErrorLine("Game over!🥸");
        InfoLine("\nDo you want to play again? Write yes or no: ");
        String answer = Console.ReadLine().ToLower();
        if (answer == "yes")
        {
            lives = 10;
            guessedLetters.Clear();
            continue;
        }
        else if(answer == "no")
        {
            break;
        }
        break;

    }
    
    }


ErrorLine($"Game Over! The word was {secretWord}.");
InfoLine();





//Just functions below this line
static bool IsWordGuessed(string word, List<char> guessedLetters)
{
    return word.All(guessedLetters.Contains);
}

static bool IsAllowedGuess(char guess)
{
    return char.IsLetter(guess);
}

static void DisplayMaskedWord(string word, List<char> guessedLetters)
{
    Console.WriteLine();
    foreach (char letter in word)
    {
        if (guessedLetters.Contains(letter))
        {
            Info(letter + " ");
        }
        
        else
        {
            Info("_ ");
        }
    }

}

static void Info(string message)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(message);
}
static void InfoLine(string message = "")
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(message);
}
static void SuccessLine(string message = "")
{
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.Write(message);
}
static void ErrorLine(string message = "")
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(message);
}
static void WarningLine(string message = "")
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(message);
}



/*
if (lives <=6)
    {
        Console.WriteLine("Maybe it is something you are using right now.");
    }

    // Player lost
    if (lives <= 0)
    {
        ErrorLine($"Game Over!");
        InfoLine("\nDo you want to play again? Write yes or no");

        string answer = Console.ReadLine().ToLower();

        if (answer == "yes")
        {
            lives = 10;
            guessedLetters.Clear();
            continue;
        }
        else if (answer == "no")
        {
            break;
        }
        */