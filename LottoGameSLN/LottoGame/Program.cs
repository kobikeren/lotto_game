using System;

namespace LottoGame
{    
    class Program
    {
        static Random random = new Random();
        const int SIZE = 6;
        const int LOWER_BOUND = 1;
        const int UPPER_BOUND = 45;

        static void Main(string[] args)
        {                        
            //numberOfSequences will store the number of sequences
            int numberOfSequences = 0;

            //selection will store the menu item the user selected
            char selection;

            do
            {
                //the first step is to print the menu to the user                
                PrintMenu();
                selection = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (selection)
                {
                    case '1':
                        Console.Clear();
                        PrintTheRules();
                        PrintMessageToGoBackToMainMenu();
                        break;
                    case '2':
                    {
                        Console.Clear();
                        Console.WriteLine("Lotto Game - Play (fill sequences by hand)");
                        Console.WriteLine("---------------------------------------------------");

                        //GetNumberOfSequences() will return the number 
                        //of sequences to be filled
                        numberOfSequences = GetNumberOfSequences();

                        //create a table with rows for the sequences
                        int[,] numbersTable = new int[numberOfSequences, SIZE];

                        //FillTableByHand will fill the table with numbers
                        FillTableByHand(numbersTable);

                        //create an array to hold the winning sequence
                        int[] winningSequence = new int[SIZE];

                        //GenerateWinningSequence will fill the array with the winning numbers
                        GenerateWinningSequence(winningSequence);

                        //create an array to hold the number of sequences, for 
                        //different numbers of hits
                        int[] summaryArray = new int[SIZE + 1];

                        Console.Clear();

                        //print the winning sequence
                        PrintWinningSequence(winningSequence);

                        //print the user's sequences
                        Console.WriteLine("***********************************************");
                        Console.Write("Your sequences are:");

                        //CountAndPrintHitsInSequence will print a sequence, and will
                        //also add that sequence to the count for a specific 
                        //number of hits 
                        for (int rowNumber = 0; rowNumber < numbersTable.GetLength(0);
                            rowNumber++)
                            CountAndPrintHitsInSequence(numbersTable,
                                rowNumber, winningSequence, summaryArray);
                        Console.WriteLine("***********************************************");

                        //print the summary
                        Console.WriteLine();
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("Summary:");
                        for (int numberOfHits = summaryArray.Length - 1;
                            numberOfHits >= 0; numberOfHits--)
                            Console.WriteLine("Number of sequences with {0} hits: {1}",
                                numberOfHits, summaryArray[numberOfHits]);
                        Console.WriteLine("\n      Total number of sequences: {0}",
                            numbersTable.GetLength(0));
                        Console.WriteLine("***********************************************");

                        PrintMessageToGoBackToMainMenu();
                        break;
                    }
                    case '3':
                    {
                        Console.Clear();
                        Console.WriteLine("Lotto Game - Play (fill sequences automatically)");
                        Console.WriteLine("---------------------------------------------------");

                        //GetNumberOfSequences() will return the number 
                        //of sequences to be filled
                        numberOfSequences = GetNumberOfSequences();

                        //create a table with rows for the sequences
                        int[,] numbersTable = new int[numberOfSequences, SIZE];

                        //FillTableAuto will fill the table with numbers
                        FillTableAuto(numbersTable);

                        //create an array to hold the winning sequence
                        int[] winningSequence = new int[SIZE];

                        //GenerateWinningSequence will fill the array with the winning numbers
                        GenerateWinningSequence(winningSequence);

                        //create an array to hold the number of sequences, for 
                        //different numbers of hits
                        int[] summaryArray = new int[SIZE + 1];

                        Console.Clear();

                        //print the winning sequence
                        PrintWinningSequence(winningSequence);

                        //print the user's sequences
                        Console.WriteLine("***********************************************");
                        Console.Write("Your sequences are:");

                        //CountAndPrintHitsInSequence will print a sequence, and will
                        //also add that sequence to the count for a specific 
                        //number of hits 
                        for (int rowNumber = 0; rowNumber < numbersTable.GetLength(0);
                            rowNumber++)
                            CountAndPrintHitsInSequence(numbersTable,
                                rowNumber, winningSequence, summaryArray);
                        Console.WriteLine("***********************************************");

                        //print the summary
                        Console.WriteLine();
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("Summary:");
                        for (int numberOfHits = summaryArray.Length - 1;
                            numberOfHits >= 0; numberOfHits--)
                            Console.WriteLine("Number of sequences with {0} hits: {1}",
                                numberOfHits, summaryArray[numberOfHits]);
                        Console.WriteLine("\n      Total number of sequences: {0}",
                            numbersTable.GetLength(0));
                        Console.WriteLine("***********************************************");

                        PrintMessageToGoBackToMainMenu();
                        break;
                    }
                    case '4':
                        Console.WriteLine("\nGood bye...\n");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nInvalid selection\n\n");
                        PrintMessageToGoBackToMainMenu();
                        break;
                }
            } while (selection != '4');
        }

