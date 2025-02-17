# ActionDemo

簡単なキャラクターアクション制御フレームワーク
主に以下の部分で構成されている：  
・プレイヤーのInput周りの処理  
・キャラ状態制御用StateMachine  
・キャラ状態に合わせたStateNotify（現在入力受付制限用InputConstraintNotifyのみ）  
・キャラ状態遷移に応じてモーションを再生する仕組み（AnimationManager辺り）  
・各種設定ファイル  

特に、キャラ状態制御用StateMachineやStateNotifyをUnityのAnimatorControllerのStateMachineに頼れず、自前で作成している。
そうすると、キャラ関連のロジック処理はアニメーションを依存せず、DedicatedServerなどで独立で処理することができる。
