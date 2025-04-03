using System;
using System.Collections.Generic;

public class Menu
{
  private readonly ErrorDictionary _errorDict;
  private readonly TextProcessor _textProcessor;

  public Menu(ErrorDictionary errorDict, TextProcessor textProcessor)
  {
    _errorDict = errorDict;
    _textProcessor = textProcessor;
  }

  public void Show()
  {
    while (true)
    {
      Console.Clear();
      Console.WriteLine("1. Обработать файлы");
      Console.WriteLine("2. Добавить слова в словарь");
      Console.WriteLine("3. Показать словарь");
      Console.WriteLine("4. Выход");
      Console.Write("Ваш выбор: ");
      string userChoice = Console.ReadLine();

      switch (userChoice)
      {
        case "1":
          ProcessFiles();
          break;
        case "2":
          AddWords();
          break;
        case "3":
          _errorDict.Display();
          break;
        case "4":
          return;
      }
      Console.ReadKey();
    }
  }

  private void ProcessFiles()
  {
    Console.Write("Путь к папке: ");
    var path = Console.ReadLine();
    _textProcessor.ProcessDirectory(path);
    Console.WriteLine("Готово!");
  }

  private void AddWords()
  {
    Console.Write("Правильное слово: ");
    var word = Console.ReadLine();

    Console.Write("Ошибки (через запятую): ");
    var mistakes = Console.ReadLine().Split(',');

    _errorDict.AddEntry(word, new List<string>(mistakes));
    Console.WriteLine("Добавлено!");
  }
}