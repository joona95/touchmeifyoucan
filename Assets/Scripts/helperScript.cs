using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class helperScript : MonoBehaviour
{
    public GameObject helperChatBox;
    public GameObject text1, text2,text3,text4;
    public GameObject character;
    public GameObject coinText, chatBoxText;

    public bool wait = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (text1.gameObject.activeSelf==true && (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return)))
        {
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(true);
            
        }
        
        else if (text2.gameObject.activeSelf == true && (Input.GetKey(KeyCode.Keypad1)||Input.GetKey(KeyCode.Alpha1)))
        {
            
            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(true); // 퀴즈풀기
            
            
        }
        else if (text2.gameObject.activeSelf == true && (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2)))
        {
            text2.gameObject.SetActive(false);
            text4.gameObject.SetActive(true); // 교환하기
            
        }
        else if ((text3.gameObject.activeSelf == true) && (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3)))
        {
            character.GetComponent<CharacterMovement>().limitTime += 15f;
            if (character.GetComponent<CharacterMovement>().limitTime > 90f)
                character.GetComponent<CharacterMovement>().limitTime = 90f;
            this.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        else if ((text3.gameObject.activeSelf == true) && (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.Alpha4)))
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        else if ( (text4.gameObject.activeSelf == true) && (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return)))
        {
            if (character.GetComponent<CharacterMovement>().coinCount >= 3)
            {
                character.GetComponent<CharacterMovement>().coinCount-=3;
                character.GetComponent<CharacterMovement>().ChatboxCount+=1;
                if (notDestroy.level == 0)
                {
                    coinText.GetComponent<Text>().text = character.GetComponent<CharacterMovement>().coinCount + "/5";
                    chatBoxText.GetComponent<Text>().text = character.GetComponent<CharacterMovement>().ChatboxCount + "/5";
                }
                else if (notDestroy.level == 1)
                {
                    coinText.GetComponent<Text>().text = character.GetComponent<CharacterMovement>().coinCount + "/7";
                    chatBoxText.GetComponent<Text>().text = character.GetComponent<CharacterMovement>().ChatboxCount + "/5";

                }
                else
                {
                    chatBoxText.GetComponent<Text>().text = character.GetComponent<CharacterMovement>().ChatboxCount + "/7";
                }
            }
            this.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
        wait = false;
    }

}
