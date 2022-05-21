using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class batNumber : MonoBehaviour
{
    public int batNum;
    public TMP_Text text;
    void Start()
    {
        batNum = Random.Range(1, 9);
        text.text = batNum.ToString();
    }
}
