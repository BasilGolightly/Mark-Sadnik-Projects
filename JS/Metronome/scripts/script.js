// variables for storing time signature and bpm
let beatsPerBar = 4, noteValue = 4, bpm = 120, intervalMs = (60 / bpm) * 1000, currentBeat = 1;
let timer = setInterval(()=>{}, 1000);
clearInterval(timer);

// audio objects for clicks
const audioRegular = new Audio("../media/regular.mp3");
const audioAccent = new Audio("../media/accent.mp3");

function tick(){
    
    currentBeat++;
}

function start(){
    timer = setInterval(tick, intervalMs);
}

function stop(){
    //clearInterval(timer);
    reset();
}

function changeTimeSignature(){
    //stop();
    
    beatsPerBar = document.getElementById('beatsPerBar').value;
    noteValue = document.getElementById('noteValue').value;
    bpm = document.getElementById('bpm').value;
    
    document.getElementById("noteImgArea").innerHTML = "";
    document.getElementById("noteNumArea").innerHTML = "";

    let noteImgPath = "media/";
    if(noteValue == 4) noteImgPath += "qNote.png";
    else if(noteValue == 8) noteImgPath += "eNote.png";
    else noteImgPath += "sNote.webp"; 

    for(let i = 1; i <= beatsPerBar; i++){
        document.getElementById("noteImgArea").innerHTML += "<td id='note" + i + "'><img src='" + noteImgPath + "'></td>";
        document.getElementById("noteNumArea").innerHTML += "<td id='noteNum" + i + "'>" + i + "</td>";
    }
}

function changeTempo(){

}

function reset(){
    currentBeat = 1;
    changeTimeSignature();
    currentBeat();
}

function markAccent(){
    this.name = "accent";
}



document.getElementById('beatsPerBar').addEventListener("select", changeTimeSignature);
document.getElementById('noteValue').addEventListener("select", changeTimeSignature);
document.getElementById('startBtn').addEventListener("click", start);
document.getElementById('bpm').addEventListener("input", stop);
document.getElementById('bpm').addEventListener("blur", changeTempo);