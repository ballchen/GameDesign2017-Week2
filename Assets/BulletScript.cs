using UnityEngine;
using System.Collections;
public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    //速度調慢一點
    private float speed = 2;
    const float flashDuration = 0.1f;
    float flashCounter = 0;
    public void InitAndShoot(Vector2 direction)
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        rigidbody2D.velocity = speed * direction;
        flashCounter = flashDuration;
    }
    // Update is called once per frame
    void Update()
    {
        if (rigidbody2D.velocity == Vector2.zero)
        {
            //確保沒有人停下來
            rigidbody2D.velocity = new Vector2(Random.Range(0, 1.0f), Random.Range(0, 1.0f)).normalized * speed;
        }
        else
        {
            //確保碰撞後速度不變
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * speed;
        }

        float rotationZ = Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg;
        Debug.Log(rotationZ);
        this.transform.eulerAngles = new Vector3(0, 0, rotationZ);
        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = Color.green;
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        flashCounter = flashDuration;
    }
}