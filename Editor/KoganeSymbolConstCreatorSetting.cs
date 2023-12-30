using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// Preferences における設定を管理する ScriptableObject
    /// </summary>
    [FilePath( "ProjectSettings/Kogane/SymbolConstCreatorSetting.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class KoganeSymbolConstCreatorSetting : ScriptableSingleton<KoganeSymbolConstCreatorSetting>
    {
        //================================================================================
        // 定数
        //================================================================================
        private static readonly string DEFAULT_OUTPUT_ASSET_PATH = "Assets/SymbolConst.cs";

        private static readonly string DEFAULT_CODE_TEMPLATE = @"namespace Kogane
{
    public static partial class SymbolConst
    {
        public const int LENGTH = #LENGTH#;

#VALUES#
    }
}";

        //================================================================================
        // 変数(static)
        //================================================================================
        [SerializeField]                  private string m_outputAssetPath = DEFAULT_OUTPUT_ASSET_PATH;
        [SerializeField][Multiline( 16 )] private string m_codeTemplate    = DEFAULT_CODE_TEMPLATE;

        //================================================================================
        // プロパティ
        //================================================================================
        public string OutputAssetPath => m_outputAssetPath;
        public string CodeTemplate    => m_codeTemplate;

        //================================================================================
        // 関数
        //================================================================================
        public void Save()
        {
            Save( true );
        }

        public void ResetToDefault()
        {
            m_outputAssetPath = DEFAULT_OUTPUT_ASSET_PATH;
            m_codeTemplate    = DEFAULT_CODE_TEMPLATE;
        }
    }
}