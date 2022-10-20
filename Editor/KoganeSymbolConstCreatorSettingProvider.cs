using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    internal sealed class KoganeSymbolConstCreatorSettingProvider : SettingsProvider
    {
        private const string PATH = "Kogane/Symbol Const Creator";

        private Editor m_editor;

        private KoganeSymbolConstCreatorSettingProvider
        (
            string              path,
            SettingsScope       scopes,
            IEnumerable<string> keywords = null
        ) : base( path, scopes, keywords )
        {
        }

        public override void OnActivate( string searchContext, VisualElement rootElement )
        {
            var instance = KoganeSymbolConstCreatorSetting.instance;

            instance.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            Editor.CreateCachedEditor( instance, null, ref m_editor );
        }

        public override void OnGUI( string searchContext )
        {
            using var changeCheckScope = new EditorGUI.ChangeCheckScope();

            m_editor.OnInspectorGUI();

            EditorGUILayout.Space();

            if ( GUILayout.Button( "Create" ) )
            {
                KoganeSymbolConstCreator.Create();
            }

            EditorGUILayout.Space();

            var setting = KoganeSymbolConstCreatorSetting.instance;

            if ( GUILayout.Button( "Reset to Default" ) )
            {
                Undo.RecordObject( setting, "Reset to Default" );
                setting.ResetToDefault();
            }

            if ( !changeCheckScope.changed ) return;

            setting.Save();
        }

        [SettingsProvider]
        private static SettingsProvider CreateSettingProvider()
        {
            return new KoganeSymbolConstCreatorSettingProvider
            (
                path: PATH,
                scopes: SettingsScope.Project
            );
        }
    }
}