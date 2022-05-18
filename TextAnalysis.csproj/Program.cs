using System;
using System.Collections.Generic;
using System.IO;
using NUnitLite;

namespace TextAnalysis
{
    internal static class Program
    {
        public static void Main(string[] args)
        {

            var testsToRun = new string[]
            {
                "TextAnalysis.SentencesParser_Tests",
                "TextAnalysis.FrequencyAnalysis_Tests",
                "TextAnalysis.TextGenerator_Tests",
            };
            new AutoRun().Execute(new[]
            {
                "--stoponerror", 
                "--noresult",
                "--test=" + string.Join(",", testsToRun)
            });

            var text = File.ReadAllText("HarryPotterText.txt");
            var sentences = SentencesParserTask.ParseSentences(text);
            var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
            
            /*
            frequency = new Dictionary<string, string>
            {
                {"harry", "potter"},
                {"potter", "boy" },
                {"boy", "who" },
                {"who", "likes" },
                {"boy who", "survived" },
                {"survived", "attack" },
                {"he", "likes" },
                {"likes", "harry" },
                {"ron", "likes" },
                {"wizard", "harry" },
            };
            */
            while (true)
            {
                Console.Write("Введите первое слово (например, harry): ");
                var beginning = Console.ReadLine();
                if (string.IsNullOrEmpty(beginning)) return;
                var phrase = TextGeneratorTask.ContinuePhrase(frequency, beginning.ToLower(), 10);
                Console.WriteLine(phrase);
            }
        }
    }
}