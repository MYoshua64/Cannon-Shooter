using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Text heightText;
    [SerializeField] private Text rotationText;
    [SerializeField] private Text velocityText;
    [SerializeField] private Cannon controlledCannon;

    void Start()
    {
        SetNewRotation(0);
    }

    public void SetNewHeight(float newHeight)
    {
        heightText.text = newHeight + " [m]";
        controlledCannon.SetHeight((int)newHeight);
    }

    public void SetNewRotation(float newAngle)
    {
        rotationText.text = string.Format(newAngle.ToString() + (char) 176);
        controlledCannon.SetRotation((int)newAngle);
    }

    public void SetNewVelocity(float newVelocity)
    {
        velocityText.text = newVelocity + " [m/s]";
        controlledCannon.SetVelocity((int)newVelocity);
    }

    public void ToggleDrag(bool value)
    {
        controlledCannon.SetDrag(value);
    }

    public void ToggleKinematic(bool value)
    {
        controlledCannon.SetKinematic(value);
    }
}
