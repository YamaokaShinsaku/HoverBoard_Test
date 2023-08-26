using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBoardController : MonoBehaviour
{
    private Rigidbody rb;

    public float multipuler;
    public float moveForce, turnTorque;

    public Transform[] anchors = new Transform[4];
    RaycastHit[] hits = new RaycastHit[4];
        
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        for (int i = 0; i < 4; i++)
        {
            ApplyForce(anchors[i], hits[i]);
        }

        rb.AddForce(v * moveForce * transform.forward);
        rb.AddTorque(h * turnTorque * transform.up);
    }

    void ApplyForce(Transform anchor, RaycastHit hit)
    {
        if(Physics.Raycast(anchor.position, -anchor.up, out hit))
        {
            float force = 0;
            force = Mathf.Abs(1 / (hit.point.y - anchor.position.y));
            rb.AddForceAtPosition(transform.up * force * multipuler, anchor.position, ForceMode.Acceleration);
        }
    }
}
