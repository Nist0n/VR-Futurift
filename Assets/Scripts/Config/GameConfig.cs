using Audio;
using UnityEngine;

namespace Config
{
    public class GameConfig : MonoBehaviour
    {
        public static GameConfig Instance;
        
        public bool IsPaused = true;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        void Start()
        {
            AudioManager.Instance.PlayMusic("Test");
            Time.timeScale = 0;
        }
    }
}
