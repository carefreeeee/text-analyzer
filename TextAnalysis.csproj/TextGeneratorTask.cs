using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            
            var word = phraseBeginning.Split(' ');
            var list = new List<string>();
            for (int i = 0; i < word.Length; i++)
                list.Add(word[i]);

            var k = list.Count - 1;
            for (int i = k; i < wordsCount + k; i++)
            {
                if (i == 0)
                {
                    if (nextWords.ContainsKey(list[i]))
                        list.Add(nextWords[list[i]]);
                    else break;
                }
                else if (nextWords.ContainsKey(list[i - 1] + " " + list[i]))
                    list.Add(nextWords[list[i - 1] + " " + list[i]]);
                else if (nextWords.ContainsKey(list[i]))
                    list.Add(nextWords[list[i]]);
                else break;
            }
            return string.Join(" ", list);
        }
    }
}