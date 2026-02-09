## 開発環境
- Unity
  - ver.2022.3.50f1
- VR
  - Meta Quest3

## 実装方法メモ
### 手の表示位置を変化させた方法
（ロジックは論文記載）

- ```OVRCameraRig > TrackingSpace > Left(Right)HandAnchor > OVRLeft(Right)HandSynthetic > OVRLeft(Right)HandVisual```に
  - オブジェクトの位置を変化させるスクリプト
  - 参加者の前屈前の柔軟性を取得する（キャリブレーションする）スクリプト
  
  をアタッチ

### 計測器を追従させた方法
- 長座体前屈計のoオブジェクト```desk_v1```  に対象となるオブジェクトと同じ座標になるスクリプトをアタッチ
- Stopを押すと追従がオフになる
