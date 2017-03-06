/* detectJs.js */
$('html').removeClass('no-js').addClass('js');

if(('ontouchstart' in window) || window.DocumentTouch && document instanceof DocumentTouch) {
    $('html').addClass('hasTouch');
} else {
    $('html').addClass('noTouch');
}

/* detectHighContrast.js */
$(function(){
	var $div = $('<div>')
				.css({"position": "absolute","top": "0","left": "-2300px","background-color": "#878787"})
				.text('hc')
				.appendTo("body");
	var testcolor = $div.css("background-color").toLowerCase();
	$div.remove();
	if (testcolor != "#878787" && testcolor != "rgb(135, 135, 135)") {
		$('html').addClass('highContrast');
	}
});

/* IE10MobileFix.js */
if (navigator.userAgent.match(/IEMobile\/10\.0/)) {
	var msViewportStyle = document.createElement("style");
	msViewportStyle.appendChild(
		document.createTextNode(
			"@-ms-viewport{width:auto!important}"
		)
	);
	document.getElementsByTagName("head")[0].
		appendChild(msViewportStyle);
}
/* fixDate.js */
$(function() {
	var timeSelect = $("time[datetime]");
	timeSelect.each(function () {
		var backToDate = new Date(this.getAttribute("datetime"));
		$(this).text(backToDate.toLocaleDateString());
	});
	$(".metadata .meta").removeClass("loading");
});

/* jquery/plugins/jquery.domReadyShield.js */
(function($){
    $.fn.oldReady = $.fn.ready;
    $.fn.ready = function(fn){
        return $.fn.oldReady( function(){ try{ if(fn) fn.apply($,arguments); } catch(e){}} );
    }
})(jQuery);

/* jquery/plugins/jquery.lald.js */
(function ($) {
	var domReady = false;
	var $document = $(document);

	var handleAttachment = function (selector, event, arg1, arg2, namespace) {
		var namespacedEvent = event + '.' + namespace;
		var data = arg2 ? arg1 : null;
		var handler = arg2 ? arg2 : arg1;

		if (!domReady) {
			if (data) {
				$document.on(namespacedEvent, selector, data, handler);
			} else {
				$document.on(namespacedEvent, selector, handler);
			}
		}

		$(function () {
			domReady = true;
			$document.off(namespacedEvent, selector, handler);	//should handler be included here?
			if (namespace === 'lald') {
				if (data) {
					$(selector).on(namespacedEvent, data, handler);
				} else {
					$(selector).on(namespacedEvent, handler);
				}
			}
		});

	};

	$.lald = function (selector, event, arg1, arg2) {
		handleAttachment(selector, event, arg1, arg2, 'lald');
	};

	$.lad = function (selector, event, arg1, arg2) {
		handleAttachment(selector, event, arg1, arg2, 'lad');
	};

}(jQuery));

/* jquery/plugins/jquery.addState.js */
(function ($) {

	$.fn.removeState = function (namespace) {
		$(this).each(function () {
			var $this = $(this);
			if ($this.attr("class") && $this.attr("class").indexOf(namespace) >= 0) {
				var otherClasses = $.grep( $this.attr("class").split(" "), function(aClass) {
					return aClass.lastIndexOf(namespace, 0) !== 0;
				});
				$this.attr("class", otherClasses.join(" "));
			}
		});
		return this;
	};

	$.fn.addState = function (namespace, state) {
		this.removeState(namespace);
		this.addClass(namespace + state);
		return this;
	};

	$.fn.toggleState = function (namespace, state, switchVal) {
		var $this = $(this);
		if (typeof switchVal === "boolean") {
			if (switchVal) {
				$this.addState(namespace, state);
			} else {
				$this.removeClass(namespace + state);
			}
			return this;
		}

		if ($this.hasClass(namespace + state)) {
			$this.removeClass(namespace + state);
		} else {
			$this.addState(namespace, state);
		}
		return this;
	};

})(jQuery);

/* jquery/plugins/jquery.ifThen.js */
jQuery.fn.extend({
	ifThen: function () {
		var args = arguments;

		if (args.length < 2) {
			return this;
		}

		for (var i = 0; i < args.length; i = i + 2) {
			if (args[i] && jQuery.isFunction(args[i + 1])) {
				args[i + 1].call(this);
				return this;
			}
		}

		if (args.length % 2 && (typeof args[args.length - 1] === "function")) {
			args[args.length - 1].call(this);
		}

		return this;
	}
});

