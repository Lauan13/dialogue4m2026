using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
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

