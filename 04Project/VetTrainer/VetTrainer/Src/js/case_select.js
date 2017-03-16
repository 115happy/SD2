(function() {
    var dieaseTabs = $('.diease-tab'),
        dieaseLists = $('.diease-list'),
        dieaseItem = $('.diease-list list-group-item');
        //tab切换
    $('.diease-tab').on('click', function() {
        var index = $(this).index();
        console.log(index);
        dieaseTabs.removeClass('active');
        $(this).addClass('active');
        dieaseLists.addClass('hidden');
        dieaseLists.eq(index).removeClass('hidden');
    })

    //具体病例显示
    dieaseItem.on('.click', function() {
        //todo
    });

    var CaseSwiper = new Swiper('.swiper-container', {
        direction: 'horizontal',
        loop: true,
        // 分页器
        pagination: '.swiper-pagination',
        // 前进后退按钮
        nextButton: '.swiper-button-next',
        prevButton: '.swiper-button-prev',
        // 滚动条
        scrollbar: '.swiper-scrollbar',
    })
})();