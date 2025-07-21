﻿using System;
using System.ComponentModel;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Rossoforge.Toolbar.Editor.Callbacks
{
    [Serializable]
    [Description("Open Scene")]
    public class ButtonCallbackOpenScene : ButtonCallback
    {
        public SceneAsset Scene;

        public override bool Enabled
        {
            get
            {
                return
                    Scene != null &&
                    !EditorApplication.isPlaying &&
                    !EditorApplication.isPaused &&
                    !EditorApplication.isCompiling &&
                    !EditorApplication.isPlayingOrWillChangePlaymode;
            }
        }

        public override bool Invoke()
        {
            string scenePath = AssetDatabase.GetAssetPath(Scene);
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(scenePath);
                return true;
            }

            return false;
        }
    }
}