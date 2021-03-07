using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial3Script : MonoBehaviour
{
    public GameObject text1, text2;
    // Start is called before the first frame update
    void Start()
    {

    }

    public bool wait = false;
    // Update is called once per frame
    void Update()
    {
        if (text1.gameObject.activeSelf == true && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)))
        {
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(true);
            wait = true;
            StartCoroutine(WaitForIt());
        }
        if (wait == false && text2.gameObject.activeSelf == true && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)))
        {
            SceneManager.LoadScene("SampleScene3");
        }

    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1.0f);
        wait = false;
    }



}
