## 開発環境
- Unity
  - ver.2022.3.50f1
- VR
  - Meta Quest3

## 実装方法メモ
### 手の表示位置を変化させた方法
（ロジックは論文記載）
※ver.2022.3.5.0f1では、OVR管理下の取得した手の座標をスクリプトで上書きできたため、以下の方法で実装

- ```OVRCameraRig > TrackingSpace > Left(Right)HandAnchor > OVRLeft(Right)HandSynthetic > OVRLeft(Right)HandVisual```に
  - オブジェクトの位置を変化させるスクリプト（ChangeHandTrackPosition.cs）
  - 参加者の前屈前の柔軟性を取得する（キャリブレーションする）スクリプト（Measure_firstposition.cs）
  
  をアタッチ

### 計測器を追従させた方法
- 長座体前屈計のoオブジェクト```desk_v1```  に対象となるオブジェクトと同じ座標になるスクリプト（Move_desk.cs）をアタッチ
- Stopを押すと追従がオフになる
