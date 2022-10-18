function registerMaskTouched() {
    let toHide = document.getElementById("base-register-mask");
    let toReveal = document.getElementById("actual-register-block");

    toHide.style.display = "none";
    toReveal.style.display = "flex";
}

function registerMaskUntouched() {
    let toReveal = document.getElementById("base-register-mask");
    let toHide = document.getElementById("actual-register-block");

    toHide.style.display = "none";
    toReveal.style.display = "flex";
}