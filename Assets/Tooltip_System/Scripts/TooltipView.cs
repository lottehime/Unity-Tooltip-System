using UnityEngine;

namespace UnityEngine.UI.Extensions
{
    public class TooltipView : MonoBehaviour
    {
        public Text tooltipText;
        public Image tooltipImage;
        public Vector3 tooltipOffset;

        public bool IsActive
        {
            get {return gameObject.activeSelf;}
        }

        void Awake()
        {
            instance = this;
            if (!tooltipText) tooltipText = GetComponentInChildren<Text>();
            HideTooltip();
        }

        public void ShowTooltip(string text, Vector3 pos, Sprite image)
        {
            if (tooltipText.text != text)
            {
                tooltipText.text = text;
            }

            transform.position = pos + tooltipOffset;
            tooltipImage.sprite = image;

            gameObject.SetActive(true);
        }

        public void HideTooltip()
        {
            gameObject.SetActive(false);
        }

        private static TooltipView instance;
        public static TooltipView Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<TooltipView>();
                return instance;
            }
        }
    }
}
