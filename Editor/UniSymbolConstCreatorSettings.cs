using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
	/// <summary>
	/// Preferences における設定を管理する ScriptableObject
	/// </summary>
	internal sealed class UniSymbolConstCreatorSettings
		: ScriptableObjectForProjectSettings<UniSymbolConstCreatorSettings>
	{
		//================================================================================
		// 定数
		//================================================================================
		private static readonly string PACKAGE_NAME              = "UniSymbolConstCreator";
		private static readonly string DEFAULT_OUTPUT_ASSET_PATH = "Assets/UniSymbolConst.cs";

		private static readonly string DEFAULT_CODE_TEMPLATE = @"namespace MyProject
{
    public static partial class UniSymbolConst
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
		// 関数(static)
		//================================================================================
		[SettingsProvider]
		private static SettingsProvider SettingsProvider()
		{
			return CreateSettingsProvider
			(
				settingsProviderPath: $"Kogane/{PACKAGE_NAME}",
				onGUIExtra: so =>
				{
					if ( !GUILayout.Button( "Reset to Default" ) ) return;

					so.FindProperty( nameof( m_outputAssetPath ) ).stringValue = DEFAULT_OUTPUT_ASSET_PATH;
					so.FindProperty( nameof( m_codeTemplate ) ).stringValue    = DEFAULT_CODE_TEMPLATE;
				}
			);
		}
	}
}