var doAjaxReq = function() {

	alert("doing ajax request");

	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function () {
		alert(this.status);
		if (this.readyState == 4 && this.status == 200) {
			var obj = JSON.parse(xhttp.responseText);
			var imgList = document.getElementsByClassName("img1");
			for (i = 0; i < obj.length; i++) {
				imgList[i].src = obj[i].img;
			}

			// Typical action to be performed when the document is ready:
			//var parent = document.body; //document.getElementsByClassName("example")[0];
			//for (i = 0; i < obj.length; i++) {
				//var img = document.createElement("IMG");
				//img.src = obj[i].img;
				//parent.appendChild(img);
			//}

			//alert(xhttp.responseText);


		}
	};
	xhttp.open("GET", "/Image/GetImage?userName=aa&pass=bb", true);
	xhttp.setRequestHeader("DbMotion", "1234");
	xhttp.send();


}