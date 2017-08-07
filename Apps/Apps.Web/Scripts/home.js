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
    $(".tabs li").on("contextmenu", function (e) {
        var subTitle = $(this).text();
        $("#mainTab").tabs("select", subTitle);
        $("#tab_menu").menu("show", {
            top: e.pageY,
            left: e.pageX
        });
        e.preventDefault();
    });
});

function addTab() {

}