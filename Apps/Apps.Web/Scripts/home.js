$(function () {
    //刷新
    $("#tab_menu-tabrefresh").click(function () {

        var iframe = $(".tabs-panels .panel").eq($(".tabs-selected").index()).find("iframe");
        var url = iframe.prop("src");
        iframe.prop("src", url);
    });

    //在新窗口打开
    $("#tab_menu-openFrame").click(function () {
        var iframe = $(".tabs-panels .panel").eq($(".tabs-selected").index()).find("iframe");
        var url = iframe.prop("src");;
        window.open(url);
    });

    //关闭所有
    $("#tab_menu-tabcloseall").click(function () {
        $(".tabs-inner span").each(function (index, value) {
            if ($(this).parent().next().is(".tabs-close")) {
                var t = $(value).text();
                $('#mainTab').tabs('close', t);
            }
            //open menu
            $(".layout-button-right").trigger("click");
        });
    });

    //关闭其他标签
    $("#tab_menu-tabcloseothers").click(function () {
        var current_title = $(".tabs-selected .tabs-inner span").text();
        $(".tabs-inner span").each(function (index, value) {
            var title = $(value).text();
            if (current_title != title) {
                $("#mainTab").tabs("close", title);
            }
        });
    });

    //关闭左侧
    $("#tab_menu-tabcloseleft").click(function () {
        var prevAll = $(".tabs-selected").prevAll();
        if (prevAll.length == 0) {
            $.messager.alert('提示', '前面没有了', 'warning');
            return false;
        }
        prevAll.each(function (index, value) {
            var t = $(value).text();
            $("#mainTab").tabs("close", t);
        });
    });

    //关闭右侧
    $("#tab_menu-tabcloseright").click(function () {
        var nextAll = $(".tabs-selected").nextAll();
        if (nextAll.length == 0) {
            $.messager.alert('提示', '后面没有了', 'warning');
            return false;
        }
        nextAll.each(function (index, value) {
            var t = $(value).text();
            $("#mainTab").tabs("close", t);
        });
    });

    //关闭当前页
    $("#tab_menu-tabclose").click(function () {
        var current_title = $(".tabs-selected .tabs-inner span").text();
        $("#mainTab").tabs("close", current_title);
        if ($(".tabs li").length == 0) {
            //open menu
            $(".layout-button-right").trigger("click");
        }
    });
});

$(function () {

    $("#mainTab").on("contextmenu", ".tabs li", function (e) {
        var subTitle = $(this).text();
        $("#mainTab").tabs("select", subTitle);
        $("#tab_menu").menu("show", {
            top: e.pageY,
            left: e.pageX
        });
        e.preventDefault();
    });
});

function addTab(subtitle, url, icon) {
    if (!$("#mainTab").tabs('exists', subtitle)) {
        $("#mainTab").tabs('add', {
            title: subtitle,
            content: createFrame(url),
            closable: true,
            icon: icon
        });
    } else {
        $("#mainTab").tabs('select', subtitle);
        $("#tab_menu-tabrefresh").trigger("click");
    }
    //菜单栏 隐藏
    //$(".layout-button-left").trigger("click");
    //tabClose();
}
function createFrame(url) {
    var s = '<iframe frameborder="0" src="' + url + '" scrolling="auto" style="width:100%; height:99%"></iframe>';
    return s;
}
$(function () {
    $(".ui-skin-nav .li-skinitem span").click(function () {
        var theme = $(this).attr("rel");
        $.messager.confirm('提示', '切换皮肤将重新加载系统！', function (r) {
            if (r) {
                $.post("../../Home/SetThemes", { value: theme }, function (data) { window.location.reload(); }, "json");
            }
        });
    });
});
$(function () {
    var o = {
        showcheck: false,
        url: "/Home/GetTree",
        onnodeclick: function (item) {
            var tabTitie = item.text;
            var url = "../../" + item.value;
            var icon = item.Icon;
            if (!item.hasChildren) {
                addTab(tabTitie, url, icon);
            } else {
                $(this).parent().find("img").trigger("click");
            }
        }
    }

    $.post("/Home/GetTree", { "id": "0" }, function (data) {
        if (data == "0") {
            window.location = "/Account";
        }
        o.data = data;
        $("#RightTree").treeview(o);;
    }, "json");
});


//生成唯一GUID
function GetGuid() {
    var s4 = function () {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    };
    return s4() + s4() + s4() + "-" + s4();
}


