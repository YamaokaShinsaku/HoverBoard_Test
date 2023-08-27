using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBoardController : MonoBehaviour
{
    // Rigidbodyを取得
    private Rigidbody rb;
    // 地面からの高さ
    public float multipuler;
    // 移動速度設定用
    public float moveForce, turnTorque;
    // アンカー
    public Transform[] anchors = new Transform[4];
    // アンカーからのRayCastHit
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
        // 前後移動、ターン移動を行う
        rb.AddForce(v * moveForce * transform.forward);
        rb.AddTorque(h * turnTorque * transform.up);
    }

    /// <summary>
    /// 地面から浮かせる
    /// </summary>
    /// <param name="anchor">アンカー</param>
    /// <param name="hit">アンカーからのRayCastHit</param>
    void ApplyForce(Transform anchor, RaycastHit hit)
    {
        if(Physics.Raycast(anchor.position, -anchor.up, out hit))
        {
            float force = 0;
            // 上方向に浮かせる力を計算
            force = Mathf.Abs(1 / (hit.point.y - anchor.position.y));
            // Rigidbodyを使用して浮かせる
            rb.AddForceAtPosition(transform.up * force * multipuler,
                anchor.position, ForceMode.Acceleration);
        }
    }
}
