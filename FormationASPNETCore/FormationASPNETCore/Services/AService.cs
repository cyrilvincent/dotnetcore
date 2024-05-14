namespace FormationASPNETCore.Services;

public abstract class AService : IService
{
    protected readonly ILogger Logger;

    protected AService(ILogger<AService> logger)
    {
        Logger = logger;
    }
}