using UnityEngine;

namespace UnityEngine.UI.Extensions
{
    public class TooltipGOTrigger : MonoBehaviour
    {
        [TextAreaAttribute]
        public string text;
        public Sprite tooltipIcon;
        public bool useMousePosition = false;
        public Vector3 offset;

        public void OnMouseOver()
        {
            if (useMousePosition)
            {
                StartTooltipHover(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            }
            else
            {
                StartTooltipHover(Input.mousePosition + offset);
            }
        }

        public void OnMouseExit()
        {
            StopTooltipHover();
        }

        void StartTooltipHover(Vector3 tooltipPos)
        {
            var image = tooltipIcon;
            TooltipView.Instance.ShowTooltip(text, tooltipPos, image);
        }

        void StopTooltipHover()
        {
            TooltipView.Instance.HideTooltip();
        }
    }
}