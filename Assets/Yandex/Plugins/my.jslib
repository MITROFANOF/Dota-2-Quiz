var player;
var lb;

YaGames
.init()
.then(ysdk => {
    console.log('Yandex SDK initialized');
    window.ysdk = ysdk;
    
});

function initPlayer() {
    return ysdk.getPlayer().then(_player => {
        player = _player;
        return player;
    });
}        

function initLB() {
    ysdk.getLeaderboards()
    .then(_lb => lb = _lb);
}

function playerAuth() {
    initPlayer().then(_player => {
        if (_player.getMode() === 'lite') {
            // Игрок не авторизован.
            ysdk.auth.openAuthDialog().then(() => {
                    // Игрок успешно авторизован
                initPlayer().catch(err => {
                        // Ошибка при инициализации объекта Player.
                });
                initLB();         
            }).catch(() => {
                    // Игрок не авторизован.
            });
        }
    }).catch(err => {
        // Ошибка при инициализации объекта Player.
    });
}

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