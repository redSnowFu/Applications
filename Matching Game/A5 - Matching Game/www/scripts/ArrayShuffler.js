/* The Fisher-Yates Shuffle */
(function () {
	"use strict";
	
    var shuffle = function (items) {
        var i, temp, pos;
        
        for (i = items.length - 1; i >= 0; i -= 1) {
            pos = Math.floor(Math.random() * (i + 1));
            temp = items[pos];
            items[pos] = items[i];
            items[i] = temp;
        }
    };

    window.ArrayShuffler = {
        shuffle: shuffle
    };
})();
