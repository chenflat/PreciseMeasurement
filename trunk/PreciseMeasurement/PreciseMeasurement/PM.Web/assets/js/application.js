$(function () {

    var $window = $(window)
    var $body = $(document.body)

    var navHeight = $('.navbar').outerHeight(true) + 10

    $body.scrollspy({
        target: '.bs-sidebar',
        offset: navHeight
    })

    $window.on('load', function () {
        $body.scrollspy('refresh')
    })

    // back to top
    setTimeout(function () {
        var $sideBar = $('.bs-sidebar')

        $sideBar.affix({
            offset: {
                top: function () {
                    var offsetTop = $sideBar.offset().top
                    var sideBarMargin = parseInt($sideBar.children(0).css('margin-top'), 30)
                    var navOuterHeight = $('.bs-docs-nav').height()

                    return (this.top = offsetTop - navOuterHeight - sideBarMargin)
                }
                    , bottom: function () {

                        return (this.bottom = $('.bs-footer').outerHeight(true))
                    }
            }
        })
    }, 100);



    $('.bs-docs-navbar').tooltip({
        selector: "a[data-toggle=tooltip]",
        container: ".bs-docs-navbar .nav"
    })


    var pathname = window.location.href;

    $.each($("#admin-nav li"), function (index, li) {
        var link = $(li).find('a').attr('href');
        if (link == pathname) {
            $(li).addClass("active");
        }
    });


    //main-nav

    console.log(window.location.pathname);
    if (window.location.pathname == "/" || window.location.pathname.toLowerCase() == "/default.aspx") {
        console.log("this");
        $("#main-nav").hide();
    }

    // console.log(pathname);

    $.each($("#main-nav li"), function (index, li) {
        var link = $(li).find('a').attr('href');
        if (pathname.indexOf(link) > -1) {
            //if (link == pathname) {
            //    $(li).addClass("active");
        }
        //console.log(link);
    });

    if (pathname.indexOf("admin") > -1) {
        $("#sysmanage").addClass("active");
    } else {
        $("#sysmanage").removeClass("active");
    }

    $('.datepicker').datepicker({
        inline: true
    });

    Modernizr.addTest('android',
            function () {
                return !!navigator.userAgent.match(/Android/i)
            });
    Modernizr.addTest('chrome',
            function () {
                return !!navigator.userAgent.match(/Chrome/i)
            });
    Modernizr.addTest('firefox',
            function () {
                return !!navigator.userAgent.match(/Firefox/i)
            });
    Modernizr.addTest('iemobile',
            function () {
                return !!navigator.userAgent.match(/IEMobile/i)
            });
    Modernizr.addTest('ie',
            function () {
                return !!navigator.userAgent.match(/MSIE/i)
            });
    Modernizr.addTest('ie10',
            function () {
                return !!navigator.userAgent.match(/MSIE 10/i)
            });
    Modernizr.addTest('ie11',
            function () {
                return !!navigator.userAgent.match(/Trident.*rv:11\./)
            });
    Modernizr.addTest('ios',
            function () {
                return !!navigator.userAgent.match(/iPhone|iPad|iPod/i)
            });


    $('.no-touch .slim-scroll').each(function () {
        var $self = $(this),
                    $data = $self.data(),
                    $slimResize;
        $self.slimScroll($data);

        console.log($data);


      
        $(window).resize(function (e) {
            clearTimeout($slimResize);
            $slimResize = setTimeout(function () { $self.slimScroll($data); }, 500);
        });
    });

    setInterval("GetTime()", 60000);




    $(document).on('click', '.nav-primary a', function (e) {
        var $this = $(e.target),
                $active;
        $this.is('a') || ($this = $this.closest('a'));
        if ($('.nav-vertical').length) {
            return;
        }
        $active = $this.parent().siblings(".active");
        $active && $active.find('> a').toggleClass('active') && $active.toggleClass('active').find('> ul:visible').slideUp(200); ($this.hasClass('active') && $this.next().slideUp(200)) || $this.next().slideDown(200);
        $this.toggleClass('active').parent().toggleClass('active');
        $this.next().is('ul') && e.preventDefault();
    });

    $(".select2").select2();

})





/**
* 动态设置日期时间和星期
*/
function GetTime() {
    var now, hour, min, sec;

    mon = new Array("01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
			"11", "12");
    now = new Date();
    hour = now.getHours();
    min = now.getMinutes();
    sec = now.getSeconds();
    if (hour < 10) {
        hour = "0" + hour;
    }
    if (min < 10) {
        min = "0" + min;
    }
    if (sec < 10) {
        sec = "0" + sec;
    }

    var time = hour + ":" + min;
    var date = now.getFullYear() + "-" + mon[now.getMonth()] + "-"
			+ now.getDate();
    //var week = day[now.getDay()];

    if ($("#time").length) {
        $("#time").html(time);
    }
}



var Message = (function () {
    "use strict";

    var elem,
        hideHandler,
        that = {};

    that.init = function (options) {
        elem = $(options.selector);
    };

    that.show = function (text) {
        clearTimeout(hideHandler);

        elem.find("span").html(text);
        elem.delay(200).fadeIn().delay(4000).fadeOut();
    };

    return that;
});

