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
    console.log(id);
    let name = "dropContainer" + id;
    if(chapters[(id-1)] == false){
        document.getElementById(name).style.display == 'block';
        return;
    }
    document.getElementById(name).style.display == 'none';   
}

document.getElementById('helpBtn').addEventListener("click", showHelp);
document.getElementById('dropBtn1').addEventListener("click", dropArea(1));