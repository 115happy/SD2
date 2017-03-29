var app = new Vue ({
	el: '#app',
	data : function() {
		return {
			currentLayer : 'welcome',

			//用户数据
			userKeyWord : '',
			users : [],
			newUser : {},
			userToDelete : '',
			userToEdit : {
				'Name' : '',
				'Password' : ''
			},

			//器械数据
			instruments : [],
			insKeyWord : [],
			newIns : {
				'Texts' : []
			},
			insToDelete : '',
			insToEdit : {},

			//科室数据
			clinics : [],
			rps : [],
			rpToEdit : {},
			newRp : {},
			rpToDelete : {},

			//药品数据
			drugs : [],
			drugKeyWord : '',
			newDrug : {},
			drugToDelete  : '',
			drugToEdit : {},

			//化验项目数据
			analysises : [],
			analysisKeyWord : '',
			newAnalysis : {},
			analysisToDelete  : '',
			analysisToEdit : {},

			charges : [],

			roles : [],

			//疾病类型数据
			diseaseTypes : [],
			typeKeyWord : '',
			newType : {},
			typeToDelete  : '',
			typeToEdit : {},

			//疾病数据
			diseases : [],
			diseaseKeyWord : '',
			newDisease : {
				'DiseaseCases' : []
			},
			diseaseToDelete  : '',
			diseaseToEdit : {},
		}
		
	},
	mounted : function() {
		// this.getUser();
		// this.getInstrument();
		this.getClinic();
		// this.getDrug();
		// this.getAnalysis();
		this.getRole();
		// this.getCharge();
		this.getDiseaseType();
		// this.getDisease();
		this.getRPRecord();
	},
	methods : {
		cloneObject : function(origin) {

		},
		getUser : function(key) {
			axios.get('../api/UserSearch/' + key)
			.then((res) => {
				this.users = JSON.parse(res.data).Data;
			}).catch((error) => {
				console.log('搜索用户失败')
			});
		},
		addUser : function() {
			console.log(this.newUser);
			axios.post('../api/UserAdd', this.newUser)
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.newUser = {};
				this.getUser();
			}).catch((error) => {
				console.log('添加用户失败')
			});
		},
		deleteUser : function() {
			axios.post('../api/UserDelete', {
				'id' : this.userToDelete
			})
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.getUser();
			}).catch((error) => {
				console.log('删除用户失败')
			});
		},
		editUser : function() {
			axios.post('../api/UserModify', this.userToEdit)
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.getUser();
			}).catch((error) => {
				console.log('修改用户失败')
			});
		},

		getInstrument : function() {
			axios.get('../api/InstrumentSearch')
			.then((res) => {
				this.instruments = JSON.parse(res.data).Data;
			}).catch((error) => {
				console.log('搜索器械失败')
			});
		},
		addIns : function() {
			axios.post('../api/InstrumentAdd', this.newIns)
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.newIns = {};
				this.getInstrument();
			}).catch((error) => {
				console.log('添加器械失败')
			});
		},
		deleteIns : function() {
			axios.post('../api/InstrumentDelete', {
				'id' : this.insToDelete
			})
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.getInstrument();
			}).catch((error) => {
				console.log('删除器械失败')
			});
		},
		getDrug : function(key) {
			axios.get('../api/DrugSearch/' + key)
			.then((res) => {
				this.drugs = JSON.parse(res.data).Data;
			}).catch((error) => {
				console.log('搜索药品失败')
			});
		},
		addDrug : function() {
			axios.post('../api/DrugAdd', this.newDrug)
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.newDrug = {};
				this.getDrug();
			}).catch((error) => {
				console.log('添加药品失败')
			});
		},
		editDrug : function() {
			axios.post('../api/DrugModify', this.drugToEdit)
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
			}).catch((error) => {
				console.log('修改药品失败')
			});
		},
		deleteDrug : function() {
			axios.post('../api/DrugDelete', {
				'id' : this.drugToDelete
			})
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.getDrug();
			}).catch((error) => {
				console.log('删除药品失败')
			});
		},
		getAnalysis : function(key) {
			axios.get('../api/AnalysisSearch/' + key)
			.then((res) => {
				this.analysises = JSON.parse(res.data).Data;
			}).catch((error) => {
				console.log('搜索化验信息失败')
			});
		},
		addAnalysis : function() {
			axios.post('../api/AnalysisAdd', this.newAnalysis)
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.newAnalysis = {};
				this.getAnalysis();
			}).catch((error) => {
				console.log('添加化验信息失败')
			});
		},
		deleteAnalysis : function() {
			axios.post('../api/AnalysisDelete', {
				'id' : this.analysisToDelete
			})
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.getAnalysis();
			}).catch((error) => {
				console.log('删除化验信息失败')
			});
		},
		getCharge : function(key) {
			axios.get('../api/ChargeSearch?searchText=' + key)
			.then((res) => {
				this.charges = JSON.parse(res.data).Data;
			}).catch((error) => {
				console.log('搜索收费信息失败')
			});
		},
		getRole : function() {
			axios.get('../api/RoleSearch/')
			.then((res) => {
				this.roles = JSON.parse(res.data).Data;
			}).catch((error) => {
				console.log('搜索角色失败')
			});
		},
		editRole : function() {

		},

		getDiseaseType : function(key) {
			axios.get('../api/DiseaseTypeSearch/' + key)
			.then((res) => {
				this.diseaseTypes = JSON.parse(res.data).Data;
			}).catch((error) => {
				console.log('搜索疾病类型失败')
			});
		},
		addDiseaseType : function() {
			axios.post('../api/DiseaseTypeAdd', this.newType)
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.newType = {};
				this.getDiseaseType();
			}).catch((error) => {
				console.log('添加疾病类型失败')
			});
		},
		deleteDiseaseType : function() {
			axios.post('../api/DiseaseTypeDelete', {
				'id' : this.typeToDelete
			})
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.getDiseaseType();
			}).catch((error) => {
				console.log('删除疾病类型失败')
			});
		},
		getDisease : function(key) {
			axios.get('../api/DiseaseSearch?searchText=' + key)
			.then((res) => {
				this.diseases = JSON.parse(res.data).Data;
			}).catch((error) => {
				console.log('搜索疾病失败')
			});
		},
		deleteDisease : function() {
			axios.post('../api/DiseaseDelete', {
				'id' : this.diseaseToDelete
			})
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.getDisease();
			}).catch((error) => {
				console.log('删除疾病失败')
			});
		},
		addDisease : function() {
			axios.post('../api/DiseaseAdd', this.newDisease)
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.newType = {};
				this.getDiseaseType();
			}).catch((error) => {
				console.log('添加疾病类型失败')
			});
		},
		getClinic : function() {
			axios.get('../api/ClinicSearch')
			.then((res) => {
				this.clinics = JSON.parse(res.data).Data;
			})
			.catch((error) => {
				console.log('搜索科室失败')
			})
		},
		getRPRecord : function() {
			axios.get('../api/getAllRPRecord')
			.then((res) => {
				this.rps = JSON.parse(res.data).Data;
			})
			.catch((error) => {
				console.log('搜索信息失败')
			})
		},
		addRp : function() {
			axios.post('../api/RoleClinicAdd', this.newRp)
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.newRp = {};
				this.getRPRecord();
			}).catch((error) => {
				console.log('添加职能信息失败')
			});
		},
		editRp : function() {
			axios.post('../api/RoleClinicModify', this.rpToEdit)
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.getRPRecord();
			}).catch((error) => {
				console.log('修改职能信息失败')
			});
		},
		deleteRp : function() {
			axios.post('../api/RoleClinicDelete', this.rpToDelete)
			.then((res) => {
				console.log(JSON.parse(res.data).Message);
				this.getRPRecord();
			}).catch((error) => {
				console.log('删除职能信息失败')
			});
		},
	}
})