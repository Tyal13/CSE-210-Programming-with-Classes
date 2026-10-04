using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _random = new Random();

        _words = new List<Word>();
        foreach (string wordText in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int count)
    {
        List<int> visibleIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndices.Add(i);
            }
        }

        int numberToHide = Math.Min(count, visibleIndices.Count);
        for (int i = 0; i < numberToHide; i++)
        {
            int randomIndex = _random.Next(visibleIndices.Count);
            int wordIndex = visibleIndices[randomIndex];
            _words[wordIndex].Hide();
            visibleIndices.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        List<string> renderedWords = new List<string>();
        foreach (Word word in _words)
        {
            renderedWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()}\n{string.Join(" ", renderedWords)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
