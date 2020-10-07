# UniSymbolConstCreator

UniSymbol に登録されているシンボルを定数の文字列で管理するクラスを生成するエディタ拡張

## 使い方

![2020-10-07_094732](https://user-images.githubusercontent.com/6134875/95274993-3d2c0d80-0882-11eb-9245-d02eb4ed7d82.png)

UniSymbolSettings.asset の Inspector で「Create Const Script」を押すと  

![2020-10-07_094759](https://user-images.githubusercontent.com/6134875/95274996-4026fe00-0882-11eb-99e6-55c2d8aca2db.png)

```cs
namespace Kogane
{
    public static partial class UniSymbolConst
    {
        public const int LENGTH = 2;

        ///<summary>
        ///<para>リリースモード有効化</para>
        ///</summary>
        public const string ENABLE_RELEASE = "ENABLE_RELEASE";
        ///<summary>
        ///<para>デバッグモード有効化</para>
        ///</summary>
        public const string DISABLE_RELEASE = "DISABLE_RELEASE";
    }
}
```

UniSymbol に登録されているシンボルを定数の文字列で管理するクラスを生成できます  

![2020-10-07_094705](https://user-images.githubusercontent.com/6134875/95274991-3b624a00-0882-11eb-8a87-8ccb319991de.png)

Project Settings の「Kogane > UniSymbolCOnstCreator」から  
生成される C# スクリプトの出力先やコードテンプレートを変更できます  
