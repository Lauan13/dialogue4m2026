using System.Collections;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ShowSplash());
    }

    private IEnumerator ShowSplash()
    {
        // Espera 2 segundos
        yield return new WaitForSeconds(2f);

        // Carrega a cena MenuPrincipal
        GameManager.Instance.LoadScene("MenuPrincipal");
    }
}

