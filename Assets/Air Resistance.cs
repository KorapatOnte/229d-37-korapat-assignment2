using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirResistance : MonoBehaviour
{
    public Rigidbody rb;
    public float enginePowerThrust, liftBooster, drag, angularDrag;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePowerThrust);
        }

        Vector3 lift = Vector3.Project(rb.velocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        rb.drag = rb.velocity.magnitude * drag;
        rb.angularDrag = rb.velocity.magnitude * angularDrag;

        rb.AddTorque(Input.GetAxis("Horizontal") * transform.forward * -1);

        rb.AddTorque(Input.GetAxis("Vertical") * transform.right);

    }
}
