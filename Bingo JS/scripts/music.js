let audios = document.getElementsByClassName('audioPlayer');
let min = 1;
let selectedSong = 1;

function songBack(){
    songStop();
    for(let i = 0; i < audios.length; i++){
        (audios[i]).currentTime = 0;
    }
    selectedSong--;

    if(selectedSong <= min){
        selectedSong = 1;
    }

    document.getElementById('musicTitle').innerHTML = 'Track ' + selectedSong;
}

function songForward(){
    songStop();
    for(let i = 0; i < audios.length; i++){
        (audios[i]).currentTime = 0;
    }
    selectedSong++;

    if(selectedSong > audios.length){
        selectedSong = audios.length;
    }

    document.getElementById('musicTitle').innerHTML = 'Track ' + selectedSong;
}

function songPlay(){
    songStop();
    document.getElementById(`audio${selectedSong}`).play();
}

function songStop(){
    for(let i = 0; i < audios.length; i++){
        (audios[i]).pause();
    }
}