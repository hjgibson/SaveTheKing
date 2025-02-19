using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;

 //   public float killTime = 1;

    private void Start()
    {
    //    Destroy(gameObject, killTime);
    }


    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
       
    }
}
