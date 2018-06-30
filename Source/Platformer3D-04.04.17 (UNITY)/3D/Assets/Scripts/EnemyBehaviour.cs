using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    Transform find_Player;
    public float enemy_RotSpeed = 3.0f; //predkosc obrotu
    public float enemy_MoveSpeed = 3.0f; //predkosc poruszania sie wroga
    public int damage_Amount = 10; //ilosc obrazen
   
    void Start ()
    {
        find_Player = GameObject.FindGameObjectWithTag("PlayerEmpty").transform; //utworzy wzkaznik na obiekt z tagiem PlayerEmpty
        
    }
	void Update ()
    {
        //lokalizowanie/spostrzeganie gracza
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(find_Player.position - transform.position), enemy_RotSpeed * Time.deltaTime);
      
        //poruszanie się w kierunku gracza
        transform.position += transform.forward * enemy_MoveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag.Equals("PlayerEmpty") == true)
        {
            PlaySound.play_Audio_Ghost = true;
            var dmg = collision.gameObject;
            var lower_health = dmg.GetComponent<PlayerHealth>();
            if (lower_health != null)
            {
                lower_health.TakeDamage(damage_Amount); //zadaj 10 pkt obrazen w wyniku kolizji z obiektem o tagu Player
            }
        }
        Destroy(this.gameObject);
    }
}
