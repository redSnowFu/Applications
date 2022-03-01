(function () {
    "use strict";

    document.addEventListener('deviceready', onDeviceReady.bind(this), false);

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener('pause', onPause.bind(this), false);
        document.addEventListener('resume', onResume.bind(this), false);
        //call function ToMain to go to the main screen
        ToMain();
        //Add eventlisteners to some elements when initial
        AddEl();
    };
})();