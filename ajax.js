

<script src="http://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js" type="text/javascript"></script>
		
<script>
var doAjaxCall = function(){
  
  $.ajax({ cache: false,
    url: "http://duda-api-test.herokuapp.com/profiles",
    success: function (data) {
        alert(JSON.stringify(data));
    },
    error: function (ajaxContext) {
        alert(ajaxContext.responseText)
    }

  });

}

window.onload= function(){
  alert("window.loaded");
  doAjaxCall();
}

</script>