/* scrollingEvents.js */
(function ($) {

	var isPinned = false;
	var pinBuffer = 18;
	var footerBuffer = 150;
	var footerTop = 99999;
	var footerDiff = 0;
	var isFooterVisible = false;
	var currentDocOutlineItemIndex = -1;
	var desktopWidth = 1024;

	var pageActionContentClass = "#page-actions-content";
	var sidebarContentClass = "#sidebarContent";

	msDocs.data.h2Tops = [];
	msDocs.data.isOutlineHighlighted = false;
	var isPageActionsAvailable = false;
	var isSidebarAvailable = false;
	msDocs.data.savedWindowWidth = $(window).width();
	msDocs.data.savedWindowHeight = $(window).height();

	msDocs.functions.updateH2Tops = function(isRefresh) {
		if(msDocs.data.isOutlineHighlighted)
		{
			msDocs.data.h2Tops = [];
			var mainh2s = $('main h2');

			if(mainh2s.length > 1) {
				mainh2s.each(function(){
					msDocs.data.h2Tops.push(Math.floor($(this).offset().top-10));
				});

				if(isRefresh){
					msDocs.functions.updateDocOutlineSelection($(window).scrollTop());
				}

				return true;
			} else {
				return false;
			}
		}
	}

	msDocs.functions.selectDocOutlineItem = function(index, override){
		if(!override && currentDocOutlineItemIndex === index) {
			return;
		}

		currentDocOutlineItemIndex = index;
		$(".doc-outline li").removeClass('selected');

		var $selectedLi = $(".doc-outline li:eq(" + index + ")");
		$selectedLi.addClass('selected');

		if(isPinned)
		{
			var liTop = $selectedLi.position().top;

			var $pac = $(pageActionContentClass);
			var st = $pac.scrollTop();
			var ht = $pac.height();

			if(liTop + 24 - st > ht - st)
			{
				var inc = liTop + 24 - ht + st;
				if(override) {
					$pac.scrollTop(inc);
				} else {
					$pac.animate({ scrollTop: inc }, "fast");
				}
			}
			else if(liTop < 0){
				var dec = st + liTop;
				if(override) {
					$pac.scrollTop(dec);
				} else {
					$pac.animate({ scrollTop: dec }, "fast");
				}
			}
		}
	}

	msDocs.functions.updateDocOutlineSelection = function(scrollTop){
		var h2Tops = msDocs.data.h2Tops;
		for (i = 0; i < h2Tops.length; i++) {
			if(i === 0 && h2Tops.length > 1 && h2Tops[1] > scrollTop){
				msDocs.functions.selectDocOutlineItem(0);
				break;
			}
			else if(i === h2Tops.length-1 && h2Tops[i] < scrollTop) {
				msDocs.functions.selectDocOutlineItem(i);
				break;
			}
			else if(h2Tops[i] <= scrollTop && h2Tops[i+1] > scrollTop) {
				msDocs.functions.selectDocOutlineItem(i);
				break;
			}
		}
	};

	msDocs.functions.setTocHeight = function(heightOffset, isFirstRun){
		var $toc = $(".toc");
		if(!$toc.length){
			return;
		}

		var tocTop = 24;
		var fhh = $(".filterHolder").height() + 24; //fhh padding-top
		var pdh = $(".pdfDownloadHolder").height();		
		if(pdh > 0)
		{
			pdh += 34; //pdh margin-top + bottom buffer
		} else {
			pdh = 10; //bottom buffer
		}

		if(!isPinned) {
			tocTop += $("#sidebar").offset().top;
		}

		var mh = msDocs.data.savedWindowHeight - tocTop - fhh - pdh - heightOffset;
		if(mh < 32){
			mh = 32;
		}

		$toc.css("max-height", mh + "px");

		if(isPinned) {
			$(".tocSpace").height(($(sidebarContentClass).height() + pinBuffer * 6) + "px");
		}

		if(isFirstRun && $toc.scrollTop() === 0)
		{
			setTimeout(function() {
				var $selectedLinks = $(".toc a.selected");
				if($selectedLinks.length > 0)
				{
					var $link = $($selectedLinks[0]);
					var totalOffset = 0;
					$link.parentsUntil(".toc").each(function( index ) {
						if($(this).prop("tagName") == "LI")
						{
							totalOffset += $(this).position().top;
						}
					});
					totalOffset = totalOffset - $(".toc").height();
					$toc.scrollTop(totalOffset);
				}
			}, 200);
		}
	}

	$(function(){
		isPageActionsAvailable = $(pageActionContentClass).length > 0;
		isSidebarAvailable = $(sidebarContentClass).length > 0;
		msDocs.data.isOutlineHighlighted = $(".doc-outline").length > 0;

		if(msDocs.data.isOutlineHighlighted)
		{
			msDocs.data.isOutlineHighlighted = msDocs.functions.updateH2Tops(false);
			if(msDocs.data.isOutlineHighlighted) {
				setTimeout(function(){
					msDocs.functions.selectDocOutlineItem(0);
				}, 40);
			}
		}

		if(msDocs.data.isOutlineHighlighted || isPageActionsAvailable || isSidebarAvailable) {

			$(window).scroll(function() {
				var scrollTop = $(window).scrollTop();

				if(msDocs.data.isOutlineHighlighted) {
					msDocs.functions.updateDocOutlineSelection(scrollTop);
				}

				if(isPageActionsAvailable || isSidebarAvailable) {
					if (scrollTop > 145) {
						if(!isPinned) {
							isPinned = true;
							setFooterTop();
							setPinnedPositions();
						}

						//TODO: remove safety check once footer insert is changed
						if(footerTop === 99999)
						{
							setFooterTop();
						}

						evalFooterState(scrollTop);
					} else {
						if(isPinned) {
							isPinned = false;
							setStaticPositions();
						}
					}
				}
			});

			$(window).resize(function() {
				msDocs.data.savedWindowHeight = $(window).height();

				var w = $(window).width();
				if(msDocs.data.savedWindowWidth !== w)
				{
					msDocs.data.savedWindowWidth = w;
					msDocs.functions.updateH2Tops(true);
				}

				if(isSidebarAvailable) {
					if(!isPinned) {
						msDocs.functions.setTocHeight(0, false);
					}
				}

				if(isPageActionsAvailable || isSidebarAvailable) {
					setFooterTop();

					if(isPinned) {
						setPinnedPositions();
						evalFooterState($(window).scrollTop());
					}
				}
			});
		}

		var evalFooterState = function(scrollTop){
			if(scrollTop + msDocs.data.savedWindowHeight > footerTop) {
				footerDiff = scrollTop + msDocs.data.savedWindowHeight - footerTop;
				isFooterVisible = true;
				setPinnedPositions();
				if(msDocs.data.isOutlineHighlighted) {
					msDocs.functions.selectDocOutlineItem(currentDocOutlineItemIndex, true);
				}
			} else {
				if(isFooterVisible)
				{
					isFooterVisible = false;
					setPinnedPositions();
					if(msDocs.data.isOutlineHighlighted) {
						msDocs.functions.selectDocOutlineItem(currentDocOutlineItemIndex, true);
					}
				}
			}
		}

		var setFooterTop = function(){
			var $ft = $("#footer");
			if($ft.length > 0) { //safety check needed due to current footer replcement technique
				footerTop = $ft.offset().top;
			}
		}

		var setPinnedPositions = function(){
			if(isPageActionsAvailable){
				var $pac = $(pageActionContentClass);

				if(msDocs.data.savedWindowWidth >= desktopWidth){
					$pac.css({"top": pinBuffer + "px", "width": ($("#page-actions").innerWidth() - pinBuffer) + "px"});
				} else {
					$pac.css({"top": "0", "width": "100%"});
				}

				$pac.addClass("pinned-actions");
				if(isFooterVisible){
					$pac.css("max-height", (msDocs.data.savedWindowHeight - footerDiff - pinBuffer * 2) + "px");
				} else {
					$pac.css("max-height", (msDocs.data.savedWindowHeight - pinBuffer * 2) + "px");
				}
			}

			if(isSidebarAvailable){
				var $sc = $(sidebarContentClass);
				$sc.css({"top": pinBuffer + "px", "width": $("#sidebar").innerWidth() + "px"});

				$(".tocSpace").height(($sc.height() + pinBuffer * 6) + "px");

				$sc.addClass("fixed");
				if(isFooterVisible){
					msDocs.functions.setTocHeight(footerDiff, false);
				} else {
					msDocs.functions.setTocHeight(0, false);
				}
			}
		}

		var setStaticPositions = function(){
			$(pageActionContentClass).css({"width": "auto", "max-height": "none"})
				.removeClass("pinned-actions");

			$(sidebarContentClass).css("width", "auto")
				.removeClass("fixed");

			$(".tocSpace").height("0");

			msDocs.functions.setTocHeight(0, false);
		};
	});
})(jQuery);

