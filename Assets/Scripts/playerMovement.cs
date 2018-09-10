using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerMovement : MonoBehaviour {

    [Header("General")]

    [Tooltip("In m/s")][SerializeField] float speed = 5f;
    [SerializeField] float xRange = 7f;
    [SerializeField] float yRange = 4f;

    [Header("Screen-Position Parameters")]

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 4f;

    [Header("Control-Throw Parameters")]

    [SerializeField] float controlPitchFactor = -12f;
    [SerializeField] float controlRollFactor = -12f;

    [SerializeField] GameObject[] guns;

    float xThrow;
    float xOffset;
    float rawX;
    float clampedX;

    float yThrow;
    float yOffset;
    float rawY;
    float clampedY;

    private bool isDead = false;
    
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDead) { 
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
        }
	}

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        xOffset = xThrow * speed * Time.deltaTime;
        rawX = transform.localPosition.x + xOffset;
        clampedX = Mathf.Clamp(rawX, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        yOffset = yThrow * speed * Time.deltaTime;
        rawY = transform.localPosition.y + yOffset;
        clampedY = Mathf.Clamp(rawY, -yRange, yRange);

        transform.localPosition = new Vector3(clampedX, clampedY, transform.localPosition.z);
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            SetGunsActive(true);
        }
        else {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns) {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    void OnPlayerDeath() { //Called by string reference from collisionHandler
        print("controls deactivated");
        isDead = true;
    }

}
