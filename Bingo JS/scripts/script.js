/*VARS*/
var sekund = 0;
var arrIzbranih = [];
var max = 75;
var IzbranoSt = 0;
var moznaIzbira = false;
var stVrstic = 3;
var gameActive = false;
var timerID = 0;
var nextNum = 0;
var computerMax = 0, computerMin = 0;
var playerMax = 0, playerMin = 0;

/*VARS*/

/*HTML ELEMENTS*/

document.getElementById('startBtn').disabled = false;
document.getElementById('resetBtn').disabled = true;
stVrstic = document.getElementById('numRows').value;

/*HTML ELEMENTS*/

/*START GAME*/

function startGame(){
    arrIzbranih = [];
    document.getElementById('playerLoading').style.display = 'flex';
    document.getElementById('gameStatus').innerHTML = "IZBERITE KARTO";
    document.getElementById('resetBtn').disabled = false;
    document.getElementById('startBtn').disabled = true;
    document.getElementById('numRows').disabled = true;
    document.getElementById('playerLoading').style.display = 'none';

    moznaIzbira = true;
}

/*START GAME*/

/*STOP GAME*/

function pauseGame(){
    stopTimer();
}   

function resumeGame(){
    startTimer();
}

function resetGame(){    
    document.getElementById('playerLoading').style.display = 'none';
    sekund = -1;
    izpisiCas();
    nextNum = 0;
    moznaIzbira = false;
    resetTimer();
    generirajKarte();

    document.getElementById('rerollBtn').disabled = true;
    document.getElementById('bingoBtn').disabled = true;
    document.getElementById('gameStatus').innerHTML = "ZAČNI IGRO";
    document.getElementById('resetBtn').disabled = true;
    document.getElementById('startBtn').disabled = false;
    document.getElementById('numRows').disabled = false;
    document.getElementById('selectedNumber').innerHTML = "--";
    document.getElementById('playerLoading').style.display = 'none';
}

/*STOP GAME*/

/*FUNCS*/

function generirajKarte(){
    stVrstic = document.getElementById('numRows').value;
    let cardsOutput = document.getElementById('generateCardOutput');
    max = 0;

    if(stVrstic == 4){
        max = 80;
    } 
    else{
        max = 75; 
    } 

    let stCelic = stVrstic * 5;
    let outputString = ``;

    for(let i = 1, stKarte = 0; i <= max; i++){

        if(i % 5 == 0 || i == 1){
            //nova karta
            if(i % stCelic == 0 || i == 1){

                if(i == 1){
                    outputString = `
                    <div class="card" onclick="izberiKarto(${stKarte})">
                        <table class="cardTable">
                            <tr class="cardRow">
                                <td class="cardNum"><span class="cardNumInner" id="generated${i}">${i}</span></td>
                    `;

                }
                //last number
                else if(i == max){
                    outputString += `
                            <td class="cardNum"><span class="cardNumInner" id="generated${i}">${i}</span></td>
                        </tr>
                    </table>

                    <div class="cardName">
                        <span id="generatedCardOrder${stKarte}">${stKarte}</span>. Karta
                    </div>
                    </div>
                    `;
                }
                //last number of card
                else{
                    outputString += `
                            <td class="cardNum"><span class="cardNumInner" id="generated${i}">${i}</span></td>
                        </tr>
                    </table>

                    <div class="cardName">
                        <span id="generatedCardOrder${stKarte}">${stKarte}</span>. Karta
                    </div>
                    </div>

                    <div class="card" onclick="izberiKarto(${stKarte})">
                        <table class="cardTable">
                            <tr class="cardRow">
                                
                    `;
                }       

                stKarte++;
            }
            //nova vrsta - zadnji stolpec v vrstici (5, 10, 15, 20, ...)
            else if(i % 5 == 0){
                outputString += `
                <td class="cardNum"><span class="cardNumInner" id="generated${i}">${i}</span></td>  
                </tr>
                `;
            }
        }

        //izpisi stevilko
        else{
            outputString += `
                <td class="cardNum"><span class="cardNumInner" id="generated${i}">${i}</span></td>
            `;
        }
    }

    cardsOutput.innerHTML = outputString;

    //prikazi karte za okras, glede na število vrstic
    let computerShow1 = `
    <tr class="playRow">
        <td class="playNum"><button class="computerNumInner ">R</button></td>
        <td class="playNum"><button class="computerNumInner computerCircle">I</button></td>
        <td class="playNum"><button class="computerNumInner ">V</button></td>
        <td class="playNum"><button class="computerNumInner computerCircle">A</button></td>
        <td class="playNum"><button class="computerNumInner ">L</button></td>
    </tr>
    `;

    let computerShow2 = `
    <tr class="playRow">
        <td class="playNum"><button class="computerNumInner computerCircle">B</button></td>
        <td class="playNum"><button class="computerNumInner ">I</button></td>
        <td class="playNum"><button class="computerNumInner computerCircle">N</button></td>
        <td class="playNum"><button class="computerNumInner ">G</button></td>
        <td class="playNum"><button class="computerNumInner computerCircle">O</button></td>
    </tr>
    `;

    let playerShow1 = `
    <tr class="playRow">
        <td class="playNum"><button class="playNumInner playerCircle">B</button></td>
        <td class="playNum"><button class="playNumInner ">I</button></td>
        <td class="playNum"><button class="playNumInner playerCircle">N</button></td>
        <td class="playNum"><button class="playNumInner ">G</button></td>
        <td class="playNum"><button class="playNumInner playerCircle">O</button></td>
    </tr>
    `;

    let playerShow2 = `
    <tr class="playRow">
        <td class="playNum"><button class="playNumInner ">B</button></td>
        <td class="playNum"><button class="playNumInner playerCircle">I</button></td>
        <td class="playNum"><button class="playNumInner ">N</button></td>
        <td class="playNum"><button class="playNumInner playerCircle">G</button></td>
        <td class="playNum"><button class="playNumInner ">O</button></td>
    </tr>
    `; 

    let playerCard = document.getElementById('playerCard');
    let computerCard = document.getElementById('computerCard');
    playerCard.innerHTML = ``;
    computerCard.innerHTML = ``;

    for(let i = 1; i <= stVrstic; i++){
        if(i % 2 == 0){
            playerCard.innerHTML += playerShow2;
            computerCard.innerHTML += computerShow2;
        }
        else{
            playerCard.innerHTML += playerShow1;
            computerCard.innerHTML += computerShow1;
        }
    }

}

