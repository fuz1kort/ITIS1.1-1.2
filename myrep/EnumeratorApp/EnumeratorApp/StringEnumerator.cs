using System.Collections;

namespace YieldApp;

public class StringEnumerator : IEnumerable<string>
{
<<<<<<< HEAD
    private string[] Words;
    //public WordsEnumerator WordsOrderedByLength;
=======
    private readonly string[] Words;
    public WordsEnumerator WordsOrderedByLength;
>>>>>>> w
    private bool IfOrdered = false;

    public StringEnumerator(string words)
    {
        Words = words.Split(' ');
    }
    public IEnumerator<string> GetEnumerator()
    {
        foreach (var word in Words.OrderBy(p => p.Length))
        //foreach(var word in Words)
        {
            yield return word;
        }
    }

    //public IEnumerable<string> GetOrderedByLength()
    //{
    //    if (!IfOrdered)
    //    {
    //        WordsOrderedByLength = new WordsEnumerator(Words);
    //        IfOrdered = true;
    //    }

    //    return WordsOrderedByLength;
    //}

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}