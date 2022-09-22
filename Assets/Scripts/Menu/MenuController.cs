using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private RectTransform title;
        [SerializeField] private RectTransform titleNumber;

        [SerializeField] private RectTransform[] buttons;
    
        private void Start()
        {
            var position = title.position.x;
            title.DOMoveX(position - 1000, 0);
            title.DOMoveX(position, 0.5f)
                .SetEase(Ease.OutCubic)
                .SetDelay(1);

            var posNumber = titleNumber.position.y;
            titleNumber.DOMoveY(posNumber + 400, 0);
            titleNumber.DOMoveY(posNumber, 0.2f)
                .SetEase(Ease.OutBounce)
                .SetDelay(2);

            var delay = 2.5f;
        
            foreach (var button in buttons)
            {
                var posButton = button.position.x;
                button.DOMoveX(posButton - 1000, 0);
                button.DOMoveX(posButton, 0.5f)
                    .SetEase(Ease.OutCubic)
                    .SetDelay(delay);

                delay += 0.1f;
            }
        }

        public void ClickPlay()
        {
            SceneManager.LoadScene(1);
        }

        public void ClickQuit()
        {
            Application.Quit();
        }
    }
}