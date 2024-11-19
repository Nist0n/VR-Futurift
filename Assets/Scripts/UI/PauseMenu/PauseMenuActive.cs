using Config;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI.PauseMenu
{
    public class PauseMenuActive : MonoBehaviour
    {
        [SerializeField] private InputActionProperty pauseAction;

        [SerializeField] private GameObject pauseMenu;
        
        private void Update()
        {
            if (pauseAction.action.triggered)
            {
                Time.timeScale = GameConfig.Instance.IsPaused ? 1 : 0;
                
                pauseMenu.SetActive(!GameConfig.Instance.IsPaused);
                
                GameConfig.Instance.IsPaused = !GameConfig.Instance.IsPaused;
            }
        }
    }
}
