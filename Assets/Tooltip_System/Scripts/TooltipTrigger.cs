using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
    {
        [TextAreaAttribute]
        public string text;
        public bool useMousePosition = false;
        public Vector3 offset;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (useMousePosition)
            {
                StartTooltipHover(new Vector3(eventData.position.x, eventData.position.y, 0f));
            }
            else
            {
                StartTooltipHover(transform.position + offset);
            }
        }

        public void OnSelect(BaseEventData eventData)
        {
            StartTooltipHover(transform.position);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            StopTooltipHover();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            StopTooltipHover();
        }

        void StartTooltipHover(Vector3 tooltipPos)
        {
            var image = GetComponent<Image>().sprite;
            TooltipView.Instance.ShowTooltip(text, tooltipPos, image);
        }

        void StopTooltipHover()
        {
            TooltipView.Instance.HideTooltip();
        }
    }
}