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
                if (sceneToggleButton.Button != null)
                {
                    switch (sceneToggleButton.Method)
                    {
                        case BtnMethod.Load:
                            if (sceneToggleButton.Scene != null)
                            {
                                sceneToggleButton.Button.onClick.AddListener(delegate { LoadScene(sceneToggleButton.Scene.name); });
                            }
                            break;
                        case BtnMethod.Quit:
                            sceneToggleButton.Button.onClick.AddListener(delegate { Quit(); });
                            break;
                    }
                }
            }
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Quit()
    {
        Application.Quit();
    }

    [Serializable]
    public class SceneButton
    {
        public Button Button;
        public BtnMethod Method;
        public Object Scene;
    }

    public enum BtnMethod
    {
        Load,
        Quit,
    }
}
