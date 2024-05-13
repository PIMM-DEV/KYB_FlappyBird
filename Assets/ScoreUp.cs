using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : MonoBehaviour
{
    private void OnTriggetEnter2D(Collider2D other)
    {
        Score.score++; // 클래스.변수
    }

}
