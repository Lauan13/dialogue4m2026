using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("PlayGame() foi chamado!");
        
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance é NULL!");
            return;
        }
        
        Debug.Log("Chamando GameManager.LoadScene('Gameplay')");
        GameManager.Instance.LoadScene("Gameplay");
    }

    public void ExitGame()
    {
        Debug.Log("Saindo do jogo...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

