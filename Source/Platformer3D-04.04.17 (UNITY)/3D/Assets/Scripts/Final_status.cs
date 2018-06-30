using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_status : MonoBehaviour
{
    public static bool finish;
    public Text StatusText;

    void Start()
    {
        Cursor.visible = true;//ukrycie myszy
    }

    public void Update()
    {
        if (finish==true)
        {
            StatusText.text = "Congratulations!";
        }
        else
        {
            StatusText.text = "Try again!";
        }
    }

}
