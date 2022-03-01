
(function () {
    "use strict";

    document.addEventListener( 'deviceready', onDeviceReady.bind( this ), false );

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener( 'pause', onPause.bind( this ), false );
        document.addEventListener( 'resume', onResume.bind( this ), false );
        //call function ToMain to go to the main screen
        ToMain();
        //Add eventlisteners to some elements when initial
        AddEl();
    };
    //num for switching screens
    let num = 0;
    //this globle variable is for tracking the score of the current player in a specific category
    let gScore = 0;
    //select all preset elements
    let mainScreen = document.getElementById("mainScreen");
    let creatAccount = document.getElementById("creatAccount");
    let ranking = document.getElementById("ranking");
    let game = document.getElementById("game");

    let btnCreate = document.getElementById("btnCreate");
    let btnDisplay = document.getElementById("btnDisplay");
    let btnPlay = document.getElementById("btnPlay");

    let userNameInput = document.getElementById("userName");
    let passwordInput = document.getElementById("password");
    let retypePwInput = document.getElementById("retypePw");
    let userNameTxt = userNameInput.value;
    let passwordTxt = passwordInput.value;
    let retypePwTxt = retypePwInput.value;
    let btnAddUser = document.getElementById("btnAddUser");
    let btnBack1 = document.getElementById("btnBack1");
    let btnBack2 = document.getElementById("btnBack2");
    let btnBack3 = document.getElementById("btnBack3");

    let categorySelection = document.getElementById("categorySelection");
    let categoryDisplay = document.getElementById("categoryDisplay");
    let gamingCategory = document.getElementById("gamingCategory");
    let GamingArea = document.getElementById("GamingArea");
    let btnNewGame = document.getElementById("btnNewGame");

    //function name: ToMain
    //sent in: none
    //return: none
    //description: show the main screen, and call IfdisableBtns() to decide which button is available
    function ToMain() {
        //RemoveLocalStorage();
        num = 0;
        WhichToShow(num);
        IfdisableBtns();
    }

    //function name: ToCreate
    //sent in: none
    //return: none
    //description: show the Account creation screen, and set all input area to be empty
    function ToCreate() {
        num = 1;
        WhichToShow(num);
        userNameTxt = '';
        passwordTxt = '';
        retypePwTxt = '';
    }

    //function name: ToRanking
    //sent in: none
    //return: none
    //description: show the Ranking gategory selection screen. call getAllCategories(0) to create all buttons.
    function ToRanking() {
        num = 2;
        WhichToShow(num);
        ToggleRanking(0);

        getAllCategories(0);
    }

    //this funciton is for developer only, remove the local storage.
    function RemoveLocalStorage() {
        localStorage.removeItem("HangmanUser");
        localStorage.removeItem("HangmanPw");
    }

    //function name: getAllCategories
    //sent in: int
    //return: none
    //description: if the sent in number is 0, build the ranking category buttons. if not, build the gaming category buttons.
    function getAllCategories(number) {
        let url = "http://assignment0.com/hangman/webservice/categories"; // file name or server-side process name
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
                let resp = xmlhttp.responseText;
                if (resp.search("ERROR") >= 0) {
                    alert("Something's wrong");
                    ToMain();
                } else {
                    //return resp;
                    if (number === 0) {
                        buildCategoryBtns(resp);
                    }
                    else {
                        buildGamingCateBtns(resp);
                    }
                }
            }
        };
        xmlhttp.open("GET", url, true);
        xmlhttp.send();
    }

    //function name: ToggleRanking
    //sent in: int
    //return: none
    //description: show either the selction screen or the display screen
    function ToggleRanking(which) {
        if (which === 0) {
            categorySelection.classList.remove("hide");
            categorySelection.classList.add("show");
            categoryDisplay.classList.remove("show");
            categoryDisplay.classList.add("hide");
        }
        else {
            categoryDisplay.classList.remove("hide");
            categoryDisplay.classList.add("show");
            categorySelection.classList.remove("show");
            categorySelection.classList.add("hide");
        }
    }

    //function name: buildCategoryBtns
    //sent in: xmlhttp.responseText
    //return: none
    //description: Call by getAllCategories(0) to build the ranking selection buttons
    function buildCategoryBtns(text) {
        let arr = JSON.parse(text).categories;
        let targetSection = "";
        
        for (let i = 0; i < arr.length; i++) {
            let row = arr[i];
            targetSection += "<button id='" + row.categoryName + "' class='categoryBtns'>" + row.categoryName + "</button>";
        }
        
        document.getElementById("categorySelection").innerHTML = targetSection;

        for (let i = 0; i < arr.length; i++) {
            let row = arr[i];
            document.getElementById(row.categoryName).addEventListener("click", function () { ToScores(row.categoryName); }, false);
        }
    }

    //function name: ToScores
    //sent in: str
    //return: none
    //description: this function is called when a ranking category buttion is selected and it will lead to a display screen
    function ToScores(Cname) {
        let url = "http://assignment0.com/hangman/webservice/rankings/category=" + Cname; // file name or server-side process name
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
                let resp = xmlhttp.responseText;
                
                if (resp.search("ERROR") >= 0) {
                    alert("Something's wrong");
                    ToRanking();
                } else {
                    DisplayScores(resp);
                }
            }
        };
        xmlhttp.open("GET", url, true);
        xmlhttp.send();
        
    }

    //function name: DisplayScores
    //sent in: xmlhttp.responseText
    //return: none
    //description: display all players and their in a specific category in a desc order.
    function DisplayScores(text) {
        ToggleRanking(1);
        let arr = JSON.parse(text).rankings;
        let sortedArr = sortJSON(arr, 'score', 'desc');
        let scoreText = "<tr class='scoresTable' id='scoreTitle'><th>Player Name</th><th>Score</th></tr>";
        for (let i = 0; i < sortedArr.length; i++) {
            if (localStorage.getItem("HangmanUser") !== null) {
                if (localStorage.getItem("HangmanUser") === sortedArr[i].playerName) {
                    scoreText += "<tr id='currentPlayer'><td>" + sortedArr[i].playerName + "</td><td>" + sortedArr[i].score + "</td></tr>";
                }
                else {
                    scoreText += "<tr class='scoresTable'><td>" + sortedArr[i].playerName + "</td><td>" + sortedArr[i].score + "</td></tr>";
                }
            }
            else {
                scoreText += "<tr class='scoresTable'><td>" + sortedArr[i].playerName + "</td><td>" + sortedArr[i].score + "</td></tr>";
            }
        }
        document.getElementById("scoresTableId").innerHTML = scoreText;
    }

    //function name: ToGaming
    //sent in: none
    //return: none
    //description: go to the gaming selection screen, call getAllCategories(1) to build all btns.
    function ToGaming() {
        num = 3;
        WhichToShow(num);
        ToggleGaming(0);
        getAllCategories(1);
    }

    //function name: ToggleGaming
    //sent in: int
    //return: none
    //description: show either the selection or the gaming screen
    function ToggleGaming(which) {
        if (which === 0) {
            gamingCategory.classList.remove("hide");
            gamingCategory.classList.add("show");
            GamingArea.classList.remove("show");
            GamingArea.classList.add("hide");
        }
        else {
            GamingArea.classList.remove("hide");
            GamingArea.classList.add("show");
            gamingCategory.classList.remove("show");
            gamingCategory.classList.add("hide");
        }
    }

    //function name: buildGamingCateBtns
    //sent in: xmlhttp.responseText
    //return: none
    //description: Call by getAllCategories(1) to build the gaming category selection buttons
    function buildGamingCateBtns(text) {
        let arr = JSON.parse(text).categories;
        let targetSection = "";
        
        for (let i = 0; i < arr.length; i++) {
            let row = arr[i];
            targetSection += "<button id='" + row.categoryName + "Gaming' class='categoryGaming'>" + row.categoryName + "</button>";
        }

        document.getElementById("gamingCategory").innerHTML = targetSection;

        for (let i = 0; i < arr.length; i++) {
            let row = arr[i];
            document.getElementById(row.categoryName + "Gaming").addEventListener("click", function () { ToHangman(row.categoryName); }, false);
        }
    }

    //function name: ToHangman
    //sent in: str
    //return: none
    //description: go to the gaming screen, get the player's score in this category by calling getHisScore(player, Cname)
    function ToHangman(Cname) {
        ToggleGaming(1);
        GetWords(Cname);
        document.getElementById("Cname").innerHTML = Cname;
        let player = localStorage.getItem("HangmanUser");
        getHisScore(player, Cname);
    }

    //function name: GetWords
    //sent in: str
    //return: none
    //description: get a random word from the selected category
    function GetWords(Cname) {

        let url = "http://assignment0.com/hangman/webservice/vocabularies/category=" + Cname; // file name or server-side process name
        
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
                let resp = xmlhttp.responseText;
                if (resp.search("ERROR") >= 0) {
                    alert("Something's wrong");
                    ToMain();
                } else {
                    let arr = JSON.parse(resp).vocabularies.words;
                    
                    let randomWord = arr[Math.floor(Math.random() * arr.length)];
                    ResetLayout(randomWord);
                }
            }
        };
        xmlhttp.open("GET", url, true);
        xmlhttp.send();
    }

    //function name: ResetLayout
    //sent in: str
    //return: none
    //description: initial the gaming layout
    function ResetLayout(theWord) {
        GameController.newGame(theWord);
        let obj = GameController.report();
        if (obj.gameState === "GAME_IN_PROGRESS") {
            document.getElementById("remaining").innerHTML = "Guesses Remaining: " + obj.guessesRemaining;
            document.getElementById("theWord").innerHTML = obj.guess;
            let picIndex = 6 - obj.guessesRemaining;
            document.getElementById("gibbet").innerHTML = "<img src='www\\images\\Hangman-" + picIndex + ".png'>";
            document.querySelector("#keyboard").addEventListener("click", UserInput);
            
            EnableAllLetters();
            tempAlert(obj.message, 1000);
        }
        else {
            alert(obj.message);
        }
    }

    //function name: UserInput
    //sent in: event
    //return: none
    //description: decide what happens when user press a letter, when to end the game and update ranking
    function UserInput(e) {
        if (e.target.classList.contains("cell")) {
            e.target.removeEventListener("click", UserInput);
            GameController.processLetter(e.target.value);
            e.target.disabled = true;
            e.target.classList.remove("enabledLetters");
            e.target.classList.add("disabledLetters");

            let obj = GameController.report();
            let Cname = document.getElementById("Cname").innerHTML;

            if (obj.gameState !== "GAME_NOT_STARTED") {
                document.getElementById("remaining").innerHTML = "Guesses Remaining: " + obj.guessesRemaining;
                document.getElementById("theWord").innerHTML = obj.guess;
                let picIndex = 6 - obj.guessesRemaining;
                document.getElementById("gibbet").innerHTML = "<img src='www\\images\\Hangman-" + picIndex + ".png'>";
                if (obj.gameState === "GAME_IN_PROGRESS") {
                    //tempAlert(obj.message, 1000);
                }
                else {
                    if (obj.message.includes("Processed letter")) {
                        //get and update ranking
                        let score = gScore;
                        
                        if (obj.gameState.includes("WIN")) {
                            
                            score++;
                            UndateRanking(score, Cname);
                            
                            alert("You won! Your ranking has been updated!");
                        }
                        else {
                            score--;
                            UndateRanking(score, Cname);
                            
                            alert("You lost! The correct answer is: '" + obj.word + "'. Your ranking has been updated!");
                        }
                        DisableAllLetters();
                    }
                    btnNewGame.addEventListener("click", function () { ToHangman(Cname); }, false);
                    
                }
                
            }
            else {
                alert(obj.message);
                DisableAllLetters();
                btnNewGame.addEventListener("click", function () { ToHangman(Cname); }, false);
            }
        }
    }

    //function name: getHisScore
    //sent in: playername, category name
    //return: none
    //description: get the score of a player in a category and put it into a global variable gScore
    function getHisScore(player, Cname) {
        
        let url = "http://assignment0.com/hangman/webservice/rankings/player=" + player +"&category=" + Cname; // file name or server-side process name
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
                let resp = xmlhttp.responseText;
                if (resp.search("ERROR") >= 0) {
                    alert("Something's wrong");
                    ToMain();
                } else {
                    let arr = JSON.parse(resp).rankings;
                    gScore = arr[0].score;
                }
                
            }
        };
        xmlhttp.open("GET", url, true);
        xmlhttp.send();
        
    }

    //function name: UndateRanking
    //sent in: player's score, category name
    //return: none
    //description: update the player's score
    function UndateRanking(score, Cname) {
        let player = localStorage.getItem("HangmanUser");
        let password = localStorage.getItem("HangmanPw");
        let url = "http://assignment0.com/hangman/webservice/rankings/player=" + player + "&category=" + Cname;
        let obj = {
            'score': score,
            'password': password
        };

        let xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
                let resp = xmlhttp.responseText;
                if (resp != "1") {
                    alert("Something's wrong, please re-enter");
                }
                //else {
                    
                //}
            }
        };
        xmlhttp.open("POST", url, true);
        xmlhttp.send(JSON.stringify(obj));
    }

    //function name: EnableAllLetters
    //sent in: none
    //return: none
    //description: Enable all the letter input buttons
    function EnableAllLetters() {
        let letters = document.querySelectorAll(".cell");
        for (let i = 0; i < letters.length; i++) {
            letters[i].disabled = false;
            letters[i].classList.remove("disabledLetters");
            letters[i].classList.add("enabledLetters");
        }
    }

    //function name: DisableAllLetters
    //sent in: none
    //return: none
    //description: disable all the letter input buttons
    function DisableAllLetters() {
        let letters = document.querySelectorAll(".cell");
        for (let i = 0; i < letters.length; i++) {
            letters[i].disabled = true;
            letters[i].classList.add("disabledLetters");
            letters[i].classList.remove("enabledLetters");
        }
    }

    //function name: sortJSON
    //sent in: none
    //return: none
    //description: make a json arr in order
    function sortJSON(arr, key, way) {
        return arr.sort(function (a, b) {
            var x = a[key]; var y = b[key];
            if (way === 'asce') { return ((x < y) ? -1 : ((x > y) ? 1 : 0)); }
            if (way === 'desc') { return ((x > y) ? -1 : ((x < y) ? 1 : 0)); }
        });
    }

    //function name: WhichToShow
    //sent in: int
    //return: none
    //description: decide which screens to be shown
    function WhichToShow(which) {
        HideAll();
        if (which === 0) {
            mainScreen.classList.remove("hide");
            mainScreen.classList.add("show");
        }
        else if (which === 1) {
            creatAccount.classList.remove("hide");
            creatAccount.classList.add("show");
        }
        else if (which === 2) {
            ranking.classList.remove("hide");
            ranking.classList.add("show");
        }
        else if (which === 3) {
            game.classList.remove("hide");
            game.classList.add("show");
        }
    }

    //function name: HideAll
    //sent in: none
    //return: none
    //description: hide all screens
    function HideAll() {
        mainScreen.classList.remove("show");
        mainScreen.classList.add("hide");
        creatAccount.classList.remove("show");
        creatAccount.classList.add("hide");
        ranking.classList.remove("show");
        ranking.classList.add("hide");
        game.classList.remove("show");
        game.classList.add("hide");
        
    }

    //function name: IfdisableBtns
    //sent in: none
    //return: none
    //description: decide which main screen buttons to be shown
    function IfdisableBtns() {
        btnCreate.classList.remove("disabledMain");
        btnPlay.classList.remove("disabledMain");
        btnCreate.classList.add("mainBtn");
        btnPlay.classList.add("mainBtn");
        if (typeof (Storage) !== "undefined") {
            if (localStorage.getItem("HangmanUser") !== null) {
                btnCreate.disabled = true;
                btnCreate.classList.remove("mainBtn");
                btnCreate.classList.add("disabledMain");
                btnPlay.disabled = false;
            }
            else {
                btnCreate.disabled = false;
                btnPlay.disabled = true;
                btnPlay.classList.remove("mainBtn");
                btnPlay.classList.add("disabledMain");
            }
        } else {
            btnCreate.disabled = false;
            btnPlay.disabled = true;
            btnPlay.classList.remove("mainBtn");
            btnPlay.classList.add("disabledMain");
        }
    }

    //function name: AddUser
    //sent in: none
    //return: none
    //description: add a user to the server and update his rankings in all categories
    function AddUser() {
        userNameTxt = userNameInput.value;
        passwordTxt = passwordInput.value;
        retypePwTxt = retypePwInput.value;
        if (userNameTxt === "" || passwordTxt === "" || retypePwTxt === "") {
            alert("Please enter required data");
        }
        else if (passwordTxt !== retypePwTxt) {
            alert("Passwords need to be the same");
        }
        else {

            let url = "http://assignment0.com/hangman/webservice/players/player=" + userNameTxt;
            let obj = {
                'password': passwordTxt
            };

            let xmlhttp = new XMLHttpRequest();
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
                    let resp = xmlhttp.responseText;
                    if (resp != "1") {
                        alert("Something's wrong, please re-enter");
                    }
                    else {
                        localStorage.setItem("HangmanUser", userNameTxt);
                        localStorage.setItem("HangmanPw", passwordTxt);
                        
                        let urls = "http://assignment0.com/hangman/webservice/categories"; // file name or server-side process name
                        let xmlhttps = new XMLHttpRequest();
                        xmlhttps.onreadystatechange = function () {
                            if (xmlhttps.readyState === 4 && xmlhttps.status === 200) {
                                let resps = xmlhttps.responseText;
                                if (resps.search("ERROR") >= 0) {
                                    alert("Something's wrong");
                                    ToMain();
                                } else {
                                    let arr = JSON.parse(resps).categories;
                                    for (let i = 0; i < arr.length; i++) {
                                        let row = arr[i];
                                        UndateRanking(0, row.categoryName);
                                    }
                                    alert("You have create an account.");
                                    ToMain();
                                }
                            }
                        };
                        xmlhttps.open("GET", url, true);
                        xmlhttps.send();
                    }
                    
                }
            };
            xmlhttp.open("POST", url, true); 
            xmlhttp.send(JSON.stringify(obj));
        }
    }

    //function name: AddEl
    //sent in: none
    //return: none
    //description: add events listeners to some preset elements
    function AddEl() {
        btnCreate.addEventListener("click", ToCreate);
        btnDisplay.addEventListener("click", ToRanking);
        btnPlay.addEventListener("click", ToGaming);
        btnAddUser.addEventListener("click", AddUser);
        btnBack1.addEventListener("click", ToMain);
        btnBack2.addEventListener("click", ToMain);
        btnBack3.addEventListener("click", ToMain);
    }

    //function name: tempAlert
    //sent in: msg, int
    //return: none
    //description: create a auto-disappearing msg
    function tempAlert(msg, duration) {
        var el = document.createElement("div");
        el.setAttribute("style", "position:absolute;top:40%;left:20%;background-color:white;");
        el.innerHTML = msg;
        setTimeout(function () {
            el.parentNode.removeChild(el);
        }, duration);
        document.body.appendChild(el);
    }

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
    };
} )();