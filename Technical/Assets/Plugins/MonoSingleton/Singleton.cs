public abstract class Singleton<T>
    where T : Singleton<T>, new()
{
    private static T m_Instance = null;
    public static T Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new T();
                m_Instance.Init();
            }
            return m_Instance;
        }
    }

    // This function is called when the instance is used the first time
    // Put all the initializations you need here
    public virtual void Init()
    {
    }
}