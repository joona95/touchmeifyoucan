using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject moveBox;
    //public int moveFlag = 0;
    public float moveSpeed = 20;
    public float movingTime = 0f;
    float movePower = 0.12f;
    public float max = 0f;
    public float min = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(moveBox.GetComponent<moveBox>().moveFlag);
        Vector3 moveVelocity = Vector3.zero;

        if (moveBox.GetComponent<moveBox>().moveFlag==1&&moveBox.transform.position.y<=max)
        {
            moveVelocity = new Vector3(0, movePower, 0);
            moveBox.transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        }
        else if (moveBox.GetComponent<moveBox>().moveFlag == 2&& moveBox.transform.position.y >= min)
        {
            moveVelocity = new Vector3(0, -movePower, 0);
            moveBox.transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Floor")
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("switch");
            moveBox.GetComponent<moveBox>().moveFlag = 1;
            StartCoroutine("BlockMove");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Floor")
        {
            
        }
    }

    IEnumerator BlockMove()
    {
        if (moveBox.GetComponent<moveBox>().moveFlag == 1)
            moveBox.GetComponent<moveBox>().moveFlag = 2;
        else if(moveBox.GetComponent<moveBox>().moveFlag == 2)
            moveBox.GetComponent<moveBox>().moveFlag = 1;
        yield return new WaitForSeconds(movingTime);
        StartCoroutine("BlockMove");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Floor")
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("switchoff");
            moveBox.GetComponent<moveBox>().moveFlag = 0;
            StopCoroutine("BlockMove");
        }
    }
}
