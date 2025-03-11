using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewMerge : MonoBehaviour
{
    private Vector3 mousePosition;

    private float offsetX, offsetY, offsetZ;
    private bool isDragging = false;

    public static bool isMerged;

    public static bool mouseButtonReleased;

    public GameObject tower2Prefab;
    public GameObject tower3Prefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    mouseButtonReleased = false;
                    isDragging = true;

                    Vector3 objectPosition = hit.transform.position;
                    Vector3 screenPoint = Camera.main.WorldToScreenPoint(objectPosition);
                    offsetX = Input.mousePosition.x - screenPoint.x;
                    offsetY = Input.mousePosition.y - screenPoint.y;
                    offsetZ = screenPoint.z;
                }
            }
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            Vector3 screenMousePosition = new Vector3(Input.mousePosition.x - offsetX, Input.mousePosition.y - offsetY, offsetZ);
            mousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
            transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            mouseButtonReleased = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Tower1") && !isMerged)
        {
           isMerged = true;
            StartCoroutine(WaitTime());
            Debug.Log("Tower 1 detected and is merging");

            Debug.Log("tower1 detected");
            Instantiate(tower2Prefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject, .25f);

         
        }

        if(collision.gameObject.tag == "Tower2" && !isMerged)
        {
            isMerged = true;
            Debug.Log("tower2 detected and is merging");
            StartCoroutine(WaitTime());
            Instantiate(tower3Prefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject,.25f);

        }

    }
    IEnumerator WaitTime()
    {
        isMerged = true;

        yield return new WaitForSeconds(3);

        isMerged = false;



        Debug.Log("can merge now");
    }



}
