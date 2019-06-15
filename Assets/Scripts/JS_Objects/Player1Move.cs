using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    // Player1 : Left Player.

    public float speed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        speed = TopGL.initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(0.0f, 0.0f, 0.0f);


        // update moveVector
        if (Input.GetKey(KeyCode.W))
        {
            moveVector.z = 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVector.x += -1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector.z = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVector.x += 1.0f;
        }


        // FORCE WILL BE WITH YOU
        rb.AddForce(speed * moveVector, ForceMode.Impulse);


    }

}
