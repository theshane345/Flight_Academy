using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 10f;
    [Tooltip("In ms^-1")] [SerializeField] float xRangeAccross = 6f;
    [Tooltip("In ms^-1")] [SerializeField] float yRangeUp = 2.5f;
    [SerializeField] GameObject[] Guns;

    [Header("Screen Position")]
    [SerializeField] float PitchPos = -4.5f;
    [SerializeField] float YawPos = 4.5f;


    [Header("Control Throw")]
    [SerializeField] float ControlPitch = 14.5f;
    [SerializeField] float ControlRoll = -40.5f;

    [Header("Death Score")]
    [SerializeField] int scorePerHit = 10;

    ScoreBosrd scoreBosrd;

    float yThrow, xThrow;
    bool isDead = true;
    // Start is called before the first frame update
    void Start()
    {
        scoreBosrd = FindObjectOfType<ScoreBosrd>();
    }

   

    // Update is called once per frame
    void Update()
    {
        if (isDead) {
            LeftRight();
            UpDown();
            ProcessRotation();
            ProcessFiring();
        }

    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

     
     void ActivateGuns()
    {
        foreach (GameObject gun in Guns)
        {
            gun.SetActive(true);

        }
    }

    void DeactivateGuns()
    {
        foreach (GameObject gun in Guns)
        {
            gun.SetActive(false);

        }
    }


    void OnPlayerDeath()
    {
        scoreBosrd.DeathHit(scorePerHit);
        isDead = false;
        
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
        float xOffset = xThrow * Speed * Time.deltaTime;
        float Raw = transform.localPosition.x + xOffset;
        float ClampPos = Mathf.Clamp(Raw, -xRangeAccross, xRangeAccross);
        transform.localPosition = new Vector3(ClampPos,transform.localPosition.y,  transform.localPosition.z);
    }

    private void UpDown()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetUp = yThrow * Speed * Time.deltaTime;
        float RawUp = transform.localPosition.y + yOffsetUp;
        float ClampPosUp = Mathf.Clamp(RawUp, -yRangeUp, yRangeUp);
        transform.localPosition = new Vector3(transform.localPosition.x, ClampPosUp, transform.localPosition.z);
    }
}
