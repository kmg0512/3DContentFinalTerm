using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<GameObject>().activeSelf && TopGL.gameStatus != 0)
        {
            gameObject.SetActive(false);
        }
        else if(!GetComponent<GameObject>().activeSelf && TopGL.gameStatus == 0)
        {
            gameObject.SetActive(true);
        }
    }

    void ButtonClicked(int buttonNo)
    {

    }
}
