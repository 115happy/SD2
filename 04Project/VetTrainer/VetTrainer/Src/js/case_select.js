(function() {
    var diseaseTabs = $('.disease-tab'),
        diseaseLists = $('.disease-list'),
        diseaseItem = $('.disease-list list-group-item');

    //初始化
    diseaseTabs.eq(0).addClass('active');
    diseaseLists.eq(0).removeClass('hidden');
    //tab切换
    $('.disease-tab').on('click', function() {
        var index = $(this).index();
        // console.log(index);
        diseaseTabs.removeClass('active');
        $(this).addClass('active');
        diseaseLists.addClass('hidden');
        diseaseLists.eq(index).removeClass('hidden');
    })

    //具体病例显示
    diseaseItem.on('.click', function() {
        //todo
    });
    
})();