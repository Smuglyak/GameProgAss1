using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretComponent : MonoBehaviour
{
    public GameObject particleSystemToSpawn;
    public GameObject player;
    public Slider healthBar;
    public Slider awarenessBar;
    public Text awarenessText;
    public Vector3 intialFowardVector;
    public Vector3 playerDirection;
    public float maxAngle = 45;
    public float maxDistance = 100;
    public float health = 100;
    public float maxHealth = 100;
    public float awarnessTimer = 0.0f;
    public float fullAwarnessTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        intialFowardVector = transform.forward;  
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }


    // Update is called once per frame
    void Update()
    {
        
        UpdateTurretRotation();
        UpdateTurretAwareness(SeePlayer());
               
    }
    
    public void UpdateTurretAwareness(bool seePlayer)
    {
       awarnessTimer = (seePlayer)?awarnessTimer + Time.deltaTime : awarnessTimer - Time.deltaTime;
       float awarenessRatio = Mathf.Clamp(awarnessTimer / fullAwarnessTime, 0.0f, 1.0f);
       awarenessBar.value = awarenessRatio;

       if (awarnessTimer >= fullAwarnessTime)
       {
            awarenessText.enabled = true;
            // TO DO UPDATE ()
       }
       else 
       {
            awarenessText.enabled = false;
       }
       
    }


    public void ProcessHit()
    {
        health -= 10;
        healthBar.value = health;
        if(health<0)
        {
            Destroy(gameObject);
        }
    }


    public void UpdateTurretRotation()
    {
        if (SeePlayer())
        {
            playerDirection = new Vector3(playerDirection.x,0,playerDirection.z);
            transform.LookAt(player.transform.position + playerDirection);
        }

    }
    public bool SeePlayer()
    {
        // Figuring out where to look at the player
        playerDirection = player.transform.position - transform.position;
        // Is the player close enough to see
        if(playerDirection.magnitude < maxDistance)
        {
            // Figuring out if the angle of direction to the player in our limit
            // Do not forget to normalize your vectors
            Vector3 normPlayerDirection = Vector3.Normalize(playerDirection);
            float dotProduct = Vector3.Dot(intialFowardVector, normPlayerDirection);
            float angle = Mathf.Acos(dotProduct);
            float degreeAngle = angle * Mathf.Rad2Deg;
            if(degreeAngle < maxAngle)
            {
                // Is there something in between me and the player 
                Ray ray = new Ray(transform.position, normPlayerDirection);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.tag == "Player")
                    {
                        return true;
                    }
                }

            }
        }
        return false;
       
    }
}