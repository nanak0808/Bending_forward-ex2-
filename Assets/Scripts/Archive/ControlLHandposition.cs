using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLHandposition : MonoBehaviour
{
    [SerializeField] private float expansionRate = 1;
    [SerializeField] private Transform TrackingSpace;
    [SerializeField] private Transform centerEye;
    [SerializeField] private Transform leftHand;
    private Vector3 startHeadPos;

    // Start is called before the first frame update
    void Start()
    {
        /*------------
        * 初期位置を格納するんだけど、1.HMDの初期位置からの距離で計算するか、2.手の初期位置からの距離で計算するか
        * 「柔軟性の向上度」をどの距離を伸ばした値とするのか
        * 1.HMDからコントローラーまでの距離か、2.手の初期位置から今の手の位置までの距離か　で変わるから【要検討】
        */
        // startHeadPos = centerEye.position;
        startHeadPos = leftHand.position;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeHandPosition();
    }

    void ChangeHandPosition(){
        // Vector3 modifiedPosition = GetHandPosition();
        // modifiedPosition.z += expansionRate;

        // // Apply the modified position
        // transform.position = modifiedPosition;

        Vector3 handPosition = GetHandPosition();
        float diff = handPosition.z - startHeadPos.z;   // 頭の初期位置とコントローラーの位置の差分（長さ）
        float exDiff = diff * expansionRate;    // 長さを拡張した値

        handPosition.z = startHeadPos.z + exDiff;   // 柔軟性拡張後の手のz座標 = 頭の初期z座標 + 頭とコントローラーの差分を拡張した値
        transform.position = handPosition;  // オブジェクトに適用
    }

    public Vector3 GetHandPosition(){
        Vector3 localPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        Vector3 globalPos = TrackingSpace.TransformPoint(localPos);

        return globalPos;
    }
}
