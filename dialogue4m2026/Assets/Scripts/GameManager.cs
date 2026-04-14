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

        // Validar transição baseada no estado atual
        if (currentState == GameState.Iniciando && sceneName.Equals("MenuPrincipal"))
        {
            transitionAllowed = true;
            SetState(GameState.MenuPrincipal);
        }
        else if (currentState == GameState.MenuPrincipal && sceneName.Equals("Gameplay"))
        {
            transitionAllowed = true;
            SetState(GameState.Gameplay);
        }

        if (transitionAllowed)
        {
            Debug.Log("Carregando cena: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Transição não permitida! Estado atual: " + currentState + " - Cena solicitada: " + sceneName);
        }
    }
}
