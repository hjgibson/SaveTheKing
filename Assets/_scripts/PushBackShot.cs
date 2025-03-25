using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBackShot : MonoBehaviour
{
    private float speed = 1f;
    private Transform path;
    //private Rigidbody mybod;
    //private Transform hold;

    // Start is called before the first frame update
    void Start()
    {
        path = Waypoints.waypoint[0];
        //mybod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = path.position - transform.position;
        //hold = Transform.InverseTransformDirection(dir.x, dir.y, dir.z);
        transform.Translate(-dir * speed * Time.deltaTime, Space.World);


        //mybod.AddForce(Transform.InverseTransformDirection(dir)) * speed * Time.deltaTime);

        /*if (GetComponent<AbilitiesManager>().Back == false)
        {
            gameObject.GetComponent<Enemy>().enabled = true;
            gameObject.GetComponent<PushBackShot>().enabled = false;
        }*/

    }
    
    /*private void FixedUpdate()
    {
        Debug.Log("3");
        gameObject.GetComponent<Enemy>().enabled = true;
        gameObject.GetComponent<PushBackShot>().enabled = false;
    }*/

}
