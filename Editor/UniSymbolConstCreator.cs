using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
	/// <summary>
	/// UniSymbol に登録されているシンボルの定数を管理するクラスを作成するエディタ拡張
	/// </summary>
	[InitializeOnLoad]
	internal static class UniSymbolConstCreator
	{
		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		static UniSymbolConstCreator()
		{
			UniSymbolSettingsInspector.OnHeaderGUI += OnHeaderGUI;
		}

		/// <summary>
		/// UniSymbolSettings の Inspector のヘッダの GUI を描画する時に呼び出されます
		/// </summary>
		private static void OnHeaderGUI( UniSymbolSettings settings )
		{
			if ( GUILayout.Button( "Create Const Script" ) )
			{
				Create( settings );
			}
		}

		/// <summary>
		/// 定数を管理するクラスを生成します
		/// </summary>
		public static void Create( UniSymbolSettings settings )
		{
			var editorSettings = UniSymbolConstCreatorSettings.GetInstance();
			var template       = editorSettings.CodeTemplate;

			var values = settings.List
					.Select( x => new ConstStringCodeGeneratorOptions.Element { Name = x.Name, Value = x.Name, Comment = x.Comment } )
					.ToArray()
				;

			var options = new ConstStringCodeGeneratorOptions
			{
				Template = template,
				Elements = values,
			};

			var path = editorSettings.OutputAssetPath;
			var code = ConstStringCodeGenerator.Generate( options );

			code = code
					.Replace( "\t", "    " )
					.Replace( "\r\n", "#NEW_LINE#" )
					.Replace( "\r", "#NEW_LINE#" )
					.Replace( "\n", "#NEW_LINE#" )
					.Replace( "#NEW_LINE#", "\r\n" )
				;

			ConstStringCodeGenerator.Write( path, code );
			AssetDatabase.Refresh();
		}
	}
}