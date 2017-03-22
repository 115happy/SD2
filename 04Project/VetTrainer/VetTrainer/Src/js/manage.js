(function(){
	$('.manage-switch').on('click', function() {
		$('.manage-switch').removeClass('active');
		$(this).addClass('active');

		var target = $(this).data('target');
		// console.log(target);
		$('.manage-content>div').hide();
		$('.manage-' + target).fadeIn();
	});
})();