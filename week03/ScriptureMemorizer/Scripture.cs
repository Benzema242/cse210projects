using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        _words = text
            .Split(' ')
            .Select(word => new Word(word))
            .ToList();
    }


    public void HideRandomWords(int numberToHide)
    {
        var rnd = new Random();
        var candidates = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < numberToHide && candidates.Count > 0; i++)
        {
            int index = rnd.Next(candidates.Count);
            candidates[index].Hide();
            candidates.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        var displayWords = _words
            .Select(w => w.GetDisplayText());
        return $"{_reference.GetDisplayText()} {string.Join(" ", displayWords)}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

}