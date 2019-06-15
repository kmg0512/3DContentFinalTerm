using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Puck Trigger logic
    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "P1BeforeGoal":
                Debug.Log("p1bg");
                break;
            case "P2BeforeGoal":
                Debug.Log("p2bg");
                break;
            case "P1Goal":
                Debug.Log("p1g");
                break;
            case "P2Goal":
                Debug.Log("p2g");
                break;

        }
    }

    // Puck collide - for effect
    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Table":
                Debug.Log("t");
                break;
            case "Pad":
                Debug.Log("p");
                break;
        }
    }
}
