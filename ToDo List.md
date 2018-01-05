# 第2章 配列を使ったリスト

## 2.1 ArrayStack：配列を使った高速なスタック操作

通常の配列を扱った処理。実際の処理を行う際には次の2つを明確に区別する必要がある

- a.Length：配列長(配列として確保しているメモリのサイズ)
- n：格納しているデータのサイズ

また、拡張と収縮を行う際には一定のルールの下、行う必要がある

例えば、配列サイズを変更する関数(resize)を行うタイミングは以下のようにする

- 拡張をする際にはメモリサイズが足りなくなった時
- 収縮をする際には $a.Length \geqq 3n$ を満たす時

また、resize関数は $a.Length = 2n$ にする関数とする

| ArrayStackの動作 |
|----|
| ![](画像\ArrayStack.jpg) |

```cs
void resize<T>(ref T[] a, int n)
{
    T[] b = new T[n * 2];
    for (int i = 0; i < n; i++)
    {
        b[i] = a[i];
    }
    a = b;
}
```

この関数は既に関数として用意されている

```cs
Array.Resize<T>(ref a, 2 * n);
```

## 2.2 FastArrayStack：最適化されたArrayStack

ArrayStackの処理は3種類しかない

- 使用するメモリのリサイズ
- データのシフト
	- Add関数とRemove関数
- データのコピー
	- メモリのリサイズをするときに実施

データのシフトをfor文を使って行うことは非効率であり、既存の関数を使ったほうが良い

```cs
void resize<T>(ref T[] a, int n)
{
    Array.Resize<T>(ref a, 2 * n);
}

void add<T>(ref T[] a, ref int n, int i, T x)
{
    if (n + 1 > a.Length)
        resize(ref a, n);

    Array.Copy(a, i, a, i + 1, n - i);

    a[i] = x;
    n++;
}

T remove<T>(ref T[] a, ref int n, int i)
{
    T x = a[i];
    if (n + 1 > a.Length)
        resize(ref a, n);

    Array.Copy(a, i + 1, a, i, n - i - 1);
    n--;

    if (a.Length >= 3 * n)
        resize<T>(ref a, n);

    return x;
}
```

前記の手法と動作は変わらないが、コピー関数は最適化されているため、拘束に実行されることが多い。

>将来的な最適化も実施されることが考えられるため、こちらを使用しておいたほうが良い

## 2.3 ArrayQueue：配列を使ったキュー
## 2.4 ArrayDeque：配列を使った高速な双方向キュー
## 2.5 DualArrayDeque：2つのスタックから作った双方向キュー
## 2.6 RootishArrayStack：空間効率に優れた配列スタック
## 2.7 ディスカッションと練習問題

# 第3章 連結リスト

## 3.1 SLList：単方向連結リスト
## 3.2 DLList: 双方向連結リスト
## 3.3 SEList：空間効率のよい連結リスト
## 3.4 ディスカッションと練習問題

# 第4章 スキップリスト

## 4.1 基本的な構造
## 4.2 SkiplistSSet：効率的なSSet
## 4.3 SkiplistList：効率的なランダムアクセスList
## 4.4 スキップリストの解析
## 4.5 ディスカッションと練習問題

# 第5章 ハッシュテーブル

## 5.1 ChainedHashTable: チェイン法を使ったハッシュテーブル
## 5.2 LinearHashTable：線形探索法
## 5.3 ハッシュ値
## 5.4 ディスカッションと練習問題

# 第6章 二分木

## 6.1 BinaryTree：基本的な二分木
## 6.2 BinarySearchTree：バランスされていない二分探索木
## 6.3 ディスカッションと練習問題

# 第7章 ランダム二分探索木

## 7.1 ランダム二分探索木
## 7.2 Treap
## 7.3 ディスカッションと練習問題

# 第8章 Scapegoat Tree

## 8.1 ScapegoatTree：部分再構築する二分探索木
## 8.2 ディスカッションと練習問題

# 第9章 赤黒木

## 9.1 2-4 木
## 9.2 RedBlackTree：2-4 木のシミュレーション
## 9.3 要約
## 9.4 ディスカッションと練習問題

# 第10章 ヒープ

## 10.1 BinaryHeap：暗黙の二分木
## 10.2 MeldableHeap：ランダムなMeldable ヒープ
## 10.3 ディスカッションと練習問題

# 第11章 整列アルゴリズム

## 11.1 比較に基づく整列
## 11.2 計数ソートと基数ソート
## 11.3 ディスカッションと練習問題

# 第12章 グラフ

## 12.1 AdjacencyMatrix：行列によるグラフの表現
## 12.2 AdjacencyLists：リストの集まりとしてのグラフ
## 12.3 グラフの走査
## 12.4 ディスカッションと練習問題

# 第13章 整数を扱うデータ構造

## 13.1 BinaryTrie：デジタル探索木
## 13.2 XFastTrie：Doubly-Logarithmic 時間で検索を行う
## 13.3 YFastTrie：実行時間がDoubly-Logarithmic なSSet
## 13.4 ディスカッションと練習問題

# 第14章 外部メモリの探索

## 14.1 Block Store
## 14.2 B 木
## 14.3 ディスカッションと練習問題