/* localStorage.js */
(function(){
	msDocs.functions.setLocalStorage = function(key, value){
		if(!value){
			window.localStorage.removeItem(key);
		}else{
			window.localStorage.setItem(key, value);
		}
	};

	msDocs.functions.getLocalStorage = function(key){
		return window.localStorage.getItem(key);
	};
})();

/* themeSwitcher.js */
(function ($) {
	var selectorId = 'theme-selector';
	var storageName = 'theme';
	var classNamespace = 'theme';
	var placeholderClass = 'removedOnload';

	var getStorageValue = function(){
		return msDocs.functions.getLocalStorage(storageName);
	};

	var updateThemeClass = function(){
		var currentTheme = getStorageValue();
		if(currentTheme && currentTheme.length){
			currentTheme = currentTheme.replace( classNamespace, '');
			$('html').addState(classNamespace, currentTheme);
			if (currentTheme === '_night')
			{
				currentTheme = 'dark';
			}
			msDocs.data.currentTheme = currentTheme;
		} else {
			$('html').removeState(classNamespace);
			msDocs.data.currentTheme = 'light';
		}
	};

	$.lald('#' + selectorId, 'change', function(e){
		var currentValue = $(this).val();
		if(currentValue && currentValue.length){
			msDocs.functions.setLocalStorage(storageName, currentValue);
		} else {
			msDocs.functions.setLocalStorage(storageName);
		}

		updateThemeClass();
	});

	updateThemeClass();
	$(function(){
		var $selector = $('#' + selectorId);
		$selector.find('.' + placeholderClass).remove();

		var currentTheme = getStorageValue();
		if(currentTheme && currentTheme.length){
			$selector.val(currentTheme);
		}
	});

})(jQuery);

/* get_removeLocal.js */
(function ($) {
	msDocs.functions.getLocaleFromPath = function(path){
		if(path && (path.charAt(0) === '/') && (path.charAt(6) === '/') && (path.charAt(3) === '-')){
			return path.substr(1,5);
		}
		return path;
	};

	msDocs.functions.removeLocaleFromPath = function(path){
		if(path && (path.charAt(0) === '/') && (path.charAt(6) === '/') && (path.charAt(3) === '-')){
			return path.substr(6);
		}
		return path;
	};

	msDocs.data.userLocale = msDocs.functions.getLocaleFromPath(location.pathname);

})(jQuery);

/* getParam.js */
(function ($) {
	msDocs.functions.getParam = function(paramName, type){
		if(type === 'meta' && $){
			return $('meta[name="' + paramName + '"]').attr('content');
		} else {
			var frag = (type === 'hash') ? window.location.hash : window.location.search;
			if (frag && frag.length>0) {
				frag = frag.substring(1);
				var cmpstring = paramName + "=";
				var cmplen = cmpstring.length;
				var temp = frag.split("&");
				for (var i = 0; i < temp.length; i++) {
					if (temp[i].substr(0, cmplen) == cmpstring) {
						return temp[i].substr(cmplen);
					}
				}
			}
			return undefined;
		}
	};
})(jQuery);

/* loadUhf.js */
var updateSearchForm = function(){
	var $searchForm = $('#searchForm');

	//update action locale
	$searchForm.attr('action', 'https://docs.microsoft.com/' + msDocs.data.userLocale + '/search/index')
		.find('#search').removeAttr('name');

	//insert search scope element	
	var scopes = msDocs.functions.getParam('scope', 'meta');
	var hideScope = msDocs.functions.getParam('hideScope', 'meta');

	if(hideScope === 'true')
	{
		scopes = undefined;
	}

	var isSearchPage = false;
	if(scopes === undefined){
		isSearchPage = $("body.searchPage").length > 0;
		if(isSearchPage){
			scopes = msDocs.functions.getParam('scope');
		}            
	}

	if(scopes != undefined){
		var scopesArr = scopes.split(", ");
		if(scopesArr.length){
			//TODO: get from localization when available
			var searchScopeInfo = "Search filter set to ";
			var searchScopeAction = "Tap to remove filter.";

			var scopeStr = scopesArr[scopesArr.length-1];

			if(isSearchPage){
				//scrub input
				var sv = encodeURIComponent(decodeURIComponent(scopeStr.replace(/\+/g, " ")));
				sv = sv.replace(/%23/g, "#").replace(/%20/g, " ").replace(/%2b/gi, "+").replace(/%22/g, '"');
				scopeStr = sv.replace(/%26/g, "&").replace(/%3c/gi, "<").replace(/%3e/gi, ">").replace(/%2f/gi, "/").replace(/%5c/gi, "\\");
			}

			var $link = $("<a>")
						.addClass("searchScope")
						.attr("href", "#")                            
						.on('click', function(e){
							e.stopPropagation();
							e.preventDefault();                                
							$(this).remove();
							$searchForm.find('input[name="scope"]').remove();
							$searchForm.find('input[name="search"]').animate({'padding-left': '10px'}, 'fast');
						})
						.attr("title", searchScopeInfo + " '" + scopeStr + "'. " + searchScopeAction)
						.text(scopeStr);
			
			$searchForm.append($link);
			$searchForm.find('input[name="search"]').css("padding-left", ($link.width() + 34) + 'px');

			var $input = $("<input>")
							.attr('type', 'hidden')
							.attr('name', 'scope')
							.attr('value', scopeStr)

			$searchForm.append($input);
		}
	}
}

