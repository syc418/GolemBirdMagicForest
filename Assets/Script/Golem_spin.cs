using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_spin : MonoBehaviour
{

    public SphereCollider spin_detect;
    public bool spin_in_range;

    // Start is called before the first frame update
    void Start()
    {
        spin_detect = GetComponent<SphereCollider>();
        spin_in_range = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            spin_in_range = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spin_in_range = false;
        }
    }
}
