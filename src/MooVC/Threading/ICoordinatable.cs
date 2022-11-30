namespace MooVC.Threading;

public interface ICoordinatable<T>
    where T : notnull
{
    T GetKey();
}