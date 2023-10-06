using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrap : MonoBehaviour
{
    public float rotationSpeed  = 50.0f;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(new Vector3(0, 1, 0) * rotationSpeed * Time.deltaTime);
    }

    // void FixedUpdate()
    // {
    //     Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 1, 0) * rotationSpeed * Time.fixedDeltaTime);
    //     rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    // }
}
