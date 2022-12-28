using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private bool isGameOver = false;

    [SerializeField]
    private string mainMenuScene = "MainMenuScene";

    [SerializeField]
    private GameObject endBuildingPrefab;
    [SerializeField]
    private GameObject gameOverMenuUI;

    void Update()
    {
        if (endBuildingPrefab.GetComponent<EndBuilding>().health <= 0)
        {
            gameOver();
        }
    }

    private void gameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;

        gameOverMenuUI.SetActive(true);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        Destroy(MapSaver.instance.gameObject);
        SceneManager.LoadScene(mainMenuScene);
    }
}