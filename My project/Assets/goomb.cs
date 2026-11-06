using System;
using Unity.VisualScripting;
using UnityEngine;

public class goomb : MonoBehaviour
{
    private bool is_moving = true;
    private BoxCollider box_collider;

    void Awake()
    {
        box_collider = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        if (is_moving)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
            
            
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered " + other.name);

        if (other.CompareTag(""))
        {
            transform.Rotate(0, 180, 0);
        }
        
    }
}
