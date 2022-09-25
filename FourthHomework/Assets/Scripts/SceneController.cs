using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(() => RestartScene());
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
