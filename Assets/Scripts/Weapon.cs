using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform throwPoint;
    public Animator anim;
    public GameObject wbcBulletPrefab;

    public GameObject gameMaster;

    private int wbcCount = 0;

    // Update is called once per frame
    void Update()
    {
        var gm = gameMaster.GetComponent<gameMaster>();
        wbcCount = gm.wbcCount;

        if (Input.GetButtonDown("Fire1") && wbcCount > 0)
        {
            Throw();
            gm.wbcCount -= 1;
        }
    }

    void Throw()
    {
        anim.SetTrigger("Throw");
        Instantiate(wbcBulletPrefab, throwPoint.position, throwPoint.rotation);
    }
}
