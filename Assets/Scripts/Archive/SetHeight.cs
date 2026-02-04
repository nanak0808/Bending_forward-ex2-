using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHeight : MonoBehaviour
{

    // スケール変更速度
    public float scaleSpeed;

    // 最大・最小スケール
    public float maxScale;
    public float minScale;  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //右スティックのY軸の入力を取得
        float stickY = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;
        Debug.Log(stickY);

        ScaleObject(scaleSpeed * stickY);
  
        // if (OVRInput.Get(OVRInput.Button.Two)){
        //     ScaleObject(scaleSpeed);
        // }
        // else if (OVRInput.Get(OVRInput.Button.One)){
        //     ScaleObject(-scaleSpeed);
        // }
        
        // var scale = transform.localScale;
        // while(OVRInput.Get(OVRInput.Button.One)){
        //     scale = scale - basic;
        // }
        // while(OVRInput.Get(OVRInput.Button.Two)){
        //     scale = scale + basic;
        // }
    }

    private void ScaleObject(float scaleChange){
        // 現在のスケールを取得
        Vector3 currentScale = transform.localScale;
        // スケールの変更を適用
        currentScale += Vector3.one * scaleChange;

        // 最大・最小スケールの制限
        // currentScale = new Vector3(
        //     Mathf.Clamp(currentScale.x, minScale, maxScale),
        //     Mathf.Clamp(currentScale.y, minScale, maxScale),
        //     Mathf.Clamp(currentScale.z, minScale, maxScale)
        // );

        // 新しいスケールを適用
        transform.localScale = currentScale;
    }
}
