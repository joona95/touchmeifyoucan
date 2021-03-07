using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notDestroy : MonoBehaviour
{

    public static int mission1 = 0;
    public static int level = 0;
    public static bool tutorial = true;

    private void Awake()
    {
        Screen.SetResolution((int)(Screen.height * (1920f / 1080)), Screen.height, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //PlayerPrefs.SetInt("mission1", 0);
        //PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
