using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseState : MonoBehaviour
{
    Animator animator;
    public int player;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TopGL.gameStatus == 5 && flag)
        {
            if(player == TopGL.beforeGoalWho)
            {
                animator.SetTrigger("Win");
            }
            else
            {
                animator.SetTrigger("Lose");
            }
            flag = false;
        }
    }
}
