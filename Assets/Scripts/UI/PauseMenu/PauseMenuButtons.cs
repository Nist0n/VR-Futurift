using Config;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PauseMenu
{
    public class PauseMenuButtons : MonoBehaviour
    {
        [SerializeField] private Button continueButton;
    
        [SerializeField] private Button exitButton;

        [SerializeField] private GameObject pauseMenu;
        
        void Start()
        {
            continueButton.onClick.AddListener(ContinueTraining);
            exitButton.onClick.AddListener(Exit);
        }

        private void ContinueTraining()
        {
            GameConfig.Instance.IsPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        private void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}
