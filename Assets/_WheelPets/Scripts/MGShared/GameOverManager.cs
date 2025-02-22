using UnityEngine;

// TODO make this work across scenes?
// BUG is game over overlay bug fixed?
// FIXME gameover overlay needs a background color
// FIXME deprecation of GameOverPanel, use MinigameOverPrefab
public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPrefab;
    private GameObject gameOverInstance;
    public GameObject panelObject;

    void Start()
    {
        // create prefab if it doesn't exist
        if (gameOverInstance == null)
        {
            gameOverInstance = Instantiate(
                gameOverPrefab,
                parent: panelObject.transform
            );
            gameOverInstance.SetActive(false);
        }
    }

    public void ShowGameOver()
    {
        gameOverInstance.SetActive(true);
        Time.timeScale = 0f;
    }
}
