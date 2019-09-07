using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform throwPoint;
    public Animator anim;
    public GameObject wbcBulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }

    void Throw()
    {
        anim.SetTrigger("Throw");
        Instantiate(wbcBulletPrefab, throwPoint.position, throwPoint.rotation);
    }
}
