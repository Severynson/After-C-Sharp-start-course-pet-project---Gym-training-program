using System;

namespace Gym_training_program
{
    internal class Program
    {

        static string[,,] ProgramCreator(string[,,] trainingProgram)
        {

            Console.WriteLine(
                "\n\nLets go to our goal - ideal body." +
                "\n Lets start to creating training program:");

            int amountOfTrainingDaysPerWeek;
            int amountOfExercisesPerDay;

            {
                Console.WriteLine("\nType amount of days per week that" +
                                  "\nyou are going to workout: ");

                amountOfTrainingDaysPerWeek = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nType in amount of exercises per each day" +
                                  "\n( each training day has to contain the same number of exercises ): ");

                amountOfExercisesPerDay = Convert.ToInt32(Console.ReadLine());
            }

            // Creating array for storing data about training;

            const int amountOfPropertiesOfExercise = 5;

            trainingProgram = new string[
                amountOfTrainingDaysPerWeek,
                amountOfExercisesPerDay,
                amountOfPropertiesOfExercise
                ];

            int lastTrainingDay = trainingProgram.GetLength(0);

            for (int trainingDay = 0; trainingDay < lastTrainingDay; trainingDay++)
            {
                // Informs user of what training day he is filling in
                {
                    Console.WriteLine($"\n\n\n------ Training Day {trainingDay + 1} ------");
                }

                for (int exercise = 0; exercise < amountOfExercisesPerDay; exercise++)
                {
                    // Informs user of what exercise by count he is filling in
                    {
                        Console.WriteLine($"\n\t-- Exercise {exercise + 1} --");
                    }
                    string nameOfExercise;
                    string descriptionOfExercise;
                    string progressionStep;
                    string amountOfRepeats;
                    string secondsForRestBetweenSets;

                    // Getting each exercise data from user:
                    {
                        Console.WriteLine("\nPast the name of the exercise: ");
                        nameOfExercise = Console.ReadLine();

                        Console.WriteLine("\nPast the description of an exercise: ");
                        descriptionOfExercise = Console.ReadLine();

                        Console.WriteLine("\nPast the amount of repeatings in this exercise: ");
                        progressionStep = Console.ReadLine();

                        Console.WriteLine("\nPast the progression step in this exercise: ");
                        amountOfRepeats = Console.ReadLine();

                        Console.WriteLine("\nPast number of seconds for rest between sets:");
                        secondsForRestBetweenSets = Console.ReadLine();
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

                Console.WriteLine("\n\nYoure actions:" +
                    "\n-- 1) Create training program;" +
                    "\n-- 2) Watch created training program;" +
                    "\n-- 3) Start training;");

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
                            Console.WriteLine("\n\n" + "Name of 1 exercise:" + trainingProgram[0, 0, 0] + "\n\n");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Some default actions...");
                            break;
                        }
                }

            }


        }
    }
}
