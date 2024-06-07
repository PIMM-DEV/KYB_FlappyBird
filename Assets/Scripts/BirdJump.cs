using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdJump : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpPower;
    public float bounceForce = 5f;  // 튕기는 힘의 크기
    public float delayBeforeMove = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpPower; // 0, 1
            AudioManager.instance.PlaySfx(AudioManager.Sfx.JumpSound);
            Invoke("MoveToNewPosition", 10f);

        }
        MoveToOriginalPosition();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "gameover")
        {

            if (Life.life > 1)
            {
                Life.life -= 1;
                AudioManager.instance.PlaySfx(AudioManager.Sfx.CrushSound);
            }
            else if (Life.life == 1)
            {
                AudioManager.instance.PlaySfx(AudioManager.Sfx.GameOverSound);
                

                if (Score.score > Score.bestScore)
                {
                    Score.bestScore = Score.score;
                }
                SceneManager.LoadScene("GameOverScene");
            }

        }
        // 플레이어를 반대 방향으로 튕기게 하는 코드
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = (Vector2)(transform.position - other.gameObject.transform.position);  // 방향 계산
            direction = direction.normalized * bounceForce;  // 방향 벡터를 정규화하고 힘의 크기를 곱함
            rb.AddForce(direction, ForceMode2D.Impulse);

            // 일정 시간 후에 위치를 변경하기 위해 Invoke 사용
            Invoke("MoveToNewPosition", delayBeforeMove);
        }
    }

    private void MoveToNewPosition()
    {
        // 새로운 위치로 이동
        Vector3 newPosition = new Vector3(-8, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bulletminus")
        {
            Score.score -= 1;
            AudioManager.instance.PlaySfx(AudioManager.Sfx.BulletSound);
        }

        else if (other.gameObject.tag == "heart")
        {
            Life.life += 1;
            AudioManager.instance.PlaySfx(AudioManager.Sfx.HeartSound);
            Destroy(other.gameObject);
        }
    }

    private void MoveToOriginalPosition()
    {
        Vector3 originalPosition = new Vector3(-8, transform.position.y, transform.position.z);
        transform.position = originalPosition;
    }


}