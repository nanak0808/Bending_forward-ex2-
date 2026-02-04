using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_handposition : MonoBehaviour
{
    // [SerializeField] private bool IsUp;
    // [SerializeField] private int subjectNum;
    [SerializeField] private float expansion_rate = 1;
    [SerializeField] private Transform TrackingSpace;
    // [SerializeField] private Transform CenterEye;
    // [SerializeField] private Transform LeftHand;
    [SerializeField] private float HandStartPosition = 0;   //予め、長座体前屈装置に手を置いた時の手のz座標の初期位置を求めておいて設定
    [SerializeField] private bool IsLeft;  // 手を認識する用
    [SerializeField] private bool ModifyHandPosition;
    private float forHandModify = 0.1f;
    // private Vector3 startHeadPos;
    
    // Start is called before the first frame update
    void Start()
    {
        // startHeadPos = LeftHand.position;
        // subjectNum -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeHandPosition();
    }

    void ChangeHandPosition(){
        Vector3 handPosition = GetHandGlobalPosition();
        // GetChangeRate();
        float diff = handPosition.z - HandStartPosition;
        float exDiff = diff * expansion_rate;

        handPosition.z = HandStartPosition + exDiff;
        if (ModifyHandPosition){
            handPosition.z -= forHandModify;
        }
        transform.position = handPosition;
    }

    public Vector3 GetHandGlobalPosition(){
        Vector3 localpos;

        if(IsLeft == true){ // if target object is left hand
            localpos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        } else { // if target object is right hand
            localpos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        }

        Vector3 globalpos = TrackingSpace.TransformPoint(localpos);

        return globalpos;        
    }

//     void GetChangeRate(){
//         float[,] rateRaw = IsUp ? new float[,]
//         {
//             {1, 1.05f, 1.2f, 1.3f, 1, 1.1f, 1.35f, 1.15f, 1.25f, 1},
//             {1, 1.1f, 1.35f, 1.15f, 1, 1.25f, 1.05f, 1.3f, 1.2f, 1},
//             {1, 1.2f, 1.25f, 1.1f, 1, 1.35f, 1.15f, 1.05f, 1.3f, 1},
//             {1, 1.3f, 1.15f, 1.05f, 1, 1.2f, 1.25f, 1.35f, 1.1f, 1},
//             {1, 1.35f, 1.3f, 1.25f, 1, 1.15f, 1.1f, 1.2f, 1.05f, 1},
//             {1, 1.15f, 1.1f, 1.35f, 1, 1.05f, 1.3f, 1.25f, 1.2f, 1},
//             {1, 1.25f, 1.05f, 1.2f, 1, 1.3f, 1.35f, 1.1f, 1.15f, 1},
//             {1, 1.35f, 1.2f, 1.1f, 1, 1.15f, 1.3f, 1.05f, 1.25f, 1},
//             {1, 1.05f, 1.3f, 1.15f, 1, 1.35f, 1.1f, 1.25f, 1.2f, 1},
//             {1, 1.25f, 1.15f, 1.3f, 1, 1.05f, 1.2f, 1.35f, 1.1f, 1},
//             {1, 1.1f, 1.05f, 1.35f, 1, 1.2f, 1.25f, 1.3f, 1.15f, 1},
//             {1, 1.15f, 1.35f, 1.25f, 1, 1.1f, 1.05f, 1.2f, 1.3f, 1},
//             {1, 1.3f, 1.25f, 1.05f, 1, 1.35f, 1.2f, 1.15f, 1.1f, 1},
//             {1, 1.2f, 1.1f, 1.3f, 1, 1.25f, 1.15f, 1.35f, 1.05f, 1},
//             {1, 1.35f, 1.3f, 1.2f, 1, 1.05f, 1.25f, 1.15f, 1.1f, 1},
//         } :
//         new float[,]
//         {
//             {1, 0.95f, 0.8f, 0.7f, 1, 0.9f, 0.65f, 0.85f, 0.75f, 1},
//             {1, 0.9f, 0.65f, 0.85f, 1, 0.75f, 0.95f, 0.7f, 0.8f, 1},
//             {1, 0.8f, 0.75f, 0.9f, 1, 0.65f, 0.85f, 0.95f, 0.7f, 1},
//             {1, 0.7f, 0.85f, 0.95f, 1, 0.8f, 0.75f, 0.65f, 0.9f, 1},
//             {1, 0.65f, 0.7f, 0.75f, 1, 0.85f, 0.9f, 0.8f, 0.95f, 1},
//             {1, 0.85f, 0.9f, 0.65f, 1, 0.95f, 0.7f, 0.75f, 0.8f, 1},
//             {1, 0.75f, 0.95f, 0.8f, 1, 0.7f, 0.65f, 0.9f, 0.85f, 1},
//             {1, 0.65f, 0.8f, 0.9f, 1, 0.85f, 0.7f, 0.95f, 0.75f, 1},
//             {1, 0.95f, 0.7f, 0.85f, 1, 0.65f, 0.9f, 0.75f, 0.8f, 1},
//             {1, 0.75f, 0.85f, 0.7f, 1, 0.95f, 0.8f, 0.65f, 0.9f, 1},
//             {1, 0.9f, 0.95f, 0.65f, 1, 0.8f, 0.75f, 0.7f, 0.85f, 1},
//             {1, 0.85f, 0.65f, 0.75f, 1, 0.9f, 0.95f, 0.8f, 0.7f, 1},
//             {1, 0.7f, 0.75f, 0.95f, 1, 0.65f, 0.8f, 0.85f, 0.9f, 1},
//             {1, 0.8f, 0.9f, 0.7f, 1, 0.75f, 0.85f, 0.65f, 0.95f, 1},
//             {1, 0.65f, 0.7f, 0.8f, 1, 0.95f, 0.75f, 0.85f, 0.9f, 1},
//         };
//         int currentIndex = 0;
        
//         if(Input.GetKeyUp(KeyCode.RightArrow)){
//             currentIndex += 1;
//             expansion_rate = rateRaw[subjectNum, currentIndex];
//             Debug.Log("expansion rate is " + expansion_rate + " now");
//         } else if (Input.GetKeyUp(KeyCode.LeftArrow)){
//             currentIndex -= 1;
//             expansion_rate = rateRaw[subjectNum, currentIndex];
//             Debug.Log("expansion rate is " + expansion_rate + " now");
//         }
//     }
}