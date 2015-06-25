function play() {
    document.getElementById("monFlash").SetVariable("player:jsPlay", "");
}

function pause() {
    document.getElementById("monFlash").SetVariable("player:jsPause", "");
}

function stop() {
    document.getElementById("monFlash").SetVariable("player:jsStop", "");
}

function volume(n) {
    document.getElementById("monFlash").SetVariable("player:jsVolume", n);
}