using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin_GUI : MonoBehaviour
{
    public static int coinCount;
    public static int coinToWin;
    void Awake() //reset wartosci przy starcie
    {
        coinCount = 0;
        coinToWin = 10;
    }
    void OnGUI() //wyswietlenie informacji o zebranych coinach 
    {
        string TotalCoins = "Total Coins: " + coinCount;
        string CoinsToWin = "Coins left: " + coinToWin;
        GUI.Box(new Rect(Screen.width-150, 20, 130, 20),TotalCoins);
        GUI.Box(new Rect(Screen.width - 150, 40, 130, 20), CoinsToWin);       
    }
    public void Update()
    {
        if (coinToWin == 0) //jezeli zebrano wszystkie to wyswietl komunikat o tym w nastepnej scenie
        {
            Final_status.finish = true;
            Debug.Log("Finished!");
            SceneManager.LoadScene("FailedWin"); //zaladuj scene z komunikatem
            //Application.LoadLevel("FailedWin");
        }
    }
}
