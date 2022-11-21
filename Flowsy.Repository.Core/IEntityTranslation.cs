namespace Flowsy.Repository.Core;

/// <summary>
/// Represents the translated version of an entity for a specific culture.
/// </summary>
public interface IEntityTranslation : IEntity
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
    public string? TranslationLanguageId { get; set; }
    
    /// <summary>
    /// The optional language name: English, Español, etc.
    /// </summary>
    public string? TranslationLanguageName { get; set; }
    
    /// <summary>
    /// The optional country identifier: US, MX, etc.
    /// </summary>
    public string? TranslationCountryId { get; set; }
    
    /// <summary>
    /// The optional country name: United States, México, etc.
    /// </summary>
    public string? TranslationCountryName { get; set; }
}