# asp_net_core_mvc_sample
ASP.NET Core MVCを試すコード
DBはSQL ServerのLocalDBを前提

# .NET 5 開発環境

.NET 5 SDKをインストールする。内部には.NET CLIも含まれる。

https://dotnet.microsoft.com/download

chocolateyの場合はdotnet-sdkパッケージをインストールする。( `choco install dotnet-sdk` )

# Visual Studioを使わずにビルド等を行うには?

.NET CLIのコマンド(`dotnet`で始めるコマンド)を利用する。詳細は以下。
https://docs.microsoft.com/ja-jp/dotnet/core/tools/


# 手順

## ASP.NET Core のテンプレートを利用して新規プロジェクトを作る

ターミナルで `dotnet new` コマンドを利用する。
ASP.NET MVCの場合は、`dotnet new mvc` 

## ツールをインストール
- `dotnet tool install --global dotnet-ef`
- `dotnet tool install --global dotnet-aspnet-codegenerator`
  - .NET のバージョンと一致したものを入れる。

## パッケージを追加
- Entity Framework Core (Sql Server)を追加する
  - `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
- Entity Framework Core (Tools)を追加する
  - `dotnet add package Microsoft.EntityFrameworkCore.Tools`
- VisualStudio.Web.CodeGeneration.Designを追加する
  - `dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design`

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

## モデル作成
- `Models` ディレクトリ下にファイルを作る。
- 内部にファイルと同名のクラスを作る
- クラスのプロパティを作成する。
  - `System.ComponentModel.DisplayName` 属性を付けることで、ビューでの表示名を設定できる
  - 個々のプロパティに情報や制限を付けるには、`System.ComponentModel.DataAnnotations` の属性を使う。
    - `StringLength` や `Range` などで制限
    - `DataType` などで付加的な型の情報を入れることも(価格や電話番号、メールアドレスなどの指定が可能)
    - データのバージョン管理を行うには、`Timestamp` 属性を
  - 複数プロパティにまたがる検証を可能とするには、`IValidatableObject` インタフェースの`Validate` メソッドを実装する。
    - 戻り値が `IEnumerable<ValidationResult>` のため、検証が1個でも列挙可能な形で返す必要あり。


## コンテキスト作成・設定
- `Models` ディレクトリ下にファイルを作り、 `Microsoft.EntityFrameworkCore.DbContext` を継承したクラスを作成。
  - プロパティに `DbSet` ジェネリックを使ったモデルへのアクセサーを用意する。
- `Startup.cs` の`ConfigureServices` 下で`services.AddDbContext` を呼び出し、コンテキストとDBを関連付ける。

## 接続文字列指定
- `appsettings.json` に`ConnectionStrings` プロパティを追加し、その子として `コンテキスト名: 接続文字列` のプロパティを追加。
  - サーバー(LocalDBの場合): `Server=(localdb)\\MSSQLLocalDB;`
  - DB名: `Database={DB名};`
  - Windows認証する場合: `Trusted_Connection=True;` 
  - 複数のセットを開けるか: `MultipleActiveResultSets=True;`

## マイグレーション
- `dotnet ef migrations add {マイグレーション名}` をコマンドで実行することで、マイグレーションを生成。
- 続けて `dotnet ef database update` でデータベースを生成

## スキャフォールディング
- `dotnet aspnet-codegenerator controller` コマンドでコントローラとビューを生成する。オプションは以下。
  - `--project` : プロジェクトパス
  - `--controllerName` コントローラ名
  - `--model` : モデル名
  - `--dataContext` : コンテキスト名
  - `--relativeFolderPath` : コントローラを保存するフォルダパス
  - `--controllerNameSpace` : コントローラが配置される名前空間
  - `--useDefaultLayout` : デフォルトレイアウトを使用する
  - `--referenceScriptLibraries` : スクリプトライブラリの参照を可能とする
# デバッグ
## VS Codeでデバッグ実行するには?

左端のタブより「デバッグ実行(矢印と虫のマーク)」をクリックする

# トラブルシューティング

## VS Codeで参照が機能しないときは?

ターミナルで `dotnet restore` を実行する

## VS CodeからlocalDBに直接接続するには?

- SQL Server連携から、 `Data Source=(localdb)\MSSQLLocalDB;Trusted_Connection=True;` を指定して接続する。

