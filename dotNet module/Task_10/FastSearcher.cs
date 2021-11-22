using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
  /// <summary>
  /// Класс с методом поиска в коллекции значений, соответствующих заданному условию.
  /// </summary>
  public class FastSearcher
  {
    private Task[] tasks;
    private int maxParallelTasks;
    private int minCountValuesInTask;

    /// <summary>
    /// Максимальное количество паралельных задач(потоков).
    /// </summary>
    public int MaxParallelTasks
    {
      get => this.maxParallelTasks;
      set
      {
        if (value >= 1)
          this.maxParallelTasks = value;
      }
    }

    /// <summary>
    /// Минимальное количество значений в одной задаче.
    /// </summary>
    public int MinCountValuesInTask
    {
      get => this.minCountValuesInTask;
      set
      {
        if (value >= 1)
          this.minCountValuesInTask = value;
      }
    }

    public FastSearcher()
    {
      this.maxParallelTasks = 10;
      this.minCountValuesInTask = 4;
    }

    /// <summary>
    /// Инициализирует задачи.
    /// </summary>
    /// <param name="collectionSize">Количество значений коллекции.</param>
    private void InitializeTasks(int collectionSize)
    {
      int taskCount = collectionSize / this.minCountValuesInTask; // общее количество тасков
      if (taskCount > this.maxParallelTasks)
        taskCount = this.MaxParallelTasks;
      this.tasks = new Task[taskCount];
    }

    /// <summary>
    /// Добавляет в колекцию resultList значения удоавлетворяющие условию делегата.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">Коллекция.</param>
    /// <param name="comparator">Условие для отбора элементов.</param>
    /// <param name="resultList">Результирующая коллекция.</param>
    public void Search<T>(IEnumerable<T> collection, Predicate<T> comparator, List<T> resultList)
    {
      for (int i = 0; i < collection.Count(); i++)
        if (comparator(collection.ElementAt(i)))
          resultList.Add(collection.ElementAt(i));
    }

    /// <summary>
    /// Находит в коллекции значения, соответствующих заданному условию.
    /// </summary>
    /// <param name="collection">Коллекция.</param>
    /// <param name="comparator">Условие для отбора элементов.</param>
    /// <returns>Возвращает generic-колекцию со значениями соответствующих условию.</returns>
    public IEnumerable<T> SearchValues<T>(IEnumerable<T> collection, Predicate<T> comparator)
    {
      this.InitializeTasks(collection.Count());
      var result = new List<T>();

      int taskSize = collection.Count() / this.tasks.Length; // Количество элементов на одном таске
      for (int i = 0; i < this.tasks.Length; i++)
      {
        var mediateColecction = collection.Skip(taskSize * i).Take(taskSize);
        this.tasks[i] = Task.Factory.StartNew(() => this.Search(mediateColecction, comparator, result));
      }

      Task.WaitAll(this.tasks);
      return result;
    }
  }
}
