using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public int bulletDamage = 10;
    public LayerMask enemyLayer;

    void Start()
    {
        InvokeRepeating("ShootNearestEnemy", 0f, 0.5f); // Adjust the interval as needed
    }

    void ShootNearestEnemy()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            ShootAtEnemy(nearestEnemy);
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float nearestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    void ShootAtEnemy(GameObject enemy)
{
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

    Vector2 direction = (enemy.transform.position - firePoint.position).normalized;
    rb.velocity = direction * bulletForce;

    Bullet bulletScript = bullet.GetComponent<Bullet>();
    bulletScript.damage = bulletDamage;
}

}
