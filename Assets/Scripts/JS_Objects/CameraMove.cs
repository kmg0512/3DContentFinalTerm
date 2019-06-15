using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    

    public int zoom;
    public int normal;
    public float smooth;

    public int wide_zoom;
    public float wide_smooth;
    public Vector3 wide_Rotation = new Vector3(54.0f, 0.0f, 0.0f);
    public Vector3 wide_Position = new Vector3(0.0f, 5.34f, -3.07f);

    public bool shakeenter;
    public float shaketimer;
    public float shakeamount;
    public float shakeduration;

    public GameObject puck;
    public Vector3 defaultGameRotation = new Vector3(81.86401f, 0.0f, 0.0f);
    public Vector3 defaultGamePosition = new Vector3(0.0f, 5.51f, -1.9f);

    private Vector3 shakeOriginPos;

    // Start is called before the first frame update
    void Start()
    {
        shakeOriginPos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (TopGL.gameStatus == 0 || TopGL.gameStatus == 5)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, wide_zoom, Time.deltaTime * wide_smooth);
            Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(wide_Rotation), Time.deltaTime * wide_smooth);
            Camera.main.transform.position = Vector3.Lerp(transform.position, wide_Position, Time.deltaTime * wide_smooth);
        }
        else if (TopGL.gameStatus == 2  || TopGL.gameStatus == 3)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, normal, Time.deltaTime * smooth);
            Camera.main.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(defaultGameRotation), Time.deltaTime * smooth);
            Camera.main.transform.position = Vector3.Lerp(transform.position, defaultGamePosition, Time.deltaTime * wide_smooth);
        }
        else if (TopGL.gameStatus == 4)
        {
            //https://www.youtube.com/watch?v=-nKn7l1iu2g
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom, Time.deltaTime * smooth);
            //https://forum.unity.com/threads/smooth-look-at.26141/
            var targetRotation = Quaternion.LookRotation(puck.transform.position - transform.position);
            Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
        }





             
        /*
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
            Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(defaultGameRotation), Time.deltaTime * smooth);
        }
        */

        // Camera shake
        //https://zprooo915.tistory.com/27
        if (!shakeenter && PuckBehavior.camerashakesignal)
        {
            // start shake
            shakeenter = true;
            shaketimer = 0;
        }

        if (shakeenter)
        {
            GetComponent<Transform>().position = (Vector3)Random.insideUnitSphere * shakeamount + shakeOriginPos;
            shaketimer += Time.deltaTime;
            if (shaketimer > shakeduration)
            {
                GetComponent<Transform>().position = shakeOriginPos;
                shakeenter = false;
                PuckBehavior.camerashakesignal = false;
            }

        }
        
    }
    
}
