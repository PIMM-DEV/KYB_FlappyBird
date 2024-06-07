using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBullet : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject Plane;
    public float timeDiff;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeDiff)
        {
            GameObject newbullet = Instantiate(Bullet);
            newbullet.transform.position = Plane.transform.position;   
            timer = 0;
            Destroy(newbullet, 2.5f);

        }
    }
}
