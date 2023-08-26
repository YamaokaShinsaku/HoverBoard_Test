using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBroomController : MonoBehaviour
{
    private Rigidbody rb;
    private bool landing = false;

    public Transform anchor;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 上昇
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * 0.08f);
            landing = false;
        }
        // 下降
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.down * 0.08f);
        }
        // 着陸許可
        else if (Input.GetKeyDown(KeyCode.R))
        {
            landing = true;
        }
        // 着陸
        if (landing)
        {
            // 下向きにrayを飛ばして、地面を感知する。
            RaycastHit hit;
            Ray ray = new Ray(anchor.position, -anchor.up);

            // 地面を感知したら着陸行動を停止する。
            if (Physics.Raycast(ray, out hit, 0.1f))
            {
                print("地面");
                landing = false;
            }

            rb.velocity = Vector3.zero;
            transform.Translate(Vector3.down * 0.03f);
        }

        // 前進
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += transform.forward * 0.3f;
        }
        // 後退
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity -= transform.forward * 0.3f;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = new Vector3(0,0,0);
        }

            // 旋回

            transform.Rotate(0, Input.GetAxis("Horizontal") * 0.8f, 0);
    }
}
