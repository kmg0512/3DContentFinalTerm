using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (TopGL.beforeGoalWho == 1)
            GetComponent<Text>().text = "Player 2 Goal!\n\nPress Enter to Continue.";
        else
            GetComponent<Text>().text = "Player 1 Goal!\n\nPress Enter to Continue.";
    }
}
