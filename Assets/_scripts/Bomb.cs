using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    private int damage = 200;
    public int explosionRadius;
    private Collider triggeringEnemy;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Enemy>(out var enemy))
        {
            triggeringEnemy = collision.collider;
            ExplodeBomb();
        }
    }
    public void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    private void ExplodeBomb()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        Damage(triggeringEnemy.transform);
        foreach (Collider collider in colliders)
        {
            if (collider == triggeringEnemy) continue;
            if (collider.GetComponent<Enemy>() != null) { Damage(collider.transform); }
            
        }
        
        gameObject.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

    }
}