var loadUhfCss = function(uhfData, callback){
	if(!uhfData || !uhfData.cssIncludes || !uhfData.cssIncludes.length){
		return;	
	}

	if (document.createStyleSheet){
		//IE10 support
		for (i = 0; i < uhfData.cssIncludes.length; i++) {
			document.createStyleSheet(uhfData.cssIncludes[i]);
		}
	} else {
		var $head = $("head");
		for (i = 0; i < uhfData.cssIncludes.length; i++) {			
			$head.append($('<link rel="stylesheet" href="' + uhfData.cssIncludes[i] + '" type="text/css" media="all" />'));
		}
	}

	//workaround to get css read callback
	var cssUrl = uhfData.cssIncludes[0];
	var img = document.createElement('img');
	img.onerror = function(){
		if(callback){
			callback(uhfData);
		} 
	}
	img.src = cssUrl;
}

var getUhfData = function(){
	if(msDocs.data.brand === 'azure') {
		return;
	}

	//retrieve header id
	var uhfHeaderId = msDocs.functions.getParam('uhfHeaderId', 'meta');
	if(!uhfHeaderId) {
		uhfHeaderId = 'MSDocsHeader-DocsL1';
	}

	var uhfUrl = 'https://docs.microsoft.com/api/GetUHF?locale=' + msDocs.data.userLocale + '&headerId=' + uhfHeaderId + '&footerId=MSDocsFooter';

	$.ajax({
		url: uhfUrl,
		dataType: 'json',
		timeout: 10000
	})
	.done(function(data, textStatus, jqXHR){		
		var uhfData = jqXHR.responseJSON;
		loadUhfCss(uhfData, function(uhfData) {
			$(function(){
				$('#uhfPlaceHolder').replaceWith($(uhfData.headerHTML));
				updateSearchForm();

				//cancel Search Suggestions
				var shellOptions = {
					as: {
						callback: function () {}
					}
				};

				if (window.msCommonShell) {
					window.msCommonShell.load(shellOptions);
				} else {
					window.onShellReadyToLoad = function () {
						window.onShellReadyToLoad = null;
						window.msCommonShell.load(shellOptions);
					};
				}
			});
		});
	});
};
getUhfData();

/* toc.js */
/*
* Handles requsting TOC from query string or meta tag
* Building html toc
* Setting selected node
*
* Requires jQuery, getParam, ifThen
*
* version 0.1
* September, 2016
* GK
*
* version 0.2
* Adding filtering
* October, 2016
*
* version 0.3
* changing filtering. Moving to a data-title attribute
* makeing text nodes triggers for expansion
* October, 2016
*
* version 0.4
* Adding breadcrumb handling
* November, 2016
*/

