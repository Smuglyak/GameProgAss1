using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneBehavior : MonoBehaviour
{
    public GameObject Player;
    Vector3 originalPlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPlayerPosition = Player.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void OnTriggerEnter(Collider other){
        if(other.name == "Player"){
            originalPlayerPosition = Player.transform.position;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player") {
        
        Player.transform.position = originalPlayerPosition;
        }
    }

    public void RestartGame()
    {
        Player.transform.position = originalPlayerPosition;
    }

}
