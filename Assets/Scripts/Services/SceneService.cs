using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneService
    {
        
        public void ReloadLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(currentSceneIndex);
        }
        
    }
}