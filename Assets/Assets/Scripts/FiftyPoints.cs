using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiftyPoints : MonoBehaviour
{
  public GameObject particleSystemToSpawn;  

    private void OnTriggerEnter(Collider other){

        if(other.name == "Player"){
            
            // Spawn and destroy particle s ystem
            Destroy(Instantiate(particleSystemToSpawn,transform.position, transform.rotation),2);
            GameManager.Instance.IncrementScore();
            // Destroy Pickup 

           Destroy(gameObject);
            // gameObject.SetActive(false);
            // Invoke("Reappear", 2.0f);
        }
    }

    void Update(){
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
    }

    

    // void Reappear(){
    //     gameObject.SetActive(true);        
    // }
}
