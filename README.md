# ActionDemo

簡単なキャラクターアクション制御フレームワーク
主に以下の部分で構成されている：  
・プレイヤーのInput周りの処理  
・キャラ状態制御用StateMachine  
・キャラ状態に合わせたStateNotify（現在入力受付制限用InputConstraintNotifyのみ）  
・キャラ状態遷移に応じてモーションを再生する仕組み（AnimationManager辺り）  
・各種設定ファイル  


特に、キャラ状態制御用StateMachineやStateNotifyをUnityのAnimatorControllerのStateMachineに頼れず、自前で作成している。
なので、キャラ関連のロジック処理はアニメーションを依存せず、DedicatedServerなどで独立で処理することができる。

ただ開発期間が短いため、コードのコメントはほぼ書いてないし、コード自体をいろいろ改善できるところもある。
後日ゆっくりリファクタリングしていく予定。


操作方法  
・移動：Keyboard WSAD / Gamepad LeftStick  
・回避：Mouse right button / Gamepad button south  
・攻撃：Mouse left button / Gamepad button west  


既知問題  
・回避や攻撃のモーションはRootMotionとして整備できてないため、Rootの移動や回転はモーション終了後に戻る  


アセット  
[Mixamo](https://www.mixamo.com/) から取得  
・Paladin W/Prop Nordstrom ＋ Sword and Shield Pack  
・Erika Archer With Bow/Arrow ＋ Pro Longbow Pack（未使用）  

