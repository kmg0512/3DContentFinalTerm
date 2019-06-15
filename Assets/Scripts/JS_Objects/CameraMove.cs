using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    

    public int zoom;
    public int normal;
    public float smooth;

    public GameObject puck;
    public Vector3 defaultRotation = new Vector3(63.31f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TopGL.gameStatus == 4)
        {
            //https://www.youtube.com/watch?v=-nKn7l1iu2g
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom, Time.deltaTime * smooth);
            //https://forum.unity.com/threads/smooth-look-at.26141/
            var targetRotation = Quaternion.LookRotation(puck.transform.position - transform.position);
            Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, normal, Time.deltaTime * smooth);
            Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(defaultRotation), Time.deltaTime * smooth);
        }
    }
}
