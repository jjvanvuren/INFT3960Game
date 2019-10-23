using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    //Source for not destroying the object when loading a new scene: https://www.youtube.com/watch?v=i0coh71r-v8

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Play Global
    private static BackgroundMusic instance = null;
    public static BackgroundMusic Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Play Global End

    // Update is called once per frame
    void Update()
    {
        
    }
}
