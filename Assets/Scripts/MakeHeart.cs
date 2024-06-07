using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHeart : MonoBehaviour
{
    public GameObject heart;
    public int minIndex = 5;
    public int maxIndex = 8;
    public float nextTimeDiff;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomSeconds();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > nextTimeDiff)
        {
            GameObject newheart = Instantiate(heart);
            newheart.transform.position = new Vector3(18f, Random.Range(-2.5f, 4.6f), 0);
            timer = 0;
            Destroy(newheart, 12.0f);
            SetRandomSeconds();
        }

    }

    void SetRandomSeconds()
    {
        int randomIndex = Random.Range(minIndex, maxIndex);
        nextTimeDiff = randomIndex * MakePipe.timeDiff;
    }


}
