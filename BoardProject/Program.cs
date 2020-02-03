using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardProject
{
    class BoardExercise
    {
        static void Main(string[] args)
        {

            //Strings
            string rowsStr;
            string columnsStr;
            string testCasesString;            

            //Ints
            int columnsAmount = 0;
            int rowsAmount = 0;
            int testCasesNumber = 0;
            int attempts = 0;

            //Chars
            char direction = 'R';

            //Arrays
            int[,] board;
            int[] currentPosition = { 0, 0 };

            //Bools
            bool flag;            

            //Execution Start                                                
            do
            {
                //How many Test Cases
                Console.Write("Hi! How many test cases do you want to do this time? TC: ");

                //Assign a number of test cases
                testCasesString = Console.ReadLine();
                try
                {
                    testCasesNumber = int.Parse(testCasesString); //Try to convert into int the input
                }
                catch
                {
                    Console.WriteLine("{0} is not an integer!\n", testCasesString); //If fails, it tells the user and continues to the next iteration
                    flag = false;
                    continue;
                }

                if (testCasesNumber < 1 || testCasesNumber > 5000)//If the values aren't as requirements dictate, displays the message and sets the flag to false
                {
                    Console.WriteLine("The number of test cases must be at least 1, maximum 5000, please enter a value between 1 and 5000\n");
                    flag = false;
                }
                else
                {
                    Console.WriteLine("There will be {0} test cases, then. Thank you.\n", testCasesNumber);
                    flag = true;
                }
                
            }
            while (flag == false); //If the flag is false, goes back to the loop, this will prevent the user from breaking the input

            //Repeat row and column assignation for each Test Case
            for (int i = 0; i < testCasesNumber; i++)
            {
                direction = 'R'; //Reset on each iteration
                attempts = 0;
                currentPosition[0] = 0;
                currentPosition[1] = 0;
                do
                {
                    //How many rows for the iteration number i
                    Console.Write("How many rows and columns (respectively) will the board number " + (i + 1) + " have? (Type first the number of rows and hit enter, and then once again but now for the number of columns. Ex: 3 3) Rows: ");

                    //Assign a number of rows
                    rowsStr = Console.ReadLine();
                    try
                    {
                        rowsAmount = int.Parse(rowsStr); //Try to convert into int the input
                    }
                    catch
                    {
                        Console.WriteLine("{0} is not an integer!\n", rowsStr); //If fails, it tells the user and continues to the next iteration
                        flag = false;
                        continue;
                    }

                    //Assign a number of columns
                    Console.Write("Columns: ");
                    columnsStr = Console.ReadLine();
                    try
                    {
                        columnsAmount = int.Parse(columnsStr); //Try to convert into int the input
                    }
                    catch
                    {
                        Console.WriteLine("{0} is not an integer!\n", columnsStr); //If fails, it tells the user and continues to the next iteration
                        flag = false;
                        continue;
                    }

                    if (rowsAmount < 1 || rowsAmount > 1000000000 || columnsAmount < 1 || columnsAmount > 1000000000)//If the values aren't as requirements dictate, displays the message and sets the flag to false
                    {
                        Console.WriteLine("The number of rows and columns must be at least 1, maximum 1000000000, each. Please enter a value between 1 and 1000000000\n");
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("There will be {0} rows and {1} columns, then. Thank you.", rowsAmount, columnsAmount);
                        flag = true;
                    }

                }
                while (flag == false); //If the flag is false, goes back to the loop, this will prevent the user from breaking the input

                board = new int[rowsAmount, columnsAmount]; //Assign the number of rows and columns the user chose

                board[0, 0] = 1;//If a block was visited, it will be a value of 1, and if not, a value of 0. The requirements say that the first block is always visited first

                while (attempts < board.Length - 1)//Navigate through rows
                {
                    //When facing RIGHT
                    if (direction == 'R')
                    {
                        if (currentPosition[1] + 1 < columnsAmount) //Checks the block to the right to see that's not out of range
                        {
                            if (board[currentPosition[0], currentPosition[1] + 1] == 0) //If it's not visited, proceed, otherwise, change direction
                            {
                                currentPosition[1]++; //Next column to the right
                                board[currentPosition[0], currentPosition[1]] = 1;//Updates current position
                                attempts++;//The amount of attempts will let the program know when the whole navigation is finished
                            }

                            else if (board[currentPosition[0], currentPosition[1] + 1] == 1)//Here it changes the direction
                            {
                                direction = 'D';
                            }
                        }
                        else
                        {
                            direction = 'D';                                                       
                        }
                    }
                    //When facing DOWN
                    else if (direction == 'D')
                    {
                        if (currentPosition[0] + 1 < rowsAmount)
                        {
                            if (board[currentPosition[0] + 1, currentPosition[1]] == 0)
                            {
                                currentPosition[0]++;
                                board[currentPosition[0], currentPosition[1]] = 1;
                                attempts++;
                            }

                            else if (board[currentPosition[0] + 1, currentPosition[1]] == 1)
                            {
                                direction = 'L';
                            }
                        }
                        else
                        {
                            direction = 'L';
                        }
                    }
                    //When facing LEFT
                    else if (direction == 'L')
                    {
                        if (currentPosition[1] - 1 >= 0)
                        {
                            if (board[currentPosition[0], currentPosition[1] - 1] == 0)
                            {
                                currentPosition[1]--;
                                board[currentPosition[0], currentPosition[1]] = 1;
                                attempts++;
                            }

                            else if (board[currentPosition[0], currentPosition[1] - 1] == 1)
                            {
                                direction = 'U';
                            }
                        }
                        else
                        {
                            direction = 'U';
                        }
                    }
                    //When facing UP
                    else if (direction == 'U')
                    {
                        if (currentPosition[0] - 1 >= 0)
                        {
                            if (board[currentPosition[0] - 1, currentPosition[1]] == 0)
                            {
                                currentPosition[0]--;
                                board[currentPosition[0], currentPosition[1]] = 1;
                                attempts++;
                            }

                            else if (board[currentPosition[0] + 1, currentPosition[1]] == 1)
                            {
                                direction = 'R';
                            }
                        }
                        else
                        {
                            direction = 'R';
                        }
                    }
                }
                
                Console.WriteLine("\nLast direction faced: " + direction); //Prints the last direction you were facing when the navigation finished
                Console.Write("Press the ENTER key to continue.");//I decided to let the user see the result, so I gave him a brief pause
                Console.ReadLine();



                /*for (int j = 0; j < rowsAmount; j++) //Uncomment to display the board
                {
                    for (int k = 0; k < columnsAmount; k++)
                    {
                        Console.Write(board[j,k] + " ");
                    }
                    Console.Write("\n");
                }
                Console.ReadLine();*/

            }            
        }        
    }
}
