using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step.Code
{
    public class OperateMsgModel
    {
        public const string Suc = "成功";
        public const string Fail = "失败";

        //Add
        public const string AddSuc = "新增成功";
        public const string AddFail = "新增失败";
        //Edit
        public const string EditSuc = "修改成功";
        public const string EditFail = "修改失败";
        //Del
        public const string DelSuc = "删除成功";
        public const string DelFail = "删除失败";
        //Upload
        public const string UploadSuc = "上传成功";
        public const string UploadFail = "上传失败";
        public const string UploadImgSuc = "上传图片成功";
        public const string UploadImgFail = "上传图片失败";
        //Save
        public const string SaveSuc = "保存成功";
        public const string SaveFail = "保存失败";
        //Operate
        public const string OperateSuc = "操作成功";
        public const string OperateFail = "操作失败";
        //Follow
        public const string FollowSuc = "关注成功";
        public const string FollowFail = "关注失败";
        public const string FollowCancelSuc = "取消关注成功";
        public const string FollowCancelFail = "取消关注失败";
        public const string FollowAlready = "已关注";
        public const string FollowNot = "未关注";
        public const string INotFollowMe = "自己不能关注自己";


        //Void
        public const string VoidData = "无数据";
        public const string VoidID = "无效ID";
        public const string VoidName = "无效名称";
        public const string VoidModel = "无效实体";
        public const string VoidGallerys = "无效的图片集合";
        public const string VoidNumber = "无效的数量";
        public const string VoidUser = "无效用户";

        //Login
        public const string LoginSuc = "登陆成功";
        public const string LoginFail = "用户名或密码错误";
        public const string RegisterSuc = "注册成功";
        public const string RegisterFail = "注册失败";
        public const string NoLogin = "未登录";

        //Auth
        public const string AuthSuc = "认证成功";
        public const string AuthFail = "认证失败";
        public const string AuthDownSuc = "取消认证成功";
        public const string AuthDownFail = "取消认证失败";


        //Goods
        public const string VoidGoods = "不存在此商品或已下架";
        public const string PoorNumber = "库存不足";

        //Img

        //User
        public const string UserImgVoid = "用户头像为空";

        //Order
        public const string CreateOrderFail = "生成订单失败";
        public const string VoidOrder = "无效订单";
        public const string VoidOrderOrNoAccess = "无效订单或此订单状态不允许进行相应操作";
        public const string OrderCancelSuc = "取消订单成功";
        public const string OrderCancelErr = "取消订单失败";
        public const string OrderConsumeSuc = "消费成功";
        public const string OrderConsumeFail = "消费失败";
        public const string OrderApplyBackSuc = "申请退款成功";
        public const string OrderApplyBackFail = "申请退款失败";
        public const string PaySuc = "支付成功";
        public const string PayFail = "支付失败";
        public const string PayStatusErr = "订单不存在或支付状态异常";
        public const string OrderAmountErr = "订单金额为0";

        //Community
        //Common
        public const string GetInfoFail = "信息获取失败";
        public const string NoAccess = "无权限";
        public const string AlreadyPraise = "已点赞";
        public const string NoPraise = "未点赞";
        public const string PraiseSuc = "点赞成功";
        public const string PraiseFail = "点赞失败";
        public const string CancelPraiseSuc = "取消成功";
        public const string CancelPraiseFail = "取消失败";
        public const string VoidComment = "评论内容不能为空";
        public const string CommentSuc = "评论成功";
        public const string CommentFail = "评论失败";




        //cookie & session msg
        public const string SessionLoginUser = "StepAdminUser";
        public const string CookieLoginUser = "CKStepAdminUser";

        //menu
        public const string MainMenuList = "MainMenuList";
        public const string SubMenuList = "SubMenuList";

        //admin user name
        public const string AdminUserName = "admin"; 


    }
}
