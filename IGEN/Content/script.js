$(document).ready(function() {
  var offset = $("input").offset();
  var cutmain = ($(document).width() - 960) / 2 - 1;
  $("#a6").css("visibility", "hidden");

  $("#a4").click(function() {
    if($("#search input").css("top") == "18px") {
      $("#searchform #search input[type='text']").focus();
      $("#search input").animate({
        top:"94.5px",
        zIndex:"1"
      }, 500);
      $("#topsearch").css("visibility", "hidden");
      $("#a6").css("visibility", "initial");
      $("#a6").animate({
        top:"102.5px",
        color:"#000000"
      }, 500);
    }
    else {
      $("#searchform #search input[type='text']").trigger("blur");
      $("#search input").animate({
        top:"18px"
      }, 500);
      $("#search input").css("z-index", "-1");
      $("#a6").animate({
        top:"28px",
        visibility:"hidden",
        color:"#FFFFFF"
      }, 500);
    }
  });

  $("#a33").click(function() {
    if($("#more").css("visibility") == "hidden") {
      $("#more").css("visibility", "initial");
    }
    else {
      $("#more").css("visibility", "hidden");
    }
  });

  $(document).on('click', function (e) {
    if ($(e.target).closest("#a33").length === 0) {
      $("#more").css("visibility", "hidden");
    }
  });

  $("#cpa1, #cardheader1").mouseenter(function() {
    $("#cardheader1").css("background-color", "#DC143C");
  });

  $("#cpa1, #cardheader1").mouseleave(function() {
    $("#cardheader1").css("background-color", "#000000");
  });

  $("#cpa2, #cardheader2").mouseenter(function() {
    $("#cardheader2").css("background-color", "#DC143C");
  });

  $("#cpa2, #cardheader2").mouseleave(function() {
    $("#cardheader2").css("background-color", "#000000");
  });

  $("#cpa3, #cardheader3").mouseenter(function() {
    $("#cardheader3").css("background-color", "#DC143C");
  });

  $("#cpa3, #cardheader3").mouseleave(function() {
    $("#cardheader3").css("background-color", "#000000");
  });

  $("#cpa4, #cardheader4").mouseenter(function() {
    $("#cardheader4").css("background-color", "#DC143C");
  });

  $("#cpa4, #cardheader4").mouseleave(function() {
    $("#cardheader4").css("background-color", "#000000");
  });

  $("#cpa5, #cardheader5").mouseenter(function() {
    $("#cardheader5").css("background-color", "#DC143C");
  });

  $("#cpa5, #cardheader5").mouseleave(function() {
    $("#cardheader5").css("background-color", "#000000");
  });

  $("#cpa6, #cardheader6").mouseenter(function() {
    $("#cardheader6").css("background-color", "#DC143C");
  });

  $("#cpa6, #cardheader6").mouseleave(function() {
    $("#cardheader6").css("background-color", "#000000");
  });

  $(".sidepic1, .sidehead1").mouseenter(function() {
    $("#mostreadbg1").css("visibility", "initial");
  });

  $(".sidepic1, .sidehead1").mouseleave(function() {
    $("#mostreadbg1").css("visibility", "hidden");
  });

  $(".sidepic2, .sidehead2").mouseenter(function() {
    $("#mostreadbg2").css("visibility", "initial");
  });

  $(".sidepic2, .sidehead2").mouseleave(function() {
    $("#mostreadbg2").css("visibility", "hidden");
  });

  $(".sidepic3, .sidehead3").mouseenter(function() {
    $("#mostreadbg3").css("visibility", "initial");
  });

  $(".sidepic3, .sidehead3").mouseleave(function() {
    $("#mostreadbg3").css("visibility", "hidden");
  });

  $("#sendfeedbacksubmit").click(function() {
      $("#feedbacknotification").animate({opacity:1, width:"340px"}, 750).delay(5000).animate({opacity: 0, width:"0px"}, 750);
      $("#sendfeedback textarea").val("");
  });

  $("#sendfeedbacksubmit").click(function() {
      $("#feedbacknotificationtext").delay(420).animate({opacity:1}, 600).delay(4700).animate({opacity: 0}, 310);
  });

  $("#followdeveloper").click(function() {
    $("#follownotification").delay(100).animate({
      top:"1200px"
    }, 600).delay(5000);

    $("#follownotification").animate({
      top:"1130px"
    }, 600);
  });

  $("#followdeveloper").click(function() {
    if($("#followdeveloper").text() == "Follow this developer") {
      $("#followdeveloper").css("color", "#DC143C");
      setTimeout(function(){ $("#followdeveloper").text("Unfollow this developer"); }, 200);
      $("#follownotification").html("<i class='fa fa-check'></i>You are now following this developer!");
    }

    else {
      $("#followdeveloper").css("color", "#DC143C");
      setTimeout(function(){ $("#followdeveloper").text("Follow this developer"); }, 200);
      $("#follownotification").html("<i class='fa fa-check'></i>You are no longer following this developer.");
    }
  });

  $("#showmore").click(function() {
    $("#showmore").css("opacity", "0");
    $("#showless").css("z-index", "3");
    setTimeout(function(){ $("#showless").animate({
      opacity:"1"
    }, 200); }, 450);
    setTimeout(function(){ $("#showmorecontent").slideDown(); }, 100);
    setTimeout(function(){ $("#cpa3 img, #cpa3, #cha3 h1, #cha3").animate({
      opacity:"0"
    }, 300); }, 100);
    $("#cutmain").animate({
      width:"647px",
      marginLeft:cutmain
    }, 200);
  });

  $("#showmore").click(function() {
    $("#showmorecontent").css("z-index", "1");
  });

  $("#showless").click(function() {
    setTimeout(function(){ $("#showmorecontent").css("z-index", "-1"); }, 500);
  });

  $("#showless").click(function() {
    setTimeout(function(){ $("#showmore").animate({
      opacity:"1"
    }, 200); }, 450);
    $("#showless").css("opacity", "0");
    $("#showless").css("z-index", "0");
    $("#showmorecontent").slideUp();
    setTimeout(function(){ $("#cpa3 img, #cpa3, #cha3 h1, #cha3").animate({
      opacity:"1"
    }); }, 100);
    setTimeout(function(){ $("#cutmain").animate({
      width:"960px",
      margin:"0 auto"
    }, 200); }, 250);
  });

  $("#searchform").submit(function( event ) {
      if($('#searchform #search input[type="text"]').val() == '') {
          event.preventDefault();
      }
  });
});
