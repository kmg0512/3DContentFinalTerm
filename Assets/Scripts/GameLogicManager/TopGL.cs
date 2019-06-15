using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // animation character
    public GameObject unitychan1;
    public GameObject unitychan2;

    // UI gameobject
    public GameObject ScoreUI;
    public Text timerUI;
    public GameObject resultUI;
    public GameObject IntroUI;


    // speed manipulator
    public static float speedmult = 0.0f;


    // Game initialization constants
    public static float initialSpeed = 0.2f;
    public static Vector3 player1_initialPosition = new Vector3(-2.0f, 1.715f, 0.0f);
    public static Vector3 player2_initialPosition = new Vector3(2.0f, 1.715f, 0.0f);
    public static Vector3 puck_initialPosition = new Vector3(0.0f, 1.673f, 0.0f);


    // gameStatus2 exit time
    public const float gameStatus2_exit_time = 2.4f;
    public float gameStatus2_exit_measure;

    // gameStatus4 exit time
    public const float gameStatus4_exit_time = 0.3f;
    public float gameStatus4_exit_measure;
    


    // Start is called before the first frame update
    void Start()
    {
        gameStatus = 1;
        previousGameStatus = 1;
        speedmult = 0.0f;

        gameStatus1_start();
        //gameStatus0_start();
    }

    // Update is called once per frame
    void Update()
    {
        // special input - number keypad
        getSpecialInput();

        if (Input.GetKey(KeyCode.Escape) || Input.GetButton("Fire2"))
        {
            gameStatus = 0;
        }

        if ((previousGameStatus == 0 || previousGameStatus == 5) && (Input.GetKey(KeyCode.Return) || Input.GetButton("Fire1")))
        {
            gameStatus = 2;
        }

        if (previousGameStatus != gameStatus)
        {
            switch(gameStatus)
            {
                case 0:
                    gameStatus0_start();
                    break;
                case 1:
                    gameStatus1_start();
                    break;
                case 2:
                    gameStatus2_start();
                    break;
                case 3:
                    gameStatus3_start();
                    break;
                case 4:
                    gameStatus4_start();
                    break;
                case 5:
                    gameStatus5_start();
                    break;
            }
        }

        // gamestatus2-specific
        if (gameStatus == 2)
        {
            gameStatus2_exit_measure -= Time.deltaTime;
            if (gameStatus2_exit_measure < 0)
            {
                gameStatus3_start();
            }
        }

        // gamestatus4-specific
        if (gameStatus == 4)
        {
            gameStatus4_exit_measure -= Time.deltaTime;
            if(gameStatus4_exit_measure < 0)
            {
                gameStatus3_start();
            }
        }

        // UI set active
        ScoreUI_Determine_Active();
        ResultUI_Determine_Active();
        IntroUI_Determine_Active();

        previousGameStatus = gameStatus;
        return;
    }

    private void FixedUpdate()
    {
        
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

        beforeGoalWho = 0;

        return;
    }

    void gameStatus0_start()
    {
        Debug.Log("gameStatus : 0 Start");
        gameStatus = 0;

        Time.timeScale = 1.0f;
        SetGame();
    }

    void gameStatus1_start()
    {
        Debug.Log("gameStatus : 1 Start");
        gameStatus = 1;

        Time.timeScale = 1.0f;
        DisableMove();
    }

    void gameStatus2_start()
    {
        Debug.Log("gameStatus : 2 Start");
        gameStatus = 2;

        gameStatus2_exit_measure = gameStatus2_exit_time;

        unitychan1.GetComponent<WinLoseState>().ResetFlag();
        unitychan2.GetComponent<WinLoseState>().ResetFlag();

        StartCoroutine(UpdateTimerUI());

        Time.timeScale = 1.0f;
        SetGame();
    }

    void gameStatus3_start()
    {
        Debug.Log("gameStatus : 3 Start");
        gameStatus = 3;

        Time.timeScale = 1.0f;
        EnableMove();
    }

    void gameStatus4_start()
    {
        Debug.Log("gameStatus : 4 Start");
        gameStatus = 4;

        gameStatus4_exit_measure = gameStatus4_exit_time;

        Time.timeScale = 0.2f;
        EnableMove();
    }

    void gameStatus5_start()
    {
        Debug.Log("gameStatus : 5 Start");
        gameStatus = 5;

        if(beforeGoalWho == 1)
        {
            player2Score += 1;
        }
        else if (beforeGoalWho == 2)
        {
            player1Score += 1;
        }

        Time.timeScale = 1.0f;
        DisableMove();
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

    void ScoreUI_Determine_Active()
    {
        if (TopGL.gameStatus > 1 && !ScoreUI.activeSelf)
        {
            ScoreUI.SetActive(true);
        }
        else if(TopGL.gameStatus <= 1 && ScoreUI.activeSelf)
        {
            ScoreUI.SetActive(false);
        }
    }

    private IEnumerator UpdateTimerUI()
    {
        timerUI.gameObject.SetActive(true);
        timerUI.text = "3";
        for (float f = 1; f > 0.2f; f -= Time.deltaTime)
        {
            timerUI.color = new Color(1, 1, 0, f);
            yield return null;
        }
        timerUI.text = "2";
        for (float f = 1; f > 0.2f; f -= Time.deltaTime)
        {
            timerUI.color = new Color(1, 1, 0, f);
            yield return null;
        }
        timerUI.text = "1";
        for (float f = 1; f > 0.2f; f -= Time.deltaTime)
        {
            timerUI.color = new Color(1, 1, 0, f);
            yield return null;
        }
        timerUI.color = new Color(1, 1, 0, 1);
        timerUI.text = "Start!";
        yield return new WaitForSeconds(0.5f);
        timerUI.gameObject.SetActive(false);
    }

    private void ResultUI_Determine_Active()
    {
        if (!resultUI.activeSelf && (gameStatus == 5))
        {
            resultUI.SetActive(true);
        }
        else if(resultUI.activeSelf && (gameStatus != 5))
        {
            resultUI.SetActive(false);
        }
    }

    private void IntroUI_Determine_Active()
    {
        if (!IntroUI.activeSelf && (gameStatus == 1))
        {
            IntroUI.SetActive(true);
        }
        else if (IntroUI.activeSelf && (gameStatus != 1))
        {
            IntroUI.SetActive(false);
        }
    }
}
