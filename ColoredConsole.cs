using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ColoredConsole
{
    /// <summary>
    /// Класс для работы с консолью
    /// </summary>
	public class ColoredConsole
	{
		private ColoredConsoleStyle _default_stile = new ColoredConsoleStyle
		{
			ForegroundColor = Console.ForegroundColor,
			BackgroundColor = Console.BackgroundColor,
			TabSize = 3,
			TabSpace = ' '
		};

        /// <summary>
        /// Словарь стилей.
        /// </summary>
		public Dictionary<string, ColoredConsoleStyle> Styles = new Dictionary<string, ColoredConsoleStyle>();

		private ColoredConsoleStyle _current_style;
		private bool _add_date_time;

        /// <summary>
        /// Заголовок окна консоли
        /// </summary>
		public string Title
		{
			get
			{
				return Console.Title;
			}
			set
			{
				Console.Title = value;
			}
		}

        /// <summary>
        /// Конструктор
        /// </summary>
		public ColoredConsole()
		{
			Styles.Add("default", _default_stile);
			_current_style = _default_stile;
		}

        /// <summary>
        /// Сброс стиля
        /// </summary>
		public void Reset()
		{
			Console.ForegroundColor = _default_stile.ForegroundColor;
			Console.BackgroundColor = _default_stile.BackgroundColor;
		}

        /// <summary>
        /// Утановка стиля
        /// </summary>
        /// <param name="color">Цвет текста</param>
        /// <param name="bgcolor">Цвет фона</param>
        /// <returns></returns>
		public ColoredConsole SetDefault(ConsoleColor color, ConsoleColor bgcolor)
		{
			_default_stile.BackgroundColor = bgcolor;
			_default_stile.ForegroundColor = color;
			return this;
		}

        /// <summary>
        /// Размер табуляции
        /// </summary>
        /// <param name="size">Кол-во пробелов</param>
        /// <returns></returns>
		public ColoredConsole SetTabSize(int size)
		{
			_current_style.TabSize = size;
			return this;
		}

        /// <summary>
        /// Задает символ пробела
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
		public ColoredConsole SetSpace(char space)
		{
			_current_style.TabSpace = space;
			return this;
		}

        /// <summary>
        /// Задает цвет текста
        /// </summary>
        /// <param name="color">Цвет текста</param>
        /// <returns></returns>
		public ColoredConsole Color(ConsoleColor color)
		{
			_current_style.ForegroundColor = color;
			return this;
		}

        /// <summary>
        /// Задает цвет фона
        /// </summary>
        /// <param name="color">Цвет фона</param>
        /// <returns></returns>
		public ColoredConsole BgColor(ConsoleColor color)
		{
			_current_style.BackgroundColor = color;
			return this;
		}

        /// <summary>
        /// Задает ранее сохраненный стиль
        /// </summary>
        /// <param name="style">Наименование стиля</param>
        /// <returns></returns>
		public ColoredConsole SetStyle(string style)
		{
			foreach(KeyValuePair<string, ColoredConsoleStyle> st in Styles)
			{
				if (st.Key == style)
				{
					_current_style = st.Value;
					return this;
				}
			}
			_current_style = _default_stile;
			throw new UnknownStyleException(style);
		}

		private void _SetStyle()
		{
			Console.ForegroundColor = _current_style.ForegroundColor;
			Console.BackgroundColor = _current_style.BackgroundColor;
		}

        /// <summary>
        /// Устанавливает заголовок окна консоли
        /// </summary>
        /// <param name="title">Текст заголовка</param>
        /// <returns></returns>
		public ColoredConsole SetTitle(string title)
		{
			Console.Title = title;
			return this;
		}

        /// <summary>
        /// Задает отображение даты-времени в начале при выводе строки
        /// </summary>
        /// <param name="add_date_time">Флаг даты-времени</param>
        /// <returns></returns>
		public ColoredConsole SetAddDateTime(bool add_date_time) {
			_add_date_time = add_date_time;
			return this;
		}

        /// <summary>
        /// Читает ввод
        /// </summary>
        /// <returns></returns>
		public string ReadLine()
		{
			return Console.ReadLine();
		}

        /// <summary>
        ///  Получает следующий нажатый пользователем символ или функциональную клавишу. Нажатая
        ///     клавиша может быть отображена в окне консоли.
        /// </summary>
        /// <returns></returns>
		public ConsoleKeyInfo ReadKey()
		{
			return Console.ReadKey();
		}

        /// <summary>
        ///  Получает следующий нажатый пользователем символ или функциональную клавишу. Нажатая
        ///     клавиша может быть отображена в окне консоли.
        /// </summary>
        /// <param name="intercept">Определяет, следует ли отображать нажатую клавишу в окне консоли. Значение true,
        ///     чтобы не отображать нажатую клавишу; в противном случае — значение false.</param>
        /// <returns></returns>
		public ConsoleKeyInfo ReadKey(bool intercept)
		{
			return Console.ReadKey(intercept);
		}

        /// <summary>
        /// Читает следующий символ из стандартного входного потока.
        /// </summary>
        /// <returns></returns>
		public int Read()
		{
			return Console.Read();
		}

        /// <summary>
        /// Записывает заданное строковое значение в стандартный выходной поток.
        /// </summary>
        /// <param name="value">Значение для записи.</param>
		public void Write(string value)
		{
			_SetStyle();
			Console.Write(value.Replace("\t", new string(_current_style.TabSpace, _current_style.TabSize)));
			Reset();
		}

        /// <summary>
        /// Записывает заданное строковое значение, за которым следует текущий признак конца
        ///    строки, в стандартный выходной поток.
        /// </summary>
        /// <param name="value">Значение для записи.</param>
		public void WriteLine(string value)
		{
			_SetStyle();
			if (_add_date_time)
				Console.Write("{0} ", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.ffff"));
			Console.WriteLine(value.Replace("\t", new string(_current_style.TabSpace, _current_style.TabSize)));
			Reset();
		}
	}

    /// <summary>
    /// Класс стиля
    /// </summary>
	public class ColoredConsoleStyle
	{
        /// <summary>
        /// Цвет текста
        /// </summary>
		public ConsoleColor ForegroundColor { get; set; }
        /// <summary>
        /// Цвет фона
        /// </summary>
		public ConsoleColor BackgroundColor { get; set; }
        /// <summary>
        /// Размер таблуяции
        /// </summary>
		public int TabSize { get; set; }
        /// <summary>
        /// Символ табуляции
        /// </summary>
		public char TabSpace { get; set; }
	}

    /// <summary>
    /// Синглтон для работы с консолью
    /// </summary>
	public sealed class ConsoleHelper
	{
		private static volatile ColoredConsole _instance;
		private static readonly object _lock = new object();

		private ConsoleHelper()
		{
		}

        /// <summary>
        /// Объект для работы с консолью
        /// </summary>
		public static ColoredConsole Console
		{
			get
			{
				if (_instance == null)
				{
					lock (_lock)
					{
						if (_instance == null)
							_instance = new ColoredConsole();
					}
				}
				return _instance;
			}
		}
	}

    /// <summary>
    /// Класс ошибки неизвестного стиля
    /// </summary>
	public class UnknownStyleException : Exception
	{
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="style">Наименование стиля</param>
		public UnknownStyleException(string style):base(string.Format("Unknown style \"{0}\"", style))
		{
		
		}
	}
}
