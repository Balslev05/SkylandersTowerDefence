using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    void Update()
    {
         if (Input.GetMouseButtonDown(1)) 
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition); // Convert to 2D position
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero); // Raycast in 2D
            if (hit.collider != null) // If the ray hit something
            {
                if (hit.collider.CompareTag("SpawnPoint")) 
                {
                    hit.collider.GetComponent<SpawnPoint>().Deselcted(hit.collider.gameObject);
                    Debug.Log("Remove tHIS SHIT");
                }
                else
                {
                    Debug.Log("Hit object, but tag did not match: " + hit.collider.name);
                }
            }
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition); // Convert to 2D position
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero); // Raycast in 2D

            if (hit.collider != null) // If the ray hit something
            {

                if (hit.collider.CompareTag("SpawnPoint")) 
                {
                    hit.collider.GetComponent<SpawnPoint>().Selected();
                }
                else
                {
                    Debug.Log("Hit object, but tag did not match: " + hit.collider.name);
                }
            }
            else
            {
                Debug.Log("Raycast did not hit anything.");
            }
        }
    }
}
