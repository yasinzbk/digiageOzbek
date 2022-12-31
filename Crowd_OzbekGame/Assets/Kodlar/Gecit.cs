using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gecit : MonoBehaviour
{
    public bool carpmaMi;
    public int miktar;

    public TextMeshPro text;

    private void Start()
    {
        if (carpmaMi)
        {
            text.text = "x" + miktar.ToString();
        }
        else
        {
            text.text = "+" + miktar.ToString();

        }
    }
}
