using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false; //ukrycie myszy
    }
    void OnGUI()
    {
        string health = "Health:" + PlayerHealth.currentHealth;  //wyswietl zycie
        GUI.Box(new Rect(Screen.width - 150, 60, 130, 20), health);
    }
}
