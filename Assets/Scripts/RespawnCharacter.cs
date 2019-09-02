using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCharacter : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        character.transform.position = respawnPoint.transform.position;
    }
}
