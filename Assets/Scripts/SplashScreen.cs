using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

    public Image splashLogo;
    public Text splashText;

    IEnumerator Start()
    {
        // Set the logo and text to be fully transparent at the beginning
        splashLogo.canvasRenderer.SetAlpha(0.0f);
        splashText.canvasRenderer.SetAlpha(0.0f);

        // Fade them in
        FadeIn();
        yield return new WaitForSeconds(2.5f);

        // Fade them out
        FadeOut();
        yield return new WaitForSeconds(2.5f);

        // Load the next scene in the queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void FadeIn()
    {
        splashLogo.CrossFadeAlpha(1.0f, 1.5f, false);
        splashText.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        splashLogo.CrossFadeAlpha(0.0f, 2.5f, false);
        splashText.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
