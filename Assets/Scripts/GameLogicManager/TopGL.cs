using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopGL : MonoBehaviour
{
    // GameStatus
    public static int gameStatus = 0;
    public static int previousGameStatus = 0;

    // beforeGoalWho
    // 0 : none
    // 1 : player 1
    // 2 : player 2
    public static int beforeGoalWho = 0;

    // Store Score
    public static int player1Score = 0;
    public static int player2Score = 0;

    // Remember core gameobjects
    public GameObject player1;
    public GameObject player2;
    public GameObject puck;

    // speed manipulator
    public static float speedmult = 0.0f;


    // Game initialization constants
    public static float initialSpeed = 0.2f;
    public static Vector3 player1_initialPosition = new Vector3(-2.0f, 1.715f, 0.0f);
    public static Vector3 player2_initialPosition = new Vector3(2.0f, 1.715f, 0.0f);
    public static Vector3 puck_initialPosition = new Vector3(0.0f, 1.673f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = 0;
        previousGameStatus = 0;
        speedmult = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // special input - number keypad
        getSpecialInput();

        if (Input.GetKey(KeyCode.Escape))
        {
            gameStatus = 0;
        }

        if (previousGameStatus == 5 && Input.GetKey(KeyCode.Return))
        {
            gameStatus = 3;
        }

        if(previousGameStatus != gameStatus)
        {
            switch(gameStatus)
            {
                case 0:
                    SetGame();
                    break;
                case 1:
                    DisableMove();
                    break;
                case 2:
                    SetGame();
                    break;
                case 3:
                    EnableMove();
                    break;
                case 4:
                    DisableMove();
                    break;
                case 5:
                    DisableMove();
                    break;
            }
        }

        previousGameStatus = gameStatus;
        return;
    }


    static void DisableMove()
    {
        speedmult = 0.0f;
    }

    static void EnableMove()
    {
        speedmult = 1.0f;
    }

    void SetGame()
    {
        DisableMove();

        // set core gameobjects' position and velocity 0.
        player1.transform.position = player1_initialPosition;
        player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player2.transform.position = player2_initialPosition;
        player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
        puck.transform.position = puck_initialPosition;
        puck.GetComponent<Rigidbody>().velocity = Vector3.zero;

        return;
    }

    void getSpecialInput()
    {
        if(Input.GetKey(KeyCode.F1))
        {
            gameStatus = 1;
        }
        if (Input.GetKey(KeyCode.F2))
        {
            gameStatus = 2;
        }
        if (Input.GetKey(KeyCode.F3))
        {
            gameStatus = 3;
        }
        if (Input.GetKey(KeyCode.F4))
        {
            gameStatus = 4;
        }
        if (Input.GetKey(KeyCode.F5))
        {
            gameStatus = 5;
        }
        if (Input.GetKey(KeyCode.F6))
        {
            gameStatus = 0;
        }
    }


}
