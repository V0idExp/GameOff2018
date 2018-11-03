using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    bool alreadyTriggered = false;

	public void StartGameOver()
    {
        if (alreadyTriggered)
        {
            return;
        }

        var audio = GetComponent<AudioSource>();
        var sleep = audio.clip.length + 1.0f;
        audio.Play();
        StartCoroutine(ReloadAfter(sleep));

        alreadyTriggered = true;
    }

    IEnumerator ReloadAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        alreadyTriggered = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
