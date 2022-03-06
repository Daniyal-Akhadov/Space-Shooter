using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _panelExitMainAnimation;

    public void ExitGame()
    {
        _panelExitMainAnimation.SetActive(true);
        Invoke(nameof(Application.Quit), 1.3f);
    }

    public void StartGame()
    {
        _panelExitMainAnimation.SetActive(true);
        Invoke(nameof(PlayBaseScene), 1.3f);
    }

    private void PlayBaseScene()
    {
        SceneManager.LoadScene(1);
    }


}
