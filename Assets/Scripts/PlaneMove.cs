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
        //���� ��ġ(x)�� ��� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�

        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� ��� �̵������� (x)�ִ밪���� ����

        else if (currentPosition <= botBoundary)
        {
            direction *= -1;
            currentPosition = botBoundary;
        }
        //���� ��ġ(x)�� �·� �̵������� (x)�ִ밪���� ũ�ų� ���ٸ�
        //�̵��ӵ�+���⿡ -1�� ���� ������ ���ְ� ������ġ�� �·� �̵������� (x)�ִ밪���� ����
        transform.position = new Vector3(10, currentPosition, 0);
        //"Stone"�� ��ġ�� ���� ������ġ�� ó��
    }

}
