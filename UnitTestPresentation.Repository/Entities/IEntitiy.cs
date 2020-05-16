namespace UnitTestPresentation.Repository.Entities
{
    public interface IEntitiy<T>
    {
        T Id { get; set; }
    }
}
