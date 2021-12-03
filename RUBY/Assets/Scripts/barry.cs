using UnityEngine;
/// <summary>
/// 回血寶物
/// </summary>
public class barry : MonoBehaviour
{
    #region 欄位
    public GameObject Effects;
    //遊戲物件 特效
    #endregion
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Instantiate(Effects, gameObject.transform.position, Quaternion.identity);
        RubyMove rubyMove = collision.GetComponent<RubyMove>();
        //RubyMove在這個C#的名字是rubyMove(要告知這個C#檔案才能使用)
        //將其定義為碰撞(collision)時從RubyMove裡拿取資料
        print(rubyMove + "拿到了!");
        //檢查Ruby碰撞
        rubyMove.ChangeHealth(1);
        //帶入到rubyMove(barry這個C#檔案裡RubyMove的名字)的ChangeHealth(帶入變數<加減血量>)
        Destroy(gameObject);
        //讓物件消失
    }
   
}
