$(function () {   
    /****************VUE JS********************/

    // 2 将axios添加到Vue的原型对象中
    Vue.prototype.$http = axios;


    var datass = [{
        'id': '1',
        'title': 'xxxxx书',
        'text':
            '低了关系方面和面向对象的方面之间的阻抗不匹配，使开发人员能够使用表示应用程序域的强抗不匹配，使开发人员能够使用表示应用程序域的强',
        date: '2018-sss',
        uname: 'admin',
        readcount: '123',
        img: '../../Content/images/02.jpg'
    },
    {
        'id': '2',
        'title': 'xxxxx书',
        'text':
            '低了关系方面和面向对象的方面之间的阻抗不匹配，使开发人员能够使用表示应用程序域的强...',
        date: '2018-sss',
        uname: 'admin',
        readcount: '123',
        img: '../../Content/images/02.jpg'
    },
    {
        'id': '3',
        'title': 'xxxxx书',
        'text':
            '低了关系方面和面向对象的方面之间的阻抗不匹配，使开发人员能够使用表示应用程序域的强...',
        date: '2018-sss',
        uname: 'admin',
        readcount: '123',
        img: '../../Content/images/02.jpg'
    },
    {
        'id': '4',
        'title': 'xxxxx书',
        'text':
            '低了关系方面和面向对象的方面之间的阻抗不匹配，使开发人员能够使用表示应用程序域的强...',
        date: '2018-sss',
        uname: 'admin',
        readcount: '123',
        img: '../../Content/images/02.jpg'
    },
    {
        'id': '5',
        'title': 'xxxxx书',
        'text':
            '低了关系方面和面向对象的方面之间的阻抗不匹配，使开发人员能够使用表示应用程序域的强...',
        date: '2018-sss',
        uname: 'admin',
        readcount: '123',
        img: '../../Content/images/02.jpg'
    },
    {
        'id': '6',
        'title': 'xxxxx书',
        'text':
            '低了关系方面和面向对象的方面之间的阻抗不匹配，使开发人员能够使用表示应用程序域的强...',
        date: '2018-sss',
        uname: 'admin',
        readcount: '123',
        img: '../../Content/images/02.jpg'
    },
    {
        'id': '7',
        'title': 'xxxxx书',
        'text':
            '低了关系方面和面向对象的方面之间的阻抗不匹配，使开发人员能够使用表示应用程序域的强低了关系方面和面向对象的方面之间的阻抗不匹配，使开发人员能够使用表示应用程序域的强...',
        date: '2018-sss',
        uname: 'admin',
        readcount: '123',
        img: '../../Content/images/02.jpg'
    }
    ];
    var sysmenu=[
        {
            id:'1',
            name:'首页',
            action:'/home/index'
        },
        {
            id: '1',
            name: '文章',
            action: '/blog/articlelist'
        },
        {
            id: '1',
            name: '读书指南',
            action: '/home/bookguide'
        },
        {
            id: '1',
            name: '工具软件',
            action: '/home/tools'
        },
        {
            id: '1',
            name: '技巧',
            action: '/home/skill'
        }
    ]
    var vue = new Vue({
        el: '#app',
        data() {
            return {
                message: 'hellow vue',
                count: 0,
                datas: datass,
                menus: sysmenu,
                targetObj: Object,
                isMouseenter: false,
                isChange: false,
                searchtext: '',
                pinlunnum: 11,
                isnotLogin: true,
                loginuser: {
                    nickname: '',
                    userid:'',
                    uemail: '',
                    uweb: '',
                    uimg:''
                },
                user: { Name: '', Password: '' },
                loginRules: {
                    Name: [{ required: true, message: '请输入用户名', trigger: 'blur' }],
                    Password: [{ required: true, message: '请输入密码', trigger: 'blur' }]
                }
            }
        },
        mounted() {
            let pcmenulist = this.$refs.siteHome; //通过ref获取dom元素
            let pcmenulist2 = this.$refs.siteHome2;
            var menu_a = pcmenulist[0].children[0]; //获取pcmenulist[0]下的子元素
            var menu_a2 = pcmenulist2[0].children[0];
            $(menu_a).addClass('clickCSS');
            $(menu_a2).addClass('clickCSS'); //初始时首页color
            window.addEventListener('scroll', this.handleScroll);
        },
        methods: {
            submitForm(formName) {
                var opt = this;
                this.$refs[formName].validate(valid => {
                    if (valid) {
                        //验证成功，登录
                        var url = "/Account/Login";
                        this.$http.post(url, { "Name": this.user.Name,"Password":this.user.Password }).then(function (result) {
                            var res = result.data;
                            console.log(res);
                            if (res.type === 1) {
                                var user = res.obj;
                                console.log(user.nickName);
                                opt.loginuser.nickname = user.nickName;
                                opt.loginuser.userid = user.id;
                                opt.loginuser.uemail = user.email;
                                opt.loginuser.uweb = user.imgUrl;
                                opt.loginuser.uimg = user.webUrl;

                                opt.isnotLogin = false;
                            } else {
                                opt.$message({
                                    message: res.message,
                                    type: 'warning'
                                });
                            }

                        }).catch(function (err) {
                            opt.$message({
                                message: err.message,
                                type: 'warning'
                            });

                        });
                       
                    } else {
                        
                    }
                });
            },
            logout: function() {
                this.$confirm('即将注销登录, 是否继续?',
                    '提示',
                    {
                        confirmButtonText: '确定',
                        cancelButtonText: '取消',
                        type: 'warning'
                    }).then(() => {
                    this.$message({
                        type: 'success',
                        message: '注销成功!'
                    });
                    this.isnotLogin = true;
                }).catch(() => {
                    this.$message({
                        type: 'info',
                        message: '注销失败'
                    });
                });
            },
            registerForm(formName) {
                this.$refs[formName].resetFields();
                window.location.href = "http://www.baidu.com";
            },
            handleScroll: function() {
                if (window.scrollY > 1000) {
                    $('.toTop').show();
                } else {
                    $('.toTop').hide();
                }
                var dom = this.$refs.helptags;
                if (window.scrollY > 1300) {
                    $(dom).addClass('changeflex');
                } else {
                    $(dom).removeClass('changeflex');
                }
            },
            showmobilemenu: function() {
                var bodyEl = $('body');
                bodyEl.toggleClass('showing');
                event.preventDefault();
            },
            gotoTop: function() {
                let logo = document.querySelector('body'); //根据class名获取元素
                $('body,html').animate({ scrollTop: 0 }, 1000); //滚动回顶部
            },
            loadmore: function() {
                $('.sk-three-bounce').show();
                $('.more').hide();
                $('.sk-child').addClass('activeLoading');
                setTimeout(function() {
                        $('.sk-child').removeClass('activeLoading');
                        $('.sk-three-bounce').hide();
                        $('.more').show();
                        var readdata = [
                            {
                                id: '8',
                                title: 'xxxxx书',
                                text: '低了关系方面和面向对象的方面之间的阻抗不匹配，使开发人员能够使用表示应用程序域的强抗不匹配，使开发人员能够使用表示应用程序域的强',
                                date: '2018-sss',
                                uname: 'admin',
                                readcount: '123',
                                img: '../../Content/images/02.jpg'
                            },
                            {
                                id: '9',
                                title: 'xxxxx书',
                                text: '低了关系方面和面向对象的方面之间的阻抗不匹配，使开发人员能够使用表示应用程序域的强...',
                                date: '2018-sss',
                                uname: 'admin',
                                readcount: '123',
                                img: '../../Content/images/02.jpg'
                            }
                        ];
                        readdata.forEach(function(v) {
                            datass.push(v);
                        });
                    },
                    2000);
                //重新绑定数据
            },
            toggleShow: function(event) {
                var dom = event.currentTarget
                dom.style.backgroundColor = '#EAF2F8';
            },
            toggleHide: function(event) {
                var dom = event.currentTarget
                dom.style.backgroundColor = '#ffffff';
            },
            titleShow: function(event) {
                var dom = event.currentTarget;
                this.targetObj = dom;
                this.isChange = !this.isChange;
            },
            changebgColor: function(event) {
                var dom = event.target;
                // console.log(dom.getAttribute('class')+"---hover")
                this.targetObj = dom;
                this.isMouseenter = !this.isMouseenter;
            },
            setColor: function(event) {
                var dom = event.target
                let pcmenulist = this.$refs.siteHome;//通过ref获取dom元素
                let pcmenulist2 = this.$refs.siteHome2; //通过ref获取dom元素
                pcmenulist.forEach(element => {
                    $(element.children[0]).removeClass('clickCSS');
                    $(element.children[0]).removeClass('hoverCSS');
                })
                pcmenulist2.forEach(element => {
                    $(element.children[0]).removeClass('clickCSS');
                    $(element.children[0]).removeClass('hoverCSS');
                })

                $(dom)
                    .addClass('clickCSS')
                    .removeClass('hoverCSS');
            },
            SearchData: function() {
                alert(this.searchtext);
            }
        },
        watch: {
            isMouseenter: function(newVal) {
                if (newVal) {
                    var dom = this.targetObj;
                    $(dom).addClass('hoverCSS');
                } else {
                    var dom = this.targetObj;
                    $(dom).removeClass('hoverCSS');
                }
            },
            isChange: function(newVal) {
                var dom = this.targetObj;
                newVal ? $(dom).addClass('hoverCSS') : $(dom).removeClass('hoverCSS');
            }
        }
    });
    /*****************************************/
})