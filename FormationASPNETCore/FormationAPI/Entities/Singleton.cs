namespace FormationAPI.Entities
{
    public class Singleton
    {
        public static Singleton? singleton = null;

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (singleton == null)
            {
                singleton = new Singleton();
            }
            return singleton;
        }
    }
}
