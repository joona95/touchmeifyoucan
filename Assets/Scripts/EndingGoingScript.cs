using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndingGoingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3())
    }

    void goEnding()
    {
        SceneManager.LoadScene("Ending");
    }
}
