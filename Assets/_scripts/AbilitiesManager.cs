using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    public float waitTime = 12f;
    public bool Back = false;
    public List<GameObject> Save;

    private int Num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Restart();
        if (Back == false)
        {
            foreach (GameObject gameObject in Save)
            {
                gameObject.GetComponent<Enemy>().enabled = true;
                gameObject.GetComponent<PushBackShot>().enabled = false;
            }

        }
        if(Save == null)
        {
            return;
        }
    }
    public IEnumerator TurnBack()
    {
        Back = true;
        yield return new WaitForSeconds(waitTime);
        Back = false;
        Debug.Log("Bruh2");

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Save.Add(other.gameObject);
            StartCoroutine(TurnBack());
            if(Back == true)
            {
                other.gameObject.GetComponent<Enemy>().enabled = false;
                other.gameObject.GetComponent<PushBackShot>().enabled = true;

            }
            
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
