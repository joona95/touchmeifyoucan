using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour,IPointerDownHandler
{
    public bool isBtnDown = false;
    public GameObject scrollView;
    public GameObject character;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isBtnDown)
        {
            scrollView.gameObject.SetActive(true);
            isBtnDown = true;
            Time.timeScale = 0f;
            if (notDestroy.tutorial == true)
            {
                    character.gameObject.GetComponent<TutorialCharacter>().enabled = false;

            }

            else
            {
                character.gameObject.GetComponent<CharacterMovement>().enabled = true;
            }
        }
        else
        {
            scrollView.gameObject.SetActive(false);
            isBtnDown = false;
            Time.timeScale = 1f;
            if (notDestroy.tutorial == true)
            {
                    character.gameObject.GetComponent<TutorialCharacter>().enabled = true;
;
            }
            else
            {
                character.gameObject.GetComponent<CharacterMovement>().enabled = true;
            }
        }
    }
    
}
