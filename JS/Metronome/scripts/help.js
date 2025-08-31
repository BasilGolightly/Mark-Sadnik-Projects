let help = false;
let chapters = [false, false];

function showHelp(){
    if(help){
        help = false;
        document.getElementById('footer').style.display = "none";
        return;
    }
    help = true;
    document.getElementById('footer').style.display = "grid";
}

function dropArea(id){
    //console.log(id);
    let name = 'dropContainer' + id;
    //console.log(name);
    //console.log(chapters[(id-1)]);
    if(chapters[(id-1)] === false){
        document.getElementById(name).style.display = 'block';
    }
    else{
        document.getElementById(name).style.display = 'none';   
    }
    chapters[(id-1)] = !chapters[(id-1)];
}

document.getElementById('helpBtn').addEventListener("click", showHelp);
for(let i = 1; i <= chapters.length; i++){
    console.log(i);
    document.getElementById('dropBtn' + i).addEventListener("click", () => dropArea(i));
}

