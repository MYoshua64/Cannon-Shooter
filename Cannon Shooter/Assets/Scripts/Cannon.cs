using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform cannonBallParent;
    [SerializeField] private Vector3 zeroHeightPosition;
    [SerializeField] private Vector3 fullHeightPosition;
    [SerializeField] private bool kinematicProjectile = false;
    [SerializeField] private float angle;
    [SerializeField] private float initialVel = 15f;
    [SerializeField] private Rigidbody2D projectileDynamic;
    [SerializeField] private KinematicCannonBall projectileKinematic;
    [SerializeField] private bool drag;
    [SerializeField] private KeyCode keyToFire;

    void Start()
    {
        transform.position = Vector3.Lerp(zeroHeightPosition, fullHeightPosition, 10f / 15f);
    }

    public void Fire()
    {
        if (kinematicProjectile)
        {
            FireKinematic();
        }
        else
        {
            FireDynamic();
        }
    }

    private void FireKinematic()
    {
        Vector3 projRotation = angle * Vector3.forward + transform.eulerAngles.y * Vector3.up;
        KinematicCannonBall newCannonBall =
            Instantiate(projectileKinematic, transform.position, Quaternion.Euler(projRotation), cannonBallParent);
        Vector2 launchDirection = newCannonBall.transform.TransformDirection(Vector2.right);
        newCannonBall.InitCannonBall(launchDirection * initialVel, drag);
    }

    private void FireDynamic()
    {
        Vector3 projRotation = angle * Vector3.forward + transform.eulerAngles.y * Vector3.up;
        Rigidbody2D newProj = Instantiate(projectileDynamic, transform.position, Quaternion.Euler(projRotation), cannonBallParent);
        if (drag)
        {
            newProj.drag = 0.6f;
        }
        Vector2 launchDirection = newProj.transform.TransformDirection(Vector2.right);
        newProj.AddForce(launchDirection * initialVel, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToFire))
        {
            Fire();
        }
    }

    public void SetHeight(int _height)
    {
        transform.position = Vector3.Lerp(zeroHeightPosition, fullHeightPosition, _height / 15f);
    }

    public void SetRotation(int rotation)
    {
        Vector3 newRotation = new Vector3(0, transform.eulerAngles.y, rotation);
        transform.rotation = Quaternion.Euler(newRotation);
        angle = rotation;
    }

    public void SetVelocity(int velocity)
    {
        initialVel = velocity;
    }

    public void SetDrag(bool value)
    {
        drag = value;
    }

    public void SetKinematic(bool value)
    {
        kinematicProjectile = value;
    }
}
