mergeInto(LibraryManager.library, {

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

    ShareHighScore: function(value, hardmode){
        playerAuth();

        ysdk.getLeaderboards()
        .then(lb => {
            if(hardmode)
                lb.setLeaderboardScore('Highscore', value, 'EXPERT');
            else
                lb.setLeaderboardScore('Highscore', value, 'EASY');
        });
    },
}); 