
//全选/全不选
function CheckAll(val) {
    $("input[name='cbSub']").each(function () {
        this.checked = val;
    });
}

//表格内部全选/全不选
function CheckSubAll(val, obj, pra) {
    var tbl = "#tbl_" + pra + " input[name='cbSub']";
    $(tbl).each(function () {
        this.checked = val;
    });
}

//收集选中的项的值
function GetCheckedValue() {
    var ids = "";
    $("input[name='cbSub']").each(function () {
        if (true == this.checked) {
            if ($(this).attr('value')) {
                ids += $(this).attr('value') + ',';
            }
        }
    });
    return ids;
}