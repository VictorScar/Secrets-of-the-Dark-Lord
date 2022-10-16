using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SODL.UI
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] GameObject infoPanel;
        [SerializeField] TMP_Text messageText;
        [SerializeField] Button button;

        private void Awake()
        {
            button.onClick.AddListener(CloseInfoPanel);
        }

        public void ShowInfoPanel(string info)
        {
            messageText.text = info;
            infoPanel.SetActive(true);
        }

        public void CloseInfoPanel()
        {
            infoPanel.SetActive(false);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(CloseInfoPanel);
        }
    }
}