using System.Text.RegularExpressions;

public class PhoneFormatter
{
  public string Format(string text)
  {
    var pattern = @"\((\d{3})\)\s*(\d{3})-(\d{2})-(\d{2})";
    var replacement = "+380 $1 $2 $3 $4";
    return Regex.Replace(text, pattern, replacement);
  }
}