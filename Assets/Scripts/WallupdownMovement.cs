using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallupdownMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int moveFlag = 1;
    public float moveSpeed = 20;
    public float movingTime = 0f;
    float movePower = 0.12f;
    void Start()
    {
        StartCoroutine("BlockMove");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (this.moveFlag == 1)
        {
            moveVelocity = new Vector3(0, movePower, 0);
        }
        else
        {
            moveVelocity = new Vector3(0, -movePower, 0);
        }
        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }
    IEnumerator BlockMove()
    {
        if (moveFlag == 1)
            moveFlag = 2;
        else
            moveFlag = 1;
        yield return new WaitForSeconds(movingTime);
        StartCoroutine("BlockMove");
    }
}
