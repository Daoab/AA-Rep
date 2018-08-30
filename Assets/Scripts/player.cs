using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour {

    [Tooltip("In m/s")][SerializeField] float speed = 5f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 4f;

    [SerializeField] float controlPitchFactor = -12f;
    [SerializeField] float controlRollFactor = -12f;

    float xThrow;
    float xOffset;
    float rawX;
    float clampedX;

    float yThrow;
    float yOffset;
    float rawY;
    float clampedY;

    [SerializeField]float xRange = 7f;
    [SerializeField]float yRange = 4f;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        ProcessTranslation();
        ProcessRotation();
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

    private void OnCollisionEnter(Collision collision)
    {
        print("player collided with something");
    }

    void OnTriggerEnter(Collider other)
    {
        print("player trigger with something");
    }
}
