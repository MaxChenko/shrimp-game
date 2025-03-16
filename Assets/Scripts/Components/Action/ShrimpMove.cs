using UnityEngine;

public class ShrimpMove : MonoBehaviour
{
 private Rigidbody2D _rb;
    public float speed = 2f;
    private Vector2 direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        direction = new Vector2(
            Random.Range(0, 2) == 0 ? 1 : -1, 
            Random.Range(0, 2) == 0 ? 1 : -1
        );

        _rb.linearVelocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;

        if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y))
        {
            direction.x *= -1;
        }
        else
        {
            direction.y *= -1;
        }

        _rb.linearVelocity = direction * speed;
    }
}