function izberiKarto(stKarte){
    //omogoci izbiro karte samo, če se je kliknal start tipko
    if(moznaIzbira == true){       
        document.getElementById('rerollBtn').disabled = false;
        document.getElementById('bingoBtn').disabled = false;
        
        let playerCard = document.getElementById('playerCard');
        let computerCard = document.getElementById('computerCard');

        //indeksi karte se zacnejo z nulo
        let selectedCardIndex = stKarte+1;
        playerMax = selectedCardIndex * stVrstic * 5;
        playerMin = (playerMax - (stVrstic * 5)) + 1
        let playerStVrstice = 1;
        let playerOutput = `<tr class="playRow" id="playerRow${playerStVrstice}">`;

        //render player card
        for(let i = playerMin; i <= playerMax; i++){
            //render new row / end table
            if(i % 5 == 0){
                //last rendered <td>
                if(i == playerMax){
                    playerOutput += `
                        <td class="playNum"><button class="playNumInner" id="playerNum${i}" onclick="oznaciStevilko(${i})">${i}</button></td>
                    </tr>
                    `;
                }
                //new row <tr>
                else{
                    playerStVrstice++;
                    playerOutput += `
                        <td class="playNum"><button class="playNumInner" id="playerNum${i}" onclick="oznaciStevilko(${i})">${i}</button></td>
                    </tr>

                    <tr class="playRow" id="playerRow${playerStVrstice}">
                    `;
                }
                
            }
            //render <td>
            else{
                playerOutput += `
                    <td class="playNum"><button class="playNumInner" id="playerNum${i}" onclick="oznaciStevilko(${i})">${i}</button></td>
                `;
            }
        }

        playerCard.innerHTML = playerOutput;

        //make computer select random card
        let renderCards = document.getElementsByClassName('card');
        let cardsCount = renderCards.length;

        let computerCardIndex = Math.floor(Math.random() * (cardsCount)) + 1;
        while(computerCardIndex == selectedCardIndex){
            computerCardIndex = Math.floor(Math.random() * (cardsCount)) + 1;
        }

        computerMax = computerCardIndex * stVrstic * 5;
        computerMin = (computerMax - (stVrstic * 5)) + 1;
        
        let computerStVrstce = 1;
        let computerOutput = `<tr class="playRow" id="computerRow${computerStVrstce}">`;

        //render computer card
        for(let i = computerMin; i <= computerMax; i++){
            if(i % 5 == 0){
                //last rendered <td>
                if(i == computerMax){
                    computerOutput += `
                        <td class="playNum"><button class="computerNumInner" id="computerNum${i}" disabled>${i}</button></td>  
                    </tr>
                    `;
                }
                //new row
                else{
                    computerStVrstce++
                    computerOutput += `
                        <td class="playNum"><button class="computerNumInner" id="computerNum${i}" disabled>${i}</button></td>  
                    </tr>

                    <tr class="playRow" id="computerRow${computerStVrstce}">
                    `;
                }
            }
            //render <td>
            else{
                computerOutput += `
                    <td class="playNum"><button class="computerNumInner" id="computerNum${i}" disabled>${i}</button></td>  
                `;
            }
        }

        computerCard.innerHTML = computerOutput;

        document.getElementById('gameStatus').innerHTML = "IGRA V TEKU";

        moznaIzbira = false;

        startTimer();

        naslednjaStevilka();
    }
}

