using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_AI : MonoBehaviour
{

    public Animator anim;
    public bool is_awake;

    public Golem_spin spin;
    public Golem_shoot shoot;

    public GameObject target;

    public Rigidbody rb;
    public float turnSpeed;
    public float speed;

    public ParticleSystem[] fire_point;

    public float cooldown;
    public float fire_rate;
    public float fire_remain;

    public float life;
    public float current_life;
    public float hit_point;

    public GameObject vfx;

    public GameObject life_bar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        is_awake = false;

        spin = GetComponentInChildren<Golem_spin>();
        shoot = GetComponentInChildren<Golem_shoot>();

        //target

        rb = GetComponent<Rigidbody>();

        fire_remain = 0;

        current_life = life;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_life <= 0)
        {
            anim.SetBool("is_standby", false);
            vfx.SetActive(false);
            life_bar.SetActive(false);
            is_awake = false;
            current_life = life;
            return;
        }

        if (fire_remain > 0)
        {
            fire_remain -= fire_rate * Time.deltaTime;
        }
        if (is_awake) 
        {
            //animate activation
            anim.SetBool("is_standby", true);
            vfx.SetActive(true);
            life_bar.SetActive(true);

            //check player in range - spin
            if (spin.spin_in_range)
            {
                anim.SetBool("is_moving", false);
                anim.SetTrigger("spin");
            }
            //check player in range - shoot
            else if (shoot.shoot_in_range)
            {
                if (fire_remain <= 0)
                {
                    anim.SetBool("is_moving", false);
                    anim.SetTrigger("shoot");

                    if (fire_point.Length > 0) 
                    {
                        for (int i = 0; i < fire_point.Length; i++) 
                        {
                            fire_point[i].Play();
                        }
                    }
                    fire_remain = cooldown;
                }

                
            }
            //rotate facing toward player
            else 
            {
                if (target) 
                {
                    anim.SetBool("is_moving", true);

                    Vector3 _dir = target.transform.position - rb.position;
                    _dir.Normalize();
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_dir), turnSpeed * Time.deltaTime);

                    rb.AddForce(_dir);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && is_awake) 
        {
            current_life -= hit_point;
        }
    }

}
