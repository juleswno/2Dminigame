namespace MiniGames
{
    public class FlappyGameController : MonoBehaviour
    {
        public int score = 0;
        public UI.MiniGameController gameController;

        void Update()
        {
            // 임시 점수 시스템 (스페이스 누르면 점수 상승)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                score += 10;
                if (score >= 100)
                    gameController.EndMiniGame(true, score);
            }
        }
    }

    public class StackGameController : MonoBehaviour
    {
        public int score = 0;
        public UI.MiniGameController gameController;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                score += 5;
                if (score >= 50)
                    gameController.EndMiniGame(true, score);
            }
        }
    }
}