(function ($) {
	var urlTocQueryName = 'toc';
	var urlTocMetaName = 'toc_rel';
	var urlBcQueryName = 'bc';
	var urlBcMetaName = 'breadcrumb_path';
	var pagetypeMetaName = 'pagetype';

	var selectedClass = 'selected';
	var selectedHolderClass = 'selectedHolder';
	var rotateClass = 'rotate';
	var noSubsClass = 'noSubs';
	var noSibsClass = 'noSibs';
	var filterClassName = 'tocFilter';
	var emptyFilterClassName = 'emptyFilter';
	var emptyFilterMessageClassName = 'emptyFilterMessage';
	var hideFocusClass = 'hideFocus';
	var tocHolderSelector = '.toc';
	var filterHolderSelector = '.filterHolder';

	var breadcrumbClass = 'breadcrumbs';

	var eventNamespace = 'msDocs';

	var mTocSubNodeIndent = '&nbsp;&nbsp;&nbsp;';
	var noLinkClass = 'noLink';
	var mTocHolderSelector = '#menu-nav select';

	var isTouchEvent = false;
	/* this is used because the click target of the ul's is bigger than it should be (really bad in Chrome) when using touch.
	   when a touch event is initiated, the stopPropagation method is not called in the outter parts of a the element that is being used as a block.
	   the amount excluded is just a guess at this point.
	*/

	var timeout = 10000;
	var otherTocDelay = 510;    //how many milliseconds to wait until drawing secondary TOC

	var relativeCanonicalUrl = '';
	var relativeCanonicalUrlNoQuery = '';
	var relativeCanonicalUrlUniformIndex = '';
	var tocUrl = '';
	var tocFolder = '';
	var bcUrl = '';
	var bcFolder = '';
	var locale = '';
	var locationFolder = '';
	var $savedToc;
	var tocJson = [];

	var tocQueryUrl = msDocs.functions.getParam(urlTocQueryName);
	var tocMetaUrl = msDocs.functions.getParam(urlTocMetaName, 'meta');

	var bcQueryUrl = msDocs.functions.getParam(urlBcQueryName);
	if(bcQueryUrl){
		bcQueryUrl = decodeURIComponent(bcQueryUrl);
	}
	var bcMetaUrl = msDocs.functions.getParam(urlBcMetaName, 'meta');

	var pagetype = msDocs.functions.getParam(pagetypeMetaName, 'meta');
	var tocBestMatch = [];
	//This should have been a promise. Maybe change it someday
	var tocFinished = false;
	var bcFinished = false;

	var cleanTitle =  function(value) {
		if(value && value.length){
			return value
				.replace(/&/g, '&amp;')
				.replace(/"/g, '&quot;')
				.replace(/'/g, '&#39;')
				.replace(/</g, '&lt;')
				.replace(/>/g, '&gt;');
		}
		return value;
	};

	var breakDots =  function(str) {
		if(str && str.length){
			return str.split('.').join('\u200B.');
		}
		return str;
	};

	var resolveRelativePath = function(path, folder){
		if(!path || !path.length){
			return path;
		}

		folder = folder || locationFolder;
		var firstChar = path.charAt(0);

		if(firstChar === '/'){
			if((path.charAt(6) === '/') && (path.charAt(3) === '-')){
				return path;
			}
			return '/' + locale + path;
		}

		if((path.substr(0,7) === 'http://') || (path.substr(0,8) === 'https://')){
			return path;
		}

		if(firstChar !== '.'){
			return '/' + locale + folder + '/' + path;
		}

		if(path.substr(0,3) === '../'){
			return resolveRelativePath(path.substr(3), getFolder(folder));
		}

		if(path.substr(0,2) === './'){
			return '/' + locale + folder + '/' + path.substr(2);
		}

		return path;
	};

	var removeQueryString = function(path){
		if(path && path.length){
			var index = path.indexOf('?');
			if(index > 0){
				path = path.substring(0, index);
			}
		}
		return path;
	};

	var getUniformIndex = function(path){
		// if path ends with /, /index or /index.xxx, ruturn path up to last /, else return empty string
		if(path && path.length){
			if(path.charAt(path.length-1) == '/'){
				return path;
			}
			var whackIndex = path.lastIndexOf('/');
			var indexIndex = path.indexOf('index', whackIndex);
			if(indexIndex > 0){
				if(indexIndex == path.length-5){
					return path.substring(0, indexIndex);
				}
				var dotIndex = path.indexOf('.', whackIndex);
				if(dotIndex > 0){
					path = path.substring(0, dotIndex);
					if(path.substring(path.length-6) == '/index'){
						return path.substring(0, path.length-5);
					}
				}
			}
		}
		return '';
	};

	var getRelativeCanonicalUrl = function(removeTheQueryString){
		var canonicalUrl = $('link[rel="canonical"]').attr('href');
		if(canonicalUrl && canonicalUrl.length){
			if((canonicalUrl.substr(0,7) === 'http://') || (canonicalUrl.substr(0,8) === 'https://')){
				canonicalUrl = canonicalUrl.substring(canonicalUrl.indexOf('//')+2);
				canonicalUrl = canonicalUrl.substring(canonicalUrl.indexOf('/'));
			}
		}else{
			canonicalUrl = document.location.pathname;
		}
		canonicalUrl = msDocs.functions.removeLocaleFromPath(canonicalUrl);
		if(removeTheQueryString){
			canonicalUrl = removeQueryString(canonicalUrl);
		}
		return canonicalUrl;
	}

	var getFolder = function(path){
		return path.substring(0, path.lastIndexOf('/'));
	};

	var thisIsMe = function(href){
		href = href.toLowerCase();
		var hrefNoQuery = removeQueryString(msDocs.functions.removeLocaleFromPath(href));
		if(relativeCanonicalUrlNoQuery === hrefNoQuery){
			return true;
		}
		//Canonical is an index page
		if(relativeCanonicalUrlUniformIndex){
			if( href.lastIndexOf('/') == href.length-1 ){
				if(relativeCanonicalUrlUniformIndex === hrefNoQuery ){
					return true;
				}
			}

			//the word index comes after the last /
			if( href.indexOf('index', href.lastIndexOf('/')) > 0 ){
				if(relativeCanonicalUrlUniformIndex === getUniformIndex(hrefNoQuery) ){
					return true;
				}
			}
		}
		return false;
	};

	var toggleAriaExpanded = function(el){
		var $el = $(el);
		var $tempEl;
		var tempHeight;
		var hasGrandKids = false;

		if($el.attr('aria-expanded') == 'true'){

			$el.addClass(rotateClass).children('ul').each(function(i, el){
				var $tempEl = $(el);
				$tempEl.css({'height': $tempEl.height()}).animate({'height': 0}, 200, function(){
					$(this).css('height', '');
					$el.attr('aria-expanded', 'false').removeClass(rotateClass);
				});
			});
		}else{
			var $ulKids = $el.children('ul');

			$el.attr('aria-expanded', 'true');
			$ulKids.find('li').css('display', '');
			$ulKids.each(function(i, el){
				var $tempEl = $(el);
				tempHeight = $tempEl.height();
				$tempEl.css({'height': '0'}).animate({'height': tempHeight}, 200, function(){
					$(this).css('height', '');
				});
			});
		}
	};

	var stopSomePropagation = function(e, direction){
		switch (direction){
			case 'top':
				if(isTouchEvent){
					if(e.offsetY > 20){
						e.stopPropagation();
					}
				}else{
					e.stopPropagation();
				}
				break;
			case 'left':
				if(isTouchEvent){
					if(e.offsetX > 15){
						e.stopPropagation();
					}
				}else{
					e.stopPropagation();
				}
				break;
		}
	};

	var drawToc = function(json){
		var createTocNode = function(node, ul, nodeMap){
			var aNode;
			var href;
			var aCleanTitle;
			var nodeSelected = false;
			var displayName;

			nodeMap.push(-1);

			ul.setAttribute('aria-treegrid', 'true');
			ul.addEventListener('click', function(e){
				stopSomePropagation(e, 'top');
			});

			for(var i=0; i<node.length; i++){
				aNode = node[i];
				aCleanTitle = cleanTitle(aNode.toc_title);
				//if displayName exists on a TOC node, add it to the data-text attribute
				if (aNode.displayName && aNode.displayName.length) {
					displayName = cleanTitle(aNode.displayName);
				}
				else {
					displayName = "";
				}

				nodeMap[nodeMap.length-1] = i;

				var nextNode = document.createElement('li');
				var titleHolder;

				if(aNode.href && aNode.href.length){
					href = resolveRelativePath(aNode.href, tocFolder);
					titleHolder = document.createElement('a');
					if(i == 0){
						titleHolder.addEventListener('click', function(e){
							stopSomePropagation(e, 'left');
						});
					};
					titleHolder.setAttribute('tabindex', '1');
					if(thisIsMe(href)){
						titleHolder.classList.add(selectedClass);
						nodeSelected = true;
						if(!nodeMap.length || (tocBestMatch.length < nodeMap.length) ){
							tocBestMatch = nodeMap.slice(0);
						}
					}else{
						nodeSelected = false;
					};
					if(aNode.maintainContext){
						titleHolder.setAttribute('href', href + ((href.indexOf('?') > -1)? '&': '?') + tocUrlTerm + '&' + bcUrlTerm);
					}else{
						titleHolder.setAttribute('href', href);
					}
				}else{
					titleHolder = document.createElement('span');
				}

				titleHolder.setAttribute('data-text', aCleanTitle.toLowerCase() + " " + displayName.toLowerCase());
				titleHolder.innerHTML = breakDots(aCleanTitle);
				nextNode.appendChild(titleHolder);

				if(aNode.children && aNode.children.length){
					if(nodeSelected){
						nextNode.setAttribute('aria-expanded', 'true');
					}else{
						nextNode.setAttribute('aria-expanded', 'false');
					}
					nextNode.setAttribute('tabindex', '1');
					nextNode.setAttribute('aria-treeitem', 'true');
					nextNode.addEventListener('click', function(e){
						e.stopPropagation();
						toggleAriaExpanded(this);
					});
					hasGrandKids = false;
					for(var j=0; j<aNode.children.length; j++){
						if(aNode.children[j].children && aNode.children[j].children.length){
							hasGrandKids = true;
							break;
						}
					}
					if(!hasGrandKids){
						nextNode.classList.add(noSubsClass);
					}
					var nextUL = document.createElement('ul');
					createTocNode(aNode.children, nextUL, nodeMap.slice(0));
					nextNode.appendChild(nextUL);
				}

				ul.appendChild(nextNode);
			}
		};

		var createFilter = function(){
			var $filter = $('<form>')
				.addClass(filterClassName)
				.submit(function(e){
					e.preventDefault();
				})
				.append(
					$('<input>')
						.attr('placeholder', 'Filter')
						.attr('aria-label', 'Filter')
						.attr('type', 'search')
						.keypress(function(e) {
							if ( e.which === 13 ) {
								e.preventDefault();
								return;
							}
						})
						.keyup(function(){
							filterToc(this);
						})
				)
				.append(
					$('<a>')
						.attr('href', '#')
						.attr('title', 'clear filter')
						.addClass('clearInput')
						.html('<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g><path class="bar" d="M6,6l14,14Z" /></g><g><path class="bar" d="M20,6l-14,14Z" /></g></svg>')
						.on('click', function(e){
									e.stopPropagation();
									e.preventDefault();
									var ipt = $('.' + filterClassName + ' input[type=search]');
									ipt.val('');
									filterToc(ipt);
								})
				);

			//TODO: This needs to be internationalized
			var $noResults = $('<div>')
				.addClass(emptyFilterMessageClassName)
				.html('No results');

			return [$filter, $noResults];
		};

		var toc = document.createElement('ul');

		createTocNode(json, toc, []);

		var $toc = $(toc);
		$toc.find('.' + selectedClass).parent().addClass(selectedHolderClass).parents('li[aria-expanded="false"]').attr('aria-expanded', 'true');
		$toc.on('touchstart pointerdown MSPointerDown', function(e){
			if(e.type == 'touchstart' || ( ( (e.type == 'pointerdown') || (e.type == 'MSPointerDown') ) && (e.originalEvent.pointerType == 'touch') ) ){
				isTouchEvent = true;
				setTimeout(function(){
					isTouchEvent = false;
				}, 700);
			}
		})
		.on('mousedown', function(e){
			$(this).addClass(hideFocusClass);
		})
		.on('mouseup', function(e){
			$(e.target).blur().parent().blur();
			$(this).removeClass(hideFocusClass);
		})
		.on('keypress', 'li', function(e){
			if(e.which == '13' && !$toc.hasClass(noSibsClass)){
				e.stopPropagation();
				toggleAriaExpanded($(this));
			}
		})
		.on('keypress', 'a', function(e){
			if(e.which == '13'){
				e.stopPropagation();
			}
		});

		if(json.length == 1){
			$toc.addClass(noSibsClass);
			$toc.children('li').attr('aria-expanded', 'true').off('click.' + eventNamespace).removeAttr('tabindex');
		}

		var arrfilter = createFilter();


		$(function () {
			//there is only one tocHolder, and toc is up to date, so fall back to native append. Save almost 100ms in IE11 for a 9000 node toc
			$(tocHolderSelector).attr('role', 'application')[0].appendChild(toc);
			$(filterHolderSelector).prepend(arrfilter);

			setTimeout(function(){
				msDocs.functions.setTocHeight(0, true);
			}, 200);

			tocFinished = true;
			if(bcFinished && msDocs.settings.extendBreadcrumb){
				extendBc();
			}
		});
	};

	var drawMToc = function(json){
		/* create mobile toc. This will be removed soon, so it is built as a completely seperate creation path */

		var createMTocNode = function(node, indent, $mToc){
			var aNode;
			var href;

			for(var i=0; i<node.length; i++){
				aNode = node[i];

				$mToc
					.append(
						$('<option>')
							.html(indent + cleanTitle(aNode.toc_title))
							.ifThen((aNode.href && aNode.href.length),
								function(){
									href = resolveRelativePath(aNode.href, tocFolder);
									if(aNode.maintainContext){
										this.attr('value', href + ((href.indexOf('?') > -1)? '&': '?') + urlTocQueryName + '=' + encodeURIComponent(tocUrl) + '&' + urlBcQueryName + '=' + encodeURIComponent(bcUrl));
									} else {
										this.attr('value', href);
									}
									if(thisIsMe(href)){
										this.attr('selected', 'selected');
									}
								},
								function(){
									this.addClass(noLinkClass);
								}
							)
					)
					.ifThen((aNode.children && aNode.children.length),
						function(){
							createMTocNode(aNode.children, indent + mTocSubNodeIndent, $mToc);
						}
					);
			}
		};

		var $mToc = $('<select>')
			.on('change', function(){
				var target = $(this).find('option:selected').attr('value');
				if(target && target.length){
					$(location).attr('href', target);
				}
			});
		createMTocNode(json, '', $mToc);
		$(function () {
			$(mTocHolderSelector).replaceWith($mToc);
		});
	};

	var filterToc = function(inputField){
		var val = cleanTitle($(inputField).val().toLowerCase());
		var $tocHolder = $(tocHolderSelector);
		var $filterHolder = $(filterHolderSelector);

		$filterHolder.removeClass(emptyFilterClassName);

		if(val && val.length){
			$('.' + filterClassName).addClass('clearFilter');

			var resultIsEmpty = true;
			var $currentToc = $tocHolder.children('ul[aria-treegrid="true"]').detach();
			if(!$savedToc){
				$savedToc = $currentToc.clone(true, true);
			}
			$currentToc.find('li').css('display', 'none').filter('[aria-expanded]').attr('aria-expanded', 'false');
			var $this;
			$currentToc.find('a, span').each(function(a){
				$this = $(this);
				if($this.attr('data-text').indexOf(val) !== -1 ){
					resultIsEmpty = false;
					$this.parents('li').css('display', '').filter('[aria-expanded]').not($this.parent()).attr('aria-expanded', 'true');
				}
			});
			$tocHolder.append($currentToc);
			if(resultIsEmpty){
				$filterHolder.addClass(emptyFilterClassName);
			}
		}else if($savedToc){
			$('.' + filterClassName).removeClass('clearFilter');

			$tocHolder.children('ul[aria-treegrid="true"]').replaceWith($savedToc);
			$savedToc = null;
		}
	};

	var getTocData = function(url, fallbackToMeta){
		$.ajax({
			url: url,
			dataType: 'json',
			timeout: timeout
		})
		.done(function(data, textStatus, jqXHR){
			tocUrl = resolveRelativePath(url)
			tocFolder = getFolder(msDocs.functions.removeLocaleFromPath(tocUrl));
			tocJson = jqXHR.responseJSON


			if( window.matchMedia( "(max-width: 768px)" ).matches ){
				drawMToc(jqXHR.responseJSON);

				$(function(){
					setTimeout(function(){
						drawToc(jqXHR.responseJSON);
					}, otherTocDelay);
				});
			}else{
				drawToc(jqXHR.responseJSON);

				$(function(){
					setTimeout(function(){
						drawMToc(jqXHR.responseJSON);
					}, otherTocDelay);
				});
			}
		})
		.fail(function(){
			if(fallbackToMeta && tocMetaUrl && tocMetaUrl.length){
				getTocData(tocMetaUrl);
			};
		});
	};

	var extendBc = function(){
		//this can only run after DOM ready and should only be called after toc and bc have been drawn
		var $breadcrumbs = $('.' + breadcrumbClass);

		var addNodeToBc = function(node, bestMatch){
			var href = node.href;
			var aCleanTitle = breakDots(cleanTitle(node.toc_title));

			$breadcrumbs.ifThen( !href || !href.length || (!bestMatch.length && (relativeCanonicalUrlUniformIndex === getUniformIndex(node.href).toLowerCase())),
				function(){
					this.append(
						$('<li>').html(aCleanTitle)
					);
				},
				function(){
					this.append(
						$('<li>').append(
							$('<a>')
								.attr('href', resolveRelativePath(href, tocFolder))
								.html(aCleanTitle)
						)
					);
				}
			);

			if( bestMatch.length && node.children && node.children.length ){
				addNodeToBc(node.children[bestMatch.shift()], bestMatch);
			}
		};

		if(tocBestMatch.length){
			addNodeToBc(tocJson[tocBestMatch.shift()], tocBestMatch);
		}
	};

	var drawBc = function(json){
		var relativeCanonicaFolder = getFolder(relativeCanonicalUrlNoQuery) + '/';	//relativeCanonicalUrlNoQuery is all lowercase
		var bestMatch = [];
		var $breadcrumbs = $('<ul>').addClass(breadcrumbClass);
		var node;
		var nodeHrefNoQuery;

		var findBestMatch = function(json, nodeMap){
			//this will find the deepest match. First match at that level wins.
			nodeMap.push(-1);

			for(var i=0; i<json.length; i++){
				node = json[i];
				nodeMap[nodeMap.length-1] = i;

				if(!nodeMap.length || (bestMatch.length < nodeMap.length) ){
					if (node.href) {
						nodeHrefNoQuery = node.href.split('?')[0].toLowerCase();
						if(relativeCanonicaFolder.indexOf(nodeHrefNoQuery) ===  0  || relativeCanonicalUrlNoQuery === nodeHrefNoQuery) {
							bestMatch = nodeMap.slice(0);
						}
					}
				}

				if(node.children && node.children.length){
					findBestMatch(node.children, nodeMap.slice(0));
				}
			}
		};

		var makeDisplayHtml = function($breadcrumbs, node, bestMatch){
			var href =  node.homepage || node.href || '';
			var aCleanTitle = breakDots(cleanTitle(node.toc_title));

			$breadcrumbs.ifThen( !href || !href.length || (!bestMatch.length && (relativeCanonicalUrlUniformIndex === getUniformIndex(node.href).toLowerCase())),
				function(){
					this.append(
						$('<li>').html(aCleanTitle)
					);
				},
				function(){
					this.append(
						$('<li>').append(
							$('<a>')
								.attr('href', resolveRelativePath(href, bcFolder))
								.html(aCleanTitle)
						)
					);
				}
			);

			if( bestMatch.length && node.children && node.children.length ){
				makeDisplayHtml($breadcrumbs, node.children[bestMatch.shift()], bestMatch);
			}
		};

		findBestMatch(json, []);
		if( bestMatch.length ){
			makeDisplayHtml($breadcrumbs, json[bestMatch.shift()], bestMatch);
		}

		$(function () {
			$('.' + breadcrumbClass).replaceWith($breadcrumbs);
			bcFinished = true;
			if(tocFinished && msDocs.settings.extendBreadcrumb){
				extendBc();
			}
		});
	};

	var getBcData = function(url, fallbackToMeta){
		$.ajax({
			url: resolveRelativePath(url),
			dataType: 'json',
			timeout: timeout
		})
		.done(function(data, textStatus, jqXHR){
			bcUrl = url;
			bcFolder = getFolder(msDocs.functions.removeLocaleFromPath(bcUrl));
			drawBc(jqXHR.responseJSON);
		})
		.fail(function(){
			if(fallbackToMeta && bcMetaUrl && bcMetaUrl.length){
				getBcData(bcMetaUrl);
			};
		});
	};

	/* start here */
	relativeCanonicalUrl = getRelativeCanonicalUrl();
	relativeCanonicalUrlNoQuery = getRelativeCanonicalUrl(true).toLowerCase();
	relativeCanonicalUrlUniformIndex = getUniformIndex(relativeCanonicalUrlNoQuery);
	locale = msDocs.functions.getLocaleFromPath(document.location.pathname);
	locationFolder = getFolder(msDocs.functions.removeLocaleFromPath(document.location.pathname));

	if(tocQueryUrl && tocQueryUrl.length){
		tocQueryUrl = decodeURIComponent(tocQueryUrl);
		tocQueryUrl = resolveRelativePath(tocQueryUrl);
		getTocData(tocQueryUrl, true);
	}else if(tocMetaUrl && tocMetaUrl.length){
		getTocData(tocMetaUrl);
	}

	var hideBc = msDocs.functions.getParam('hide_bc', 'meta');
	if(hideBc === undefined || hideBc !== 'true') {
		if(bcQueryUrl && bcQueryUrl.length){
			getBcData(bcQueryUrl, true);
		}else if(bcMetaUrl && bcMetaUrl.length){
			getBcData(bcMetaUrl);
		}
	}

})(jQuery);

//js.cookie.js
;(function (factory) {
	if (typeof define === 'function' && define.amd) {
		define(factory);
	} else if (typeof exports === 'object') {
		module.exports = factory();
	} else {
		var OldCookies = window.Cookies;
		var api = window.Cookies = factory();
		api.noConflict = function () {
			window.Cookies = OldCookies;
			return api;
		};
	}
}(function () {
	function extend () {
		var i = 0;
		var result = {};
		for (; i < arguments.length; i++) {
			var attributes = arguments[ i ];
			for (var key in attributes) {
				result[key] = attributes[key];
			}
		}
		return result;
	}

	function init (converter) {
		function api (key, value, attributes) {
			var result;
			if (typeof document === 'undefined') {
				return;
			}

			// Write

			if (arguments.length > 1) {
				attributes = extend({
					path: '/'
				}, api.defaults, attributes);

				if (typeof attributes.expires === 'number') {
					var expires = new Date();
					expires.setMilliseconds(expires.getMilliseconds() + attributes.expires * 864e+5);
					attributes.expires = expires;
				}

				try {
					result = JSON.stringify(value);
					if (/^[\{\[]/.test(result)) {
						value = result;
					}
				} catch (e) {}

				if (!converter.write) {
					value = encodeURIComponent(String(value))
						.replace(/%(23|24|26|2B|3A|3C|3E|3D|2F|3F|40|5B|5D|5E|60|7B|7D|7C)/g, decodeURIComponent);
				} else {
					value = converter.write(value, key);
				}

				key = encodeURIComponent(String(key));
				key = key.replace(/%(23|24|26|2B|5E|60|7C)/g, decodeURIComponent);
				key = key.replace(/[\(\)]/g, escape);

				return (document.cookie = [
					key, '=', value,
					attributes.expires && '; expires=' + attributes.expires.toUTCString(), // use expires attribute, max-age is not supported by IE
					attributes.path    && '; path=' + attributes.path,
					attributes.domain  && '; domain=' + attributes.domain,
					attributes.secure ? '; secure' : ''
				].join(''));
			}

			// Read

			if (!key) {
				result = {};
			}

			// To prevent the for loop in the first place assign an empty array
			// in case there are no cookies at all. Also prevents odd result when
			// calling "get()"
			var cookies = document.cookie ? document.cookie.split('; ') : [];
			var rdecode = /(%[0-9A-Z]{2})+/g;
			var i = 0;

			for (; i < cookies.length; i++) {
				var parts = cookies[i].split('=');
				var cookie = parts.slice(1).join('=');

				if (cookie.charAt(0) === '"') {
					cookie = cookie.slice(1, -1);
				}

				try {
					var name = parts[0].replace(rdecode, decodeURIComponent);
					cookie = converter.read ?
						converter.read(cookie, name) : converter(cookie, name) ||
						cookie.replace(rdecode, decodeURIComponent);

					if (this.json) {
						try {
							cookie = JSON.parse(cookie);
						} catch (e) {}
					}

					if (key === name) {
						result = cookie;
						break;
					}

					if (!key) {
						result[name] = cookie;
					}
				} catch (e) {}
			}

			return result;
		}

		api.set = api;
		api.get = function (key) {
			return api(key);
		};
		api.getJSON = function () {
			return api.apply({
				json: true
			}, [].slice.call(arguments));
		};
		api.defaults = {};

		api.remove = function (key, attributes) {
			api(key, '', extend(attributes, {
				expires: -1
			}));
		};

		api.withConverter = init;

		return api;
	}

	return init(function () {});
}));

//js.cookie_noConflict.js
msDocs.functions.cookies = Cookies.noConflict();

/* downloadPdf.js */
(function ($) {
	msDocs.functions.renderPdfLink = function(){
		var urlTocQueryName = 'toc';
		var pdfUrl = msDocs.functions.getParam('pdf_url_template', 'meta');
		var tocQueryUrl = msDocs.functions.getParam(urlTocQueryName);
		if(pdfUrl !== undefined && tocQueryUrl === undefined)
		{			
			var branchName = msDocs.functions.cookies.get("CONTENT_BRANCH");
			if(typeof branchName === 'undefined') {
				branchName = "live";
			}

			pdfUrl = pdfUrl.replace(/\{branchName\}/, branchName);

			//TODO: change to loc 'downloadPdf' when available
			var downloadText = "Download PDF";
			var $div = $(".pdfDownloadHolder");
			if($div.length){
				var $link = $("<a href='" + pdfUrl + "' ms.cmpnm='downloadPdf'>" + downloadText + "</a>");
				$div.append($link);
				$div.show();
			}
		}
	};

	$(function(){
		msDocs.functions.renderPdfLink();
	})

})(jQuery);