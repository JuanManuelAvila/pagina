var timer;
var percent = 0;
var audio = document.getElementById("audio_1");//audio

audio.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio);
});
audio.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
var advance = function(duration, element) {
  var progress = document.getElementById("progress_1");//barra
  increment = 10/duration
  percent = Math.min(increment * element.currentTime * 10, 100);
  progress.style.width = percent+'%'
  startTimer(duration, element);
}
var startTimer = function(duration, element){ 
  if (percent < 100)
  {
    timer = setTimeout(function (){advance(duration, element)}, 100);   
  }
}

function togglePlay (e) {
  e = e || window.event;
  var btn = e.target;  
  if (!audio.paused) {
    btn.classList.remove('active');
    audio.pause();
    isPlaying = false;
  } else {
    btn.classList.add('active');
    audio.play();
    isPlaying = true;
  }
}

function secondsToHms(timestamp) {
        var hours = Math.floor(timestamp / 60 / 60);
        var minutes = Math.floor((timestamp / 60) - (hours * 60));
        var seconds = Math.floor(timestamp % 60);
        var formatted = minutes.toString().padStart(2, '0') + ':' + seconds.toString().padStart(2, '0');
        return formatted;
}