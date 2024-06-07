using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public static int life = 1;
    // Start is called before the first frame update
    void Start()
    {
        life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "LIFE: " + life.ToString();
    }
}
