namespace Flowsy.Repository.Core;

public interface IEntityTranslation : IEntity
{
    public string CultureId { get; set; }
}