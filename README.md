# Miscellaneous.Net
Разные полезности

Класс **ColoredConsole** - самостоятельная реализация "цветной консоли".

Пример:
```
ConsoleHelper.Console.SetTitle("Colored Console app");
ConsoleHelper.Console.SetAddDateTime(true);
ConsoleHelper.Console.Styles.Add("error", new ColoredConsoleStyle
{
    BackgroundColor = ConsoleColor.White,
    ForegroundColor = ConsoleColor.DarkRed,
    TabSize = 5,
    TabSpace = '='
});
ConsoleHelper.Console.Styles.Add("message", new ColoredConsoleStyle
{
    BackgroundColor = ConsoleColor.Black,
    ForegroundColor = ConsoleColor.Green,
    TabSize = 3,
    TabSpace = '='
});

ConsoleHelper.Console.SetSpace('=').BgColor(ConsoleColor.White).Color(ConsoleColor.DarkGreen).WriteLine("	Тест");
ConsoleHelper.Console.SetSpace('+').BgColor(ConsoleColor.Blue).Color(ConsoleColor.White).WriteLine("	Тест");
ConsoleHelper.Console.SetStyle("error").WriteLine("\tError");
ConsoleHelper.Console.SetStyle("message").WriteLine("\t\tMessage");
try
{
    ConsoleHelper.Console.SetStyle("unknown").WriteLine("\tUnknown");
}
catch (Exception ex)
{
    ConsoleHelper.Console.SetStyle("error").WriteLine(ex.Message);
}
```
Класс **DateTimeExtentions** - предоставляет методы-расширения для конвертации типа DateTime в Double

Пример:
```
DateTime dt = DateTime.Now;
double d = dt.ConvertDateTimeToDouble();
Console.WriteLine(d); //out: 20190326151922
DateTime temp = d.ConvertDateTimeFromDouble();
Console.WriteLine(temp); //out: 26.03.2019 15:19:22
```
