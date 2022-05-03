// The variable that gets manipulated and displayed
let cookieAmount = 0;

document.getElementById("cookie").addEventListener("click", add);

// Adding click events for adding buildings
document.getElementById("clicker").addEventListener("click", addBuilding);
document.getElementById("grandma").addEventListener("click", addBuilding);
document.getElementById("farm").addEventListener("click", addBuilding);
document.getElementById("mine").addEventListener("click", addBuilding);


let totalCpS = 0;
// Each building type production rate 
let clickerCpS = 0;
let grandmaCpS = 0;
let farmCpS = 0;
let mineCpS = 0;

// Fetches variables from html document after it is done loading
// (values are brought from database by server on get request)
window.onload = function () {
    cookieAmount = parseInt(document.getElementById("cookieAmount").value);
    //localStorage.setItem("cookieAmount", cookieAmount);

    updateCpS();

    //console.log("onload")
}

// Submits the form on the page to process it by server
// Doesn't work 
window.onbeforeunload = function () {
    document.forms["form"].submit();
}

// Click event that gets called when you click the cookie
function add() {
    cookieAmount += 1;
    updateCookie();
}

// Updates cookie amount on the page
function updateCookie() {
    document.getElementById("cookieAmount").value = cookieAmount;
    document.title = cookieAmount + " Cookies";
}

// Calculates and updates the new building price after you bought one
// Maybe? the formula should be done on the server
function updateBuildingPrice(tr) {
    //let price = parseInt(tr.getElementsByTagName("td")[2].children[0].value);
    let amountOwned = parseInt(tr.getElementsByTagName("td")[1].children[0].value);
    let basicProduction = parseInt(tr.getElementsByTagName("td")[3].children[0].value);
    //console.log(price);
    //console.log(amountOwned);
    //console.log(basicProduction);

    let newPrice = basicProduction * (amountOwned + 1) * 6;
    tr.getElementsByTagName("td")[2].innerText = newPrice;
}

// Interval to save the progress every 60 seconds
// Doesn't work
/* 
setInterval(function(){
    document.forms["form"].submit();
}, 60000)
*/

// Updates cookie amount every 1 second
setInterval(autoAdd, 1000);

function autoAdd() {
    updateTotalCpS();
    cookieAmount += totalCpS;
    updateCookie();
}

// Evaluates and updates new totalCpS
function updateTotalCpS(){
    totalCpS = clickerCpS + grandmaCpS + farmCpS + mineCpS;
    document.getElementById("totalCpS").innerHTML = totalCpS + " CpS";
    document.getElementById("totalCpSReal").value = totalCpS;
}

//
function addBuilding() {
    let price = parseInt(this.getElementsByTagName("td")[2].innerText);
    if (cookieAmount >= price) {
        this.getElementsByTagName("td")[1].children[0].value = parseInt(this.getElementsByTagName("td")[1].children[0].value) + 1;
        cookieAmount -= price;
        updateCookie();
        updateBuildingPrice(this);
        updateCpS();
    }
}

function updateCpS() {
    clickerCpS = parseInt(document.getElementById("clicker").children[3].children[0].value)
        * parseInt(document.getElementById("clicker").children[1].children[0].value);
    grandmaCpS = parseInt(document.getElementById("grandma").children[3].children[0].value)
        * parseInt(document.getElementById("grandma").children[1].children[0].value);
    farmCpS = parseInt(document.getElementById("farm").children[3].children[0].value)
        * parseInt(document.getElementById("farm").children[1].children[0].value);
    mineCpS = parseInt(document.getElementById("mine").children[3].children[0].value)
        * parseInt(document.getElementById("mine").children[1].children[0].value);
}