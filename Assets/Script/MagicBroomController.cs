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
        // �㏸
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * 0.08f);
            landing = false;
        }
        // ���~
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.down * 0.08f);
        }
        // ��������
        else if (Input.GetKeyDown(KeyCode.R))
        {
            landing = true;
        }
        // ����
        if (landing)
        {
            // ��������ray���΂��āA�n�ʂ����m����B
            RaycastHit hit;
            Ray ray = new Ray(anchor.position, -anchor.up);

            // �n�ʂ����m�����璅���s�����~����B
            if (Physics.Raycast(ray, out hit, 0.1f))
            {
                print("�n��");
                landing = false;
            }

            rb.velocity = Vector3.zero;
            transform.Translate(Vector3.down * 0.03f);
        }

        // �O�i
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += transform.forward * 0.3f;
        }
        // ���
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity -= transform.forward * 0.3f;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = new Vector3(0,0,0);
        }

            // ����

            transform.Rotate(0, Input.GetAxis("Horizontal") * 0.8f, 0);
    }
}
