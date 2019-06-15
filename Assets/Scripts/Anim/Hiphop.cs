using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLosePose : MonoBehaviour
{
    private Animator anim;
    private AnimatorStateInfo currentState;
    private AnimatorStateInfo previousState;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentState = anim.GetCurrentAnimatorStateInfo(0);
        previousState = currentState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
