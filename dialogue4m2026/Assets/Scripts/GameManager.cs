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

    private GameState currentState;

    public void SetState(GameState newState)
    {
        currentState = newState;
        Debug.Log("Estado atual: " + currentState);
    }

    public void LoadScene(string sceneName)
    {
        bool transitionAllowed = false;
        GameState targetState = currentState; // Default, but will be set if allowed

        // Validar transição baseada no estado atual
        if (currentState == GameState.Iniciando && sceneName.Equals("MenuPrincipal"))
        {
            transitionAllowed = true;
            targetState = GameState.MenuPrincipal;
        }
        else if (currentState == GameState.MenuPrincipal && sceneName.Equals("Gameplay"))
        {
            transitionAllowed = true;
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
}
