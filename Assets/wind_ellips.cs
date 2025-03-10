using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_ellips : MonoBehaviour
{
    public int napr = 1; //по часовой, 1 - вверхи и по 45 градусов
    public float power = 100.0f;
    private Vector2 force;
    [SerializeField] private GameObject Hero;
    private Vector2 coords;
    private Vector2 target;
    private float x;
    private float y;

    void Start()
    {
        coords = transform.position;
        x = transform.localScale.x/2;
        print(coords);
        y = transform.localScale.y/2;
        Hero = GameObject.FindGameObjectWithTag("Player");
        switch (napr)
        {
            case 1: force = new Vector2(0, power); break;
            case 2: force = new Vector2(power * 0.71f, power * 0.71f); break;
            case 3: force = new Vector2(power, 0); break;
            case 4: force = new Vector2(power * 0.71f, -power * 0.71f); break;
            case 5: force = new Vector2(0, -power); break;
            case 6: force = new Vector2(-power * 0.71f, power * 0.71f); break;
            case 7: force = new Vector2(-power, 0); break;
            case 8: force = new Vector2(-power * 0.71f, -power * 0.71f); break;
            default: print("разраб алкаш"); break;
        }
    }


    void Update()
    {
        target = Hero.transform.position;
        print(target);
        if ((target.x - coords.x) * (target.x - coords.x) + (target.y - coords.y) * (target.y - coords.y)*(x*x/y/y) < x*x)
        {
            Hero.GetComponent<Rigidbody2D>().AddForce(force);
        }
    }
}
