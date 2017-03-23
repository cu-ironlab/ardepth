using UnityEngine;
using System.Collections;

public class GlobalControl : MonoBehaviour {

    public static GlobalControl Instance;
    public static int counter = 0;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
