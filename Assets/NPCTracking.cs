using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTracking : MonoBehaviour
{
    [SerializeField] List<GameObject> Spheres = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject sphere in Spheres) 
        {
            RaycastHit hit;

            Physics.Raycast(transform.position, sphere.transform.position - transform.position, out hit, 1000f);

            Debug.DrawLine(transform.position, hit.point, Color.red);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Sphere"))
                {
                    sphere.GetComponent<MeshRenderer>().enabled = true;
                }
                else if (hit.collider.CompareTag("Obstacle"))
                {
                    sphere.GetComponent<MeshRenderer>().enabled = false;
                }
                else
                {
                    sphere.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else continue;
        }
    }
}
