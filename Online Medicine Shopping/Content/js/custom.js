/*
 Template Name: Barret
 File Name: custom.js
 Author Name: ThemeVault
 Author URI: http://www.themevault.net/
 License URI: http://www.themevault.net/license/
 */


(function ($) {
    $(document).ready(function () {

        $('[data-toggle="offcanvas"]').click(function () {
            $('.tv-left-canvas').toggleClass('active')
        });

        $(window).scroll(function () {
            if ($(this).scrollTop() > 200) {
                $('.back-to-top').addClass('active');
            } else {
                $('.back-to-top').removeClass('active');
            }
        });
        $('#back-to-top').click(function () {
            $("html, body").animate({scrollTop: 0}, 600);
            return false;
        });

        // Show box-cart fixed
        fixed_cart();

//        shift_menu();


        function fixed_cart() {
            $('#tv-cart-top').click(function () {

                $('.tv-bg-overlay').addClass('show-overlay');
                $('.cart-top .dropdown-menu').addClass('show-cart-block');
            });
            $('.tv-bg-overlay').click(function () {
                $(this).removeClass('show-overlay');
                $('.cart-top .dropdown-menu').removeClass('show-cart-block');
            });
        }

        function shift_menu() {
            var menuLeft = document.getElementById('cbp-spmenu-s1'),
                    showLeftPush = document.getElementById('showLeftPush'),
                    showLeftPush1 = document.getElementById('showLeftPush1'),
                    body = document.body;


            showLeftPush.onclick = function () {
                classie.toggle(this, 'active');
                classie.toggle(body, 'cbp-spmenu-push-toright');
                classie.toggle(menuLeft, 'cbp-spmenu-open');
                disableOther('showLeftPush');
            };
            showLeftPush1.onclick = function () {
                classie.toggle(this, 'active');
                classie.toggle(body, 'cbp-spmenu-push-toright');
                classie.toggle(menuLeft, 'cbp-spmenu-open');
                disableOther('showLeftPush1');
            };

            function disableOther(button) {

                if (button !== 'showLeftPush') {
                    classie.toggle(showLeftPush, 'disabled');
                }
                if (button !== 'showLeftPush1') {
                    classie.toggle(showLeftPush, 'disabled');
                }
            }
        }

        $("body").on("click", "i.click-menu-open.fa-plus-square", function () {
            $this = $(this);
            $this.removeClass('fa-plus-square').addClass('fa-minus-square');
            $this.parent().find('.dropdown-menu:first').toggle();
        });
        $("body").on("click", "i.click-menu-open.fa-minus-square", function () {
            $(this).removeClass('fa-minus-square').addClass('fa-plus-square');
            $(this).parent().find('.dropdown-menu:first').toggle();
        });

    });

})(jQuery);

