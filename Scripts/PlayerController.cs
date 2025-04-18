using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D obj;
    readonly Vector2 force1 = new Vector2(0, 400);
    readonly Vector2 force2 = new Vector2(10, 0);
    readonly Vector2 force3 = new Vector2(-10, 0);
    readonly Vector2 force4 = new Vector2(5, 1);
    readonly Vector2 vmax = new Vector2(20, 10);
    readonly Vector2 rivok = new Vector2(40, 0);
    float nextrTime = 0f;
    public float rRate = 2f;
    bool inAir;

    private void Start()
    {
        obj = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !inAir)
        {
            inAir = true;
            obj.AddForce(force1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            obj.AddForce(force3);
        }
        if (Input.GetKey(KeyCode.D))
        {
            obj.AddForce(force2);
        }
        if(Time.time >= nextrTime)
        {
            if (Input.GetKey(KeyCode.C))
            {
                obj.AddForce(rivok * obj.velocity.x / obj.velocity.x);
                nextrTime = Time.time + 1f / rRate;
            }
        }
        obj.AddForce(new Vector2(-1 * force4.x * obj.velocity.x / vmax.x, -1 * force4.y * obj.velocity.y / vmax.y));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            inAir = false;
    }
}
