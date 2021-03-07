using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject A;  //A라는 GameObject변수 선언
    Transform AT;
    public float time = 0;
    public static bool start = true;
    void Start()
    {
        A.gameObject.GetComponent<CharacterMovement>().enabled = false;
        AT = A.transform;
        //transform.position.x = new Vector3(28f, 15f, 0);
        //AT.position.y = 15f;
        notDestroy.tutorial = false;
    }
    void LateUpdate()
    {
        /*
        time += Time.deltaTime;
        //Debug.Log(time);
        
        if (time > 5f)
        {
            A.gameObject.GetComponent<CharacterMovement>().enabled = true;
            if (start == false)
            {
                //Debug.Log(AT.position.x + "," + AT.position.y);
                //Debug.Log(AT.GetComponent<Camera>().orthographicSize);
                if (AT.position.x > 4f && AT.position.x <= 55.11f)
                {

                    if (AT.position.y > 4f)
                        transform.position = new Vector3(AT.position.x, AT.position.y, transform.position.z);
                    else
                        transform.position = new Vector3(AT.position.x, 4f, transform.position.z);
                }
                else if (AT.position.x > 55.11f)
                {
                    if (AT.position.y > 4f)
                        transform.position = new Vector3(55.11f, AT.position.y, transform.position.z);
                    else
                        transform.position = new Vector3(55.11f, 4f, transform.position.z);
                }
                else
                {
                    if (AT.position.y > 4f)
                        transform.position = new Vector3(4f, AT.position.y, transform.position.z);
                    else
                    { //초기화면
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    }
                }
            }
        }
        else
        {
            
            if (Camera.main.orthographicSize >= 7f)
            {
                Debug.Log(AT.position.x + "," + AT.position.y);
                float x = this.gameObject.transform.position.x;
                x = x - 0.02f;
                float y = this.gameObject.transform.position.y;
                y = y - 0.01f;
                transform.position = new Vector3(x, y, transform.position.z);
                Camera.main.orthographicSize -= 0.01f;
            }
                
        }*/

        if (Camera.main.orthographicSize >= 12f)
        {
            Debug.Log(AT.position.x + "," + AT.position.y);
            float x = this.gameObject.transform.position.x;
            x = x - 0.1f;
            float y = this.gameObject.transform.position.y;
            y = y - 0.045f;
            transform.position = new Vector3(x, y, transform.position.z);
            Camera.main.orthographicSize -= 0.03f;
        }
        else
        {
            A.gameObject.GetComponent<CharacterMovement>().enabled = true;
            if (start == false)
            {
                //Debug.Log(AT.position.x + "," + AT.position.y);
                //Debug.Log(AT.GetComponent<Camera>().orthographicSize);
                if (AT.position.x > 1f && AT.position.x <= 55.11f)
                {

                    if (AT.position.y > 1f)
                        transform.position = new Vector3(AT.position.x, AT.position.y, transform.position.z);
                    else
                        transform.position = new Vector3(AT.position.x, 2f, transform.position.z);
                }
                else if (AT.position.x > 55.11f)
                {
                    if (AT.position.y > 1f)
                        transform.position = new Vector3(55.11f, AT.position.y, transform.position.z);
                    else
                        transform.position = new Vector3(55.11f, 1f, transform.position.z);
                }
                else
                {
                    if (AT.position.y > 1f)
                        transform.position = new Vector3(1f, AT.position.y, transform.position.z);
                    else
                    { //초기화면
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
