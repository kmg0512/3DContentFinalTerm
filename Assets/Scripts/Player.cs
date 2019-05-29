using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
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
}
