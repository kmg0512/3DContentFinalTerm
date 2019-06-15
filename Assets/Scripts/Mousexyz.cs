using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mousexyz : MonoBehaviour
{
    Text xyz;
    // Start is called before the first frame update
    void Start()
    {
        xyz = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float z = Input.mousePosition.z;

        xyz.text = x.ToString("0") + " " + y.ToString("0") + " " + z.ToString("0");
    }
}
