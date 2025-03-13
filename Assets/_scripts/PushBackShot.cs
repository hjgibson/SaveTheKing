using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBackShot : MonoBehaviour
{
    public float speed = -2f;
    private Transform path;
    private int wavepointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        path = Waypoints.waypoint[0];

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = path.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);



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
