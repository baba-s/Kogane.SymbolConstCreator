using System.Linq;
using UnityEditor;

namespace Kogane.Internal
{
    /// <summary>
    /// UniSymbol に登録されているシンボルの定数を管理するクラスを作成するエディタ拡張
    /// </summary>
    internal static class KoganeSymbolConstCreator
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// 定数を管理するクラスを生成します
        /// </summary>
        public static void Create()
        {
            var settings       = KoganeSymbolSetting.instance;
            var creatorSetting = KoganeSymbolConstCreatorSetting.instance;
            var template       = creatorSetting.CodeTemplate;

            var values = settings.List
                    .Select( x => new ConstStringCodeGeneratorOptions.Element { Name = x.Name, Value = x.Name, Comment = x.Comment } )
                    .ToArray()
                ;

            var options = new ConstStringCodeGeneratorOptions
            {
                Template = template,
                Elements = values,
            };

            var path = creatorSetting.OutputAssetPath;
            var code = ConstStringCodeGenerator.Generate( options );

            ConstStringCodeGenerator.Write( path, code );
            AssetDatabase.Refresh();
        }
    }
}