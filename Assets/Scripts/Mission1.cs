using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission1 : MonoBehaviour
{
    public GameObject mission1;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (PlayerPrefs.GetInt("mission1") == 1)
        {
            mission1.gameObject.SetActive(true);
        }*/

        if (notDestroy.mission1 == 1)
        {
            mission1.gameObject.SetActive(true);
        }
    }
}
