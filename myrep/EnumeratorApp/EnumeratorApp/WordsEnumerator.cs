using System.Collections;

namespace YieldApp;

public class WordsEnumerator : IEnumerable<string>
{
    public readonly string[] Words;

    public WordsEnumerator(string[] words)
    {
        Words = new string[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            Words[i] = words[i];
        }
        Sort();

    }

    private void Sort()
    {
        for (int i = 0; i < Words.Length; i++)
        {
            for (int e = i; e < Words.Length; e++)
            {
                if (Words[i].Length > Words[e].Length)
                    (Words[i], Words[e]) = (Words[e], Words[i]);
            }
        }
    }

    public IEnumerator<string> GetEnumerator()
    {
        foreach (var word in Words)
        {
            yield return word;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}