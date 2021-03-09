using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
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

    public int coinCount = 0;
    public int ChatboxCount = 0;
    public float limitTime = 90f;
    public GameObject timer;
    public GameObject coinText;
    public GameObject chatText;
    public GameObject helperChatBox;
    public GameObject text1, text2, text3, text4;
    public GameObject gameOver, success;

    public bool hasson = false;
    public bool feverMode = false;
    public bool smallMode = false;
    // Update is called once per frame
    void Update()
    {
        timer.GetComponent<Slider>().value = (1f / 90f*limitTime);
        limitTime -= Time.deltaTime;

        Debug.Log(notDestroy.level);
        //Time.timeScale = 0f;
        if (notDestroy.level == 0)
        {
            if (coinCount == 5 || ChatboxCount == 5)
            {
                success.SetActive(true);
                StartCoroutine(Success1());
                
            }
        }
        else if (notDestroy.level == 1)
        {
            if (coinCount == 9 || ChatboxCount == 5)
            {
                success.SetActive(true);
                StartCoroutine(Success2());
                
            }
        }
        else
        {
            if (ChatboxCount == 7)
            {
                success.SetActive(true);
                StartCoroutine(Success3());
                
            }
        }

      

        if (limitTime <= 0f)
        {
            //Time.timeScale = 0f;
            gameOver.SetActive(true);
            StartCoroutine(GameOver());
            
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CameraMovement.start = false;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            if (notDestroy.level == 1)
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (!isLeft)
            {
                isRight = false;
                //float x = this.gameObject.GetComponent<BoxCollider2D>().offset.x + 1.1f;
                //float y = this.gameObject.GetComponent<BoxCollider2D>().offset.y;
                if(!smallMode)
                    this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.6f, this.gameObject.GetComponent<BoxCollider2D>().offset.y);
                else
                {
                    this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.2f, -0.8f);
                    this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1.5f);
                }

                Debug.Log(this.gameObject.GetComponent<BoxCollider2D>().offset.x);
                isLeft = true;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            CameraMovement.start = false;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (notDestroy.level==1)
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (!isRight)
            {
                isLeft = false;
                //float x = this.gameObject.GetComponent<BoxCollider2D>().offset.x - 1.1f;
                //float y = this.gameObject.GetComponent<BoxCollider2D>().offset.y;
                if (!smallMode)
                    this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.5f, this.gameObject.GetComponent<BoxCollider2D>().offset.y);
                else
                {
                    this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.2f, -0.8f);
                    this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1.5f);
                }
                Debug.Log(this.gameObject.GetComponent<BoxCollider2D>().offset.x);
                isRight = true;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            CameraMovement.start = false;
            Debug.Log(isJumping);
            if (!isJumping)
            {
                isJumping = true;
                if (!smallMode)
                    this.gameObject.GetComponent<Animator>().SetTrigger("jump");
                //this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
                this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpPower;
            }
                
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Floor")
        //{
            isJumping = false;
        //}
        if (collision.gameObject.tag == "coin")
        {
            coinCount++;
            if(notDestroy.level == 0)
                coinText.GetComponent<Text>().text = coinCount + "/5";
            else if(notDestroy.level == 1)
                coinText.GetComponent<Text>().text = coinCount + "/9";
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Chatbox")
        {
            ChatboxCount++;
            if (notDestroy.level == 0||notDestroy.level==1)
                chatText.GetComponent<Text>().text = ChatboxCount + "/5";
            else
                chatText.GetComponent<Text>().text = ChatboxCount + "/7";
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "fever")
        {
            Destroy(collision.gameObject);
            feverMode = true;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "potion")
        {
            Destroy(collision.gameObject);
            smallMode = true;
            this.gameObject.GetComponent<Animator>().SetTrigger("small");
            
        }
        if (collision.gameObject.tag == "jumpWall")
        {
            isJumping = false;
            this.gameObject.GetComponent<Animator>().SetTrigger("jump");
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "brokeWall")
        {
            isJumping = false;
            if (feverMode == true)
            {
                collision.gameObject.SetActive(false);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isJumping = false;
        if (collision.gameObject.tag == "helper")
        {

            /*
            if (PlayerPrefs.HasKey("mission1"))
            {
                Debug.Log("yes");
                PlayerPrefs.SetInt("mission1", 1);
                PlayerPrefs.Save();
            }
            PlayerPrefs.GetInt("mission1");
            */
            notDestroy.mission1 = 1;

            Debug.Log("charactertrtigger");
            helperChatBox.gameObject.SetActive(true);
            text1.gameObject.SetActive(true);
            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(false);
            text4.gameObject.SetActive(false);
            Time.timeScale = 0f;
            
        }
        if (collision.gameObject.tag == "sonsugen")
        {
            Destroy(collision.gameObject);
            hasson = true;
            
        }
        if (collision.gameObject.tag == "Cry" && hasson == true)
        {
            if (notDestroy.level == 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (notDestroy.level == 1)
            {
                SceneManager.LoadScene("SampleScene2");
            }
            else
            {
                SceneManager.LoadScene("SampleScene3");
            }
            
        }
            
    }

    IEnumerator Success1()
    {
        yield return new WaitForSeconds(5.0f);
        notDestroy.level++;
        notDestroy.tutorial = true;
        SceneManager.LoadScene("Tutorial2");
        
    }

    IEnumerator Success2()
    {
        yield return new WaitForSeconds(5.0f);
        notDestroy.level++;
        notDestroy.tutorial = true;
        SceneManager.LoadScene("Tutorial3");
        
    }

    IEnumerator Success3()
    {
        yield return new WaitForSeconds(5.0f);
        notDestroy.level++;
        notDestroy.tutorial = true;
        SceneManager.LoadScene("beforeEnding");
        
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5.0f);
        notDestroy.tutorial = true;

        if (notDestroy.level == 0)
            SceneManager.LoadScene("Tutorial");
        else if (notDestroy.level == 1)
            SceneManager.LoadScene("Tutorial2");
        else if (notDestroy.level == 2)
            SceneManager.LoadScene("Tutorial3");

        
    }
}
