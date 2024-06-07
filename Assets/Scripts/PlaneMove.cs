using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public float speed;
    public float topBoundary = 5.75f;
    public float botBoundary = -3.2f;
    float currentPosition;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        currentPosition += Time.deltaTime * direction;

        if (currentPosition >= topBoundary)
        {
            direction *= -1;
            currentPosition = topBoundary;

        }
        //현재 위치(x)가 우로 이동가능한 (x)최대값보다 크거나 같다면

        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 우로 이동가능한 (x)최대값으로 설정

        else if (currentPosition <= botBoundary)
        {
            direction *= -1;
            currentPosition = botBoundary;
        }
        //현재 위치(x)가 좌로 이동가능한 (x)최대값보다 크거나 같다면
        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 좌로 이동가능한 (x)최대값으로 설정
        transform.position = new Vector3(10, currentPosition, 0);
        //"Stone"의 위치를 계산된 현재위치로 처리
    }

}
