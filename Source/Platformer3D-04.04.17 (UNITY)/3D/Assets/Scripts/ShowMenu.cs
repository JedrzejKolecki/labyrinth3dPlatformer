using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShowMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        { 
            Cursor.visible = true; //ukrycie myszy
            SceneManager.LoadScene("Menu");
        }
    }
}
