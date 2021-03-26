using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golem_lifebar : MonoBehaviour
{
    public Golem_AI golem;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = golem.life;
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (golem.current_life != slider.value) 
        {
            slider.value = golem.current_life;
        }
    }
}
