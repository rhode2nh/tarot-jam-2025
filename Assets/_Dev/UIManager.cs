using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TMP_Text _cardText;
    public GameObject CardPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void SetCardName(string cardName)
    {
        _cardText.SetText(cardName);
    }

    public void OpenCardPanel()
    {
        CardPanel.SetActive(true);
    }

    public void CloseCardPanel()
    {
        CardPanel.SetActive(false);
        _cardText.SetText("");
    }
}
