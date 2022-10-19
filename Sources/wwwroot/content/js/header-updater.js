var i = 0;
const info = [
    "лучший",
    "совершеннейший",
    "современный",
    "полезный"
];

function updateHeader() {
    let element = document.getElementById("animate-text");
    if (i < 3) {
        i++;
    } else {
        i = 0;
    }

    if (element != null) {
        element.innerHTML = info[i];
    }
}