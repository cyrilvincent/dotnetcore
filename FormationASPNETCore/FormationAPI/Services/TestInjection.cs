using FormationAPI.Entities;

namespace FormationAPI.Services
{
    public interface ITestInjection
    {
        IEntity Entity { get; set; }
    }

    public class TestInjection : ITestInjection
    {
        public IEntity Entity { get; set; }

        public TestInjection(IEntity entity)
        {
            Entity = entity;
        }
    }
}
