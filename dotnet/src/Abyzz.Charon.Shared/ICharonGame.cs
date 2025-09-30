namespace Charon;

public interface ICharonGame: IDisposable
{
    void Initialize();
    void Run();
    void Shutdown();
}
