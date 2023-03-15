using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Transform cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, cam.transform.position-transform.position, out hit, 1000f);

        Debug.DrawLine(transform.position, hit.point, Color.red);

        if (hit.collider) Debug.Log(hit.collider.name);

        if (hit.collider == null || !hit.collider.CompareTag("Obstacle"))
        {
            if (meshRenderer.enabled == false)
            {
                meshRenderer.enabled = true;
            }
        }

        else if (hit.collider.CompareTag("Obstacle"))
        {
            if (meshRenderer.enabled == true)
            {
                meshRenderer.enabled = false;
            }
            else return;
        }
        else
        {
            return;
        }
    }
}
