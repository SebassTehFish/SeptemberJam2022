using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Object = UnityEngine.Object;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    public List<SceneButton> SceneToggleButtons;

    void Start()
    {
        if (SceneToggleButtons != null && SceneToggleButtons.Count > 0)
        {
            foreach (var sceneToggleButton in SceneToggleButtons)
            {
                if (sceneToggleButton.Button != null && sceneToggleButton.Scene != null)
                {
                    sceneToggleButton.Button.onClick.AddListener(delegate { LoadScene(sceneToggleButton.Scene.name); });
                }
            }
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    [Serializable]
    public class SceneButton
    {
        public Button Button;
        public Object Scene;
    }
}