function resetTimer(){
    stopTimer();
    sekund = 0;
}

function startTimer(){
    timerID = setInterval(izpisiCas, 1000);
}

function stopTimer(){
    clearInterval(timerID);
}

function izpisiCas(){
    sekund += 1;
    let min = Math.floor(sekund / 60);
    let sekundRem= Math.floor(sekund % 60);

    let timerOutput = document.getElementById('timerOutput');
    if(min.toString().length < 2) min = '0' + min;
    if(sekundRem.toString().length < 2) sekundRem = '0' + sekundRem; 
    timerOutput.innerHTML = `${min} : ${sekundRem}`;
}

function preveriZmago(){
    //computer rows
    let playerCheckedList = document.getElementsByClassName('playNumInner');
    let playerArr = new Array(stVrstic);
    let temp = new Array(5);

    for(let i = 0, j = 0, k = 0; i < playerCheckedList.length; i++){
        let num = 0;
        if(playerCheckedList[i].classList.contains('playerCircle')){
            num = (playerCheckedList[i].id).substring(9);
            num = parseInt(num);
        }
        temp[j] = num;

        if((i+1) % 5 == 0){
            j = 0;
            playerArr[k] = temp; 
            k++;
            temp = new Array(5);
            continue;
        }
         
        j++;
    }

    //console.log(playerArr);

    let zmaga = false;
    //stolpci
    for (let i = 0; i < 5 && stVrstic == 5; i++) {
        let isFullCol = true;

        for (let j = 0; j < stVrstic && stVrstic == 5; j++) {
            if (playerArr[j][i] == 0) {
                isFullCol = false;
            }
        }

        if (isFullCol) {
            zmaga = true;
            break;
        }
    }

    //vrstice
    if (!zmaga) {
        for (let i = 0; i < stVrstic; i++) {
            let isFullRow = true;

            for (let j = 0; j < 5; j++) {
                if (playerArr[i][j] == 0) {
                    isFullRow = false;
                }
            }

            if (isFullRow) {
                zmaga = true;
                break;
            }
        }

        //diagonale
        if (!zmaga && stVrstic == 5) {
            let isFullDiagonal = true;
            for (let i = 0, j = 0; i < stVrstic; i++) {
                if (playerArr[i][j] == 0) {
                    isFullDiagonal = false;
                    break;
                }

                j++;
            }

            if (!isFullDiagonal) {
                isFullDiagonal = true;
                for (let i = 0, j = stVrstic - 1; i < stVrstic; i++) {
                    if (playerArr[i][j] == 0) {
                        isFullDiagonal = false;
                    }

                    j--;
                }
            }

            if (isFullDiagonal) {
                zmaga = true;
            }


        }
    }

    //zmaga
    if (zmaga) {
        konecIgre(2);
    }

    //goljufanje - ni zmage
    else{
        alert("NE GOLJUFAJ!");
    }
}

