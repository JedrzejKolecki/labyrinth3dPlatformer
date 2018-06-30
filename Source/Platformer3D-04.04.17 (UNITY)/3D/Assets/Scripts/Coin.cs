using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public float rotateSpeed = 5f;
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed); //ciagle obracanie sie coina
    }
    void OnTriggerEnter(Collider collider)
    {
        switch(collider.gameObject.name) //jesli dojdzie do kolizji z graczem, to obiekt (this) ktoremu jest przypisany skrypt zostanie zniszczony
        {
            case "Player":
                    PlaySound.play_Audio = true; //w wypadku kolizji odtworz dzwiek (skrypt PlaySound)
                    Coin_GUI.coinCount++;
                    Coin_GUI.coinToWin--; 
                    Debug.Log(Coin_GUI.coinCount);
                    Destroy(this.gameObject); //zniszcz obiekt z hierarchii 
                    break; 
        }
    }
    
}
