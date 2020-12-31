using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCannonBall : MonoBehaviour
{
    [Min((float)1e-07)] public float mass = 1f;
    private Rigidbody2D rb;
    private Vector2 netForce;
    private bool drag;

    public void InitCannonBall(Vector2 vel, bool _drag)
    {
        rb = GetComponent<Rigidbody2D>();
        netForce = vel / mass;
        drag = _drag;
    }

    void FixedUpdate()
    {
        netForce += Physics2D.gravity * Time.fixedDeltaTime;
        if (drag)
        {
            netForce -= netForce * 0.6f * Time.fixedDeltaTime;
        }

        
        rb.position += netForce * Time.fixedDeltaTime;
    }
}
