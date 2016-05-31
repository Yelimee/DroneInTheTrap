public class SingleTon
{
    private static SingleTon instance;

    public static SingleTon getInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingleTon();
            }

            return instance;
        }
    }

    public int reached1 = 0;
    public int reached2 = 0;
    public int reached3 = 0;
    public int reached4 = 0;
    public int reached5 = 0;
}
