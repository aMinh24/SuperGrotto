using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager<T> : MonoBehaviour where T: BaseManager<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Object.FindObjectOfType<T>();
                if (instance != null)
                {
                    Debug.Log("No Singleton Instance");
                }
            }
            return instance;
        }
    }
    public static bool HasInstance
    {
        get
        {
            return (instance != null);
        }
    }

    protected virtual void Awake()
    {
        CheckInstance();
    }
    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(this);
            return true;
        }
        else if (instance == this)
        {
            DontDestroyOnLoad(this);
            return true;
        }
        Object.Destroy(this.gameObject);
        return false;
    }
}
