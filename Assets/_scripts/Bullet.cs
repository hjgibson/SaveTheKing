using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;

    private Transform target;

    private int damage = 100;

    private void Start()
    {
 
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }
  

    private void Update()
    {
        if (target == null)
        {
           Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if ( dir.magnitude <= distanceThisFrame )
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
    /// <summary>
    /// destroys the bullet
    /// </summary>
    void HitTarget()
    {
        Damage(target);
        Destroy(gameObject);
        Debug.Log("Hit Something");
    }

    /// <summary>
    /// does damage to the enemy and kills them 
    /// </summary>
    /// <param name="enemy"> the enemies in the scene </param>
    public void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

}
