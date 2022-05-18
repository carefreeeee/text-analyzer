using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var promej = new Dictionary<string, Dictionary<string,int>>();

            for (int i = 0; i < text.Count; i++)  // по предложениям
            {
                for (int j = 0; j < text[i].Count - 1; j++) // по словам
                {
                    if (!promej.ContainsKey(text[i][j]))
                        promej.Add(text[i][j], new Dictionary<string, int>() { [text[i][j + 1]] = 1 });   // биграммы
                    else if (!promej[text[i][j]].ContainsKey(text[i][j + 1]))
                        promej[text[i][j]].Add(text[i][j + 1], 1);
                    else promej[text[i][j]][text[i][j + 1]] ++;
                }

                for (int k = 0; k < text[i].Count - 2; k++)  // по словам
                {
                    string key = text[i][k] + " " + text[i][k + 1];
                    if (!promej.ContainsKey(key))
                        promej.Add(key, new Dictionary<string, int>() { [text[i][k + 2]] = 1 }); // триграммы
                    else if (!promej[key].ContainsKey(text[i][k + 2]))
                        promej[key].Add(text[i][k + 2], 1);
                    else promej[key][text[i][k + 2]]++;
                }
            }

            foreach (string key in promej.Keys)
            {
                int max = 0;
                string strMax = "";
                foreach (string key2 in promej[key].Keys)
                {
                    if (promej[key][key2] == max && String.CompareOrdinal(key2, strMax) < 0)
                    {
                        max = promej[key][key2];
                        strMax = key2;
                    }

                    if (promej[key][key2] > max)
                    {
                        max = promej[key][key2];
                        strMax = key2;
                    }
                }
                result.Add(key, strMax);
            }
            return result;
        }
    }
}