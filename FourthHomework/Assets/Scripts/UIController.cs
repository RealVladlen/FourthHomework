using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsCounterText;

    [SerializeField] private PlayerMove _playerController;

    [SerializeField] private GameObject _winPanel;

    private CanvasGroup _winPanelCanvas;

    private void Awake()
    {
        _winPanelCanvas = _winPanel.GetComponent<CanvasGroup>();
        _winPanelCanvas.alpha = 0;
        _winPanel.SetActive(false);
    }

    public void CoinsCouintUpdate(int count)
    {
        _coinsCounterText.text = count.ToString();
        _coinsCounterText.transform.DOScale(1.5f, 0.15f).SetLoops(2, LoopType.Yoyo);
    }

    public void ShowWinPanel()
    {
        _winPanel.SetActive(true);
        _winPanelCanvas.DOFade(1, 1);
        _playerController.ClearSpeed();
    }
}
