using System.Collections.Generic;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var speech = new List<string>();
            var sentences = text.Split('.', '!', '?', ';', ':', '(', ')');
            string[] words;
            foreach (var e in sentences)
            {
                words = e.Split(new char[] {' ', '^', '#', '$', '-', '—', '+', '1', '=', '\t', '\n', '\r', ' ', ',', '“', '”', '‘', '…', '*', '/'});
                for (var i = 0; i < words.Length; i++)   // удалить лишние символы
                {
                    words[i] = words[i].ToLower();
                    if (words[i] != "" && !int.TryParse(words[i], out int q))
                        speech.Add(words[i]);
                }
                if (speech.Count > 0)
                    sentencesList.Add(new List<string>(speech));
                speech.Clear();
            }
            return sentencesList;
        }
    }
}


