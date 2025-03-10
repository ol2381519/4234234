using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class enemy : MonoBehaviour
{
    public Vector2 target;
    public Vector2 Pos;
    public float speed = 1.0f;
    [SerializeField] private GameObject Hero;
    Rigidbody2D me;
    private float delta = 0;
    private bool napr = true;
    public bool isHsm = false;
    private float lava_dmg = 1;
    private bool hjp = true;
    private bool jump = false;

    private void Start()
    { 
        Hero = GameObject.FindGameObjectWithTag("Player");
        me = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        target = Hero.transform.position;
        Pos = transform.position;
        if (isHsm) { 
            if (target.x > Pos.x) me.AddForce(new Vector2(5.0f * speed, 0));
            if (target.x < Pos.x) me.AddForce(new Vector2(-5.0f * speed, 0));
            if ((target.x - Pos.x) > 25 || (target.x - Pos.x) < -25) isHsm = false;
            if (jump && hjp && target.y > Pos.y+0.2f)
            {
                me.AddForce(new Vector2(0, 350));
                jump = false;
                hjp = false;
            }
            else hjp = target.y - 0.2f <= Pos.y;
        }
        else if (napr)
        {
            hjp = true;
            if (Pos.x < target.x && Pos.x - target.x > -10) isHsm = true;
            else if (delta < 300)
            {
                me.AddForce(new Vector2(3.0f * speed, 0));
            }
            else
            {
                napr = false;
            }
        }
        else
        {
            hjp = true;
            if (Pos.x > target.x && Pos.x - target.x < 10) isHsm = true;
            else if (delta > -300)
            {
                me.AddForce(new Vector2(-3.0f * speed, 0));
            }
            else
            {
                napr = true;
            }
        }
        delta += me.velocity.x;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            me.AddForce(new Vector2( 0 , 20));
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Lava"))
        {
            me.GetComponent<perso>().TakeDamage(lava_dmg* Time.deltaTime);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            me.AddForce(new Vector2(0, 200));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jump = true;
            speed = 1.0f;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Lava"))
        {
            jump = true;
            speed = 0.67f;
        }
}
}