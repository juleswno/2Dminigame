# MainMap.unity 구성 설명

## 🎮 Hierarchy 구성
- Main Camera
- Canvas
  - PopupUI (비활성화 상태로 시작)
- Player (Player.prefab, 태그: "Player")
- MiniGameZone (빈 GameObject, Trigger Collider 포함)

## 🔌 연결된 컴포넌트
- Player: Rigidbody2D, BoxCollider2D, PlayerController.cs
- Camera: CameraFollow.cs (Player 연결됨)
- MiniGameZone: BoxCollider2D (IsTrigger), MiniGameTrigger.cs
- Canvas: PopupUI 오브젝트 연결 (MiniGameTrigger에 참조됨)

