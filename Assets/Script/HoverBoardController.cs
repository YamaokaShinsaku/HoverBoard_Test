using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBoardController : MonoBehaviour
{
    // Rigidbody���擾
    private Rigidbody rb;
    // �n�ʂ���̍���
    public float multipuler;
    // �ړ����x�ݒ�p
    public float moveForce, turnTorque;
    // �A���J�[
    public Transform[] anchors = new Transform[4];
    // �A���J�[�����RayCastHit
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
        // �O��ړ��A�^�[���ړ����s��
        rb.AddForce(v * moveForce * transform.forward);
        rb.AddTorque(h * turnTorque * transform.up);
    }

    /// <summary>
    /// �n�ʂ��畂������
    /// </summary>
    /// <param name="anchor">�A���J�[</param>
    /// <param name="hit">�A���J�[�����RayCastHit</param>
    void ApplyForce(Transform anchor, RaycastHit hit)
    {
        if(Physics.Raycast(anchor.position, -anchor.up, out hit))
        {
            float force = 0;
            // ������ɕ�������͂��v�Z
            force = Mathf.Abs(1 / (hit.point.y - anchor.position.y));
            // Rigidbody���g�p���ĕ�������
            rb.AddForceAtPosition(transform.up * force * multipuler,
                anchor.position, ForceMode.Acceleration);
        }
    }
}
