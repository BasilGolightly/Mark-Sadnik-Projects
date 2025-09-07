// variables for storing time signature and bpm
let beatsPerBar = 4, noteValue = 4, bpm = 120, intervalMs = (60 / bpm) * 1000, currentBeat = 1;
let timer = setInterval(()=>{}, 1000);
let accented = [];

clearInterval(timer);

// audio objects for clicks
const audioRegular = new Audio("../media/regular.mp3");
const audioAccent = new Audio("../media/accent.mp3");

function start(){
    intervalMs = ((60 / bpm) * 1000) / (noteValue / 4);
    timer = setInterval(tick, intervalMs);
    document.getElementById("startBtn").disabled = true;
    document.getElementById("stopBtn").disabled = false;
}

function stop(){
    currentBeat = 1;
    clearInterval(timer);
    document.getElementById("stopBtn").disabled = true;
    document.getElementById("startBtn").disabled = false;
}

async function tick(){
    const beats = Number(beatsPerBar);
    let prevBeat = ((beats+(currentBeat-2)) % beats) + 1;
    //console.log(prevBeat);

    document.getElementById('note' + currentBeat).style.borderBottom = "2px solid black";
    document.getElementById('noteNum' + currentBeat).style.fontWeight = "bold";
    
    // accent note
    if(accented[(currentBeat-1)] === true){
        audioAccent.currentTime = 0;
        audioAccent.play();
    }
    // non-accented note
    else{
        audioRegular.currentTime = 0;
        audioRegular.play();
    }
    
    document.getElementById('note' + prevBeat).style.borderBottom = "none";
    document.getElementById('noteNum' + prevBeat).style.fontWeight = "";

    // end of bar - reset to count 1
    if(currentBeat == beatsPerBar) {
        currentBeat = 1;
        return;
    }
    
    currentBeat++;
}

function changeCountingStyle(){
    // quarter notes
    if(document.getElementById('countingStyle').value == "quarter"){
        if(noteValue == 8){
            for(let i = 1, j = 1; i <= beatsPerBar; i++){
                if(i % 2 === 0){
                    document.getElementById('noteNum' + i).innerHTML = "+";
                    j++;
                }
                else{
                    document.getElementById('noteNum' + i).innerHTML = j;
                }
            }
            return;
        }
        else if(noteValue == 16){
            for(let i = 1, j = 1, k = 1; i <= beatsPerBar; i++){
                // 4th 16th
                if(k % 4 === 0){
                    document.getElementById('noteNum' + i).innerHTML = "a";
                    j++;
                    k = 1;
                    continue;
                }
                // 3rd 16th
                else if(k % 3 === 0){
                    document.getElementById('noteNum' + i).innerHTML = "&";
                }
                // 2nd 16th
                else if(k % 2 === 0){
                    document.getElementById('noteNum' + i).innerHTML = "e";
                }
                // 1st 16th
                else{
                    document.getElementById('noteNum' + i).innerHTML = j;
                }
                k++;
            }
            return;
        }
    }
    // sequential / quarters [1, beats per bar]
    for(let i = 1; i <= beatsPerBar; i++){
        document.getElementById('noteNum' + i).innerHTML = i;
    }
}

function changeTimeSignature(){    
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
        accented[(i-1)] = false;
    }

    // accent first note
    markAccent(1);
    changeCountingStyle();
}

function markAccent(noteId){
    //non-accented
    if(accented[(noteId-1)] === false){
        document.getElementById('note' + noteId).className = "accentNote";
        document.getElementById('noteNum' + noteId).style.fontWeight = "bold";
        document.getElementById('noteNum' + noteId).style.fontStyle = "italic";
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
    changeTimeSignature();
}

document.getElementById('beatsPerBar').addEventListener("change", changeTimeSignature);
document.getElementById('noteValue').addEventListener("change", changeTimeSignature);
document.getElementById('startBtn').addEventListener("click", start);
document.getElementById('stopBtn').addEventListener("click", stop);
document.getElementById('bpm').addEventListener("input", stop);
document.getElementById('bpm').addEventListener("blur", checkInput);
document.getElementById('countingStyle').addEventListener("change", changeCountingStyle);

changeTimeSignature();

