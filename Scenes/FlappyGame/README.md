# FlappyGame.unity 구성 설명

# Hierarchy 구성
- Main Camera
- GameController (빈 오브젝트, MiniGameController.cs 연결)
- Canvas
  - GameOverPanel (비활성화)
  - ResultText

# 연결된 컴포넌트
- GameController: MiniGameController.cs, resultText 연결
- FlappyGameController.cs: SPACE로 점수 누적, 성공 시 EndMiniGame 호출
