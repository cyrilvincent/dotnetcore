namespace FormationAPI.Entities
{
    public enum ModeFactory { Transient, Scoped, Singleton}

    public class CompteFactory
    {
        public static Compte? Factory(ModeFactory mode)
        {
            if (mode == ModeFactory.Transient)
            {
                return new Compte();
            }
            else if (mode == ModeFactory.Singleton)
            {
                return null; // Programme le singleton
            }
            else
            {
                return null; // ??
            }
        }
    }
}
