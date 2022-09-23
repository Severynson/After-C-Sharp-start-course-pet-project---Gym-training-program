using System;

namespace Gym_training_program
{
    internal class Program
    {

        static string AskAndCollectingStringDataWithErrorCatching(string message)
        {
            Console.WriteLine($"\n\n{message}");
            string valueToReturn;

        UncorrectDataAndNeedToRefilledItAgain:
            string numberInStringFormat = Console.ReadLine();

            int numericValue;
            bool isNumber = int.TryParse(numberInStringFormat, out numericValue);
            if (isNumber)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{numericValue} in not correct datatype - names can't contain numbers. Type again please: ");
                Console.BackgroundColor = ConsoleColor.Black;
                goto UncorrectDataAndNeedToRefilledItAgain;
            }
            else
            {
                // Can be used successfully
                valueToReturn = numberInStringFormat;
            }


            return valueToReturn;
        }

        static string AskAndCollectingUIntDataWithErrorCatching(string message)
        {
            Console.WriteLine($"\n\n{message}");
            uint valueToReturn;

        UncorrectDataAndNeedToRefilledItAgain:
            string numberInStringFormat = Console.ReadLine();

            if (uint.TryParse(numberInStringFormat, out valueToReturn))
            {
                // Can be converted successfully
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou passed too big number, negative value or not a number. Type again please: ");
                Console.BackgroundColor = ConsoleColor.Black;
                goto UncorrectDataAndNeedToRefilledItAgain;
            }


            return Convert.ToString(valueToReturn);
        }

        static string[,,] ProgramCreator(string[,,] trainingProgram)
        {

            Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(
                "\n\nLets go to our goal - ideal body." +
                "\n Lets start to creating training program:");
            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;

            uint amountOfTrainingDaysPerWeek;
            uint amountOfExercisesPerDay;

            {
                Console.WriteLine("\nType amount of days per week that" +
                                  "\nyou are going to workout: ");

                amountOfTrainingDaysPerWeek = Convert.ToUInt32(Console.ReadLine());

                Console.WriteLine("\nType in amount of exercises per each day" +
                                  "\n( each training day has to contain the same number of exercises ): ");

                amountOfExercisesPerDay = Convert.ToUInt32(Console.ReadLine());
            }

            // Creating array for storing data about training;

            const uint amountOfPropertiesOfExercise = 5;

            trainingProgram = new string[
                amountOfTrainingDaysPerWeek,
                amountOfExercisesPerDay,
                amountOfPropertiesOfExercise
                ];

            uint lastTrainingDay = Convert.ToUInt32(trainingProgram.GetLength(0));

            for (uint trainingDay = 0; trainingDay < lastTrainingDay; trainingDay++)
            {
                // Informs user of what training day he is filling in
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\n\n\n------ Training Day {trainingDay + 1} ------");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                for (uint exercise = 0; exercise < amountOfExercisesPerDay; exercise++)
                {
                    // Informs user of what exercise by count he is filling in
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\n\t-- Exercise {exercise + 1} --");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    string nameOfExercise;
                    string descriptionOfExercise;
                    string progressionStep;
                    string amountOfRepeats;
                    string secondsForRestBetweenSets;

                    // Getting each exercise data from user:
                    {
                        nameOfExercise = AskAndCollectingStringDataWithErrorCatching("Past the name of the exercise: ");
                        descriptionOfExercise = AskAndCollectingStringDataWithErrorCatching("Past the description of an exercise: ");

                        progressionStep = AskAndCollectingUIntDataWithErrorCatching("Past the amount of repeats in this exercise: ");
                        amountOfRepeats = AskAndCollectingUIntDataWithErrorCatching("Past the progression step in this exercise: ");
                        secondsForRestBetweenSets = AskAndCollectingUIntDataWithErrorCatching("Past number of seconds for rest between sets: ");
                    }


                    // Assigning data of exercise to it's place in trainingProgram array
                    {
                        trainingProgram[trainingDay, exercise, 0] = nameOfExercise;
                        trainingProgram[trainingDay, exercise, 1] = descriptionOfExercise;
                        trainingProgram[trainingDay, exercise, 2] = progressionStep;
                        trainingProgram[trainingDay, exercise, 3] = amountOfRepeats;
                        trainingProgram[trainingDay, exercise, 4] = secondsForRestBetweenSets;
                    }

                }

            }

            return trainingProgram;
        }

        static void DisplayProgram(string[,,] trainingProgram)
        {

            if (trainingProgram.GetLength(0) == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nNo training program created yet.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n--------- |||| Training program |||| ---------");
                Console.BackgroundColor = ConsoleColor.Black;

                int lastTrainingDay = trainingProgram.GetLength(0);
                int amountOfExercisesPerDay = trainingProgram.GetLength(1);

                for (int trainingDay = 0; trainingDay < lastTrainingDay; trainingDay++)
                {
                    // Informs user of what training day is displaying
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"\n\n------ Training Day {trainingDay + 1} ------");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    for (int exercise = 0; exercise < amountOfExercisesPerDay; exercise++)
                    {
                        // Informs user of what exercise is displaying
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"\n\t-- Exercise {exercise + 1} --");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        string nameOfExercise;
                        string descriptionOfExercise;
                        string progressionStep;
                        string amountOfRepeats;
                        string secondsForRestBetweenSets;

                        // Assigning data of exercise to it's variables;
                        {
                            nameOfExercise = trainingProgram[trainingDay, exercise, 0];
                            descriptionOfExercise = trainingProgram[trainingDay, exercise, 1];
                            progressionStep = trainingProgram[trainingDay, exercise, 2];
                            amountOfRepeats = trainingProgram[trainingDay, exercise, 3];
                            secondsForRestBetweenSets = trainingProgram[trainingDay, exercise, 4];
                        }

                        // Getting each exercise data from user:
                        {
                            Console.WriteLine($"\nExercise Name: {nameOfExercise}");

                            Console.WriteLine($"\nExercise description: {descriptionOfExercise}");

                            Console.WriteLine($"\nProgression step in this exercise: {progressionStep}");

                            Console.WriteLine($"\nAmount of repeats in this exercise: {amountOfRepeats}");

                            Console.WriteLine($"\nNumber of seconds for rest between sets: {secondsForRestBetweenSets}");
                        }

                    }
                }
            }


        }

        static void Main(string[] args)
        {

            Console.WriteLine("Hello user, nice to see you!" +
            "\nThanks for choosing our app." +
            "\nYou can create your own training program with this app." +
            "\nThis version will have some limitations not because we" +
            "\nhave some better edition we want some money, but because" +
            "\nSeveryn didn't learn C# so good to write it better." +
            "\n\nBut he will soon of course)))");

            string[,,] trainingProgram = { };

            while (true)
            {

                Console.BackgroundColor = ConsoleColor.Green; Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\nYoure actions:" +
                    "\n-- 1) Create training program;" +
                    "\n-- 2) Watch created training program;" +
                    "\n-- 3) Start training;");
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;

                char usersAction = Console.ReadKey().KeyChar;

                switch (usersAction)
                {
                    case '1':
                        {
                            trainingProgram = ProgramCreator(trainingProgram);
                            break;
                        }
                    case '2':
                        {
                            DisplayProgram(trainingProgram);
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("\n\nSection is not ready yet...");
                            break;
                        }
                }

            }


        }
    }
}
