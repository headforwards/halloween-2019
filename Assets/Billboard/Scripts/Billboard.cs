using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Billboard : MonoBehaviour
{
    TextMeshPro billboardText;

    public string Text = "Billboard text";

    void Start()
    {
        billboardText = GetComponentInChildren<TextMeshPro>();
        SetBillboardText(Text);
    }

    public void SetBillboardText(string text)
    {
        billboardText.text = text;
    }

}
