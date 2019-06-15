using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    // Player2 : Right Player.

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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveVector.z = 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVector.x += -1.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveVector.z = -1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVector.x += 1.0f;
        }


        // FORCE WILL BE WITH YOU
        rb.AddForce(TopGL.speedmult * speed * moveVector, ForceMode.Impulse);


    }
}
