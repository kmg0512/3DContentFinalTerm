using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float strength;
    public Rigidbody rb;

    private float previous_mouse_x;
    private float previous_mouse_y;
    private float previous_mouse_z;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        rb = GetComponent<Rigidbody>();

        previous_mouse_x = Input.mousePosition.x;
        previous_mouse_y = Input.mousePosition.y;
        previous_mouse_z = Input.mousePosition.z;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        float x = Input.mousePosition.x;
        float z = Input.mousePosition.z;

        if (x > 0)      x = 0.0f;
        if (x < -2.5)   x = -2.5f;
        if (z > 1)      z = 1.0f;
        if (z < -1)     z = -1.0f;

        this.transform.position = new Vector3(x, this.transform.position.y, z);
    }
    */

    void Update()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float z = Input.mousePosition.z;

        float delta_x = x - previous_mouse_x;
        float delta_y = y - previous_mouse_y;
        float delta_z = z - previous_mouse_z;

        float boardaxis_force_x = delta_y;
        float boardaxis_force_y = 0.0f;
        float boardaxis_force_z = -1.0f * delta_x;
        rb.AddForce(boardaxis_force_x * strength, boardaxis_force_y * strength, boardaxis_force_z * strength, ForceMode.Force);

        previous_mouse_x = x;
        previous_mouse_y = y;
        previous_mouse_z = z;
    }
}
