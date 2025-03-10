using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class swordman : MonoBehaviour
{
    public float atk_rad = 5.0f;
    public float k = 750.0f;
    public float atk_dmg = 5.0f;
    Rigidbody2D me;
    private double timer = 0;
    private float x;
    private float y;
    private float a;
    private GameObject Hero;

    void Start()
    {
        me = GetComponent<Rigidbody2D>();
        Hero = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (me.GetComponent<enemy>().isHsm)
        {
            SLAY();
            timer += Time.deltaTime;
        }
    }
    void SLAY()
    {
        x = me.GetComponent<enemy>().target.x - me.GetComponent<enemy>().Pos.x;
        y = me.GetComponent<enemy>().target.y - me.GetComponent<enemy>().Pos.y;
        if (x * x < atk_rad && y*y<=4 && timer>=1)
        {
            a = Convert.ToSingle(Math.Sqrt(x * x + y * y)); 
            Hero.GetComponent<perso>().TakeDamage(atk_dmg);
            Hero.GetComponent<Rigidbody2D>().AddForce(new Vector2(k * x / a, k * y / a));
            timer = 0;
        }
    }

}
