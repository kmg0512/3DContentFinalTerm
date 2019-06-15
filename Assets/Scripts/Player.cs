using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = TopGL.initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3(0.0f, 0.0f, 0.0f);

        // update moveVector
        if (Input.GetKey(KeyCode.W)) moveVector.z = 1.0f;
        if (Input.GetKey(KeyCode.A)) moveVector.x += -1.0f;
        if (Input.GetKey(KeyCode.S)) moveVector.z = -1.0f;
        if (Input.GetKey(KeyCode.D)) moveVector.x += 1.0f;
        moveVector.x += Input.GetAxis("Pad1X");
        moveVector.z -= Input.GetAxis("Pad1Y");


        // FORCE WILL BE WITH YOU
        rb.AddForce(speed * moveVector, ForceMode.Impulse);
    }
}
