using System;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Участник планирования.
  /// </summary>
  public class User : Entity
  {
    /// <summary>
    /// Имя участника.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Токен.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id участника.</param>
    /// <param name="name">Имя участника.</param>
    /// <param name="token">Токен участника.</param>
    public User(Guid id, string name, string token)
    {
      this.Id = id;
      this.Name = name;
      this.Token = token;
    }
  }
}
