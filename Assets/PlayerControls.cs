using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xRange = 5f;
    [SerializeField] private Vector2 yRange;

    // Update is called once per frame
    void Update()
    {
        var horizontalThrow = Input.GetAxis("Horizontal");
        var verticalThrow = Input.GetAxis("Vertical");
        
        var xOffset = horizontalThrow * Time.deltaTime * controlSpeed;
        var newXPos = transform.localPosition.x + xOffset;
        var clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);

        var yOffset = verticalThrow * Time.deltaTime * controlSpeed;
        var newYPos = transform.localPosition.y + yOffset;
        var clampedYPos = Mathf.Clamp(newYPos, yRange.x, yRange.y);



        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);


        
    }
}
