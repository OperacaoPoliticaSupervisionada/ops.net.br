/*! jQuery UI - v1.10.3 - 2013-09-28
* http://jqueryui.com
* Copyright 2013 jQuery Foundation and other contributors; Licensed MIT */

(function(t){function e(t,e,i){return t>e&&e+i>t}t.widget("ui.droppable",{version:"1.10.3",widgetEventPrefix:"drop",options:{accept:"*",activeClass:!1,addClasses:!0,greedy:!1,hoverClass:!1,scope:"default",tolerance:"intersect",activate:null,deactivate:null,drop:null,out:null,over:null},_create:function(){var e=this.options,i=e.accept;this.isover=!1,this.isout=!0,this.accept=t.isFunction(i)?i:function(t){return t.is(i)},this.proportions={width:this.element[0].offsetWidth,height:this.element[0].offsetHeight},t.ui.ddmanager.droppables[e.scope]=t.ui.ddmanager.droppables[e.scope]||[],t.ui.ddmanager.droppables[e.scope].push(this),e.addClasses&&this.element.addClass("ui-droppable")},_destroy:function(){for(var e=0,i=t.ui.ddmanager.droppables[this.options.scope];i.length>e;e++)i[e]===this&&i.splice(e,1);this.element.removeClass("ui-droppable ui-droppable-disabled")},_setOption:function(e,i){"accept"===e&&(this.accept=t.isFunction(i)?i:function(t){return t.is(i)}),t.Widget.prototype._setOption.apply(this,arguments)},_activate:function(e){var i=t.ui.ddmanager.current;this.options.activeClass&&this.element.addClass(this.options.activeClass),i&&this._trigger("activate",e,this.ui(i))},_deactivate:function(e){var i=t.ui.ddmanager.current;this.options.activeClass&&this.element.removeClass(this.options.activeClass),i&&this._trigger("deactivate",e,this.ui(i))},_over:function(e){var i=t.ui.ddmanager.current;i&&(i.currentItem||i.element)[0]!==this.element[0]&&this.accept.call(this.element[0],i.currentItem||i.element)&&(this.options.hoverClass&&this.element.addClass(this.options.hoverClass),this._trigger("over",e,this.ui(i)))},_out:function(e){var i=t.ui.ddmanager.current;i&&(i.currentItem||i.element)[0]!==this.element[0]&&this.accept.call(this.element[0],i.currentItem||i.element)&&(this.options.hoverClass&&this.element.removeClass(this.options.hoverClass),this._trigger("out",e,this.ui(i)))},_drop:function(e,i){var s=i||t.ui.ddmanager.current,o=!1;return s&&(s.currentItem||s.element)[0]!==this.element[0]?(this.element.find(":data(ui-droppable)").not(".ui-draggable-dragging").each(function(){var e=t.data(this,"ui-droppable");return e.options.greedy&&!e.options.disabled&&e.options.scope===s.options.scope&&e.accept.call(e.element[0],s.currentItem||s.element)&&t.ui.intersect(s,t.extend(e,{offset:e.element.offset()}),e.options.tolerance)?(o=!0,!1):undefined}),o?!1:this.accept.call(this.element[0],s.currentItem||s.element)?(this.options.activeClass&&this.element.removeClass(this.options.activeClass),this.options.hoverClass&&this.element.removeClass(this.options.hoverClass),this._trigger("drop",e,this.ui(s)),this.element):!1):!1},ui:function(t){return{draggable:t.currentItem||t.element,helper:t.helper,position:t.position,offset:t.positionAbs}}}),t.ui.intersect=function(t,i,s){if(!i.offset)return!1;var o,n,r=(t.positionAbs||t.position.absolute).left,a=r+t.helperProportions.width,l=(t.positionAbs||t.position.absolute).top,h=l+t.helperProportions.height,c=i.offset.left,p=c+i.proportions.width,f=i.offset.top,d=f+i.proportions.height;switch(s){case"fit":return r>=c&&p>=a&&l>=f&&d>=h;case"intersect":return r+t.helperProportions.width/2>c&&p>a-t.helperProportions.width/2&&l+t.helperProportions.height/2>f&&d>h-t.helperProportions.height/2;case"pointer":return o=(t.positionAbs||t.position.absolute).left+(t.clickOffset||t.offset.click).left,n=(t.positionAbs||t.position.absolute).top+(t.clickOffset||t.offset.click).top,e(n,f,i.proportions.height)&&e(o,c,i.proportions.width);case"touch":return(l>=f&&d>=l||h>=f&&d>=h||f>l&&h>d)&&(r>=c&&p>=r||a>=c&&p>=a||c>r&&a>p);default:return!1}},t.ui.ddmanager={current:null,droppables:{"default":[]},prepareOffsets:function(e,i){var s,o,n=t.ui.ddmanager.droppables[e.options.scope]||[],r=i?i.type:null,a=(e.currentItem||e.element).find(":data(ui-droppable)").addBack();t:for(s=0;n.length>s;s++)if(!(n[s].options.disabled||e&&!n[s].accept.call(n[s].element[0],e.currentItem||e.element))){for(o=0;a.length>o;o++)if(a[o]===n[s].element[0]){n[s].proportions.height=0;continue t}n[s].visible="none"!==n[s].element.css("display"),n[s].visible&&("mousedown"===r&&n[s]._activate.call(n[s],i),n[s].offset=n[s].element.offset(),n[s].proportions={width:n[s].element[0].offsetWidth,height:n[s].element[0].offsetHeight})}},drop:function(e,i){var s=!1;return t.each((t.ui.ddmanager.droppables[e.options.scope]||[]).slice(),function(){this.options&&(!this.options.disabled&&this.visible&&t.ui.intersect(e,this,this.options.tolerance)&&(s=this._drop.call(this,i)||s),!this.options.disabled&&this.visible&&this.accept.call(this.element[0],e.currentItem||e.element)&&(this.isout=!0,this.isover=!1,this._deactivate.call(this,i)))}),s},dragStart:function(e,i){e.element.parentsUntil("body").bind("scroll.droppable",function(){e.options.refreshPositions||t.ui.ddmanager.prepareOffsets(e,i)})},drag:function(e,i){e.options.refreshPositions&&t.ui.ddmanager.prepareOffsets(e,i),t.each(t.ui.ddmanager.droppables[e.options.scope]||[],function(){if(!this.options.disabled&&!this.greedyChild&&this.visible){var s,o,n,r=t.ui.intersect(e,this,this.options.tolerance),a=!r&&this.isover?"isout":r&&!this.isover?"isover":null;a&&(this.options.greedy&&(o=this.options.scope,n=this.element.parents(":data(ui-droppable)").filter(function(){return t.data(this,"ui-droppable").options.scope===o}),n.length&&(s=t.data(n[0],"ui-droppable"),s.greedyChild="isover"===a)),s&&"isover"===a&&(s.isover=!1,s.isout=!0,s._out.call(s,i)),this[a]=!0,this["isout"===a?"isover":"isout"]=!1,this["isover"===a?"_over":"_out"].call(this,i),s&&"isout"===a&&(s.isout=!1,s.isover=!0,s._over.call(s,i)))}})},dragStop:function(e,i){e.element.parentsUntil("body").unbind("scroll.droppable"),e.options.refreshPositions||t.ui.ddmanager.prepareOffsets(e,i)}}})(jQuery);