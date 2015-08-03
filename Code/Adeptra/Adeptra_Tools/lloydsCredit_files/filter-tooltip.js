$(document).ready(function(){
	$("#portfolioFilter").on("mouseenter", "div[rel=tooltip] > input:not(.hasTooltip)", function(){
		$(this).tooltip({animation: true, placement: "bottom", delay: {show: 250, hide: 100}}).addClass("hasTooltip");
		$("#portfolioFilter").off("mouseenter", "div[rel=tooltip] > input.hasTooltip");
		$(this).trigger("mouseenter");
	});
});
