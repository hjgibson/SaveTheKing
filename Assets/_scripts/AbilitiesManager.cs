using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    public float waitTime = 2f;
    public bool Back = false;
    public Rigidbody mybod;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<Enemy>().enabled = true;
        //gameObject.GetComponent<PushBackShot>().enabled = false;

        //Vector3 dir = path.position - transform.position;
        //transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        
        
    }
    public IEnumerator TurnBack()
    {
        Back = true;
        Debug.Log("Bruh2");
        yield return new WaitForSeconds(waitTime);
        Back = false;
        
        gameObject.GetComponent<Enemy>().enabled = true;
        gameObject.GetComponent<PushBackShot>().enabled = false;

    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PBS")
        {
            gameObject.GetComponent<Enemy>().enabled = false;
            gameObject.GetComponent<PushBackShot>().enabled = true;
            StartCoroutine(TurnBack());
            
        }


    }
    public void Restart()
    {
        /*if(Back == false)
        {
            foreach (GameObject gameObject in Save)
            {
                gameObject.GetComponent<Enemy>().enabled = false;
                gameObject.GetComponent<PushBackShot>().enabled = true;
            }
          
        }*/
        
    }

    
}
