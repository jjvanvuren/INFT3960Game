using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public int totalScore;

    private static ScoreTracker instance = null;
    public static ScoreTracker Instance
    {
        get { return instance; }
    }


    private void Update()
    {
        GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = "Score: " + totalScore;
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

}