        static void PrintMenu()
        {
            Console.WriteLine("Lotto Game - Main Menu");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("1. Learn the rules");
            Console.WriteLine("2. Play (fill sequences by hand)");
            Console.WriteLine("3. Play (fill sequences automatically)");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your selection: ");
        }

        static void PrintTheRules()
        {
            Console.WriteLine("Lotto Game - Learn the rules");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Choose number of sequences to fill (between");
            Console.WriteLine("1 and 5)\n");
            Console.WriteLine("In each sequence fill 6 numbers between");
            Console.WriteLine("1 and 45\n\n");
            Console.WriteLine("Then the winning sequence will be generated\n");
            Console.WriteLine("After the winning sequence will be printed, the system");
            Console.WriteLine("will check your sequences for hits\n\n\n");
            Console.WriteLine("Good luck !");
        }

        static void PrintMessageToGoBackToMainMenu()
        {
            Console.WriteLine("\n\n\n - * - * - * - * - * - * - * - * - * - * - * ");
            Console.WriteLine("Press enter to go back to main menu");
            Console.ReadLine();
            Console.Clear();
        }

        static int GetNumberOfSequences()
        {
            int numberInt = 0;
            char numberChar;

            while (numberInt < 1)
            {
                //get the number of sequences from the user
                Console.WriteLine("The number of sequences can be between 1 and 5");
                Console.Write("How many sequences do you want to fill? : ");
                numberChar = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (numberChar)
                {
                    case '1':
                        numberInt = 1;
                        break;
                    case '2':
                        numberInt = 2;
                        break;
                    case '3':
                        numberInt = 3;
                        break;
                    case '4':
                        numberInt = 4;
                        break;
                    case '5':
                        numberInt = 5;
                        break;
                    default:
                        //if the number is not legal, display message to the user 
                        //before starting the loop again
                        Console.WriteLine("Number of sequences cannot be {0}\n", numberChar);
                        break;
                }
            }

            return numberInt;
        }

        static void FillTableByHand(int[,] numbersTable)
        {
            string numberStr = "";
            int numberInt = 0, xInt;
            bool inputIsNotNumber, numberOutOfRange, numberAlreadyExist;
            int[] localArray = new int[numbersTable.GetLength(1)];

            for (int rowNumber = 0; rowNumber < numbersTable.GetLength(0); rowNumber++)
            {
                Console.WriteLine();
                for (int columnNumber = 0; columnNumber < localArray.Length; columnNumber++)
                {
                    inputIsNotNumber = true;
                    numberOutOfRange = true;
                    numberAlreadyExist = true;

                    while (inputIsNotNumber || numberOutOfRange || numberAlreadyExist)
                    {
                        inputIsNotNumber = false;
                        numberOutOfRange = false;
                        numberAlreadyExist = false;

                        //get a number from the user
                        Console.Write("Enter number {0} (sequence {1}): ", columnNumber + 1,
                            rowNumber + 1);
                        numberStr = Console.ReadLine();
                        if (!int.TryParse(numberStr, out xInt))
                            inputIsNotNumber = true;
                        else
                            numberInt = int.Parse(numberStr);

                        if (!inputIsNotNumber)
                        {
                            if (numberInt < LOWER_BOUND || numberInt > UPPER_BOUND)
                                numberOutOfRange = true;
                        }

                        if (!inputIsNotNumber && !numberOutOfRange)
                        {
                            for (int columnIndex = 0; columnIndex < columnNumber; columnIndex++)
                            {
                                if (numberInt == localArray[columnIndex])
                                {
                                    numberAlreadyExist = true;
                                    break;
                                }
                            }
                        }

                        //if the number is not legal, display message to the user before 
                        //starting the loop again
                        if (inputIsNotNumber)
                            Console.WriteLine("{0} is not a number", numberStr);
                        if (numberOutOfRange)
                            Console.WriteLine("{0} is not between {1} and {2}",
                                numberInt, LOWER_BOUND, UPPER_BOUND);
                        if (numberAlreadyExist)
                            Console.WriteLine(
                                "{0} already exist in the current sequence (sequence {1})",
                                numberInt, rowNumber + 1);
                    }
                    //insert the number to the local array
                    localArray[columnNumber] = numberInt;

                    //insert the number to the table 
                    numbersTable[rowNumber, columnNumber] = localArray[columnNumber];
                }
            }
        }

        static void FillTableAuto(int[,] numbersTable)
        {
            int number = 0;
            bool numberNotSelected;

            for (int rowNumber = 0; rowNumber < numbersTable.GetLength(0); rowNumber++)
            {
                for (int columnNumber = 0; columnNumber < numbersTable.GetLength(1);
                    columnNumber++)
                {
                    numberNotSelected = true;
                    while (numberNotSelected)
                    {
                        numberNotSelected = false;

                        //get a random number
                        number = random.Next(LOWER_BOUND, UPPER_BOUND + 1);

                        //a loop to check that the random number is legal
                        for (int columnIndex = 0; columnIndex < columnNumber; columnIndex++)
                        {
                            if (number == numbersTable[rowNumber, columnIndex])
                            {
                                numberNotSelected = true;
                                break;
                            }
                        }
                    }

                    numbersTable[rowNumber, columnNumber] = number;
                }
            }
        }

        static void GenerateWinningSequence(int[] winningSequence)
        {
            //create a table with only one row
            int[,] localTable = new int[1, winningSequence.Length];

            //fill the table with numbers
            FillTableAuto(localTable);

            //fill the winning sequence
            for (int columnNumber = 0; columnNumber < winningSequence.Length; columnNumber++)
            {
                winningSequence[columnNumber] = localTable[0, columnNumber];
            }
        }

        static void PrintWinningSequence(int[] winningSequence)
        {
            Console.WriteLine();
            Console.WriteLine("***********************************************");
            Console.WriteLine("The winning sequence is:");

            //print the winning sequence
            for (int columnNumber = 0; columnNumber < winningSequence.Length; columnNumber++)
            {
                Console.Write("{0,4}", winningSequence[columnNumber]);
            }
            Console.WriteLine();
            Console.WriteLine("***********************************************");
            Console.WriteLine();
        }

        static void CountAndPrintHitsInSequence(int[,] numbersTable, int rowNumber,
            int[] winningSequence, int[] summaryArray)
        {
            int numberOfHits = 0;

            //for every column in the table
            for (int columnNumber = 0; columnNumber < numbersTable.GetLength(1); columnNumber++)
            {
                //for every element in the winning sequence
                for (int columnNumberInSequence = 0;
                    columnNumberInSequence < winningSequence.Length; columnNumberInSequence++)
                {
                    if (winningSequence[columnNumberInSequence] ==
                        numbersTable[rowNumber, columnNumber])
                    {
                        //if there is a hit, then count it
                        numberOfHits++;
                        break;
                    }
                }
            }

            //add that sequence to the count.
            //summaryArray, counts sequences for different numbers of hits            
            summaryArray[numberOfHits]++;

            //print the sequence
            Console.WriteLine("\nSequence {0}:", rowNumber + 1);
            for (int columnNumber = 0; columnNumber < numbersTable.GetLength(1);
                columnNumber++)
            {
                Console.Write("{0,4}", numbersTable[rowNumber, columnNumber]);
            }

            //print the number of hits
            Console.WriteLine("\nNumber of hits: {0}", numberOfHits);
        }
    }
}
