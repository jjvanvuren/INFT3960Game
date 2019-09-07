using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EryDeath : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform character;
    public Animator anim;

    private void Update()
    {
        var player = GameObject.Find("Ery").GetComponent<CharacterController2D>();
        int iLives = player.CharacterLives;
        if (iLives < 1)
        {
            anim.SetTrigger("Dead");
            character.transform.position = respawnPoint.transform.position;
        }
    }
}
