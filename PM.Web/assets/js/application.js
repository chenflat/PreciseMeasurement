
!function ($) {

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

        $('.bs-docs-container [href=#]').click(function (e) {
            e.preventDefault()
        })

        // back to top
        setTimeout(function () {
            var $sideBar = $('.bs-sidebar')

            $sideBar.affix({
                offset: {
                    top: function () {
                        var offsetTop = $sideBar.offset().top
                        var sideBarMargin = parseInt($sideBar.children(0).css('margin-top'), 10)
                        var navOuterHeight = $('.bs-docs-nav').height()

                        console.log("offsetTop:" + offsetTop);
                        console.log("sideBarMargin:" + sideBarMargin);
                        console.log("navOuterHeight:" + navOuterHeight);
                        console.log("aa:" + (offsetTop - navOuterHeight - sideBarMargin));

                        return (this.top = offsetTop - navOuterHeight - sideBarMargin)
                    }
                    , bottom: function () {
                        console.log("bb:" + $('.bs-footer').outerHeight(true));

                        return (this.bottom = $('.bs-footer').outerHeight(true))
                    }
                }
            })
        }, 100)

        setTimeout(function () {
           // $('.bs-top').affix()
        }, 100)

        // tooltip demo
        $('.tooltip-demo').tooltip({
            selector: "[data-toggle=tooltip]",
            container: "body"
        })

        $('.tooltip-test').tooltip()
        $('.popover-test').popover()

        $('.bs-docs-navbar').tooltip({
            selector: "a[data-toggle=tooltip]",
            container: ".bs-docs-navbar .nav"
        })

        // popover demo
        $("[data-toggle=popover]")
      .popover()

        // button state demo
        $('#fat-btn')
      .click(function () {
          var btn = $(this)
          btn.button('loading')
          setTimeout(function () {
              btn.button('reset')
          }, 3000)
      })

        // carousel demo
        $('.bs-docs-carousel-example').carousel()

        var pathname = window.location.pathname;

        $.each($("#admin-nav li"), function (index, li) {
            var link = $(li).find('a').attr('href');
            if (link == pathname) {
                $(li).addClass("active");
            }
            console.log(link);
        });

        $.each($("#main-nav li"), function (index, li) {
            var link = $(li).find('a').attr('href');
            if (link == pathname) {
                $(li).addClass("active");
            }
            console.log(link);
        });

        $('.datepicker').datepicker({
            inline: true
        });
    })

} (window.jQuery)



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
} ());