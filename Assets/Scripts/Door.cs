using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int LevelToLoad;
    public bool levelHasPlatelets;
    public int plateletsNeeded;

    private gameMaster gm;

    void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<gameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (levelHasPlatelets == true)
        {
            
            if (col.CompareTag("Player") && (gm.plateletCount >= plateletsNeeded))
            {
                SceneManager.LoadScene(LevelToLoad);
            }
        } else
        {
            if (col.CompareTag("Player"))
            {
                SceneManager.LoadScene(LevelToLoad);
            }
        }

    }

}
