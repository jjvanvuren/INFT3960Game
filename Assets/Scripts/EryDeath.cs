using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EryDeath : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform character;
    public GameObject Ery;

    public Animator anim;

    private void Update()
    {
        var player = GameObject.Find("Ery").GetComponent<CharacterController2D>();
        int iLives = player.CharacterLives;
        if (iLives < 1)
        {
            
            player.CharacterLives = 4;
            GameObject.Find("Ery").GetComponent<PlayerMovement>().enabled = false;
            anim.SetTrigger("Dead");
            Invoke("Die", 2f);
            
        }
    }

    void Die()
    {
        character.transform.position = respawnPoint.transform.position;
        GameObject.Find("Ery").GetComponent<PlayerMovement>().enabled = true;
    }
}
