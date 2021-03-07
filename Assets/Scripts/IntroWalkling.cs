using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroWalkling : MonoBehaviour
{
    public GameObject ground;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void customEvent()
    {
        Debug.Log("customEvent");
        ground.gameObject.SetActive(true);
        character.gameObject.SetActive(true);
    }

    void changeEvent()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
