using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Loading,
    Playing,
    Paused,
    GameOver
}

public class GameManager : MonoSingleton<GameManager>
{
    public GameState gameState = GameState.Loading;
    public float transitionTime = 2.0f;
    public string[] sceneNames;

    [SerializeField]
    private string currentSceneName;
    private bool isTransitioning = false;
    [SerializeField]
    private GameObject player;

    void Update()
    {
        switch (gameState)
        {
            case GameState.Loading:
                // Update loading progress
                break;

            case GameState.Playing:
                // Update gameplay logic
                break;

            case GameState.Paused:
                // Update pause menu
                break;

            case GameState.GameOver:
                // Update game over screen
                break;
        }
    }

    public void LoadScene(string sceneName)
    {
        if (isTransitioning)
        {
            return;
        }
        isTransitioning = true;
        StartCoroutine(TransitionToScene(sceneName));
    }

    private IEnumerator TransitionToScene(string sceneName)
    {
        gameState = GameState.Loading;

        //yield return new WaitForSeconds(transitionTime);
        yield return SceneManager.LoadSceneAsync(sceneName);
        currentSceneName = sceneName;
        isTransitioning = false;
        gameState = GameState.Playing;
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        GameObject obj = Resources.Load("Prefabs/Player") as GameObject;
        
        player = Instantiate(obj, Vector3.zero, Quaternion.identity);
    }

    public GameObject GetPlayer()
    {
        return player;
    }

}
