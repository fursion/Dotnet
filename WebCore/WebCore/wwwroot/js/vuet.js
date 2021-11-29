const testapp = {
    data() {
        return {
            message: 'hello vue'
        }
    }
}
Vue.createApp(testapp).mount('#test')
const app = Vue.createApp({})
app.component('hhh', {
    template: '<div class="blog-html-body-html show-border">测试</div>'
})
app.mount('#app')
const app_mtk = {
    data() {
        return {
            km: 0,
            m: 0
        }
    },
    watch: {
        km: function (val) {
            this.km = val;
            this.m = this.km * 1000
        },
        m:function(val){
            this.km=val/1000;
            this.m=val;
        }
    }
}
Vue.createApp(app_mtk).mount('#app-mtk')
const app_select={
    data(){
        return{
            selected:'www.baidu.com',
            options:[
                {text:'Baidu',value:'www.baidu.com'},
                {text:'Google',value:'www.google.com'},
                {text:'Taobao',value:'www.taobao.com'}
            ]
        }
    }
}
Vue.createApp(app_select).mount('#app-select')
