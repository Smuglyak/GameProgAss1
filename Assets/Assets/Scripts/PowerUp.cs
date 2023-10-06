using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject particleSystemToSpawn;
    private void OnTriggerEnter(Collider other){

        if(other.name == "Player"){

            CharacterMovement.bluePickedUp = true;
            CharacterMovement.maxJumpCount = 2;
            // Spawn and destroy particle s ystem
            Destroy(Instantiate(particleSystemToSpawn,transform.position, transform.rotation),2);

            // Destroy Pickup 
           // Destroy(gameObject);
            gameObject.SetActive(false);
            Invoke("Reappear", 30.0f);
        }
    }

    void Reappear(){
        gameObject.SetActive(true);         
    }

    void Update(){
        transform.Rotate(new Vector3(0f, 0f, 100f) * Time.deltaTime);
    }
}
