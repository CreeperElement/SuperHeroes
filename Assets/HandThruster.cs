using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandThruster : MonoBehaviour
{
    public enum ControllerSelectoin { LEFT = 14, RIGHT = 15};
    public ControllerSelectoin selectedController;
    public float Thrust;
    // Defined here in case we want to be able to change it dynamically
    private Vector3 Forward { get { return -1 * gameObject.transform.forward; } }
    private Rigidbody rbody;

    public float ThrustModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var squeeze = SteamVR_Input.GetSingleAction("Squeeze", false);
        var triggerModifier = squeeze.axis;
        Debug.Log(triggerModifier);
        //thrustPower = Thrust;
        if(triggerModifier > 0)
        {
            var tolerance = .05f;
            if ((triggerModifier * Thrust > -1*Physics.gravity.y - tolerance  && (triggerModifier * Thrust) < -1*Physics.gravity.y + tolerance)) {
                rbody.AddForce(-1*Physics.gravity.y * Forward, ForceMode.Acceleration);
            } else
            {
                rbody.AddForce(Forward * triggerModifier * Thrust, ForceMode.Acceleration);
            }
        }
    }
}
