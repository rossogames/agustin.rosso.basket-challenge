using Rossoforge.Toolbar.Editor.Profiles.Buttons;
using Rossoforge.Toolbar.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace Rossoforge.Toolbar.Editor.Editors
{

    [CustomEditor(typeof(IconButtonProfile))]
    public class IconButtonProfileEditor : ButtonProfileEditor
    {
        protected IconButtonProfile _targetData;
        private SerializedProperty _toolTipProp;

        private GUIContent _selectIconButtonContent;

        protected override void OnEnable()
        {
            base.OnEnable();

            _targetData = (IconButtonProfile)target;
            _toolTipProp = serializedObject.FindProperty("_toolTip");

            _selectIconButtonContent = EditorGUIUtility.IconContent("Search Icon");
            _selectIconButtonContent.tooltip = "Select Icon";
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawToolTipProp();
            base.DrawSize();
            DrawIconSelector();
            base.DrawAddCallBackButton();
            base.DrawCallbacks();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawToolTipProp()
        {
            EditorGUILayout.PropertyField(_toolTipProp);
        }

        private void DrawIconSelector()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Icon");

            DrawIcon();
            DrawSearchIconButton();

            EditorGUILayout.EndHorizontal();
        }
        private void DrawIcon()
        {
            if (!string.IsNullOrEmpty(_targetData.IconName))
            {
                GUIContent iconContent = EditorGUIUtility.IconContent(_targetData.IconName);
                if (iconContent != null && iconContent.image != null)
                {
                    iconContent.tooltip = string.Empty;
                    GUILayout.Label(iconContent, GUILayout.Width(48), GUILayout.Height(48));
                }
            }
        }
        private void DrawSearchIconButton()
        {
            if (GUILayout.Button(_selectIconButtonContent, GUILayout.Width(32), GUILayout.Height(32)))
            {
                IconSelectorWindows.ShowPopup((selectedIcon) =>
                {
                    _targetData.IconName = selectedIcon;
                    EditorUtility.SetDirty(_targetData);
                });
            }
        }
    }
}
