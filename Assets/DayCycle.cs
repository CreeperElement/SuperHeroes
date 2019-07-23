using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public float secondsForFullRotation;
    private float XRot, YRot, ZRot;
    
    // Start is called before the first frame update
    void Start()
    {
        XRot = transform.rotation.eulerAngles.x;
        YRot = transform.rotation.eulerAngles.y;
        ZRot = transform.rotation.eulerAngles.z;
        Debug.Log(transform.rotation.eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.rotation);
        XRot += 360 * (Time.deltaTime / secondsForFullRotation);
        XRot %= 360;
        transform.rotation = Quaternion.Euler(new Vector3(XRot, YRot, ZRot));
    }
}
