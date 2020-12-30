using System;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheNorthwoodSuite_FovChanger
{
    [BepInPlugin("dev.lone.TheNorthwoodSuite_FovChanger", "TheNorthwoodSuite_FovChanger", "1.0.0.0")]
    public class TheNorthwoodSuite_FovChanger : BaseUnityPlugin
    {
        private ConfigEntry<int> config_fov;

        Camera mainCamera;

        void Awake()
        {
            config_fov = Config.Bind("General", "FOV", 80, "Custom fov");
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }

        private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
        {
            mainCamera = Camera.main;
        }

        void Update()
        {
            if (mainCamera != null && mainCamera.enabled && mainCamera.fieldOfView != config_fov.Value)
                mainCamera.fieldOfView = config_fov.Value;
        }
    }
}