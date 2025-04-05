using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class TextProcessor
{
  private readonly ErrorDictionary _errorDict;
  private readonly PhoneFormatter _phoneFormatter;

  public TextProcessor(ErrorDictionary errorDict, PhoneFormatter phoneFormatter)
  {
    _errorDict = errorDict;
    _phoneFormatter = phoneFormatter;
  }

  public void ProcessDirectory(string path)
  {
    foreach (var file in Directory.GetFiles(path, "*.txt"))
    {
      var content = File.ReadAllText(file, Encoding.UTF8);
      var processed = ProcessText(content);
      File.WriteAllText(file, processed, Encoding.UTF8);
    }
  }

  private string ProcessText(string text)
  {
    text = FixSpelling(text);
    text = _phoneFormatter.Format(text);
    return text;
  }

  private string FixSpelling(string text)
  {
    foreach (var entry in _errorDict.GetDictionary())
    {
      foreach (var mistake in entry.Value)
      {
        text = Regex.Replace(text, $@"\b{mistake}\b", entry.Key, RegexOptions.IgnoreCase);
      }
    }
    
    return text;
  }
}