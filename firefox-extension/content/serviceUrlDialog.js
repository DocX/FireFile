// Called once when the dialog displays
function onLoad() {
  // Use the arguments passed to us by the caller
  document.getElementById("serviceUrlTextbox").value = window.arguments[0].serviceUrlDefault;
}

// Called once if and only if the user clicks OK
function onOK() {
   // Return the changed arguments.
   // Notice if user clicks cancel, window.arguments[0].out remains null
   // because this function is never called
   window.arguments[0].serviceUrl = document.getElementById("serviceUrlTextbox").value;
   return true;
}