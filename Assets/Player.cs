using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In ms^-1")] [SerializeField] float xRangeAccross = 2f;
    [Tooltip("In ms^-1")] [SerializeField] float yRangeUp = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftRight();
        UpDown();
    }

    private void LeftRight()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float Raw = transform.localPosition.x + xOffset;
        float ClampPos = Mathf.Clamp(Raw, -xRangeAccross, xRangeAccross);
        transform.localPosition = new Vector3(ClampPos,transform.localPosition.y,  transform.localPosition.z);
    }

    private void UpDown()
    {
        float xFly = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetUp = xFly * xSpeed * Time.deltaTime;
        float RawUp = transform.localPosition.y + yOffsetUp;
        float ClampPosUp = Mathf.Clamp(RawUp, -yRangeUp, yRangeUp);
        transform.localPosition = new Vector3(transform.localPosition.x, ClampPosUp, transform.localPosition.z);
    }
}
