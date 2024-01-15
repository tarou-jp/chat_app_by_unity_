# ChatGPT APIを活用したチャットアプリの開発

## 概要
このプロジェクトでは、ChatGPT APIを使用して、音声やテキスト入力に対応するチャットアプリを開発した。アプリはユーザーの入力を受け取り、テキストまたは音声で応答する機能を備えている。また、SwitchボットAPIを組み込み、家電操作を行う機能や、大学の未提出課題を表示し警告する機能も実装されている。

## 主な機能
1. ユーザー入力の受付: テキストまたは音声によるユーザーの入力を受け付ける。
2. 返答機能: 入力に対してテキストまたは音声で返答する。
3. 家電操作: SwitchボットAPIを利用して、簡単なAIでユーザーの家電操作の意図を検出し、操作を行う。
4. 未提出課題の警告: 大学の未提出課題を表示し、ユーザーに警告する。

## システム説明
アプリ側処理: ユーザーのデバイス上で基本的なUI操作や入力処理を実行する。
サーバー側処理: 複雑なAPI呼び出しや音声認識などは別のサーバーで処理し、WebSocketを使用してアプリ側とサーバー側のデータ送受信を行う。

## ディレクトリ説明
after_websocket: サーバー側のソースコード（設定ファイル等は含まない）
scripts_unity: Unityで作成したソースコード

## 使用例

## 使用技術
- Unity
- Node.js
- C#
- Python
- 簡単な機械学習
