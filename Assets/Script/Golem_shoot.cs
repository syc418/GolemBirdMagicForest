using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_shoot : MonoBehaviour
{

    public BoxCollider shoot_detect;
    public bool shoot_in_range;

    // Start is called before the first frame update
    void Start()
    {
        shoot_detect = GetComponent<BoxCollider>();
        shoot_in_range = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shoot_in_range = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shoot_in_range = false;
        }
    }
}
