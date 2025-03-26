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
    public GameObject spawnPoint; // Where towers are placed


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


            if (!isMerged && spawnNode != null)
            {
                transform.position = spawnNode.position; 
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isMerged || hasMerged)
            return;
        if ((collision.gameObject.CompareTag("Tower1") || collision.gameObject.CompareTag("Tower2")) && !isMerged)
        {
            isMerged = true; // Lock the merging process to prevent it from happening more than once
            hasMerged = true;
            GameObject newTower = null;

            // Check if the collided object is Tower1 or Tower2
            if (collision.gameObject.CompareTag("Tower1"))
            {
                if (tower2Prefab != null)
                {
                    newTower = Instantiate(tower2Prefab, transform.position, Quaternion.identity);
                    Debug.Log("Tower 1 merged into Tower 2");
                }
            }
            else if (collision.gameObject.CompareTag("Tower2"))
            {
                if (tower3Prefab != null)
                {
                    newTower = Instantiate(tower3Prefab, transform.position , Quaternion.identity);
                    Debug.Log("Tower 2 merged into Tower 3");
                }
            }
            // Ensure the new tower gets the spawn node and reset merge status
            if (newTower != null)
            {
                NewMerge newTowerScript = newTower.GetComponent<NewMerge>();
                if (newTowerScript != null)
                {
                    // Ensure spawn node is set properly
                    newTowerScript.SetSpawnNode(this.spawnNode);
                    newTowerScript.ResetMergeStatus();  // Reset `isMerged` for the new towers

                    // Make sure the new tower spawns at the correct position
                    newTower.transform.position = this.spawnNode.position; //+ newTowerScript.GetOffset();
                }
            }

            // Delay destroying the current tower to ensure the new one is set up correctly
            StartCoroutine(DestroyOldTower(collision.gameObject));
        }

    }


    // Method to set spawn node
    public void SetSpawnNode(Transform node)
    {
        spawnNode = node;
    }

    public void ResetMergeStatus()
    {
        isMerged = false;
    }


    // Coroutine to delay destruction and allow the new tower to be instantiated first
    private IEnumerator DestroyOldTower(GameObject oldTower)
    {
        // Disable the colliders temporarily to avoid re-triggering the collision
        Collider oldTowerCollider = oldTower.GetComponent<Collider>();
        Collider currentTowerCollider = gameObject.GetComponent<Collider>();
        if (oldTowerCollider != null)
            oldTowerCollider.enabled = false;
        if (currentTowerCollider != null)
            currentTowerCollider.enabled = false;

        // Allow a frame for the new tower to be instantiated before destroying
        yield return null;

        // Destroy the old tower (this could be Tower1 or Tower2)
        Destroy(oldTower);

        // Also destroy this current tower (the one that merged)
        Destroy(gameObject);

        // Re-enable the colliders just in case we need them back
        if (oldTowerCollider != null)
            oldTowerCollider.enabled = true;
        if (currentTowerCollider != null)
            currentTowerCollider.enabled = true;
    }

    public Vector3 GetOffset()
    {
        return transform.position - spawnNode.position;
    }
}
