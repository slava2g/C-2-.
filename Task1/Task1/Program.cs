using System;
using System.IO;

namespace Task1
{
    internal class Program
    {
        public delegate string TextOperation(string text);

        static string ToUpperCase(string text)
        {
            return "[UPPERCASE]\n" + text.ToUpper();
        }

        static string CountCharacters(string text)
        {
            return $"[СИМВОЛИ] Кількість символів: {text.Length}";
        }


        static string CountWords(string text)
        {
            string[] words = text.Split(
                new char[] { ' ', '\n', '\t' },
                StringSplitOptions.RemoveEmptyEntries
            );

            return $"[СЛОВА] Кількість слів: {words.Length}";
        }

        static void ProcessFile(string inputPath, string outputPath, TextOperation operation)
        {
            try
            {
                string text = File.ReadAllText(inputPath);
                string result = operation(text);
                File.AppendAllText(outputPath, result + "\n\n");

                Console.WriteLine("Операція виконана");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            string inputFile = "textPD25.txt";
            string outputFile = "resultPD25.txt";


            if (!File.Exists(inputFile))
            {
                File.WriteAllText(inputFile, "Це тестовий текст для перевірки");
            }

            File.WriteAllText(outputFile, "");
            ProcessFile(inputFile, outputFile, ToUpperCase);
            ProcessFile(inputFile, outputFile, CountCharacters);
            ProcessFile(inputFile, outputFile, CountWords);
            Console.WriteLine("Готово!");
        }
    }
}
