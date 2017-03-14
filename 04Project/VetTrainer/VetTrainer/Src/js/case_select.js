(function() {
    var dieaseTabs = $('.diease-tab'),
        dieaseLists = $('.diease-list');
    $('.diease-tab').on('click', function() {
        var index = $(this).index();
        console.log(index);
        dieaseTabs.removeClass('active');
        $(this).addClass('active');
        dieaseLists.addClass('hidden');
        dieaseLists.eq(index).removeClass('hidden');
    })

    var CaseSwiper = new Swiper('.swiper-container', {
        direction: 'horizontal',
        loop: true,

        // 如果需要分页器
        pagination: '.swiper-pagination',

        // 如果需要前进后退按钮
        nextButton: '.swiper-button-next',
        prevButton: '.swiper-button-prev',

        // 如果需要滚动条
        scrollbar: '.swiper-scrollbar',
    })
})();