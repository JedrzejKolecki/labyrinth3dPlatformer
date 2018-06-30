using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sterowanie : MonoBehaviour {

    public CharacterController MyController; //zmienna do ktorej mozemy sie odnosic w Inspektorze, przeciagnac na nia dodany CharacterController
    public Transform CameraTransform; 
    public float _speed=3f; //predkosc
    public float _gravityStrength = 5f;
    public float _jumpSpeed = 10f;
    float verticalVelocity; //pion
    bool CanJump = false;
    void Update ()
    {
        

        Vector3 MyVector = new Vector3(0,0,0); //wektor 3D, okresla sposob zmiany polozenia;; 0,0,0 nie przemiesci obiektu sam z siebie
        //input od gracza
        MyVector.x = Input.GetAxis("Horizontal"); //klasa Input zawiera wszystko co potrzeba do sterowania, grawitacja dodana automatycznie
        MyVector.z = Input.GetAxis("Vertical");
        MyVector = Vector3.ClampMagnitude(MyVector, 1f); //lagodne zejscie, generowanie przekatnej
        MyVector = MyVector *_speed*Time.deltaTime; //przyspieszenie ruchu 

        MyVector = CameraTransform.rotation*MyVector; //poruszanie sie relatywnie wzgledem kamery, zalezy od katu patrzenia
                                                      //poruszaj w zaleznosci od gracza
      
                                          
        verticalVelocity = verticalVelocity - _gravityStrength*Time.deltaTime; 

        if (Input.GetButtonDown("Jump"))
        {
          if(CanJump) verticalVelocity += _jumpSpeed; 
        }

        MyVector.y = verticalVelocity*Time.deltaTime; //Grawitacja wymaga przyspieszenia w trakcie spadania

        CollisionFlags flags = MyController.Move(MyVector);

        if ((flags & (CollisionFlags.Below|CollisionFlags.Sides)) != 0) //moze skoczyc jesli ma kolizje z czyms, czyli np stoi na czyms
        {
            CanJump = true;
            verticalVelocity = -3f; 
        }
        else
        CanJump = false; //jest w powietrzu, wiec nie skoczy
        MyController.Move(MyVector);
    }
}
