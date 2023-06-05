using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public int damage;

    private float currentLifeSpan = 0f;
    private float maxLifeSpan = 10f;

    private void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);

        currentLifeSpan += Time.deltaTime;
        if (currentLifeSpan >= maxLifeSpan)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
