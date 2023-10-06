using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevel : MonoBehaviour
{

    public void OnTriggerEnter(Collider other){        
        if(other.name == "Player"){
            GameManager.Instance.NextLevel();
        }
    }

}
