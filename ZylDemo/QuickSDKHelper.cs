using UnityEngine;
using System.Collections;
using quicksdk;
public static class QuickSDKHelper {
    private static GameRoleInfo m_Role=new GameRoleInfo();
    private static OrderInfo m_Order=new OrderInfo();
    public static GameRoleInfo GetRole
    {
        get {
            return m_Role;
        }
    }

    public static OrderInfo GetOrder
    {
        get
        {
            return m_Order;
        }
    }

    public static void SetRoleInfo()
    {
        m_Role.gameRoleBalance = "0";
        m_Role.gameRoleID = "000001";
        m_Role.gameRoleLevel = "1";
        m_Role.gameRoleName = "钱多多";
        m_Role.partyName = "同济会";
        m_Role.serverID = "1";
        m_Role.serverName = "火星服务器";
        m_Role.vipLevel = "1";
        m_Role.roleCreateTime = "roleCreateTime";//UC，当乐与1881渠道必传，值为10位数时间戳
        m_Role.gameRoleGender = "男";//360渠道参数
        m_Role.gameRolePower = "38";//360渠道参数，设置角色战力，必须为整型字符串
        m_Role.partyId = "1100";//360渠道参数，设置帮派id，必须为整型字符串
        m_Role.professionId = "11";//360渠道参数，设置角色职业id，必须为整型字符串
        m_Role.profession = "法师";//360渠道参数，设置角色职业名称
        m_Role.partyRoleId = "1";//360渠道参数，设置角色在帮派中的id
        m_Role.partyRoleName = "帮主"; //360渠道参数，设置角色在帮派中的名称
        m_Role.friendlist = "无";//360渠道参数，设置好友关系列表，格式请参考：http://open.quicksdk.net/help/detail/aid/190
    }

    public static void SetOrderInfo()
    {
        m_Order.goodsID = "1";
        m_Order.goodsName = "勾玉";
        m_Order.amount = 1;
        m_Order.count = 10;
        m_Order.cpOrderID = "cporderidzzw";
        m_Order.extrasParams = "extparma";
        m_Order.price = 0.1f;  //停用的，不用给值
        m_Order.quantifier = "个";  //停用的，不用给值
        m_Order.goodsDesc = "10个勾玉";  //停用的，不用给值
    }
}
