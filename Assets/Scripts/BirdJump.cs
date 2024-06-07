using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdJump : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpPower;
    public float bounceForce = 5f;  // ƨ��� ���� ũ��
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
        // �÷��̾ �ݴ� �������� ƨ��� �ϴ� �ڵ�
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = (Vector2)(transform.position - other.gameObject.transform.position);  // ���� ���
            direction = direction.normalized * bounceForce;  // ���� ���͸� ����ȭ�ϰ� ���� ũ�⸦ ����
            rb.AddForce(direction, ForceMode2D.Impulse);

            // ���� �ð� �Ŀ� ��ġ�� �����ϱ� ���� Invoke ���
            Invoke("MoveToNewPosition", delayBeforeMove);
        }
    }

    private void MoveToNewPosition()
    {
        // ���ο� ��ġ�� �̵�
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