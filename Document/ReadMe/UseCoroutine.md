## 12. コルーチンを使おう

今回は、UnityC#において使用できる便利な機能、コルーチンの使い方を説明します。  
コルーチンとは、 **処理の途中で停止したり、その後そこから再開できるような関数**
であると考えてもらえれば大丈夫かと思います。  
言葉で説明するとわかりづらいと思うので、具体的な例を出します。  

````cs
private void Start() {

       // StartCoroutine(CountUpCoroutine());

       CountUp();

       Debug.Log("hoge");
   }

   private void CountUp() {

       for (int i = 0; i < 10; ++i) {
           Debug.Log(i);
       }
   }

   private IEnumerator CountUpCoroutine() {

       for (int i = 0; i < 10; ++i) {
           Debug.Log(i);
           yield return null;
       }
   }
````

ここで、上のCountUpが通常のカウントアップ関数、下のCountUpがコルーチンを用いたカウントアップ関数です。  
Start関数内で、CountUpを呼んだときの出力は、  
0,1,2,3,4,5,6,7,8,9,hoge  
になります。
次に、Start関数内で、StartCoroutine(CountUpCoroutine())を呼んだときの出力は、  
0,hoge,1,2,3,4,5,6,7,8,9  
となります。

どうしてこうなるのかというと、コルーチンを用いた方は、forループの中に  
yield return null  
という記述があると思いますが、ここに辿りついた時点で、一度関数から抜けているわけです。  
そのため、関数から抜けてStart関数内に戻り、そのあとに記述されていたDebug.Log("hoge")を実行して、hogeがログに出力されるのです。  

これらの説明でもやはり少しわかりづらいと思いますが、今は処理が途中で停止できて、再開もできる便利なやつという認識でいればよいかと思います。  

では、上記のソースコードに関して少し解説をします。  
まず、コルーチンは、上記のようにIEnumeratorを返り値として作成します。  
コルーチンの中断方法はいくつかあり、今回は、1フレーム後に動作を再開するというyield return nullを使用しました。  
その他にも、**yield return new WaitForSeconds(5f);**　とすれば、5秒後に関数内の処理を再開できたりします。  

次に、コルーチンの呼び出し方についてですが、StartCoroutine()というものを使って呼びます。  
コルーチンはStartCoroutine()を使って呼び出すたびに起動します。  
なので、Update内でStartCoroutine()を使ってしまうと、たくさんのコルーチンが起動してしまうことになるので、注意しましょう。  

では、今回のゲームにもコルーチンを用いてみましょう。  
現在、コインの生成はIキーを押したときに生成される、という仕組みになっています。  
これを一定時間ごとに自動で出現するように修正しましょう。  
この一定時間ごとに、という処理はコルーチンに非常に向いています。  

以下にCoinGenerator.csのソースコードを示します。以前作成したものを修正しましょう。  

````cs
using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

    private const float generate_span_ = 2f;

    [SerializeField]
    private GameObject coin_prefab_;

    private void Start() {
        StartCoroutine(GenerateCoin());
    }

    private IEnumerator GenerateCoin() {

        while (true) {
            Instantiate(coin_prefab_, RandomCoinPos(), Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    //コインの生成位置をランダムに返す
    private Vector3 RandomCoinPos() {
        int pos_x = Random.Range(-90, 90);
        int pos_z = Random.Range(-90, 90);

        Vector3 pos = new Vector3(pos_x, 1, pos_z);
        return pos;
    }

}
````

上記のソースコードは、今回説明したことを理解できていればわかるかと思います。  
やっていることは、Start関数でコルーチンを起動し、そのコルーチン内では、永遠に2秒ごとにコインを１枚ランダムな位置に生成するということを行っています。  

この状態で、ゲームを起動してみると、自動でコインが生成されるようになったかと思います。  
このように、一定時間ごとにこれをしたい、とか何秒か待ってからこれをしたいという処理には非常にコルーチンは向いているので、積極的に学んで利用していきましょう。  

[←敵を動かそう](./MakeEnemy.md) | [UIを作ろう→](./MakeUI.md)

[目次に戻る](../../README.md)  
