﻿mergeInto(LibraryManager.library, {

    ShowFullscreenAdv: function(){
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function(wasShown) {
                  // some action after close
                },
                onError: function(error) {
                  // some action on error
                }
            }
        })
    },

}); 