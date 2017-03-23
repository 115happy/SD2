// (function(){
// 	$('.manage-switch').on('click', function() {
// 		$('.manage-switch').removeClass('active');
// 		$(this).addClass('active');

// 		var target = $(this).data('target');
// 		// console.log(target);
// 		$('.manage-content>div').hide();
// 		$('.manage-' + target).fadeIn();
// 	});
// })();

var app = new Vue ({
	el: '#app',
	data : {
		currentLayer : '',
		users : [],
		newUser : {}
	},
	mounted : function() {
		this.toggleWelcome();
	},
	methods : {
		getUser : function() {
			axios.get('../api/UserSearch')
			.then((res) => {
				this.users = JSON.parse(res.data).Data;
			});
		},
		addUser : function() {
			console.log(this.newUser);
		},










		toggleWelcome : function() {
			this.currentLayer = 'welcome';
		},
		toggleUser : function() {
			this.currentLayer = 'user';
		},
		toggleInstrument : function() {
			this.currentLayer = 'instrument';
		},
		toggleClinic : function() {
			this.currentLayer = 'clinic';
		},
		toggleDrug : function() {
			this.currentLayer = 'drug';
		},
		toggleAnalysis : function() {
			this.currentLayer = 'analysis';
		},
		toggleCharge : function() {
			this.currentLayer = 'charge';
		},
		toggleRole : function() {
			this.currentLayer = 'role';
		},
		toggleDiseaseType : function() {
			this.currentLayer = 'diseasetype';
		},
		toggleDisease : function() {
			this.currentLayer = 'disease';
		},
		toggleCase : function() {
			this.currentLayer = 'case';
		},
		toggleBackup : function() {
			this.currentLayer = 'backup';
		},
	}
})