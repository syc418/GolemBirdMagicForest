using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_cast_spell : MonoBehaviour
{
    public float cooldown;
    public float fire_rate;
    public float fire_remain;

    public GameObject[] projectiles;
    public int current_projectile_index;

    public GameObject fire_point;

    public Animator anim;

    public Golem_AI golem;

    // Start is called before the first frame update
    void Start()
    {
        fire_remain = 0;

        current_projectile_index = 0;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject vfx;
        if (fire_remain > 0)
        {
            fire_remain -= fire_rate * Time.deltaTime;
        }
        else 
        {
            //left click to shoot
            if (Input.GetMouseButtonDown(0)) 
            {
                if (projectiles[current_projectile_index]) 
                {
                    anim.SetTrigger("CastSpell");
                    vfx = Instantiate(projectiles[current_projectile_index], fire_point.transform.position, fire_point.transform.rotation);
                    fire_remain = cooldown;
                }
            }
            //right click to switch
            if (Input.GetMouseButtonDown(1)) 
            {
                Switch_Spell();
            }
        }

        if (!golem.is_awake)
        {
            if (Input.GetKeyDown("p"))
            {
                golem.is_awake = true;
            }
        }
        else 
        {
            if (Input.GetKeyDown("p"))
            {
                golem.is_awake = false;
            }
        }
    }

    void Switch_Spell() 
    {
        if (current_projectile_index >= projectiles.Length - 1)
        {
            current_projectile_index = 0;
        }
        else 
        {
            current_projectile_index++;
        }
    }
}
