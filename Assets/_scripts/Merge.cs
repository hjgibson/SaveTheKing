using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public GameObject tower1Prefab;
    public GameObject tower2Prefab;



    private bool isDragging = false;
    public Vector3 offset;



    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - MouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newMousePosition = MouseWorldPosition();
            transform.position = new Vector3(newMousePosition.x+ offset.x, transform.position.y, newMousePosition.z + offset.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
     
   
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Tower1"))
        {
            Debug.Log("tower1 detected");
            MergeTowers();
            Destroy(collision.gameObject);
        }
        
    }

    private Vector3 MouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = Camera.main.ScreenToWorldPoint(transform.position).z;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void MergeTowers()
    {
        //  Vector3 currentPosition = transform.position;
        //    Quaternion currentRotation = transform.rotation;

        Instantiate(tower2Prefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
        //  Destroy(gameObject);
    }
}

