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

# トラブルシューティング

## VS Codeで参照が機能しないときは?

ターミナルで `dotnet restore` を実行する
