using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestJob
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
		{
			SceneManager.LoadScene(sceneName);
		}
    }
}
