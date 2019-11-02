using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float xRangeAccross = 6f;
    [Tooltip("In ms^-1")] [SerializeField] float yRangeUp = 4.5f;

    [SerializeField] float PitchPos = -4.5f;
    [SerializeField] float ControlPitch = 14.5f;

    [SerializeField] float YawPos = 4.5f;
    [SerializeField] float ControlRoll = -40.5f;
    

    float yThrow, xThrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LeftRight();
        UpDown();
        ProcessRotation();

    }

    private void ProcessRotation()
    {
        float picthDueToControl = yThrow * ControlPitch;
        float pitchDueToPos = transform.localPosition.y * PitchPos;
        float pitch = pitchDueToPos + picthDueToControl;


        float yaw = transform.localPosition.x * YawPos;


        float roll = xThrow * ControlRoll;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void LeftRight()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float Raw = transform.localPosition.x + xOffset;
        float ClampPos = Mathf.Clamp(Raw, -xRangeAccross, xRangeAccross);
        transform.localPosition = new Vector3(ClampPos,transform.localPosition.y,  transform.localPosition.z);
    }

    private void UpDown()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetUp = yThrow * xSpeed * Time.deltaTime;
        float RawUp = transform.localPosition.y + yOffsetUp;
        float ClampPosUp = Mathf.Clamp(RawUp, -yRangeUp, yRangeUp);
        transform.localPosition = new Vector3(transform.localPosition.x, ClampPosUp, transform.localPosition.z);
    }
}
