using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreText : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void setScore(int value)
    {
        text.text = value.ToString();
    }
}
