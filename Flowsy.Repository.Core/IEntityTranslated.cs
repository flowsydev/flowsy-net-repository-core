namespace Flowsy.Repository.Core;

/// <summary>
/// Represents the translated version of an entity for a specific culture.
/// Classes implementing this interface shall inherit from the entity being translated. 
/// </summary>
public interface IEntityTranslated : IEntity
{
    /// <summary>
    /// The culture identifier: en-US, es-MX, etc.
    /// </summary>
    public string CultureId { get; set; }
    
    /// <summary>
    /// The optional culture name: English (United States), Español (México), etc.
    /// </summary>
    public string? CultureName { get; set; }
    
    /// <summary>
    /// The optional language identifier: en, es, etc.
    /// </summary>
    public string? LanguageId { get; set; }
    
    /// <summary>
    /// The optional language name: English, Español, etc.
    /// </summary>
    public string? LanguageName { get; set; }
    
    /// <summary>
    /// The optional country identifier: US, MX, etc.
    /// </summary>
    public string? CountryId { get; set; }
    
    /// <summary>
    /// The optional country name: United States, México, etc.
    /// </summary>
    public string? CountryName { get; set; }
}