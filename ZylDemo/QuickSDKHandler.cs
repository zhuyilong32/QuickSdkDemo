using UnityEngine;
using System.Collections;
using quicksdk;
using UnityEngine.UI;
public class QuickSDKHandler : QuickSDKListener
{
    Button m_Login;
    Button m_Pay;
    Button m_Enter;
    void Awake()
    {
        QuickSDK.getInstance().setListener(this);
        m_Login = GameObject.Find("Canvas/Login").GetComponent<Button>();
        m_Login.onClick.AddListener(OnLoginBtnDown);
        m_Pay= GameObject.Find("Canvas/Pay").GetComponent<Button>();
        m_Pay.onClick.AddListener(OnPayDown);
        m_Enter = GameObject.Find("Canvas/Enter").GetComponent<Button>();
        m_Enter.onClick.AddListener(OnEnterDown);
    }

    void showLog(string title, string message)
    {
        Debug.Log("title: " + title + ", message: " + message);
    }

    //callback
    public override void onInitSuccess()
    {
        showLog("onInitSuccess", "");
        //QuickSDK.getInstance ().login (); //如果游戏需要启动时登录，需要在初始化成功之后调用
        QuickSDKHelper.SetOrderInfo();
        QuickSDKHelper.SetRoleInfo();
    }

    public override void onInitFailed(ErrorMsg errMsg)
    {
        showLog("onInitFailed", "msg: " + errMsg.errMsg);
    }

    public override void onLoginSuccess(UserInfo userInfo)
    {
        showLog("onLoginSuccess", "uid: " + userInfo.uid + " ,username: " + userInfo.userName + " ,userToken: " + userInfo.token + ", msg: " + userInfo.errMsg);
    }

    public override void onSwitchAccountSuccess(UserInfo userInfo)
    {
        //切换账号成功，清除原来的角色信息，使用获取到新的用户信息，回到进入游戏的界面，不需要再次调登录
        showLog("onLoginSuccess", "uid: " + userInfo.uid + " ,username: " + userInfo.userName + " ,userToken: " + userInfo.token + ", msg: " + userInfo.errMsg);
    }

    public override void onLoginFailed(ErrorMsg errMsg)
    {
        showLog("onLoginFailed", "msg: " + errMsg.errMsg);
    }

    public override void onLogoutSuccess()
    {
        showLog("onLogoutSuccess", "");
        //注销成功后回到登陆界面0
        //Application.LoadLevel("scene1");
    }



    public override void onPaySuccess(PayResult payResult)
    {
        showLog("onPaySuccess", "orderId: " + payResult.orderId + ", cpOrderId: " + payResult.cpOrderId + " ,extraParam" + payResult.extraParam);
    }

    public override void onPayCancel(PayResult payResult)
    {
        showLog("onPayCancel", "orderId: " + payResult.orderId + ", cpOrderId: " + payResult.cpOrderId + " ,extraParam" + payResult.extraParam);
    }

    public override void onPayFailed(PayResult payResult)
    {
        showLog("onPayFailed", "orderId: " + payResult.orderId + ", cpOrderId: " + payResult.cpOrderId + " ,extraParam" + payResult.extraParam);
    }

    public override void onExitSuccess()
    {
        showLog("onExitSuccess", "");
        //退出成功的回调里面调用  QuickSDK.getInstance ().exitGame ();  即可实现退出游戏，杀进程。为避免与渠道发生冲突，请不要使用  Application.Quit ();
        QuickSDK.getInstance().exitGame();
    }

    /// <summary>
    /// 登陆时候调用
    /// </summary>
    void Login()
    {
        QuickSDK.getInstance().login();
    }

    public void OnLoginBtnDown()
    {
        Login();
        Debug.Log("LoginBtnDown");
    }

    public void OnPayDown()
    {
        Pay(QuickSDKHelper.GetOrder,QuickSDKHelper.GetRole);
        Debug.Log("PayBtnDown");
    }

    public void OnEnterDown()
    {
        QuickSDK.getInstance().enterGame(QuickSDKHelper.GetRole);
        Debug.Log("EnterBtnDown");
    }

    void CreateRole()
    {
        QuickSDK.getInstance().createRole(QuickSDKHelper.GetRole);//创建角色
    }
    //进入游戏上传
    void EnterGame(GameRoleInfo gameRoleInfo)
    {
        QuickSDK.getInstance().enterGame(gameRoleInfo);
    }

    void updateRole(GameRoleInfo gameRoleInfo)
    {
        QuickSDK.getInstance().updateRole(gameRoleInfo);
    }

    void Pay(OrderInfo orderInfo, GameRoleInfo gameRoleInfo)
    {
        QuickSDK.getInstance().pay(orderInfo, gameRoleInfo);
    }

    void logOut()
    {
        QuickSDK.getInstance().logout();
    }


}
