using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xRange = 5f;
    [SerializeField] private Vector2 yRange;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitichFactor = -10f;

    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlYawFactor = 10f;
    [SerializeField] float controlRollFactor = 5f;


    float horizontalThrow, verticalThrow;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }


    private void ProcessRotation() 
    {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = verticalThrow * controlPitichFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToControl = horizontalThrow * controlYawFactor;
        float yaw = yawDueToPosition + yawDueToControl;


        float roll = horizontalThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        horizontalThrow = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");

        var xOffset = horizontalThrow * Time.deltaTime * controlSpeed;
        var newXPos = transform.localPosition.x + xOffset;
        var clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);

        var yOffset = verticalThrow * Time.deltaTime * controlSpeed;
        var newYPos = transform.localPosition.y + yOffset;
        var clampedYPos = Mathf.Clamp(newYPos, yRange.x, yRange.y);



        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
