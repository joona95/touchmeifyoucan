using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButtonScript : MonoBehaviour,IPointerDownHandler
{
    // Start is called before the first frame update
    public GameObject intro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
            intro.gameObject.GetComponent<Animator>().SetTrigger("start");
            this.gameObject.SetActive(false);

         
      
    }
}
