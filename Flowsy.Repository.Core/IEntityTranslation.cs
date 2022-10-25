namespace Flowsy.Repository.Core;

/// <summary>
/// Represents the object that holds an entity's translation for a specific culture.
/// </summary>
public interface IEntityTranslation : IEntity
{
    /// <summary>
    /// The culture identifier: en-US, es-MX, etc.
    /// </summary>
    public string CultureId { get; set; }
}