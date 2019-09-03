using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameMaster : MonoBehaviour
{
    //Source: https://www.youtube.com/watch?v=P-Ywfxg1_M4&list=PLq3pyCh4J1B2uSvypNOK_nxYKBt5mMCJt&index=23
    public int wbcCount;
    public TextMeshProUGUI wbcCountText;

    void Update()
    {
        wbcCountText.text = ("White Blood Cells: " + wbcCount);

    }
}
