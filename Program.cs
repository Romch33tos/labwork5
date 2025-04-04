class Program
{
  static void Main()
  {
    var errorDict = new ErrorDictionary();
    var phoneFormatter = new PhoneFormatter();
    var textProcessor = new TextProcessor(errorDict, phoneFormatter);
    var menu = new Menu(errorDict, textProcessor);

    menu.Show();
  }
}