using System;
using System.Collections.Generic;

public class ErrorDictionary
{
  private readonly Dictionary<string, List<string>> _dictionary = new()
  {
    {"привет", new List<string> {"првиет", "пирвет", "приевт", "привки"}},
    {"пока", new List<string> {"пако", "копа", "пакеда"}},
    {"программа", new List<string> {"порграмма", "пргорамма", "програма"}}
  };

  public void AddEntry(string correctWord, List<string> mistakes)
  {
    if (!_dictionary.ContainsKey(correctWord))
    {
      _dictionary[correctWord] = new List<string>();
    }
    _dictionary[correctWord].AddRange(mistakes);
  }

  public Dictionary<string, List<string>> GetDictionary() => _dictionary;

  public void Display()
  {
    foreach (var entry in _dictionary)
    {
      Console.WriteLine($"Слово без ошибок: {entry.Key}");
      Console.WriteLine($"Слова с ошибками: {string.Join(", ", entry.Value)}");
      Console.WriteLine("\nНажмите на любую клавишу, чтобы вернуться в меню.");
    }
  }
}