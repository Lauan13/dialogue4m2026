using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public enum GameState
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    private GameState currentState = GameState.Iniciando;

    public void SetState(GameState newState)
    {
        currentState = newState;
        Debug.Log("Estado atual: " + currentState);
    }

    public void LoadScene(string sceneName)
    {
        bool transitionAllowed = false;
        GameState targetState = currentState;

        if (sceneName.Equals("MenuPrincipal"))
        {
            transitionAllowed = true;
            targetState = GameState.MenuPrincipal;
        }
        else if (sceneName.Equals("Gameplay"))
        {
            transitionAllowed = (currentState == GameState.MenuPrincipal || currentState == GameState.Gameplay);
            targetState = GameState.Gameplay;
        }
        else if (sceneName.Equals("SampleScene"))
        {
            transitionAllowed = (currentState == GameState.MenuPrincipal || currentState == GameState.Gameplay);
            targetState = GameState.Gameplay;
        }

        if (transitionAllowed)
        {
            SetState(targetState);
            string actualScene = sceneName;
            if (sceneName == "Gameplay")
            {
                actualScene = "SampleScene";
            }
            Debug.Log("Carregando cena: " + actualScene);
            SceneManager.LoadScene(actualScene);
        }
        else
        {
            Debug.Log("Transição não permitida! Estado atual: " + currentState + " - Cena solicitada: " + sceneName);
        }
    }

    public void StartGame()
    {
        LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Atualiza o estado com base na cena carregada
        if (scene.name == "MenuPrincipal")
        {
            SetState(GameState.MenuPrincipal);
        }
        else if (scene.name == "SampleScene")
        {
            SetState(GameState.Gameplay);
        }
    }
}
