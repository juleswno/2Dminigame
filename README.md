# 🕹 2D 미니게임

Unity 2D 환경에서 구현한 캐릭터 이동 + 미니게임 실행 시스템입니다.  
JetBrains Rider 기반으로 개발되었으며, 씬 간 전환 및 점수 저장 기능을 포함하고 있습니다.


## ✅ 구현 기능

- 캐릭터 이동 (WASD, Rigidbody2D)
- 카메라 부드러운 추적 (Clamp 제한 포함)
- 미니게임 진입 트리거 + UI 안내
- 씬 전환 및 점수 전달
- 점수 시스템 (싱글턴 + PlayerPrefs 저장)
- 게임 종료 후 자동 복귀 + 결과 UI 표시


## 🛠 사용 기능

- Unity 2022.3.17f
- C# (.NET 4.x)
- JetBrains Rider
- PlayerPrefs
- SceneManager
- Rigidbody2D / Collider2D / Trigger


## 📁 폴더 구조

Assets/
├── Scripts/
│ ├── Player/ # PlayerController.cs
│ ├── Map/ # CameraFollow.cs, MiniGameTrigger.cs
│ ├── MiniGames/ # FlappyGameController.cs
│ ├── GameSystem/ # ScoreManager.cs
│ └── UI/ # MiniGameController.cs
├── Prefabs/
│ ├── Player.prefab
│ └── MiniGameZone.prefab
├── Scenes/
│ ├── MainMap.unity
│ ├── FlappyGame.unity
│ └── StackGame.unity


## 🧪 트러블슈팅

### 🎯 Trigger 감지 이슈
 > Player 오브젝트에 `"Player"` 태그가 없어서 OnTriggerEnter2D()가 작동하지 않음  
 → 태그를 올바르게 지정한 후 정상 작동


## 📌 주의 사항

- `Build Settings`에 모든 씬 추가 필수!
- UI 연결 안 하면 점수 표시 안 됨 (Canvas → Text 연결 필요)
