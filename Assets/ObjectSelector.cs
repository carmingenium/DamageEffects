using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    void Update()
    {
        // Check if the player clicks the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
            // Create a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit object: " + hit.transform.gameObject.name);
                // Check if the object has PlayerStats or EnemyStats component
                PlayerStats playerStats = hit.transform.GetComponent<PlayerStats>();
                EnemyStats enemyStats = hit.transform.GetComponent<EnemyStats>();

                if (playerStats != null)
                {
                    // Perform actions for interacting with PlayerStats
                    Debug.Log("Selected Player: " + playerStats.gameObject.name);
                    // Example: playerStats.TakeDamage(10);
                }
                else if (enemyStats != null)
                {
                    // Perform actions for interacting with EnemyStats
                    Debug.Log("Selected Enemy: " + enemyStats.gameObject.name);
                    // Example: enemyStats.TakeDamage(10);
                }
                else
                {
                    // Handle if no specific component is found
                    Debug.Log("Selected object has no selectable component.");
                }
            }
            else
                Debug.Log("No object hit.");
        }
    }
}
