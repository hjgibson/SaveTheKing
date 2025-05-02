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


    public Transform spawnNode;
   // public GameObject spawnPoint; // Where towers are placed


    public GameObject tower2Prefab;
    public GameObject tower3Prefab;

    private bool hasMerged = false;

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

                    Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
                    offsetX = 0;
                    offsetY = -100;
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


            if (!isMerged && spawnNode != null)
            {
                transform.position = spawnNode.position;
               // transform.position = spawnPoint.transform.position;
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (hasMerged) return;

        // Avoid merging twice by checking which object has the lower instance ID (i.e., older in hierarchy)
        if (collision.gameObject.TryGetComponent<NewMerge>(out NewMerge otherTower) && gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
            return;
        // The higher ID object lets the lower ID one handle the merge

        GameObject mergeResult = GetMergeResult(collision.gameObject.tag);
        if (mergeResult != null)
        {
            hasMerged = true;
            Instantiate(mergeResult, transform.position, Quaternion.identity)
                .GetComponent<NewMerge>().SetSpawnNode(spawnNode);

            Destroy(collision.gameObject); // Destroy the other tower
            Destroy(gameObject); // Destroy this tower
        }
    }

    private GameObject GetMergeResult(string tag)
    {
        if (tag == "Tower1") return tower2Prefab;
        if (tag == "Tower2") return tower3Prefab;
        Debug.Log($"Merging Tower2 into: {tower3Prefab}");

        return null;
    }

    private Vector3 GetMouseWorldPosition(float z)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public void SetSpawnNode(Transform node)
    {
        spawnNode = node;
    }
}