function naslednjaStevilka(){
    let nextNumOutput = document.getElementById('selectedNumber');
    nextNum = Math.floor(Math.random() * max) + 1;

    //vse številke izrebane
    if(arrIzbranih.length != max){
        document.getElementById('playerLoading').style.display = 'flex';

        for(let i = 0; i <= arrIzbranih.length; i++){
            //duplicate
            if(nextNum == arrIzbranih[i]){
                i = -1;
                nextNum = Math.floor(Math.random() * max) + 1;
            }
        }

        arrIzbranih[arrIzbranih.length] = nextNum;

        nextNumOutput.innerHTML = nextNum;

        //computer select
        let computerCards = document.getElementsByClassName('computerNumInner');
        for(let i = 0; i < computerCards.length; i++){
            if(computerCards[i].id == `computerNum${nextNum}`){
                computerCards[i].classList += ' computerCircle';
            }
        }

        document.getElementById(`generated${nextNum}`).classList += ' generatedSelect';

        //computer check
        let ComputerCheckedList = document.getElementsByClassName('computerNumInner');
        let computerArr = new Array(stVrstic);
        let temp = new Array(5);

        for(let i = 0, j = 0, k = 0; i < ComputerCheckedList.length; i++){
            let num = 0;
            if(ComputerCheckedList[i].classList.contains('computerCircle')){
                num = (ComputerCheckedList[i].id).substring(11);
                num = parseInt(num);
            }
            temp[j] = num;

            if((i+1) % 5 == 0){
                j = 0;
                computerArr[k] = temp; 
                k++;
                temp = new Array(5);
                continue;
            }
             
            j++;
        }

        //console.log(computerArr)

        let poraz = false;
        //stolpci
        for(let i = 0; i < 5 && stVrstic == 5; i++){
            let isFullCol = true;

            for(let j = 0; j < stVrstic; j++){
                if(computerArr[j][i] == 0){
                    isFullCol = false;
                }
            }

            if(isFullCol){
                poraz = true;
                break;
            }
        }

        //vrstice
        if(!poraz){
            for(let i = 0; i < stVrstic; i++){
                let isFullRow = true;

                for(let j = 0; j < 5; j++){
                    if(computerArr[i][j] == 0){
                        isFullRow = false;
                    }
                }

                if(isFullRow){
                    poraz = true;
                    break;
                }
            }

            //diagonale
            if(!poraz && stVrstic == 5){
                let isFullDiagonal = true;
                for(let i = 0, j = 0; i < stVrstic; i++){
                    if(computerArr[i][j] == 0){
                        isFullDiagonal = false;
                        break;
                    }

                    j++;
                }

                if(!isFullDiagonal){
                    isFullDiagonal = true;
                    for(let i = 0, j = stVrstic-1; i < stVrstic; i++){
                        if(computerArr[i][j] == 0){
                            isFullDiagonal = false;
                        }
    
                        j--;
                    }   
                }

                if(isFullDiagonal){
                    poraz = true;
                }

                
            }
        }
        
        if(poraz){
            konecIgre(1);
        }
    }
}

function oznaciStevilko(stevilka){
    let validSelection = false;
    for(let i = 0; i < arrIzbranih.length; i++){
        if(stevilka == arrIzbranih[i]){
            validSelection = true;
        }
    }

    if(validSelection){
        let selectedNumElement = document.getElementById(`playerNum${stevilka}`);
        //deselect
        if((selectedNumElement.classList).contains('playerCircle')){
            selectedNumElement.classList = 'playNumInner'
        }
        //select
        else{
            selectedNumElement.classList += ' playerCircle';
        }

        document.getElementById('playerLoading').style.display = 'none';
    }
    else{
        alert("NE GOLJUFAJ!");
    }
}

let navodilaShown = false;

function navodilaToggle(){
    let game = document.getElementById('playingField');
    let help = document.getElementById('help');

    //hide help
    if(navodilaShown){
        help.style.display = 'none';
        game.style.display = 'grid';
        navodilaShown = false;
    }
    //show help
    else{
        game.style.display = 'none';
        help.style.display = 'flex';
        navodilaShown = true;
    }
}

async function konecIgre(mode){
    stopTimer();
    moznaIzbira = false;

    document.getElementById('gameStatus').innerHTML = "";
    document.getElementById('rerollBtn').disabled = true;
    document.getElementById('bingoBtn').disabled = true;

    for(let i = 0; i < document.getElementsByClassName('playNumInner').length; i++){
        document.getElementsByClassName('playNumInner')[i].disabled = true;
    }

    function WriteToStatus(symbol){
        document.getElementById('gameStatus').innerHTML += symbol; 
    }

    //poraz
    if(mode == 1){
        document.getElementById('gameStatus').innerHTML = `<span style="color: red">PORAZ</span>`
    }
    //zmaga
    else{
        document.getElementById('gameStatus').innerHTML = `<span style="color: green">ZMAGA</span>`
    }
    
}

/*FUNCS*/