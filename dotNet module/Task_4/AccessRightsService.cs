using System;
using System.Collections.Generic;
using System.Text;

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
    /// Если он установлен, остальные флаги игнорируются. 
    /// </remarks>
    AccessDenied = 64
  }

  /// <summary>
  /// Показать разрешенные права.
  /// </summary>
  public class AccessRightsService
  {
    /// <summary>
    /// Показать разрешенные права.
    /// </summary>
    /// <param name="accessRights">Разрешенные права.</param>
    /// <returns>Возвращает строку содержащую список прав.</returns>
    public static string GetAccessRightsInfo(AccessRights accessRights)
    {
      if (accessRights.HasFlag(AccessRights.AccessDenied))
        return "Доступ запрещен.";
      else
        return "У вас есть права: " + accessRights;
    }
  }
}
