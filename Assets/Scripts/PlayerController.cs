using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 8f;
    [SerializeField] float yRange = 4.5f;

    [Header("Screen position based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 6.5f;

    [Header("Control throw based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -30f;

    [SerializeField] GameObject[] guns;

    [Header("Joystick controlls")]
    [SerializeField] Joystick joystick;
    [SerializeField] Joybutton joybutton;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
	void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }


    private void ProcessFiring()
    {
        //if(CrossPlatformInputManager.GetButton("Fire"))
        if (joybutton.Pressed)
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach(var gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;

            for (int i = 0; i < gun.transform.childCount; i++)
            {
                var child = gun.transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(isActive);
            }
        }
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlFlow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlFlow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        //xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        //yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        xThrow = joystick.Horizontal;
        yThrow = joystick.Vertical;

        var xOffsetThisFrame = xThrow * controlSpeed * Time.deltaTime;
        var yOffsetThisFrame = yThrow * controlSpeed * Time.deltaTime;

        var rawXPosition = transform.localPosition.x + xOffsetThisFrame;
        var rawYPosition = transform.localPosition.y + yOffsetThisFrame;

        var newXPos = Mathf.Clamp(rawXPosition, -xRange, +xRange);
        var newYPos = Mathf.Clamp(rawYPosition, -yRange, +yRange);
        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }
}
