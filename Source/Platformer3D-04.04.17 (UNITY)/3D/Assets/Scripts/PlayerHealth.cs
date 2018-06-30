using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public const int maxHealth = 100;
    public static int currentHealth = maxHealth;

    void Awake()
    {
       currentHealth = maxHealth; //reset zycia przy kazdym ponownym uruchomieniu
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
            Final_status.finish = false; //jezeli gracz przegral to wyswietl o tym komunikat w nastepnej scenie
            SceneManager.LoadScene("FailedWin");
            //Application.LoadLevel("FailedWin");
        }
    }
}
