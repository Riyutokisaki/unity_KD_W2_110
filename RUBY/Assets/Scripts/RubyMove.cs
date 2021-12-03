using UnityEngine;

/// <summary>
/// 使用混合樹動畫機制ruby移動程式
/// 目前問題:Ruby移動時動畫延遲
/// </summary>
/// 

public class RubyMove : MonoBehaviour
{
    #region 欄位
    //私人欄位
    private Vector2 LookDirection;//定義看的方向 46 57
    private Vector2 RubyPosition;//定義位置 30 64
    private Vector2 RubyGO;//定義移動量 41

    //公開欄位
    public Animator RubyAnimation;//定義動畫控制器變數 22 57
    public Rigidbody2D RB;//定義鋼體(Move) 23

    public float speed = 4.2f;//64
    //血量設定
    [Header("最高血量")]
    public int maxHealth = 5;
    [Header("當前血量")]
    public int nowHealth;
    #endregion

    void Start()//遊戲開始時執行
    {
        RubyAnimation = GetComponent<Animator>();//拿到套用腳本本身物件的動畫元件，在公開欄位會顯示
        RB = GetComponent<Rigidbody2D>();//讀取套用腳本物件的剛體元件，會在公開欄位顯示
        //GetComponent        <>        ();
        //(讀取套用腳本的物件)<的某個元件>(變數);
        
        nowHealth = maxHealth;//剛開始的血量是滿血
    }

    private void FixedUpdate()//固定幀數執行
    {
        RubyPosition = transform.position;//把目前物件位置定義至私人欄位內

        #region 定義按鍵數值(偵測按鍵按多少)
        //horizontal水平 vertical垂直
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //檢測用(顯示於unity的console中)
        //print("左右鍵數值為"+horizontal);
        //print("上下鍵數值為" +vertical);
        #endregion
        
        RubyGO = new Vector2(horizontal,vertical);//把上面取得的按鍵數值設立新物件定義給RubyGo

        #region 按鍵輸入不為0時
        if (!Mathf.Approximately(RubyGO.x,0) || !Mathf.Approximately(RubyGO.y,0))
        {
            RubyAnimation.SetTrigger("GO");
            LookDirection = RubyGO;//當玩家按下移動按鍵時(不為0)，則給予Ruby方位
            LookDirection.Normalize();//標準化，使按鍵數值更快接近數值:1
        }
        else//相反的，若按鍵輸入為0則重設動畫動作(觸發wit)
        {
            RubyAnimation.SetTrigger("wit");
        }
        #endregion

        #region 控制混合樹的動畫
       //給予朝向數值
        RubyAnimation.SetFloat("x",LookDirection.x);
        RubyAnimation.SetFloat("y", LookDirection.y);
        //把RubyGo的移動量給予Speed
        RubyAnimation.SetFloat("speed", RubyGO.magnitude);
        #endregion

        //移動Ruby位置
        RubyPosition = RubyPosition + speed * RubyGO * Time.deltaTime;
        RB.MovePosition(RubyPosition);//使用鋼體進行移動

        #region 血量
        //如果血量==0 則重啟關卡
        if (nowHealth == 0)
        {
          Application.LoadLevel("SampleScene");

        }
        #endregion
        //print("Ruby血量" + nowHealth);

    }
    public void ChangeHealth(int amout)
    {
        nowHealth = nowHealth + amout; //加血機制-1
        print("Ruby血量" + nowHealth);
    }
}