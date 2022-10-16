namespace Flowsy.Repository.Core;

public interface IEntityTranslated : IEntity
{
    public string CultureId { get; set; }
    public string? CultureName { get; set; }
    
    public string? LanguageId { get; set; }
    public string? LanguageName { get; set; }
    
    public string? CountryId { get; set; }
    public string? CountryName { get; set; }
}