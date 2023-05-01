using System.Collections;
using YieldApp;

namespace YieldApp;

public class StringEnumerator : IEnumerable<string>
{
<<<<<<< HEAD
<<<<<<< HEAD
    private string[] Words;
    //public WordsEnumerator WordsOrderedByLength;
=======
    private readonly string[] Words;
    public WordsEnumerator WordsOrderedByLength;
>>>>>>> w
=======
    private string[] Words;
    //public WordsEnumerator WordsOrderedByLength;
>>>>>>> matrixthread work
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

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> matrixthread work
    //public IEnumerable<string> GetOrderedByLength()
    //{
    //    if (!IfOrdered)
    //    {
    //        WordsOrderedByLength = new WordsEnumerator(Words);
    //        IfOrdered = true;
    //    }
<<<<<<< HEAD
=======
    public IEnumerable<string> GetOrderedByLength()
    {
        if (!IfOrdered)
        {

            WordsOrderedByLength = new WordsEnumerator(Words);
            IfOrdered = true;
        }

        return WordsOrderedByLength;

    }
>>>>>>> s
=======
>>>>>>> matrixthread work

    //    return WordsOrderedByLength;
    //}

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}