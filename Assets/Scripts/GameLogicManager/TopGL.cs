using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopGL : MonoBehaviour
{
    public static int gameStatus = 0;

    // Game initialization constants
    public static float initialSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameStatus = 0;
        }
    }
}
