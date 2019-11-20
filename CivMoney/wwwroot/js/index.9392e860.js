(function(e){function t(t){for(var r,a,c=t[0],u=t[1],i=t[2],l=0,f=[];l<c.length;l++)a=c[l],s[a]&&f.push(s[a][0]),s[a]=0;for(r in u)Object.prototype.hasOwnProperty.call(u,r)&&(e[r]=u[r]);d&&d(t);while(f.length)f.shift()();return o.push.apply(o,i||[]),n()}function n(){for(var e,t=0;t<o.length;t++){for(var n=o[t],r=!0,a=1;a<n.length;a++){var c=n[a];0!==s[c]&&(r=!1)}r&&(o.splice(t--,1),e=u(u.s=n[0]))}return e}var r={},a={index:0},s={index:0},o=[];function c(e){return u.p+"js/"+({dashboard:"dashboard",login:"login",canvg:"canvg",pdfmake:"pdfmake",xlsx:"xlsx"}[e]||e)+"."+{dashboard:"14f6d0e2",login:"ece0d55e",canvg:"22fd1d8c",pdfmake:"da5152c0",xlsx:"b7041dc3"}[e]+".js"}function u(t){if(r[t])return r[t].exports;var n=r[t]={i:t,l:!1,exports:{}};return e[t].call(n.exports,n,n.exports,u),n.l=!0,n.exports}u.e=function(e){var t=[],n={dashboard:1,login:1};a[e]?t.push(a[e]):0!==a[e]&&n[e]&&t.push(a[e]=new Promise(function(t,n){for(var r="css/"+({dashboard:"dashboard",login:"login",canvg:"canvg",pdfmake:"pdfmake",xlsx:"xlsx"}[e]||e)+"."+{dashboard:"59d936c5",login:"b1f8fbae",canvg:"31d6cfe0",pdfmake:"31d6cfe0",xlsx:"31d6cfe0"}[e]+".css",s=u.p+r,o=document.getElementsByTagName("link"),c=0;c<o.length;c++){var i=o[c],l=i.getAttribute("data-href")||i.getAttribute("href");if("stylesheet"===i.rel&&(l===r||l===s))return t()}var f=document.getElementsByTagName("style");for(c=0;c<f.length;c++){i=f[c],l=i.getAttribute("data-href");if(l===r||l===s)return t()}var d=document.createElement("link");d.rel="stylesheet",d.type="text/css",d.onload=t,d.onerror=function(t){var r=t&&t.target&&t.target.src||s,o=new Error("Loading CSS chunk "+e+" failed.\n("+r+")");o.code="CSS_CHUNK_LOAD_FAILED",o.request=r,delete a[e],d.parentNode.removeChild(d),n(o)},d.href=s;var p=document.getElementsByTagName("head")[0];p.appendChild(d)}).then(function(){a[e]=0}));var r=s[e];if(0!==r)if(r)t.push(r[2]);else{var o=new Promise(function(t,n){r=s[e]=[t,n]});t.push(r[2]=o);var i,l=document.createElement("script");l.charset="utf-8",l.timeout=120,u.nc&&l.setAttribute("nonce",u.nc),l.src=c(e),i=function(t){l.onerror=l.onload=null,clearTimeout(f);var n=s[e];if(0!==n){if(n){var r=t&&("load"===t.type?"missing":t.type),a=t&&t.target&&t.target.src,o=new Error("Loading chunk "+e+" failed.\n("+r+": "+a+")");o.type=r,o.request=a,n[1](o)}s[e]=void 0}};var f=setTimeout(function(){i({type:"timeout",target:l})},12e4);l.onerror=l.onload=i,document.head.appendChild(l)}return Promise.all(t)},u.m=e,u.c=r,u.d=function(e,t,n){u.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:n})},u.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},u.t=function(e,t){if(1&t&&(e=u(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var n=Object.create(null);if(u.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var r in e)u.d(n,r,function(t){return e[t]}.bind(null,r));return n},u.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return u.d(t,"a",t),t},u.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},u.p="/",u.oe=function(e){throw console.error(e),e};var i=window["webpackJsonp"]=window["webpackJsonp"]||[],l=i.push.bind(i);i.push=t,i=i.slice();for(var f=0;f<i.length;f++)t(i[f]);var d=l;o.push([0,"chunk-vendors"]),n()})({0:function(e,t,n){e.exports=n("56d7")},"034f":function(e,t,n){"use strict";var r=n("64a9"),a=n.n(r);a.a},"1bf2":function(e,t,n){},"2ce5":function(e,t,n){"use strict";n("96cf");var r=n("3b8d"),a=n("bc3a"),s=n.n(a);t["a"]={years:function(){var e=Object(r["a"])(regeneratorRuntime.mark(function e(){return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,s.a.get("/api/transactions/yearsTotals");case 2:return e.abrupt("return",e.sent);case 3:case"end":return e.stop()}},e)}));function t(){return e.apply(this,arguments)}return t}(),getTotalPerMonthForYear:function(){var e=Object(r["a"])(regeneratorRuntime.mark(function e(t){return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,s.a.get("/api/transactions/yearsMonthTotals?year=".concat(t));case 2:return e.abrupt("return",e.sent);case 3:case"end":return e.stop()}},e)}));function t(t){return e.apply(this,arguments)}return t}(),getTotalPerDayForMonth:function(){var e=Object(r["a"])(regeneratorRuntime.mark(function e(t,n){return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,s.a.get("/api/transactions/dailyTotalMonth?year=".concat(t,"&month=").concat(n));case 2:return e.abrupt("return",e.sent);case 3:case"end":return e.stop()}},e)}));function t(t,n){return e.apply(this,arguments)}return t}(),getMonthGroupedToals:function(){var e=Object(r["a"])(regeneratorRuntime.mark(function e(t,n){return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,s.a.get("/api/transactions/monthGroupedToals?year=".concat(t,"&month=").concat(n));case 2:return e.abrupt("return",e.sent);case 3:case"end":return e.stop()}},e)}));function t(t,n){return e.apply(this,arguments)}return t}(),getTransactionsForDate:function(){var e=Object(r["a"])(regeneratorRuntime.mark(function e(t){return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,s.a.get("/api/transactions/date?date=".concat(t));case 2:return e.abrupt("return",e.sent);case 3:case"end":return e.stop()}},e)}));function t(t){return e.apply(this,arguments)}return t}()}},4678:function(e,t,n){var r={"./af":"2bfb","./af.js":"2bfb","./ar":"8e73","./ar-dz":"a356","./ar-dz.js":"a356","./ar-kw":"423e","./ar-kw.js":"423e","./ar-ly":"1cfd","./ar-ly.js":"1cfd","./ar-ma":"0a84","./ar-ma.js":"0a84","./ar-sa":"8230","./ar-sa.js":"8230","./ar-tn":"6d83","./ar-tn.js":"6d83","./ar.js":"8e73","./az":"485c","./az.js":"485c","./be":"1fc1","./be.js":"1fc1","./bg":"84aa","./bg.js":"84aa","./bm":"a7fa","./bm.js":"a7fa","./bn":"9043","./bn.js":"9043","./bo":"d26a","./bo.js":"d26a","./br":"6887","./br.js":"6887","./bs":"2554","./bs.js":"2554","./ca":"d716","./ca.js":"d716","./cs":"3c0d","./cs.js":"3c0d","./cv":"03ec","./cv.js":"03ec","./cy":"9797","./cy.js":"9797","./da":"0f14","./da.js":"0f14","./de":"b469","./de-at":"b3eb","./de-at.js":"b3eb","./de-ch":"bb71","./de-ch.js":"bb71","./de.js":"b469","./dv":"598a","./dv.js":"598a","./el":"8d47","./el.js":"8d47","./en-SG":"cdab","./en-SG.js":"cdab","./en-au":"0e6b","./en-au.js":"0e6b","./en-ca":"3886","./en-ca.js":"3886","./en-gb":"39a6","./en-gb.js":"39a6","./en-ie":"e1d3","./en-ie.js":"e1d3","./en-il":"7333","./en-il.js":"7333","./en-nz":"6f50","./en-nz.js":"6f50","./eo":"65db","./eo.js":"65db","./es":"898b","./es-do":"0a3c","./es-do.js":"0a3c","./es-us":"55c9","./es-us.js":"55c9","./es.js":"898b","./et":"ec18","./et.js":"ec18","./eu":"0ff2","./eu.js":"0ff2","./fa":"8df4","./fa.js":"8df4","./fi":"81e9","./fi.js":"81e9","./fo":"0721","./fo.js":"0721","./fr":"9f26","./fr-ca":"d9f8","./fr-ca.js":"d9f8","./fr-ch":"0e49","./fr-ch.js":"0e49","./fr.js":"9f26","./fy":"7118","./fy.js":"7118","./ga":"5120","./ga.js":"5120","./gd":"f6b4","./gd.js":"f6b4","./gl":"8840","./gl.js":"8840","./gom-latn":"0caa","./gom-latn.js":"0caa","./gu":"e0c5","./gu.js":"e0c5","./he":"c7aa","./he.js":"c7aa","./hi":"dc4d","./hi.js":"dc4d","./hr":"4ba9","./hr.js":"4ba9","./hu":"5b14","./hu.js":"5b14","./hy-am":"d6b6","./hy-am.js":"d6b6","./id":"5038","./id.js":"5038","./is":"0558","./is.js":"0558","./it":"6e98","./it-ch":"6f12","./it-ch.js":"6f12","./it.js":"6e98","./ja":"079e","./ja.js":"079e","./jv":"b540","./jv.js":"b540","./ka":"201b","./ka.js":"201b","./kk":"6d79","./kk.js":"6d79","./km":"e81d","./km.js":"e81d","./kn":"3e92","./kn.js":"3e92","./ko":"22f8","./ko.js":"22f8","./ku":"2421","./ku.js":"2421","./ky":"9609","./ky.js":"9609","./lb":"440c","./lb.js":"440c","./lo":"b29d","./lo.js":"b29d","./lt":"26f9","./lt.js":"26f9","./lv":"b97c","./lv.js":"b97c","./me":"293c","./me.js":"293c","./mi":"688b","./mi.js":"688b","./mk":"6909","./mk.js":"6909","./ml":"02fb","./ml.js":"02fb","./mn":"958b","./mn.js":"958b","./mr":"39bd","./mr.js":"39bd","./ms":"ebe4","./ms-my":"6403","./ms-my.js":"6403","./ms.js":"ebe4","./mt":"1b45","./mt.js":"1b45","./my":"8689","./my.js":"8689","./nb":"6ce3","./nb.js":"6ce3","./ne":"3a39","./ne.js":"3a39","./nl":"facd","./nl-be":"db29","./nl-be.js":"db29","./nl.js":"facd","./nn":"b84c","./nn.js":"b84c","./pa-in":"f3ff","./pa-in.js":"f3ff","./pl":"8d57","./pl.js":"8d57","./pt":"f260","./pt-br":"d2d4","./pt-br.js":"d2d4","./pt.js":"f260","./ro":"972c","./ro.js":"972c","./ru":"957c","./ru.js":"957c","./sd":"6784","./sd.js":"6784","./se":"ffff","./se.js":"ffff","./si":"eda5","./si.js":"eda5","./sk":"7be6","./sk.js":"7be6","./sl":"8155","./sl.js":"8155","./sq":"c8f3","./sq.js":"c8f3","./sr":"cf1e","./sr-cyrl":"13e9","./sr-cyrl.js":"13e9","./sr.js":"cf1e","./ss":"52bd","./ss.js":"52bd","./sv":"5fbd","./sv.js":"5fbd","./sw":"74dc","./sw.js":"74dc","./ta":"3de5","./ta.js":"3de5","./te":"5cbb","./te.js":"5cbb","./tet":"576c","./tet.js":"576c","./tg":"3b1b","./tg.js":"3b1b","./th":"10e8","./th.js":"10e8","./tl-ph":"0f38","./tl-ph.js":"0f38","./tlh":"cf75","./tlh.js":"cf75","./tr":"0e81","./tr.js":"0e81","./tzl":"cf51","./tzl.js":"cf51","./tzm":"c109","./tzm-latn":"b53d","./tzm-latn.js":"b53d","./tzm.js":"c109","./ug-cn":"6117","./ug-cn.js":"6117","./uk":"ada2","./uk.js":"ada2","./ur":"5294","./ur.js":"5294","./uz":"2e8c","./uz-latn":"010e","./uz-latn.js":"010e","./uz.js":"2e8c","./vi":"2921","./vi.js":"2921","./x-pseudo":"fd7e","./x-pseudo.js":"fd7e","./yo":"7f33","./yo.js":"7f33","./zh-cn":"5c3a","./zh-cn.js":"5c3a","./zh-hk":"49ab","./zh-hk.js":"49ab","./zh-tw":"90ea","./zh-tw.js":"90ea"};function a(e){var t=s(e);return n(t)}function s(e){var t=r[e];if(!(t+1)){var n=new Error("Cannot find module '"+e+"'");throw n.code="MODULE_NOT_FOUND",n}return t}a.keys=function(){return Object.keys(r)},a.resolve=s,e.exports=a,a.id="4678"},"56d7":function(e,t,n){"use strict";n.r(t);n("7f7f"),n("cadf"),n("551c"),n("f751"),n("097d");var r=n("2b0e"),a=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"h-100"},[e.me?n("header",[n("b-navbar",{staticClass:"civ-nav-bg",attrs:{toggleable:"lg",type:"dark"}},[n("b-navbar-brand",{attrs:{to:"/"}},[n("img",{staticClass:"d-inline-block align-top",attrs:{width:"34px",src:"https://i.imgur.com/JlQV6Co.png"}})]),n("b-navbar-toggle",{attrs:{target:"nav-collapse"}}),n("b-collapse",{attrs:{id:"nav-collapse","is-nav":""}},[n("b-navbar-nav",{staticClass:"ml-auto"},[n("b-nav-text",[e._v(e._s(e.me.username))]),n("b-nav-item",{on:{click:e.showProfile}},[n("i",{staticClass:"fas fa-cog",attrs:{title:"Your Profile"}})]),n("b-nav-item",{on:{click:e.logout}},[n("GoogleLogin",{staticClass:"google-logout",attrs:{logoutButton:!0,params:e.params,onSuccess:e.onSuccess,onFailure:e.onFailure}},[n("i",{staticClass:"fas fa-power-off",attrs:{title:"Logout"}})])],1)],1)],1)],1)],1):e._e(),n("slideout-panel"),n("router-view",{staticClass:"container-fluid h-container"})],1)},s=[],o=(n("8e6e"),n("ac6a"),n("456d"),n("96cf"),n("3b8d")),c=n("bd86"),u=n("2f62"),i=n("ec8b"),l=n.n(i),f=n("e571"),d=n.n(f),p=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"container-fluid mt-2"},[n("div",{staticClass:"row"},[n("div",{staticClass:"col-4 col-md-4 col-lg-4 col-xl-2"},[n("b-card",{staticStyle:{"background-color":"transparent"}},[n("b-card-body",[n("strong",[e._v(e._s(e.me.username))]),n("p",[e._v(" Here you can view details about your profile and change your currency.")])])],1)],1),n("div",{staticClass:"col-4 col-md-4 col-lg-4 col-xl-2"},[n("b-card",{staticStyle:{"background-color":"transparent"}},[n("b-card-body",[n("multiselect",{attrs:{allowEmpty:!1,options:e.currencies,placeholder:"Change Your Currency"},on:{input:e.updateme},model:{value:e.me.currency,callback:function(t){e.$set(e.me,"currency",t)},expression:"me.currency"}})],1)],1)],1)])])},b=[],m=n("8e5f"),g=n.n(m),h=(n("55dd"),n("6762"),n("2fdb"),n("8c4f")),j={guest:function(e,t,n){S.check()?n("/"):n()},auth:function(){var e=Object(o["a"])(regeneratorRuntime.mark(function e(t,n,r){var a;return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:if(!S.check()){e.next=4;break}r(),e.next=15;break;case 4:return e.prev=4,e.next=7,S.get();case 7:a=e.sent,S.store(a.data),r(),e.next=15;break;case 12:e.prev=12,e.t0=e["catch"](4),r({path:"/login"});case 15:case"end":return e.stop()}},e,null,[[4,12]])}));function t(t,n,r){return e.apply(this,arguments)}return t}()};r["default"].use(h["a"]);var v=new h["a"]({routes:[{path:"/login",name:"login",component:function(){return n.e("login").then(n.bind(null,"a55b"))},beforeEnter:j.guest},{path:"/",name:"home",component:function(){return n.e("dashboard").then(n.bind(null,"7277"))},beforeEnter:j.auth},{path:"/stats",name:"stats",component:function(){return n.e("dashboard").then(n.bind(null,"ed93"))},beforeEnter:j.auth}]}),y=n("2ce5"),w=n("c1df"),k=n.n(w);r["default"].use(u["a"]);var O=new u["a"].Store({state:{me:null,years:{},selectableYears:[],loggingIn:!1,loginError:null},mutations:{loginStart:function(e){return e.loggingIn=!0},loginStop:function(e,t){e.loggingIn=!1,e.loginError=t},updateMe:function(e,t){e.me=t},updateYears:function(e,t){e.years=t},updateSelectableYears:function(e,t){e.selectableYears=t}},actions:{getYears:function(){var e=Object(o["a"])(regeneratorRuntime.mark(function e(t){var n,r,a,s,c;return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return n=t.commit,e.prev=1,e.next=4,y["a"].years();case 4:return r=e.sent,a=r.data,s={},c=[],e.next=10,a.forEach(function(){var e=Object(o["a"])(regeneratorRuntime.mark(function e(t){var n,r,a;return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,y["a"].getTotalPerMonthForYear(t.dateyear);case 2:n=e.sent,r=n.data,a=r.map(function(e){return e.datemonth}),r.forEach(function(e){e.datemonth=k()("".concat(t.dateyear,"-").concat(e.datemonth,"-01")).format()}),[1,2,3,4,5,6,7,8,9,10,11,12].forEach(function(e){a.includes(e)||r.push({amount:0,datemonth:k()("".concat(t.dateyear,"-").concat(e,"-01")).format()})}),s[t.dateyear]={},s[t.dateyear].amount=t.amount,s[t.dateyear].months=r.sort(function(e,t){return new Date(e.datemonth)-new Date(t.datemonth)}),c.push(t.dateyear);case 11:case"end":return e.stop()}},e)}));return function(t){return e.apply(this,arguments)}}());case 10:n("updateSelectableYears",c),n("updateYears",s),e.next=17;break;case 14:e.prev=14,e.t0=e["catch"](1),console.error(e.t0);case 17:case"end":return e.stop()}},e,null,[[1,14]])}));function t(t){return e.apply(this,arguments)}return t}(),loginFaliure:function(e,t){var n=e.commit;n("loginStop",t.response),n("updateMe",null)},login:function(){var e=Object(o["a"])(regeneratorRuntime.mark(function e(t,n){var r,a;return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return r=t.commit,r("loginStart"),e.prev=2,a=n.getAuthResponse().id_token,e.next=6,S.login(a);case 6:v.push("/"),e.next=13;break;case 9:e.prev=9,e.t0=e["catch"](2),r("loginStop",e.t0.response),r("updateMe",null);case 13:case"end":return e.stop()}},e,null,[[2,9]])}));function t(t,n){return e.apply(this,arguments)}return t}(),logout:function(){var e=Object(o["a"])(regeneratorRuntime.mark(function e(){return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,S.logout();case 2:S.remove(),v.push("/login");case 4:case"end":return e.stop()}},e)}));function t(){return e.apply(this,arguments)}return t}()}}),x=n("bc3a"),P=n.n(x),S={user:function(){return O.state.me},check:function(){return O.state.me?O.state.me:sessionStorage.getItem("me")?(O.commit("updateMe",JSON.parse(sessionStorage.getItem("me"))),O.state.me):void 0},store:function(e){if(e)return sessionStorage.setItem("me",JSON.stringify(e)),O.commit("updateMe",e),O.state.me},remove:function(){sessionStorage.removeItem("me"),O.commit("updateMe",null)},get:function(){var e=Object(o["a"])(regeneratorRuntime.mark(function e(){return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,P.a.get("/api/user/getme");case 2:return e.abrupt("return",e.sent);case 3:case"end":return e.stop()}},e)}));function t(){return e.apply(this,arguments)}return t}(),login:function(){var e=Object(o["a"])(regeneratorRuntime.mark(function e(t){return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,P.a.post("/api/login?id_token=".concat(t));case 2:return e.abrupt("return",e.sent);case 3:case"end":return e.stop()}},e)}));function t(t){return e.apply(this,arguments)}return t}(),logout:function(){var e=Object(o["a"])(regeneratorRuntime.mark(function e(){return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,P.a.post("/api/logout");case 2:return e.abrupt("return",e.sent);case 3:case"end":return e.stop()}},e)}));function t(){return e.apply(this,arguments)}return t}(),updateme:function(){var e=Object(o["a"])(regeneratorRuntime.mark(function e(t){return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,P.a.post("/api/user/updateme?currency=".concat(t));case 2:return e.abrupt("return",e.sent);case 3:case"end":return e.stop()}},e)}));function t(t){return e.apply(this,arguments)}return t}()};function R(e,t){var n=Object.keys(e);return Object.getOwnPropertySymbols&&n.push.apply(n,Object.getOwnPropertySymbols(e)),t&&(n=n.filter(function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable})),n}function E(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?R(n,!0).forEach(function(t){Object(c["a"])(e,t,n[t])}):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):R(n).forEach(function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))})}return e}var _={name:"Profile",components:{Multiselect:g.a},data:function(){return{currencies:["$","£","€"]}},computed:E({},Object(u["c"])(["me"])),methods:E({},Object(u["b"])(["getYears"]),{updateme:function(){var e=Object(o["a"])(regeneratorRuntime.mark(function e(){var t;return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,S.updateme(this.me.currency);case 2:t=e.sent,S.store(t.data),this.getYears();case 5:case"end":return e.stop()}},e,this)}));function t(){return e.apply(this,arguments)}return t}()})},C=_,z=n("2877"),D=Object(z["a"])(C,p,b,!1,null,null,null),T=D.exports;function M(e,t){var n=Object.keys(e);return Object.getOwnPropertySymbols&&n.push.apply(n,Object.getOwnPropertySymbols(e)),t&&(n=n.filter(function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable})),n}function Y(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?M(n,!0).forEach(function(t){Object(c["a"])(e,t,n[t])}):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):M(n).forEach(function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))})}return e}var F={name:"app",components:{GoogleLogin:d.a},data:function(){return{params:{client_id:l.a.googleClientID}}},computed:Y({},Object(u["c"])(["me"])),methods:Y({},Object(u["b"])(["logout","loginFaliure"]),{showProfile:function(){this.$showPanel({component:T,height:window.innerHeight/100*27.5,openOn:"top",cssClass:"slideout-bg"})},onSuccess:function(){var e=Object(o["a"])(regeneratorRuntime.mark(function e(){return regeneratorRuntime.wrap(function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,this.logout();case 2:case"end":return e.stop()}},e,this)}));function t(){return e.apply(this,arguments)}return t}(),onFailure:function(e){this.loginFaliure(e)}})},I=F,N=(n("034f"),n("8604"),Object(z["a"])(I,a,s,!1,null,"23de7a02",null)),L=N.exports,A=n("5f5b"),G=n("7ee8"),$=n.n(G),B=n("f827"),J=n.n(B),U=n("5887"),q=n.n(U);n("4f8c"),n("4012"),n("f9e3"),n("2dd8"),n("e607"),n("3ee4");r["default"].use($.a),r["default"].component(J.a.name,J.a),r["default"].use(q.a,{firstDayOfWeek:2}),r["default"].use(A["a"]),r["default"].config.productionTip=!1,new r["default"]({router:v,store:O,render:function(e){return e(L)}}).$mount("#app")},"64a9":function(e,t,n){},8604:function(e,t,n){"use strict";var r=n("1bf2"),a=n.n(r);a.a},ac5c:function(e,t){e.exports={googleClientID:Object({NODE_ENV:"production",BASE_URL:"/"}).VUE_APP_GOOGLE_CLIENT_ID}},ec8b:function(e,t,n){e.exports=n("ac5c")}});
//# sourceMappingURL=index.9392e860.js.map