using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckBehavior : MonoBehaviour
{

    public static bool camerashakesignal = false;

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
        if(TopGL.gameStatus == 3)
        {
            switch(other.tag)
            {
                case "P1BeforeGoal":
                    TopGL.beforeGoalWho = 1;
                    TopGL.gameStatus = 4;
                    Debug.Log("trigger: p1bg");
                    break;
                case "P2BeforeGoal":
                    TopGL.beforeGoalWho = 2;
                    TopGL.gameStatus = 4;
                    Debug.Log("trigger: p2bg");
                    break;
            }
        }
        else if(TopGL.gameStatus == 4)
        {
            switch(other.tag)
            {
                case "P1Goal":
                    TopGL.gameStatus = 5;
                    Debug.Log("trigger: p1g");
                    break;
                case "P2Goal":
                    TopGL.gameStatus = 5;
                    Debug.Log("trigger: p2g");
                    break;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (TopGL.gameStatus == 4)
        {
            switch (other.tag)
            {
                case "P1BeforeGoal":
                    TopGL.beforeGoalWho = 0;
                    TopGL.gameStatus = 3;
                    Debug.Log("trigger: p1bg Exit");
                    break;
                case "P2BeforeGoal":
                    TopGL.beforeGoalWho = 0;
                    TopGL.gameStatus = 3;
                    Debug.Log("trigger: p2bg Exit");
                    break;
            }
        }

    }

    // Puck collide - for effect
    private void OnCollisionEnter(Collision collision)
    {
        if(TopGL.gameStatus == 3)
        {
            switch(collision.gameObject.tag)
            {
                case "Table":
                    Debug.Log("trigger: t");
                    camerashakesignal = true;
                    break;
                case "Pad":
                    Debug.Log("trigger: p");
                    camerashakesignal = true;
                    break;
            }
        }
    }
}
