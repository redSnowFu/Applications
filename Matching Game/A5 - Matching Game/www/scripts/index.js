
(function () {
    "use strict";

    document.addEventListener( 'deviceready', onDeviceReady.bind( this ), false );

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener( 'pause', onPause.bind( this ), false );
        document.addEventListener( 'resume', onResume.bind( this ), false );
        
        //call function AssignImg().
        AssignImg();
        //call function ToggleBtn() and sent 1 as the arguement
        ToggleBtn(1);
        //add eventlisteners to the main section and 2 btns
        document.querySelector("#game").addEventListener("click", ShowCards);
        document.querySelector("#btnDevMode").addEventListener("click", IfGoToDev);
        document.querySelector("#btnBack").addEventListener("click", IfGoBack);
    };

    
    //declare an array for all objects of imgs
    let images = [
        { img: "<img src='www\\images\\chicken.png'>", id: 0 },
        { img: "<img src='www\\images\\crab.png'>", id: 1 },
        { img: "<img src='www\\images\\dolphin.png'>", id: 2 },
        { img: "<img src='www\\images\\goldfish.png'>", id: 3 },
        { img: "<img src='www\\images\\horse.png'>", id: 4 },
        { img: "<img src='www\\images\\octopus.png'>", id: 5 },
        { img: "<img src='www\\images\\rabbit.png'>", id: 6 },
        { img: "<img src='www\\images\\turtle.png'>", id: 7 },
        { img: "<img src='www\\images\\chicken.png'>", id: 0 },
        { img: "<img src='www\\images\\crab.png'>", id: 1 },
        { img: "<img src='www\\images\\dolphin.png'>", id: 2 },
        { img: "<img src='www\\images\\goldfish.png'>", id: 3 },
        { img: "<img src='www\\images\\horse.png'>", id: 4 },
        { img: "<img src='www\\images\\octopus.png'>", id: 5 },
        { img: "<img src='www\\images\\rabbit.png'>", id: 6 },
        { img: "<img src='www\\images\\turtle.png'>", id: 7 }
    ];
    //an variable for counting scores
    let score = 0;
    //an counter
    let count = 0;
    //an variable of selecting all cell classes
    let cells = document.querySelectorAll(".cell");
    //select two buttons and a arguement for the toggle function 
    let btnDevMode = document.querySelector("#btnDevMode");
    let btnBack = document.querySelector("#btnBack");
    let hide = 0;


    //function name: ShowCards
    //sent in: event
    //return: none
    //description: click and show the img, and compare them, and tracking scores
    function ShowCards(e) {
        if (e.target.classList.contains("cell")) {
            e.target.removeEventListener("click", ShowCards);
            e.target.revealed = true;
            
            count++;
            StyleChange();
        }

        let cardNum = [];
        if (count === 2) {
            for (let i = 0; i < cells.length; i++) {
                if (cells[i].revealed === true && cells[i].classList.contains("completed") === false) {
                    cardNum.push(cells[i].cardID);

                }
                //console.log(cardNum);
            }
            if (cardNum[0] !== cardNum[1]) {
                navigator.notification.alert(
                    'You are Wrong!', // message
                    HideCards,            // callback to invoke with index of button pressed
                    'Not correct!',           // title
                    'OK'                  // buttonName
                );
                score++;
            }

            else {
                for (let i = 0; i < cells.length; i++) {
                    if (cells[i].revealed === true) {
                        cells[i].classList.remove("newBG");
                        cells[i].classList.add("completed");
                        
                    }
                }
            }
            count = 0;
        }

        EndingCheck();
        btnBack.style.display = "none";
    }

    //function name: ToggleBtn
    //sent in: int
    //return: none
    //description: decide which buttons (btnDevMode/btnBack) to be shown
    function ToggleBtn(hide) {
        if (hide === 0) {
            btnDevMode.style.display = "none";
            btnBack.style.display = "block";
        }
        else {
            btnDevMode.style.display = "block";
            btnBack.style.display = "none";
        }
    }

    //function name: HideCards
    //sent in: none
    //return: none
    //description: hide imgs that was revealed
    function HideCards() {
        
        for (let i = 0; i < cells.length; i++) {
            if (cells[i].revealed === true && cells[i].classList.contains("completed") === false) {
                
                cells[i].revealed = false;
                StyleChange();
            }
        }
    }

    //function name: AssignImg
    //sent in: none
    //return: none
    //description: assign all imgs to all the cell sections in a random sequence
    function AssignImg() {
        
        ArrayShuffler.shuffle(images);
        count = 0;
        score = 0;
        for (let i = 0; i < cells.length; i++) {
            cells[i].innerHTML = "";
            cells[i].innerHTML += images[i].img;
            cells[i].cardID = images[i].id;
            cells[i].revealed = false;   
        }
        StyleChange();
    }

    //function name: StyleChange
    //sent in: none
    //return: none
    //description: change the style of cell sections depends on if they are revealed
    function StyleChange() {
        for (let i = 0; i < cells.length; i++) {
            if (cells[i].revealed === true) {
                cells[i].firstChild.classList.remove("hide");
                cells[i].firstChild.classList.add("revealed");
                
                cells[i].classList.remove("oldBG");
                cells[i].classList.add("newBG");
            }
            else {
                cells[i].firstChild.classList.remove("revealed");
                cells[i].firstChild.classList.add("hide");
                
                cells[i].classList.remove("newBG");
                cells[i].classList.add("oldBG");
            }
        }
    }

    //function name: EndingCheck
    //sent in: none
    //return: none
    //description: check if all the img has being revealed, if it does, show a score message
    function EndingCheck() {
        let revealedList = document.querySelectorAll(".completed");
        
        if (revealedList.length === 16) {
            let msg = "Your score is " + score;
            msg += "\nWould you like to \nplay again?";
            navigator.notification.confirm(
                msg, // message
                onConfirm,            // callback to invoke with index of button pressed
                'Game Over',           // title
                ['Yes', 'No']     // buttonLabels
            );
        }
    }

    //function name: onConfirm
    //sent in: the index of the button got pressed
    //return: none
    //description: if the game is over, reset the images
    function onConfirm(buttonIndex) {
        if (buttonIndex === 1) {
            for (let i = 0; i < cells.length; i++) {
                
                //cells[i].revealed = false;
                cells[i].classList.remove("completed");
            }
            //score = 0;
            AssignImg();
        }
    }

    //function name: IfGoToDev
    //sent in: none
    //return: none
    //description: ask if the user want to go the develope mode
    function IfGoToDev() {
        let msg = "Would you like to switch to Developer mode?";
        navigator.notification.confirm(
            msg, // message
            DevMode,            // callback to invoke with index of button pressed
            'Switch Warning',           // title
            ['Yes', 'No']     // buttonLabels
        );

        
    }

    //function name: DevMode
    //sent in: the index of the button got pressed
    //return: none
    //description: switch to develope mode if the use said yes
    function DevMode(buttonIndex) {
        if (buttonIndex === 1) {
            for (let i = 0; i < cells.length; i++) {
                //cells[i].revealed = false;
                cells[i].classList.remove("completed");
            }
            AssignImg();
            document.querySelector("#game").removeEventListener("click", ShowCards);
            document.querySelector("#game").addEventListener("click", DevShowCards);
            hide = 0;
            ToggleBtn(hide);
        }
        
        
    }

    //function name: IfGoBack
    //sent in: none
    //return: none
    //description: ask if the user want to go the user mode
    function IfGoBack() {
        let msg = "Would you like to switch to user mode?";
        navigator.notification.confirm(
            msg, // message
            UserMode,            // callback to invoke with index of button pressed
            'Switch Warning',           // title
            ['Yes', 'No']     // buttonLabels
        );
    }

    //function name: UserMode
    //sent in: the index of the button got pressed
    //return: none
    //description: switch to develope mode if the use said yes
    function UserMode(buttonIndex) {
        if (buttonIndex === 1) {
            for (let i = 0; i < cells.length; i++) {
                //cells[i].revealed = false;
                cells[i].classList.remove("completed");
            }
            AssignImg();
            document.querySelector("#game").removeEventListener("click", DevShowCards);
            document.querySelector("#game").addEventListener("click", ShowCards);
            hide = 1;
            ToggleBtn(hide);
        }


    }

    //function name: DevShowCards
    //sent in: event
    //return: none
    //description: show and hide cards in pair in the develope mode, no guessing
    function DevShowCards(e) {
        
        if (e.target.classList.contains("cell")) {
            //e.target.removeEventListener("click", ShowCards);
            if (e.target.revealed === true) {
                e.target.revealed = false;
                for (let i = 0; i < cells.length; i++) {
                    if (cells[i].revealed === true && cells[i].cardID === e.target.cardID) {
                        cells[i].revealed = false;
                        cells[i].classList.remove("completed");
                        break;
                    }
                }
                e.target.classList.remove("completed");
            }
            else {
                e.target.revealed = true;
            }

            StyleChange();

            for (let i = 0; i < cells.length; i++) {
                if (cells[i].revealed === true && cells[i].classList.contains("completed") === false) {
                    //cells[i].classList.add("completed");
                    for (let j = 0; j < cells.length; j++) {
                        if (cells[j].revealed === false && cells[j].cardID === cells[i].cardID) {
                            cells[j].revealed = true;
                            StyleChange();
                            break;
                        }
                    }

                }
            }

            for (let i = 0; i < cells.length; i++) {
                if (cells[i].revealed === true) {
                    cells[i].classList.remove("newBG");
                    cells[i].classList.add("completed");
                    //cells[i].removeEventListener("click", DevShowCards);
                }
            }
        }

        else if (e.target.tagName === "IMG") {
            e.target.parentElement.click();
        }
    }

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
    };
} )();