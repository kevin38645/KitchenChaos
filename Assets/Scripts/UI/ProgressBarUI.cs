using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private IHasProgress hasProgress;
    [SerializeField] private Image barImage;

    private void Start() { 
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        if (hasProgress == null) {
            Debug.LogError($"Game object {hasProgressGameObject} does not have a component that implements IHasProgress!");
        }

        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;

        barImage.fillAmount = 0;

        Hide();
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e) {
        barImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 0f || e.progressNormalized == 1f) {
            Hide();
        } else {
            Show();
        }
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    // Althought
    public void Hide() {
        gameObject.SetActive(false);
    }
}
