using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionScreen : MonoBehaviour
{
    public bool isFinalScreen;
    public int finalScore;

    // Start is called before the first frame update
    void Start()
    {
        // Enable the mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (isFinalScreen)
        {
            finalScore = GameObject.Find("Score").GetComponent<ScoreTracker>().totalScore;
            GameObject.Find("FinalScoreText").GetComponent<TextMeshProUGUI>().text = "Final Score: " + finalScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
