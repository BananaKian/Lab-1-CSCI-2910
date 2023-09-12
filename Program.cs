using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using static System.Console;

namespace Lab_1
{
    internal class Program
    {

        public static void PublisherData(string input, List<VideoGames> data, decimal IncomingCounter)
        {
            decimal counter = 0;
            decimal counter2 = IncomingCounter;

            WriteLine("Please enter a gaming developer.\n");
            input = ReadLine();

            var publisherList = data.Where(e => e.Publisher.Contains(input)).ToList();
            publisherList.Sort();

            foreach (var e in publisherList)
            {
                WriteLine($"{e.Name} {e.Platform} {e.Year} {e.Genre} {e.Publisher} {e.NASales} {e.EUSales} {e.JPSales} {e.OtherSales} {e.GlobalSales}");
                counter++;
            }

            decimal Percentage = counter / counter2;

            WriteLine("\nOut of " + counter2 + " games, " + counter + " are " + input + " games, which is " + Percentage.ToString("P", CultureInfo.InvariantCulture) + " of all games.");
            ReadLine();
        }

        public static void GenreData(string input, List<VideoGames> data, decimal IncomingCounter)
        {
            decimal counter = 0;
            decimal counter2 = IncomingCounter;

            WriteLine("Please insert a game genre.\n");
            input = ReadLine();

            var genreList = data.Where(e => e.Genre.Contains(input)).ToList();
            genreList.Sort();

            foreach (var e in genreList)
            {
                WriteLine($"{e.Name} {e.Platform} {e.Year} {e.Genre} {e.Publisher} {e.NASales} {e.EUSales} {e.JPSales} {e.OtherSales} {e.GlobalSales}");
                counter++;
            }

            decimal Percentage = counter / counter2;

            WriteLine("\nOut of " + counter2 + " games, " + counter + " are " + input + " games, which is " + Percentage.ToString("P", CultureInfo.InvariantCulture) + " of all games.");
            ReadLine();
        }

        private static void Main(string[] args)
        {
            //file location will differ, so will need to be changed to accomodate that
            string FilePath = "C:\\Users\\robertsej1\\source\\repos\\Lab 1\\Lab 1\\videogames.csv";

            var reader = new StreamReader(FilePath);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null,
                HasHeaderRecord = false
            };

            List<VideoGames> data = new List<VideoGames>();


            var csv = new CsvReader(reader, csvConfig);
            {
                // Skips the first row, since it won't convert right
                reader.ReadLine();

                while (csv.Read())
                {
                    var record = csv.GetRecord<VideoGames>();
                    data.Add(record);
                }

            }

            //variables for the PublisherData and GenreData classes
            string UserInput = "";
            decimal counter = 0;

            //Used to get the number of games from the initial list
            foreach (var e in data)
            {
                counter++;
            }

            PublisherData(UserInput, data, counter);
            GenreData(UserInput, data, counter);
        }
    }
}