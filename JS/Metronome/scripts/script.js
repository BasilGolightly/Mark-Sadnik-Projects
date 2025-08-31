// variables for storing time signature and bpm
let beatsPerBar = 4, noteValue = 4, bpm = 120, intervalMs = (60 / bpm) * 1000, currentBeat = 1;
let timer = setInterval(()=>{}, 1000);
let accented = [];

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

async function tick(){
    audioRegular.currentTime = 0;
    // accent note
    if(accented[(currentBeat-1)] === true){
        audioAccent.play();
    }

    document.getElementById('note' + currentBeat).style.borderBottom = "2px solid black";
    audioRegular.play();
    if(currentBeat == beatsPerBar) {
        currentBeat = 1;
        return;
    }
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
    accented = new Array(beatsPerBar);

    for(let i = 1; i <= beatsPerBar; i++){
        document.getElementById("noteImgArea").innerHTML += "<td id='note" + i + "' onclick='markAccent(" + i + ")'><img src='" + noteImgPath + "'></td>";
        document.getElementById("noteNumArea").innerHTML += "<td id='noteNum" + i + "' onclick='markAccent(" + i + ")'>" + i + "</td>";
        document.getElementById('note' + i).addEventListener("click", () => markAccent(i));
        document.getElementById('noteNum' + i).addEventListener("click", () => markAccent(i));
        /*
        let currNote = document.getElementById('note' + i);
        let currNoteNum = document.getElementById('noteNum' + i);
        currNote.style.borderBottom = "none";
        currNoteNum.style.fontWeight = "normal";
        */
        accented[(i-1)] = false;
    }

    // accent first note
    markAccent(1);
}

function markAccent(noteId){
    //non-accented
    if(accented[(noteId-1)] === false){
        document.getElementById('note' + noteId).className = "accentNote";
        document.getElementById('noteNum' + noteId).className = "accentNum";
    }
    
    //accented
    else{
        document.getElementById('note' + noteId).className = "";
        document.getElementById('noteNum' + noteId).className = "";
    }
    
    accented[(noteId-1)] = !accented[(noteId-1)];
}

function checkInput(){
    if(document.getElementById('bpm').value <= 40 || document.getElementById('bpm').value > 250){
        alert("Please enter a value between 40 and 250 BPM!");
        document.getElementById('bpm').value = 120;
    }
}

document.getElementById('beatsPerBar').addEventListener("change", changeTimeSignature);
document.getElementById('noteValue').addEventListener("change", changeTimeSignature);
document.getElementById('startBtn').addEventListener("click", start);
document.getElementById('stopBtn').addEventListener("click", stop);
document.getElementById('bpm').addEventListener("input", stop);
document.getElementById('bpm').addEventListener("blur", checkInput);





