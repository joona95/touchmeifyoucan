using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public float speed = 5f;
    public float jumpPower = 5f;

    public bool isJumping = false;
    public bool isLeft = false;
    public bool isRight = false;


    public bool hasson = false;
    public GameObject cryChatBox;
    // Update is called once per frame
    void Update()
    {
        
        


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (!isLeft)
            {
                isRight = false;
                float x = this.gameObject.GetComponent<BoxCollider2D>().offset.x + 1.1f;
                float y = this.gameObject.GetComponent<BoxCollider2D>().offset.y;
                this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(x, y);
                Debug.Log(this.gameObject.GetComponent<BoxCollider2D>().offset.x);
                isLeft = true;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (!isRight)
            {
                isLeft = false;
                float x = this.gameObject.GetComponent<BoxCollider2D>().offset.x - 1.1f;
                float y = this.gameObject.GetComponent<BoxCollider2D>().offset.y;
                this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(x, y);
                Debug.Log(this.gameObject.GetComponent<BoxCollider2D>().offset.x);
                isRight = true;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {

            Debug.Log(isJumping);
            if (!isJumping)
            {
                isJumping = true;
                this.gameObject.GetComponent<Animator>().SetTrigger("jump");
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            }

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "sonsugen")
        {
            Destroy(collision.gameObject);
            hasson = true;

        }
        if (collision.gameObject.tag == "Cry" && hasson == true)
        {
            cryChatBox.gameObject.SetActive(true);
            
        }

    }
}
