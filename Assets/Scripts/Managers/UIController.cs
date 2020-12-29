using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private SettingsPopup popup;
    [SerializeField] private Text healthLabel;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }


    void Start()
    {
        OnHealthUpdated();
        popup.gameObject.SetActive(false);
    }

    private void OnHealthUpdated()
    {
        string message = "Heath: " + Managers.Player.health + "/" + Managers.Player.maxHealth;
        healthLabel.text = message;
    }

    public void SoundPanelOpen()
    {
        popup.gameObject.SetActive(true);
    }
    public void SoundPanelCose()
    {
        popup.gameObject.SetActive(false);
    }
}

