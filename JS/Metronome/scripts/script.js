// variables for storing time signature and bpm
let beatsPerBar = 4, noteValue = 4, bpm = 120, intervalMs = (60 / bpm) * 1000, currentBeat = 1;
let timer = setInterval(()=>{}, 1000);
clearInterval(timer);

// audio objects for clicks
const audioRegular = new Audio("../media/regular.mp3");
const audioAccent = new Audio("../media/accent.mp3");



function start(){
    changeTimeSignature();
    intervalMs = ((60 / bpm) * 1000) / (noteValue / 4);
    timer = setInterval(tick, intervalMs);
    document.getElementById("startBtn").enabled = false;
    document.getElementById("stopBtn").enabled = true;
}

function stop(){
    currentBeat = 1;
    clearInterval(timer);
    document.getElementById("stopBtn").enabled = false;
    document.getElementById("startBtn").enabled = true;
}

function tick(){
    let prev = (currentBeat-1)%beatsPerBar;
    document.getElementById('note' + prev).style.borderBottom = "none";
    document.getElementById('note' + currentBeat).style.borderBottom = "2px solid black";

    currentBeat++;
}

async function changeTimeSignature(){    
    stop();
    beatsPerBar = document.getElementById('beatsPerBar').value;
    noteValue = document.getElementById('noteValue').value;
    bpm = document.getElementById('bpm').value;
    
    document.getElementById("noteImgArea").innerHTML = "";
    document.getElementById("noteNumArea").innerHTML = "";

    let noteImgPath = "media/";
    // quarter notes
    if(noteValue == 4) noteImgPath += "qNote.png";
    // eighth notes
    else if(noteValue == 8) noteImgPath += "eNote.png";
    // sixteenth notes
    else noteImgPath += "sNote.webp"; 

    for(let i = 1; i <= beatsPerBar; i++){
        document.getElementById("noteImgArea").innerHTML += "<td id='note" + i + "' onclick='markAccent(" + i + ")'><img src='" + noteImgPath + "'></td>";
        document.getElementById("noteNumArea").innerHTML += "<td id='noteNum" + i + "' onclick='markAccent(" + i + ")>" + i + "</td>";
        
    }

    for(let i = 1; i < beatsPerBar; i++){
        document.getElementById('note' + i).style.borderBottom = "none";
        document.getElementById('note' + i).class = "";
        document.getElementById('noteNum' + i).style.fontWeight = "normal";
        document.getElementById('noteNum' + i).class = "";
    }

    
    markAccent(1);
}

function markAccent(noteId){
    document.getElementById('note' + noteId).class = "accentNote";
    document.getElementById('noteNum' + noteId).class = "accentNum";
}

document.getElementById('beatsPerBar').addEventListener("select", changeTimeSignature);
document.getElementById('noteValue').addEventListener("select", changeTimeSignature);
document.getElementById('startBtn').addEventListener("click", start);
document.getElementById('stopBtn').addEventListener("click", stop);
document.getElementById('bpm').addEventListener("input", stop);

