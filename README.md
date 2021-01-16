# asp_net_core_mvc_sample
ASP.NET Core MVCを試すコード

# .NET Core 開発環境

.NET Core SDKをインストールする。内部には.NET CLIも含まれる。

https://docs.microsoft.com/ja-jp/dotnet/core/sdk

# Visual Studioを使わずにビルド等を行うには?

.NET CLIのコマンド(`dotnet`で始めるコマンド)を利用する。詳細は以下。
https://docs.microsoft.com/ja-jp/dotnet/core/tools/


# 手順

## ASP.NET Core のテンプレートを利用して新規プロジェクトを作る

ターミナルで `dotnet new` コマンドを利用する。
ASP.NET MVCの場合は、`dotnet new mvc` 

## 単純なコントローラーを作る

単純な(DBアクセスを含まない)コントローラーを作るには、

- `Controllers` ディレクトリ下に `Controller` サフィックスを持つファイルを作る。
- その中に`Microsoft.AspNetCore.Mvc.Controller` を継承した、ファイルと同名のクラスを作る。
- アクションのハンドラとして、`IActionResult` を返すメソッドを用意する。
  - 非同期処理の場合、`async Task<IActionResult>` となる。
- ハンドラの中身を記述し、最終的に値を返す。
  - 単にテキストを返すのであれば、`Content` メソッド。
  - リダイレクトを行う、`Redirect` や `RedirectToActionResult` もある。
  - エラーのステータスコードを返す、`NotFound` などもある。

## ルーティング

- ルーティングは`Startup.cs` の `UseEndpoints` 関数内で定義する。
  - デフォルトでは`{コントローラ名}/{アクション名}/{id}` となっている。

# デバッグ
## VS Codeでデバッグ実行するには?

左端のタブより「デバッグ実行(矢印と虫のマーク)」をクリックする

# トラブルシューティング

## VS Codeで参照が機能しないときは?

ターミナルで `dotnet restore` を実行する
