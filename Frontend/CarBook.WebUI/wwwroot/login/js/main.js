
const inputs = document.querySelectorAll('.input');

function focusFunc() {
    let parent = this.parentNode.parentNode;
    parent.classList.add('focus');
}

function blurFunc() {
    let parent = this.parentNode.parentNode;
    if (this.value == "") {
        parent.classList.remove('focus');
    }
}

inputs.forEach(input => {
    input.addEventListener('focus', focusFunc);
    input.addEventListener('blur', blurFunc);
});

var modal = document.getElementById("modal-terms");

var btn = document.getElementById("action-modal");

var span = document.getElementsByClassName("close")[0];

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}