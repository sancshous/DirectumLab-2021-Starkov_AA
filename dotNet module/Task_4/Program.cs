using System;
using System.Data;
using System.Text;
using Task_2;

namespace Task_4
{

  /// <summary>
  /// Тип прав.
  /// </summary>
  [Flags, Serializable]
  public enum AccessRights : byte
  {
    /// <summary>
    /// Просмотр.
    /// </summary>
    View = 1,

    /// <summary>
    /// Выполнение.
    /// </summary>
    Run = 2,

    /// <summary>
    /// Добавление.
    /// </summary>
    Add = 4,

    /// <summary>
    /// Изменение.
    /// </summary>
    Edit = 8,

    /// <summary>
    /// Утверждение.
    /// </summary>
    Ratify = 16,

    /// <summary>
    /// Удаление.
    /// </summary>
    Delete = 32,

    /// <summary>
    /// Нет доступа.
    /// </summary>
    /// <remarks>
    /// Этот флаг имеет максимальный приоритет.
    /// Если он установлен, остальные флаги игнорируются 
    /// </remarks>
    AccessDenied = 64
  }

  public class Program
  {
    public static void ShowAccessRights(AccessRights accessRights)
    {
      switch (accessRights)
      {
        case AccessRights.View:
          Console.WriteLine("У вас есть разрешения на: Просмотр");
          break;
        case AccessRights.Run:
          Console.WriteLine("У вас есть разрешения на: Выполнение, Просмотр");
          break;
        case AccessRights.Add:
          Console.WriteLine("У вас есть разрешения на: Добавление, Выполнение, Просмотр");
          break;
        case AccessRights.Edit:
          Console.WriteLine("У вас есть разрешения на: Изменение, Добавление, Выполнение, Просмотр");
          break;
        case AccessRights.Ratify:
          Console.WriteLine("У вас есть разрешения на: Утверждение, Изменение, Добавление, Выполнение, Просмотр");
          break;
        case AccessRights.Delete:
          Console.WriteLine("У вас есть разрешения на: Удаление, Утверждение, Изменение, Добавление, Выполнение, Просмотр");
          break;
        case AccessRights.AccessDenied:
          Console.WriteLine("У вас нет доступа.");
          break;
        default:
          Console.WriteLine("Неизвестное наименование прав доступа! Попробуйте ввести другое.");
          break;
      }
    }
    public static string parseTable(DataSet dataset, string rowSeparator, string columnSeparator)
    {
      StringBuilder sb = new StringBuilder();

      foreach (DataRow dr in dataset.Tables[0].Rows)
      {
        foreach (var cell in dr.ItemArray)
        {
          if (cell.Equals(dr.ItemArray[^1]))
          {
            sb.Append(cell);
            sb.Append(columnSeparator);
          }
          else
          {
            sb.Append(cell);
            sb.Append(rowSeparator);
          }
        }
      }
      string value = sb.ToString();
      return value;
    }

    public static void Main(string[] args)
    {
      //Задание 2
      Console.WriteLine("Задание 2");
      DataSet bookStore = new DataSet("BookStore");
      DataTable booksTable = new DataTable("Books");
      // добавляем таблицу в dataset
      bookStore.Tables.Add(booksTable);

      // создаем столбцы для таблицы Books
      DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
      idColumn.Unique = true; // столбец будет иметь уникальное значение
      idColumn.AllowDBNull = false; // не может принимать null
      idColumn.AutoIncrement = true; // будет автоинкрементироваться
      idColumn.AutoIncrementSeed = 1; // начальное значение
      idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки

      DataColumn nameColumn = new DataColumn("Name", Type.GetType("System.String"));
      DataColumn priceColumn = new DataColumn("Price", Type.GetType("System.Decimal"));
      priceColumn.DefaultValue = 100; // значение по умолчанию
      DataColumn discountColumn = new DataColumn("Discount", Type.GetType("System.Decimal"));
      discountColumn.Expression = "Price * 0.2";

      booksTable.Columns.Add(idColumn);
      booksTable.Columns.Add(nameColumn);
      booksTable.Columns.Add(priceColumn);
      booksTable.Columns.Add(discountColumn);
      // определяем первичный ключ таблицы books
      booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["Id"] };

      DataRow row = booksTable.NewRow();
      row.ItemArray = new object[] { null, "Война и мир", 200 };
      booksTable.Rows.Add(row); // добавляем первую строку
      booksTable.Rows.Add(new object[] { null, "Отцы и дети", 170 }); // добавляем вторую строку

      Console.Write("\tИд \tНазвание \tЦена \tСкидка");
      Console.WriteLine();
      foreach (DataRow r in booksTable.Rows)
      {
        foreach (var cell in r.ItemArray)
          Console.Write("\t{0}", cell);
        Console.WriteLine();
      }
      Console.WriteLine(parseTable(bookStore, "|", ";"));

      //Задание 3
      Console.WriteLine("Задание 3");
      ShowAccessRights(AccessRights.Edit);
    }
  }
}
